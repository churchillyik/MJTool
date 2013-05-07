/*
 * 用户： Administrator
 * 日期: 2013-5-7
 * 时间: 21:56
 */
using System;

namespace MJTool
{
	/// <summary>
	/// Description of User.
	/// </summary>
	public partial class User
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
		
		// 新手引导完成情况
		public int finishGuide = 0;
		
		// 游戏账号的唯一ID
		public string single = "";
		
		// 判断用户是否登录
		public bool bIsLogined = false;
		
		public User(string name, string pswd)
		{
			strUserName = name;
			strPassword = pswd;
		}
	}
}
