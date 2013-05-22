using System;
using System.Collections.Generic;

namespace MJTool
{
	partial class Account
	{
		public void ParseGetGift(byte[] bs_result)
		{
			upCall.Print("ParseGetGift", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			
			recvGetGift pkg = new recvGetGift();
			upCall.SetSingleObject(dic_root, null, pkg);
		}
		
		public void ParseGetMessage(byte[] bs_result)
		{
			upCall.Print("ParseGetMessage", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			
			recvGetMessage pkg = new recvGetMessage();
			upCall.SetSingleObject(dic_root, null, pkg);
			
			if (!dic_root.ContainsKey("userData"))
			{
				upCall.DebugLog("dic_root不存在userData键值");
				return;
			}
			Dictionary<string, object> dic_userData = (Dictionary<string, object>) dic_root["userData"];
			upCall.SetArrayObjects(dic_userData, "message", pkg.userData.message);
			upCall.SetArrayObjects(dic_userData, "announcement", pkg.userData.announcement);
		}
		
		public void ParseMsgBox(byte[] bs_result)
		{
			upCall.Print("ParseMsgBox", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			
			recvMsgBox pkg = new recvMsgBox();
			upCall.SetSingleObject(dic_root, null, pkg);
			
			upCall.SetArrayObjects(dic_root, "userData", pkg.userData);
		}
		
		public void ParseGetLoginAward(byte[] bs_result)
		{
			upCall.Print("ParseGetLoginAward", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			
			if (dic_root.ContainsKey("className") && Convert.ToString(dic_root["className"]) == "Exception"
			    && dic_root.ContainsKey("message") && Convert.ToString(dic_root["message"]) == "awardTimeError")
			{
				upCall.DebugLog("登录奖励的领取时刻未到！");
				return;
			}
			recvGetLoginAward pkg = new recvGetLoginAward();
			upCall.SetSingleObject(dic_root, null, pkg);
			
			if (!dic_root.ContainsKey("userData"))
			{
				upCall.DebugLog("dic_root不存在userData键值");
				return;
			}
			Dictionary<string, object> dic_userData = (Dictionary<string, object>) dic_root["userData"];
			upCall.SetSingleObject(dic_root, "userData", pkg.userData);
			
			upCall.SetArrayArrayObjects(dic_userData, "award", pkg.userData.award);
		}
		
		public void ParseGetLuckInfo(byte[] bs_result)
		{
			upCall.Print("ParseGetLuckInfo", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			
			recvGetLuckInfo pkg = new recvGetLuckInfo();
			upCall.SetSingleObject(dic_root, null, pkg);
			
			upCall.SetSingleObject(dic_root, "userData", pkg.userData);
		}
		
		public bool CheckGeneralRefreshAvailable(int type, out DateTime dt)
		{
			
			switch (type)
			{
				case 1:
					dt = QueryManager.SecondsToDateTime(this.root.userData.user.tavernCdEndTime_1);
					return DateTime.Now > dt;
				case 2:
					dt = QueryManager.SecondsToDateTime(this.root.userData.user.tavernCdEndTime_2);
					return DateTime.Now > dt;
				case 3:
					dt = QueryManager.SecondsToDateTime(this.root.userData.user.tavernCdEndTime_3);
					return DateTime.Now > dt;
				case 4:
					dt = QueryManager.SecondsToDateTime(this.root.userData.user.tavernCdEndTime_4);
					return DateTime.Now > dt;
				default:
					dt = DateTime.MinValue;
					return false;
			}
		}
		
		public void UpdateGeneralRefreshData(recvRefreshGeneral pkg, int type)
		{
			this.root.userData.userTavern.id_1 = pkg.userData.userTavern.id_1;
			this.root.userData.userTavern.id_2 = pkg.userData.userTavern.id_2;
			this.root.userData.userTavern.id_3 = pkg.userData.userTavern.id_3;
			this.root.userData.userTavern.ct = pkg.userData.userTavern.ct;
			this.root.userData.userTavern.nomalRefreshTimes = pkg.userData.userTavern.nomalRefreshTimes;
			this.root.userData.userTavern.nomalRefreshTime = pkg.userData.userTavern.nomalRefreshTime;
			
			switch (type)
			{
				case 1:
					this.root.userData.user.tavernCdEndTime_1 = pkg.userData.userTavern.ct;
					break;
				case 2:
					this.root.userData.user.tavernCdEndTime_2 = pkg.userData.userTavern.ct;
					break;
				case 3:
					this.root.userData.user.tavernCdEndTime_3 = pkg.userData.userTavern.ct;
					break;
				case 4:
					this.root.userData.user.tavernCdEndTime_4 = pkg.userData.userTavern.ct;
					break;
			}
		}
		
		public void ParseRefreshGeneral(byte[] bs_result, CmdOperation cmdOprt)
		{
			upCall.Print("ParseRefreshGeneral", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			
			recvRefreshGeneral pkg = new recvRefreshGeneral();
			upCall.SetSingleObject(dic_root, null, pkg);
			
			if (!dic_root.ContainsKey("userData"))
			{
				upCall.DebugLog("dic_root不存在userData键值");
				return;
			}
			Dictionary<string, object> dic_userData = (Dictionary<string, object>) dic_root["userData"];
			upCall.SetSingleObject(dic_root, "userData", pkg.userData);
			upCall.SetSingleObject(dic_userData, "userTavern", pkg.userData.userTavern);
			upCall.SetArrayObjects(dic_userData, "userSoul", pkg.userData.userSoul);
			
			// 同步到角色数据中
			UpdateGeneralRefreshData(pkg, cmdOprt.nGenRefType);
			
			PrintTavern();
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
		public List<recvAnnouncement> announcement = new List<recvAnnouncement>();
	}
	
	public class recvGetMessage
	{
		public double serverTime;
		public int onlineX;
		public recvUserDataGetMessage userData = new recvUserDataGetMessage();
		public int newMailNumber;
		public int finishGuide;
		public List<object> message = new List<object>();
		public List<recvAnnouncement> announcement = new List<recvAnnouncement>();
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
		public List<recvAnnouncement> announcement = new List<recvAnnouncement>();
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
		public List<recvAnnouncement> announcement = new List<recvAnnouncement>();
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
	
	public class recvRefreshGeneral
	{
		public double serverTime;
		public int onlineX;
		public recvUserDataRefreshGeneral userData = new recvUserDataRefreshGeneral();
		public int newMailNumber;
		public int finishGuide;
		public List<object> message = new List<object>();
		public List<recvAnnouncement> announcement = new List<recvAnnouncement>();
	}
	
	public class recvUserDataRefreshGeneral
	{
		public entityUserTavern userTavern;
		public int firstStar;
		public List<entityUserSoul> userSoul = new List<entityUserSoul>();
	}
}
