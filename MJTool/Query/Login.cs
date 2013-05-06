using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MJTool
{
	partial class QueryManager
	{
		// 加密用到的辅助数值
		public static string strKeyPlus = "10001";
		
		// 游戏的域名地址
		public static string strGameSvr = "mjwssina.app.koramgame.com";
		// 游戏的AppID
		public static int nOriginID = 1013;
		
		// 登陆后会话的固有部分
		public static string strAct = "Index.iframe";
		public static string strServerID = "1";
		
		// 新浪的账号和密码
		private string strUserName;
		private string strPassword;
		
		// 登陆微博后获得的微博用户ID
		private string inviter_id;

		// 利用验证码从微博获得的会话信息
		private string wyx_session_key;
		private string wyx_create;
		private string wyx_expire;
		private string wyx_signature;
		
		// 通过回合信息从游戏服务器获得的游戏版本号
		private string version;
		
		// 新手引导完成情况
		private int finishGuide = 0;
		
		// 游戏账号的唯一ID
		private string single = "";
		
		private bool bIsLogined = false;
		public bool CheckIfLogined(string strQueryResult)
		{
			return bIsLogined;
		}
		
		public void doLogin(object o)
		{
			if (o is LoginParam)
			{
				LoginParam lg_pm = (LoginParam)o;
				this.strUserName = lg_pm.strName;
				this.strPassword = lg_pm.strPwd;
			}
			this.bIsLogined = false;

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
			string result = PageQuery("login.sina.com.cn", strSvrTimeURL);

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
			data.Add("su", base64_encode(strUserName));
			data.Add("service", "miniblog");
			data.Add("servertime", strSvrTime);
			data.Add("nonce", nonce);
			data.Add("pwencode", "rsa2");
			data.Add("rsakv", rsakv);
			data.Add("sp", PswRSAEncode(strPassword, pubkey, strSvrTime, nonce));
			data.Add("encoding", "UTF-8");
			data.Add("prelt", r.Next(100, 150).ToString());
			data.Add("url", "http://weibo.com/ajaxlogin.php?framelogin=1&callback=parent.sinaSSOController.feedBackUrlCallBack");
			data.Add("returntype", "META");
			
			// 发送登陆包，解析出微博的登陆URL
			result = PageQuery("login.sina.com.cn", "sso/login.php?client=ssologin.js(v1.4.2)", data, Encoding.GetEncoding("GBK"));
			m = Regex.Match(result, "location\\.replace\\(\"http://weibo\\.com/(.*?)\"\\);", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析[sso/login.php]");
				return;
			}
			string strLoginURL = m.Groups[1].Value;
			
			// 登陆微博，并解析出微博用户ID
			result = PageQuery("weibo.com", strLoginURL);
			m = Regex.Match(result, "\"uniqueid\":\"(.*?)\",", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析[weibo.com/ajaxlogin.php]");
				return;
			}
			this.inviter_id = m.Groups[1].Value;
			
			// 利用微博用户ID获得游戏登陆地址及游戏会话信息
			result = PageQuery("game.weibo.com", "mengjiangwushuang/?inviter_id=" + this.inviter_id
			                   + "&amp;amp;origin=" + nOriginID);
			m = Regex.Match(result, "mjwssina\\.app\\.koramgame\\.com(.*?)\"", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析[game.weibo.com/mengjiangwushuang]");
				return;
			}
			string koram_url_param = m.Groups[1].Value;
			m = Regex.Match(koram_url_param + "END", "wyx_session_key=(.*?)&wyx_create=(.*?)&wyx_expire=(.*?)&wyx_signature=(.*?)END", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析出会话信息！");
				return;
			}
			this.wyx_session_key = m.Groups[1].Value;
			this.wyx_create = m.Groups[2].Value;
			this.wyx_expire = m.Groups[3].Value;
			this.wyx_signature = m.Groups[4].Value;
			
			// 获取游戏页面并获取游戏版本号
			result = PageQuery("mjwssina.app.koramgame.com", koram_url_param);
			m = Regex.Match(result, "'version'\\s*:\\s*'(.*?)'", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析出版本号！");
				return;
			}
			this.version = m.Groups[1].Value;
			
			// 获取游戏资料
			CmdArg arg = new CmdArg(CmdIDs.USER_GET_INFO);
			this.doUserCommand(arg);
			
			this.bIsLogined = true;
			this.QrySta = QueryStatus.Logined;
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
			rsa.setPublic(pubkey, strKeyPlus);
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
		
		public bool ParseLogin(string strQueryResult)
		{
			return true;
		}
	}
}