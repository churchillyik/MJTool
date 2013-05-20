using System;
using System.Collections.Generic;
using System.Threading;

namespace MJTool
{
	partial class QueryManager
	{
		public void Logout(Account acc)
		{
			Thread t = new Thread(new ParameterizedThreadStart(doLogout));
			t.Name = "Logout";
			t.Start(acc);
		}
		
		public void doLogout(object o)
		{
			Account curAcc = (Account) o;
			if (curAcc == null)
			{
				return;
			}
			curAcc.bIsLogined = false;
			
			string strURL;
			Dictionary<string, string> data = new Dictionary<string, string>();
			string time_stamp = UnixTimeStamp(DateTime.Now).ToString();
			
			data.Add("entry", "miniblog");
			data.Add("r", "http://weibo.com/logout.php?backurl=%2F");
			strURL = "sso/logout.php?" + CreateQueryString(data);
			curAcc.PageQuery("login.sina.com.cn", strURL);
			
			data.Clear();
			data.Add("callback", "sinaSSOController.doCrossDomainCallBack");
			data.Add("scriptId", "ssoscript0");
			data.Add("client", "ssologin.js(v1.4.2)");
			data.Add("_", time_stamp);
			strURL = "sso/mutelogout?" + CreateQueryString(data);
			curAcc.PageQuery("weibo.com", strURL);

			data.Clear();
			data.Add("callback", "sinaSSOController.doCrossDomainCallBack");
			data.Add("scriptId", "ssoscript1");
			data.Add("client", "ssologin.js(v1.4.2)");
			data.Add("_", time_stamp);
			strURL = "sso/mutelogout.php?" + CreateQueryString(data);
			curAcc.PageQuery("app.xincai.com", strURL);
			
			data.Clear();
			data.Add("callback", "sinaSSOController.doCrossDomainCallBack");
			data.Add("scriptId", "ssoscript2");
			data.Add("client", "ssologin.js(v1.4.2)");
			data.Add("_", time_stamp);
			strURL = "sso/mutelogout.php?" + CreateQueryString(data);
			curAcc.PageQuery("www.meishitui.com", strURL);
		}
	}
}
