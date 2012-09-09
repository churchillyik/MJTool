/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2012-7-8
 * Time: 9:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MJTool
{
	partial class QueryManager
	{
		public string strUserName;
		public string strPassword;
		public bool CheckIfLogined(string strQueryResult)
		{
			return true;
		}
		
		public string QueryLoginPage()
		{
			this.QrySta = QueryStatus.NotLogined;
			return PageQuery("game.weibo.com", "mengjiangwushuang/?origin=1407", null);
		}
		
		public void Login()
		{
			string result = QueryLoginPage();
			/*
			 * <div class=\"box\">
			 * href="http://weibo.com/login.php?
			 * entry=weiyouxi&param=r%3D2337087298&url=http%3A%2F%2Fgame.weibo.com%2Fmengjiangwushuang%2F%3Forigin%3D1407"
			 *  class="btn-login">登录微博</a>
			 * */
			Match m = Regex.Match(result, "<div class=\"box\">\\s*?<a\\s*?href=\"http://weibo\\.com/(.*?)\"\\s*?class=\"btn-login\">登录微博</a>", RegexOptions.Singleline);
			if (!m.Success)
			{
				DebugLog("无法解析登录页地址！");
			}
			string strLoginURL = m.Groups[1].Value;
			result = PageQuery("weibo.com", strLoginURL, null);
			
			Dictionary<string, string> data = new Dictionary<string, string>();
			data.Add("entry", "sso");
			data.Add("callback", "sinaSSOController.preloginCallBack");
			data.Add("su", base64_encode("undefined"));
			data.Add("rsakt", "mod");
			data.Add("client", "ssologin.js(v1.4.2)");
			data.Add("_", UnixTimeStamp(DateTime.Now).ToString());
			string strSvrTimeURL = "sso/prelogin.php?"
				+ CreateQueryString(data);
			result = PageQuery("login.sina.com.cn", strSvrTimeURL, null);
			
			
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
		
		public static string CreateQueryString(Dictionary<string, string> Data)
		{
			StringBuilder sb = new StringBuilder();
			foreach(KeyValuePair<string, string> x in Data)
			{
				if(sb.Length != 0)
					sb.Append("&");

				sb.Append(HttpUtility.UrlEncode(x.Key));
				sb.Append("=");
				sb.Append(HttpUtility.UrlEncode(x.Value));
			}
			return sb.ToString();
		}
		
		private long UnixTimeStamp(DateTime time)
		{
			return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds);
		}
		
		public bool ParseLogin(string strQueryResult)
		{
			return true;
		}
	}
}