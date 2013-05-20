using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;

namespace MJTool
{
	partial class QueryManager
	{
		public void Login(Account acc)
		{
			Thread t = new Thread(new ParameterizedThreadStart(doLogin));
			t.Name = "Login";
			t.Start(acc);
		}
		
		public void doLogin(object o)
		{
			Account curAcc = (Account) o;
			if (curAcc == null)
			{
				return;
			}
			curAcc.bIsLogined = false;

			// 组装包发到登陆服务器
			Dictionary<string, string> data = new Dictionary<string, string>();
			data.Add("entry", "sso");
			data.Add("callback", "sinaSSOController.preloginCallBack");
			data.Add("su", base64_encode("undefined"));
			data.Add("rsakt", "mod");
			data.Add("client", "ssologin.js(v1.4.2)");
			data.Add("_", UnixTimeStamp(DateTime.Now).ToString());
			string strSvrTimeURL = "sso/prelogin.php?"
				+ CreateQueryString(data);
			string result = curAcc.PageQuery("login.sina.com.cn", strSvrTimeURL);

			// 解析并获得加密公钥等信息
			string strSvrTime, pcid, nonce, pubkey, rsakv;
			Match m = Regex.Match(result, "\"servertime\":(.*?),\"pcid\":\"(.*?)\",\"nonce\":\"(.*?)\"," +
			                      "\"pubkey\":\"(.*?)\",\"rsakv\":\"(.*?)\"", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析[sso/prelogin.php]");
				return;
			}
			strSvrTime = m.Groups[1].Value;
			pcid = m.Groups[2].Value;
			nonce = m.Groups[3].Value;
			pubkey = m.Groups[4].Value;
			rsakv = m.Groups[5].Value;
			
			// 组装登陆包
			Random r = new Random();
			data.Clear();
			data.Add("entry", "weibo");
			data.Add("gateway", "1");
			data.Add("from", "");
			data.Add("savestate", "7");
			data.Add("useticket", "1");
			data.Add("vsnf", "1");
			data.Add("ssosimplelogin", "1");
			data.Add("su", base64_encode(curAcc.strUserName));
			data.Add("service", "miniblog");
			data.Add("servertime", strSvrTime);
			data.Add("nonce", nonce);
			data.Add("pwencode", "rsa2");
			data.Add("rsakv", rsakv);
			data.Add("sp", PswRSAEncode(curAcc.strPassword, pubkey, strSvrTime, nonce));
			data.Add("encoding", "UTF-8");
			data.Add("prelt", r.Next(100, 150).ToString());
			data.Add("url", "http://weibo.com/ajaxlogin.php?framelogin=1&callback=parent.sinaSSOController.feedBackUrlCallBack");
			data.Add("returntype", "META");
			
			// 发送登陆包，解析出微博的登陆URL
			result = curAcc.PageQuery("login.sina.com.cn", "sso/login.php?client=ssologin.js(v1.4.2)", data, Encoding.GetEncoding("GBK"));
			m = Regex.Match(result, "location\\.replace\\(\"http://weibo\\.com/(.*?)\"\\);", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析[sso/login.php]\r\n" + result);
				return;
			}
			string strLoginURL = m.Groups[1].Value;
			
			// 登陆微博，并解析出微博用户ID
			result = curAcc.PageQuery("weibo.com", strLoginURL);
			m = Regex.Match(result, "\"uniqueid\":\"(.*?)\",", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析[weibo.com/ajaxlogin.php]，可能因为手机端或其他电脑的客户端已经登入新浪微博，请先从这些客户端登出\r\n" + result);
				return;
			}
			
			// 利用微博用户ID获得游戏登陆地址及游戏会话信息
			result = curAcc.PageQuery("game.weibo.com", "mengjiangwushuang?origin=" + ServerParam.strOrigin);
			m = Regex.Match(result, "mjwssina\\.app\\.koramgame\\.com(.*?)\"", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析[game.weibo.com/mengjiangwushuang]");
				return;
			}
			string koram_url_param = m.Groups[1].Value;
			m = Regex.Match(koram_url_param + "END", "origin=(.*?)&wyx_user_id=(.*?)&wyx_session_key=(.*?)&wyx_create=(.*?)&wyx_expire=(.*?)&wyx_signature=(.*?)END", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析出会话信息！");
				return;
			}
			ServerParam.strOrigin = m.Groups[1].Value;
			curAcc.wyx_user_id = m.Groups[2].Value;
			curAcc.wyx_session_key = m.Groups[3].Value;
			curAcc.wyx_create = m.Groups[4].Value;
			curAcc.wyx_expire = m.Groups[5].Value;
			curAcc.wyx_signature = m.Groups[6].Value;
			
			// 组装游戏页面URL
			data.Clear();
			data.Add("act",  ServerParam.strAct);
			data.Add("wyx_user_id",  curAcc.wyx_user_id);
			data.Add("wyx_session_key",  curAcc.wyx_session_key);
			data.Add("wyx_create", curAcc.wyx_create);
			data.Add("wyx_expire",  curAcc.wyx_expire);
			data.Add("wyx_signature", curAcc.wyx_signature);
			data.Add("serverId",   ServerParam.strServerID);
			koram_url_param = "?" + CreateQueryString(data);

			// 获取游戏页面并获取游戏版本号以及swf下载地址
			result = curAcc.PageQuery(ServerParam.strGameSvr, koram_url_param);
			m = Regex.Match(result, "embedSWF\\(\"(.*?)=(.*?)\"", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析出版本号以及swf下载地址！");
				return;
			}
			ServerParam.strSWFDownLoadURL = m.Groups[1].Value + "=" + m.Groups[2].Value;
			ServerParam.strVersion = m.Groups[2].Value;

			// 获取游戏资料
			CmdArg arg = new CmdArg(CmdIDs.USER_GET_INFO, curAcc);
			this.doUserCommand(arg);
			
			curAcc.bIsLogined = true;
			curAcc.QrySta = QueryStatus.Logined;
			DebugLog("已成功登陆！");
		}
		
		public static string sKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
		public static string base64_encode(string str)
		{
			byte[] temp1 = Encoding.UTF8.GetBytes(HttpUtility.UrlEncode(str));
			string temp2 = Convert.ToBase64String(temp1);
			return temp2;
		}
		
		public static string base64_decode(string str)
		{
			byte[] sa = Convert.FromBase64String(str);
			Encoding Ansi = Encoding.GetEncoding("GB2312");
			string wa = Ansi.GetString(sa);
			return wa;
		}
		
		public static string PswRSAEncode(string strPassword, string pubkey, string server_time, string nonce)
		{
			BigInteger.init_BI_RC();
			SecureRandom.init_pool();

			RSAKey rsa = new RSAKey();
			rsa.setPublic(pubkey, ServerParam.strKeyPlus);
			return rsa.encrypt(server_time + "\t" + nonce + "\n" + strPassword);
		}
		
		public static string CreateQueryString(Dictionary<string, string> Data)
		{
			StringBuilder sb = new StringBuilder();
			foreach(KeyValuePair<string, string> x in Data)
			{
				if(sb.Length != 0)
				{
					sb.Append("&");
				}

				sb.Append(HttpUtility.UrlEncode(x.Key));
				sb.Append("=");
				sb.Append(HttpUtility.UrlEncode(x.Value));
			}
			return sb.ToString();
		}
		
		public static long UnixTimeStamp(DateTime time)
		{
			return Convert.ToInt64(time.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds);
		}
		
		public static DateTime SecondsToDateTime(double seconds)
		{
			DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
			return dt.AddSeconds(seconds);
		}
		
		public static DateTime MillisecondsToDateTime(long milliseconds)
		{
			DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
			return dt.AddMilliseconds(milliseconds);
		}
	}
}