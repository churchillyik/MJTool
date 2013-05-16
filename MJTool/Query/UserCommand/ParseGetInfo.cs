/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2013-5-13
 * 时间: 15:23
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MJTool
{
	/// <summary>
	/// Description of ParseGetInfo.
	/// </summary>
	public partial class Account
	{
		public void ParseGetInfo(byte[] bs_result)
		{
			List<byte> lst_byte_res = new List<byte>();
			for (int i = 1; i < bs_result.Length; i++)
			{
				lst_byte_res.Add(bs_result[i]);
			}

			try
			{
				byte[] b_res = lst_byte_res.ToArray();
				Dictionary<string, object> dic_root = QueryManager.AMF_Deserializer<Dictionary<string, object>>(b_res, b_res.Length);
				
				// serverTime
				if (dic_root.ContainsKey("serverTime"))
				{
					root.serverTime = Convert.ToDouble(dic_root["serverTime"]);
				}
				
				// single
				if (dic_root.ContainsKey("single"))
				{
					root.single = Convert.ToString(dic_root["single"]);
				}
				
				// newMailNumber
				if (dic_root.ContainsKey("newMailNumber"))
				{
					root.newMailNumber = Convert.ToInt32(dic_root["newMailNumber"]);
				}
				
				// userData
				if (!dic_root.ContainsKey("userData"))
				{
					return;
				}
				Dictionary<string, object> dic_userData = (Dictionary<string, object>)dic_root["userData"];
				
				// userData.userSendFeed
				if (dic_userData.ContainsKey("userSendFeed"))
				{
					Dictionary<string, object> dic_userSendFeed = (Dictionary<string, object>)dic_userData["userSendFeed"];
					foreach (KeyValuePair<string, object> pair in dic_userSendFeed)
					{
						Dictionary<string, object> val = (Dictionary<string, object>)pair.Value;
						entityUserSend ent = new entityUserSend();
						ent.id = Convert.ToInt32(val["id"]);
						ent.num = Convert.ToInt32(val["num"]);
						ent.ct = Convert.ToDouble(val["ct"]);
						root.userData.userSendFeed.Add(pair.Key, ent);
					}
				}
				
				// userData.msgBoxNum
				if (dic_userData.ContainsKey("msgBoxNum"))
				{
					root.userData.msgBoxNum = (int)dic_userData["msgBoxNum"];
				}
				
				SetSingleObject(dic_userData, "user", root.userData.user);
				SetArrayObjects(dic_userData, "userGeneral", root.userData.userGeneral);
				SetArrayObjects(dic_userData, "userItem", root.userData.userItem);
				SetArrayObjects(dic_userData, "userEquip", root.userData.userEquip);
				SetArrayObjects(dic_userData, "userFormation", root.userData.userFormation);
				if (dic_userData.ContainsKey("feedstoryovi"))
				{
					root.userData.feedstoryovi = Convert.ToInt32(dic_userData["feedstoryovi"]);
				}
				SetArrayObjects(dic_userData, "userFriend", root.userData.userFriend);
				SetArrayObjects(dic_userData, "userEnemy", root.userData.userEnemy);
				SetArrayObjects(dic_userData, "userBuff", root.userData.userBuff);
				SetArrayObjects(dic_userData, "userGuildFriend", root.userData.userGuildFriend);
				SetArrayObjects(dic_userData, "userEmployNpc", root.userData.userEmployNpc);
				SetArrayObjects(dic_userData, "userPlant", root.userData.userPlant);
				SetArrayObjects(dic_userData, "userRace", root.userData.userRace);
				SetArrayObjects(dic_userData, "lastUserRace", root.userData.lastUserRace);
				SetArrayObjects(dic_userData, "userTrain", root.userData.userTrain);
				SetArrayObjects(dic_userData, "userArena", root.userData.userArena);
				SetArrayObjects(dic_userData, "userSoul", root.userData.userSoul);
				SetSingleObject(dic_userData, "userTavern", root.userData.userTavern);
				SetArrayObjects(dic_userData, "userFormationGeneral", root.userData.userFormationGeneral);
				SetSingleObject(dic_userData, "userDefend", root.userData.userDefend);
				SetSingleObject(dic_userData, "userTower", root.userData.userTower);
				SetArrayObjects(dic_userData, "userScene", root.userData.userScene);
				SetArrayObjects(dic_userData, "userTotem", root.userData.userTotem);
				SetArrayObjects(dic_userData, "userUnlock", root.userData.userUnlock);
				SetSingleObject(dic_userData, "activityInfo", root.userData.activityInfo);
				SetSingleObject(dic_userData, "activitySendInfo", root.userData.activitySendInfo);
				SetSingleObject(dic_userData, "guild", root.userData.guild);
				if (dic_userData.ContainsKey("warTally"))
				{
					root.userData.warTally = Convert.ToInt32(dic_userData["warTally"]);
				}
				SetArrayObjects(dic_userData, "userMission", root.userData.userMission);
				SetArrayObjects(dic_userData, "userLivenessEvent", root.userData.userLivenessEvent);
				SetSingleObject(dic_userData, "userTimeAward", root.userData.userTimeAward);
				SetSingleObject(dic_userData, "userSevenDayAward", root.userData.userSevenDayAward);
				SetSingleObject(dic_userData, "userYellow", root.userData.userYellow);
				SetArrayObjects(dic_userData, "userOccupyTotem", root.userData.userOccupyTotem);
				SetArrayObjects(dic_userData, "userRobbedTotems", root.userData.userRobbedTotems);
				SetSingleObject(dic_userData, "userLevelupChest", root.userData.userLevelupChest);
				SetArrayObjects(dic_userData, "userGeneralStar", root.userData.userGeneralStar);
				SetArrayObjects(dic_userData, "userGeneralSpectrum", root.userData.userGeneralSpectrum);
				SetArrayObjects(dic_userData, "userCopy", root.userData.userCopy);
				SetArrayObjects(dic_userData, "copyOrderInfo", root.userData.copyOrderInfo);
				SetArrayObjects(dic_userData, "honorAnnoun", root.userData.honorAnnoun);
				SetArrayObjects(dic_userData, "userEscorts", root.userData.userEscorts);
				SetArrayObjects(dic_userData, "userRobbeds", root.userData.userRobbeds);
				SetArrayObjects(dic_userData, "userRess", root.userData.userRess);
				SetSingleObject(dic_userData, "userExchangeCode", root.userData.userExchangeCode);
				SetArrayObjects(dic_userData, "userCards", root.userData.userCards);
				SetSingleObject(dic_userData, "cardActivity", root.userData.cardActivity);
				SetArrayObjects(dic_userData, "userStargazings", root.userData.userStargazings);
				SetArrayObjects(dic_userData, "userStargazingGenerals", root.userData.userStargazingGenerals);
				SetSingleObject(dic_userData, "userConquerorInfo", root.userData.userConquerorInfo);
				SetArrayObjects(dic_userData, "userConquerorCityInfo", root.userData.userConquerorCityInfo);
				SetArrayObjects(dic_userData, "userConquerorLugInfo", root.userData.userConquerorLugInfo);
				SetSingleObject(dic_userData, "userConquerorAward", root.userData.userConquerorAward);
				SetArrayObjects(dic_userData, "userPetFight", root.userData.userPetFight);
				
				// userData.VipShadowWin
				SetArrayObjects(dic_userData, "VipShadowWin", root.userData.VipShadowWin);
				
				// userData.invitIsOpen
				if (dic_userData.ContainsKey("invitIsOpen"))
				{
					root.userData.invitIsOpen = Convert.ToString(dic_userData["invitIsOpen"]);
				}
			}
			catch (Exception e)
			{
				upCall.DebugLog(e.StackTrace);
			}
		}
		
		public void SetSingleObject<T>(Dictionary<string, object> dic_parent, string key, T t_obj)
		{
			if (!dic_parent.ContainsKey(key))
			{
				return;
			}
			
			Dictionary<string, object> dic = (Dictionary<string, object>)dic_parent[key];
			SetSingleObject(dic, t_obj);
		}
		
		public void SetSingleObject<T>(Dictionary<string, object> dic, T t_obj)
		{
			FieldInfo[] field_info = t_obj.GetType().GetFields();
			foreach (FieldInfo f in field_info)
			{
				if (dic.ContainsKey(f.Name))
				{
					f.SetValue(t_obj, dic[f.Name]);
				}
			}
		}
		
		public void SetArrayObjects<T>(Dictionary<string, object> dic_parent, string key, List<T> lst_t_obj) where T : new()
		{
			if (!dic_parent.ContainsKey(key))
			{
				return;
			}
			lst_t_obj.Clear();
			object[] arr_obj = (object[])dic_parent[key];
			foreach (object o in arr_obj)
			{
				Dictionary<string, object> dic = (Dictionary<string, object>) o;
				T obj = new T();
				SetSingleObject(dic, obj);
				lst_t_obj.Add(obj);
			}
		}
	}
}
