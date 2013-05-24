using System;
using System.Collections.Generic;

namespace MJTool
{
	partial class Account
	{
		public bool CheckGeneralRefreshAvailable(int type)
		{
			switch (type)
			{
				case 1:
					if (root.userData.userTavern.nomalRefreshTimes >= 10)
					{
						return false;
					}
					return (QueryManager.UnixTimeStamp(DateTime.Now) / 1000) + ServerParam.secDiff > this.root.userData.user.tavernCdEndTime_1;
				case 2:
					return  (QueryManager.UnixTimeStamp(DateTime.Now) / 1000) + ServerParam.secDiff > this.root.userData.user.tavernCdEndTime_2;
				case 3:
					return  (QueryManager.UnixTimeStamp(DateTime.Now) / 1000) + ServerParam.secDiff > this.root.userData.user.tavernCdEndTime_3;
				case 4:
					return  (QueryManager.UnixTimeStamp(DateTime.Now) / 1000) + ServerParam.secDiff > this.root.userData.user.tavernCdEndTime_4;
				default:
					return false;
			}
		}
		
		private bool CheckForException(Dictionary<string, object> dic_root)
		{
			if (dic_root.ContainsKey("className") && Convert.ToString(dic_root["className"]) == "Exception")
			{
				if (dic_root.ContainsKey("message"))
				{
					upCall.DebugLog("返回错误码：" + Convert.ToString(dic_root["message"]));
				}
				return true;
			}
			return false;
		}
		
		public void ParseGetGift(byte[] bs_result)
		{
			upCall.Print("ParseGetGift", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			if (CheckForException(dic_root))
			{
				return;
			}
			
			recvGetGift pkg = new recvGetGift();
			upCall.SetSingleObject(dic_root, null, pkg);
			
			// 更新本地和服务器时间差
			RefreshTimeDiff(pkg.serverTime);
		}
		
		public void ParseGetMessage(byte[] bs_result)
		{
			upCall.Print("ParseGetMessage", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			if (CheckForException(dic_root))
			{
				return;
			}
			
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
			
			// 更新本地和服务器时间差
			RefreshTimeDiff(pkg.serverTime);
		}
		
		public void ParseMsgBox(byte[] bs_result)
		{
			upCall.Print("ParseMsgBox", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			if (CheckForException(dic_root))
			{
				return;
			}
			
			recvMsgBox pkg = new recvMsgBox();
			upCall.SetSingleObject(dic_root, null, pkg);
			
			upCall.SetArrayObjects(dic_root, "userData", pkg.userData);
			
			// 更新本地和服务器时间差
			RefreshTimeDiff(pkg.serverTime);
		}
		
		public void ParseGetLoginAward(byte[] bs_result)
		{
			upCall.Print("ParseGetLoginAward", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			if (CheckForException(dic_root))
			{
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
			
			// 更新本地和服务器时间差
			RefreshTimeDiff(pkg.serverTime);
		}
		
		public void ParseGetLuckInfo(byte[] bs_result)
		{
			upCall.Print("ParseGetLuckInfo", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			if (CheckForException(dic_root))
			{
				return;
			}
			recvGetLuckInfo pkg = new recvGetLuckInfo();
			upCall.SetSingleObject(dic_root, null, pkg);
			
			upCall.SetSingleObject(dic_root, "userData", pkg.userData);
			
			// 更新本地和服务器时间差
			RefreshTimeDiff(pkg.serverTime);
		}
		
		public void ParseRefreshGeneral(byte[] bs_result, CmdOperation cmdOprt)
		{
			upCall.Print("ParseRefreshGeneral", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			if (CheckForException(dic_root))
			{
				return;
			}
			
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
			UpdateDataAfterGeneralRefresh(pkg, cmdOprt.nGenRefType);
			
//			PrintTavern();
			
			// 更新UI显示
			upCall.UIUpdateRefreshGeneral();
		}
		
		public void ParseEmployGeneral(byte[] bs_result)
		{
			upCall.Print("ParseEmployGeneral", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			if (CheckForException(dic_root))
			{
				return;
			}
			
			recvEmployGeneral pkg = new recvEmployGeneral();
			upCall.SetSingleObject(dic_root, null, pkg);
			
			if (!dic_root.ContainsKey("userData"))
			{
				upCall.DebugLog("dic_root不存在userData键值");
				return;
			}
			Dictionary<string, object> dic_userData = (Dictionary<string, object>) dic_root["userData"];
			upCall.SetSingleObject(dic_userData, "userSoul", pkg.userData.userSoul);
			
			// 同步酒馆数据
			UpdateDataAfterEmployGeneral(pkg);
			
			// 更新UI显示
			upCall.UIUpdateEmployGeneral();
		}
		
		public void ParseUserSigin(byte[] bs_result)
		{
			upCall.Print("ParseUserSigin", bs_result);
			Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
			if (CheckForException(dic_root))
			{
				return;
			}
			
			recvSigin pkg = new recvSigin();
			upCall.SetSingleObject(dic_root, null, pkg);
		}
		
		// ------------------------------------------------------------------------------------------------
		
		private void UpdateDataAfterGeneralRefresh(recvRefreshGeneral pkg, int type)
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
					this.root.userData.user.tavernCdEndTime_1 = pkg.userData.userTavern.ct + 10 * 60;
					break;
				case 2:
					this.root.userData.user.tavernCdEndTime_2 = pkg.userData.userTavern.ct + 24 * 3600;
					break;
				case 3:
					this.root.userData.user.tavernCdEndTime_3 = pkg.userData.userTavern.ct + 3 * 24 * 3600;
					break;
				case 4:
					this.root.userData.user.tavernCdEndTime_4 = pkg.userData.userTavern.ct + 7 * 24 * 3600;
					break;
			}
			
			// 更新本地和服务器时间差
			RefreshTimeDiff(pkg.serverTime);
		}
		
		private void UpdateDataAfterEmployGeneral(recvEmployGeneral pkg)
		{
			// 删除酒馆中的将魂
			entityUserSoul soul = pkg.userData.userSoul;
			bool bDone = false;
			bDone = DeleteSoul(ref root.userData.userTavern.id_1, soul, bDone);
			bDone = DeleteSoul(ref root.userData.userTavern.id_2, soul, bDone);
			bDone = DeleteSoul(ref root.userData.userTavern.id_3, soul, bDone);
			
			// 更新将魂列表
			bool bFound = false;
			foreach (entityUserSoul sl in root.userData.userSoul)
			{
				if (sl.generalType == soul.generalType)
				{
					sl.number += soul.number;
					bFound = true;
				}
			}
			if (!bFound)
			{
				root.userData.userSoul.Add(soul);
			}
			
			// 更新本地和服务器时间差
			RefreshTimeDiff(pkg.serverTime);
		}
		
		private bool DeleteSoul(ref int gen_id, entityUserSoul soul, bool bDone)
		{
			if (bDone)
			{
				return true;
			}
			DBGeneral gen = QueryManager.gGameDB.GetGeneral(gen_id);
			if (gen != null && gen.type == soul.generalType && gen.soul == soul.number)
			{
				gen_id = 0;
				return true;
			}
			else
			{
				return false;
			}
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
		public entityUserTavern userTavern = new entityUserTavern();
		public int firstStar;
		public List<entityUserSoul> userSoul = new List<entityUserSoul>();
	}
	
	public class recvEmployGeneral
	{
		public double serverTime;
		public int onlineX;
		public recvUserDataEmployGeneral userData = new recvUserDataEmployGeneral();
		public int newMailNumber;
		public int finishGuide;
		public List<object> message = new List<object>();
		public List<recvAnnouncement> announcement = new List<recvAnnouncement>();
	}
	
	public class recvSigin
	{
		public double serverTime;
		public int onlineX;
//		public recvUserDataEmployGeneral userData = new recvUserDataEmployGeneral();
		public int newMailNumber;
		public int finishGuide;
		public List<object> message = new List<object>();
		public List<recvAnnouncement> announcement = new List<recvAnnouncement>();
	}
	
	public class recvUserDataEmployGeneral
	{
		public entityUserSoul userSoul = new entityUserSoul();
	}
}
