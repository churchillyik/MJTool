using System;
using System.Collections.Generic;

namespace MJTool
{
	partial class Account
	{
		public void ParseGetGift(byte[] bs_result)
		{
			upCall.Print("ParseGetGift", bs_result);
			Dictionary<string, object> dic_root = GetRootDic(bs_result);
			
			recvGetGift pkg = new recvGetGift();
			SetSingleObject(dic_root, null, pkg);
		}
		
		public void ParseGetMessage(byte[] bs_result)
		{
			upCall.Print("ParseGetMessage", bs_result);
			Dictionary<string, object> dic_root = GetRootDic(bs_result);
			
			recvGetMessage pkg = new recvGetMessage();
			SetSingleObject(dic_root, null, pkg);
			
			if (!dic_root.ContainsKey("userData"))
			{
				upCall.DebugLog("dic_root不存在userData键值");
				return;
			}
			Dictionary<string, object> dic_userData = (Dictionary<string, object>) dic_root["userData"];
			SetArrayObjects(dic_userData, "message", pkg.userData.message);
			SetArrayObjects(dic_userData, "announcement", pkg.userData.announcement);
		}
		
		public void ParseMsgBox(byte[] bs_result)
		{
			upCall.Print("ParseMsgBox", bs_result);
			Dictionary<string, object> dic_root = GetRootDic(bs_result);
			
			recvMsgBox pkg = new recvMsgBox();
			SetSingleObject(dic_root, null, pkg);
			
			SetArrayObjects(dic_root, "userData", pkg.userData);
		}
		
		public void ParseGetLoginAward(byte[] bs_result)
		{
			upCall.Print("ParseGetLoginAward", bs_result);
			Dictionary<string, object> dic_root = GetRootDic(bs_result);
			
			if (dic_root.ContainsKey("className") && Convert.ToString(dic_root["className"]) == "Exception"
			    && dic_root.ContainsKey("message") && Convert.ToString(dic_root["message"]) == "awardTimeError")
			{
				upCall.DebugLog("登录奖励的领取时刻未到！");
				return;
			}
			recvGetLoginAward pkg = new recvGetLoginAward();
			SetSingleObject(dic_root, null, pkg);
			
			if (!dic_root.ContainsKey("userData"))
			{
				upCall.DebugLog("dic_root不存在userData键值");
				return;
			}
			Dictionary<string, object> dic_userData = (Dictionary<string, object>) dic_root["userData"];
			SetSingleObject(dic_root, "userData", pkg.userData);
			
			SetArrayArrayObjects(dic_userData, "award", pkg.userData.award);
		}
		
		public void ParseGetLuckInfo(byte[] bs_result)
		{
			upCall.Print("ParseGetLuckInfo", bs_result);
			Dictionary<string, object> dic_root = GetRootDic(bs_result);
			
			recvGetLuckInfo pkg = new recvGetLuckInfo();
			SetSingleObject(dic_root, null, pkg);
			
			SetSingleObject(dic_root, "userData", pkg.userData);
		}
	}
	
	public class recvGetGift
	{
		public double serverTime;
		public int onlineX;
		public List<object> userData = new List<object>();
		public int newMailNumber;
		public int finishGuide;
		public List<object> message = new List<object>();
		public List<object> announcement = new List<object>();
	}
	
	public class recvGetMessage
	{
		public double serverTime;
		public int onlineX;
		public recvUserDataGetMessage userData = new recvUserDataGetMessage();
		public int newMailNumber;
		public int finishGuide;
		public List<object> message = new List<object>();
		public List<object> announcement = new List<object>();
	}
	
	public class recvUserDataGetMessage
	{
		public List<object> message = new List<object>();
		public List<recvAnnouncement> announcement = new List<recvAnnouncement>();
	}
	
	public class recvAnnouncement
	{
		public int userId;
		public string userName;
		public string userIcon;
		public string message;
		public double sendTime;
		public string hz;
		public int vip;
		public int quality;
		public int priority;
		public int conquerorType;
	}
	
	public class recvMsgBox
	{
		public double serverTime;
		public List<recvUserMsgBox> userData = new List<recvUserMsgBox>();
	}
	
	public class recvUserMsgBox
	{
		public int id;
		public string feedid;
		public int fuid;
		public int type;
		public int status;
		public string desc;
		public double ct;
		public int platfrom;
		public string button;
		public int realId;
		public string title;
		public string username;
		public string img;
		public string msg;
	}
	
	public class recvGetLoginAward
	{
		public double serverTime;
		public int onlineX;
		public recvUserDataGetLoginAward userData = new recvUserDataGetLoginAward();
		public int newMailNumber;
		public int finishGuide;
		public List<object> message = new List<object>();
		public List<object> announcement = new List<object>();
	}
	
	public class recvUserDataGetLoginAward
	{
		public List<List<recvAward>> award = new List<List<recvAward>>();
		public int nDouble;
	}
	
	public class recvAward
	{
		public int categoryId;
		public int typeId;
		public int number;
	}
	
	public class recvGetLuckInfo
	{
		public double serverTime;
		public int onlineX;
		public recvUserDataGetLuckInfo userData = new recvUserDataGetLuckInfo();
		public int newMailNumber;
		public int finishGuide;
		public List<object> message = new List<object>();
		public List<object> announcement = new List<object>();
	}
	
	public class recvUserDataGetLuckInfo
	{
		public int luck;
		public double changeTime;
		public int luckTrend;
		public int cdTrend;
		public double cdEndTime;
		public List<object> userBuff = new List<object>();
	}
}
