using System;

namespace MJTool
{
	public class ServerParam
	{
		// 加密用到的辅助数值
		public static string strKeyPlus = "10001";
		
		// 游戏的域名地址
		public static string strGameSvr = "mjwssina.app.koramgame.com";
		
		// 登陆后会话的固有部分
		public static string strAct = "Index.iframe";
		public static string strServerID = "1";
		
		// 游戏的AppID
		public static string strOrigin = "3054";
		
		// 游戏swf下载地址
		public static string strSWFDownLoadURL = "";
		
		// 通过回合信息从游戏服务器获得的游戏版本号
		public static string strVersion = "";
		
		// 游戏服务器和本地的时间差（秒）
		public static double secDiff = 0;
		
		public static DateTime serverTime
		{
			get
			{
				return DateTime.Now.AddSeconds(secDiff);
			}
		}
	}
}
