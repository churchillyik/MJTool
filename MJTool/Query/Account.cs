using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MJTool
{
	public partial class QueryManager
	{
		public static string gAccountFilePath = "Account";
		public void LoadAccounts(List<Account> lstAccs)
		{
			if (lstAccs == null)
			{
				return;
			}
			else
			{
				lstAccs.Clear();
			}
			if (!File.Exists(gAccountFilePath))
			{
				return;
			}
			
			string[] lines = File.ReadAllLines(gAccountFilePath);
			foreach (string line in lines)
			{
				string[] pair = line.Split(new char[] {'\t'});
				if (pair.Length != 2)
				{
					DebugLog("帐号文件行[" + line + "]无效");
					continue;
				}
				
				Account acc = new Account(pair[0], pair[1]);
				acc.upCall = this;
				lstAccs.Add(acc);
			}
		}
		
		public void SaveAccounts(List<Account> lstAccs)
		{
			if (lstAccs == null || lstAccs.Count == 0)
			{
				return;
			}
			
			StringBuilder sb = new StringBuilder();
			foreach (Account acc in lstAccs)
			{
				sb.AppendLine(acc.strUserName + "\t" + acc.strPassword);
			}
			
			WriteLog(gAccountFilePath, sb.ToString());
		}
	}
	
	public partial class Account
	{
		public QueryManager upCall = null;
		
		// 新浪的账号和密码
		public string strUserName;
		public string strPassword;

		// 利用验证码从微博获得的会话信息
		public string wyx_user_id;
		public string wyx_session_key;
		public string wyx_create;
		public string wyx_expire;
		public string wyx_signature;
		
		public UserRoot root = new UserRoot();
		
		// 判断用户是否登录
		public bool bIsLogined = false;
		
		// 当前帐号一次发出获取将魂的请求数
		public int nEplGenReqCnt = 0;
		
		public Account(string name, string pswd)
		{
			strUserName = name;
			strPassword = pswd;
		}
	}
}
