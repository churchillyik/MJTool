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
				SetSingleObject(dic_root, null, root);
				
				// userData
				if (!dic_root.ContainsKey("userData"))
				{
					upCall.DebugLog("dic_root不存在userData键值");
					return;
				}
				Dictionary<string, object> dic_userData = (Dictionary<string, object>)dic_root["userData"];
				SetSingleObject(dic_root, "userData", root.userData);

				SetMapObjects(dic_userData, "userSendFeed", root.userData.userSendFeed);
				SetSingleObject(dic_userData, "user", root.userData.user);
				SetArrayObjects(dic_userData, "userGeneral", root.userData.userGeneral);
				SetArrayObjects(dic_userData, "userItem", root.userData.userItem);
				SetArrayObjects(dic_userData, "userEquip", root.userData.userEquip);
				SetArrayObjects(dic_userData, "userFormation", root.userData.userFormation);
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
				SetSingleObject(dic_userData, "userTurntable", root.userData.userTurntable);
				SetArrayObjects(dic_userData, "userGood", root.userData.userGood);
				SetArrayObjects(dic_userData, "serverGood", root.userData.serverGood);
				SetSingleObject(dic_userData, "userDice", root.userData.userDice);
				SetArrayObjects(dic_userData, "userHook", root.userData.userHook);
				SetArrayObjects(dic_userData, "userShadow", root.userData.userShadow);
				SetSingleObject(dic_userData, "userPropLock", root.userData.userPropLock);
				SetSingleObject(dic_userData, "userServerRace", root.userData.userServerRace);
				SetArrayObjects(dic_userData, "userServerRaceStage3ServerCounts", root.userData.userServerRaceStage3ServerCounts);
				SetArrayObjects(dic_userData, "userServerRace1s", root.userData.userServerRace1s);
				SetSingleObject(dic_userData, "userServerRace3", root.userData.userServerRace3);
				SetArrayObjects(dic_userData, "serverRace4s", root.userData.serverRace4s);
				SetSingleObject(dic_userData, "userStarTower", root.userData.userStarTower);
				SetSingleObject(dic_userData, "userRich", root.userData.userRich);
				SetArrayObjects(dic_userData, "userThreeRacing", root.userData.userThreeRacing);
				SetArrayObjects(dic_userData, "userThreeRacingItem", root.userData.userThreeRacingItem);
				SetSingleObject(dic_userData, "userPetBaby", root.userData.userPetBaby);
				SetSingleObject(dic_userData, "functionOpen", root.userData.functionOpen);
				SetSingleObject(dic_userData, "userSigin", root.userData.userSigin);
				SetSingleObject(dic_userData, "userEggAward", root.userData.userEggAward);
				SetArrayObjects(dic_userData, "userFish", root.userData.userFish);
				SetSingleObject(dic_userData, "userGuess", root.userData.userGuess);
				SetBaseArrayObjects(dic_userData, "VipShadowWin", root.userData.VipShadowWin);
				
				// userData.userConquerorCityInfo
				if (dic_userData.ContainsKey("userConquerorCityInfo"))
				{
					object[] arr_obj = (object[]) dic_userData["userConquerorCityInfo"];
					for (int i = 0; i < arr_obj.Length; i++)
					{
						Dictionary<string, object> dic = (Dictionary<string, object>) arr_obj[i];
						SetArrayObjects(dic, "guildName", root.userData.userConquerorCityInfo[i].guildName);
						SetArrayObjects(dic, "cityBuff", root.userData.userConquerorCityInfo[i].cityBuff);
					}
				}
				
				// userData.userConquerorAward
				if (dic_userData.ContainsKey("userConquerorAward"))
				{
					Dictionary<string, object> dic_userConquerorAward = (Dictionary<string, object>)dic_userData["userConquerorAward"];
					SetArrayObjects(dic_userConquerorAward, "dayAward", root.userData.userConquerorAward.dayAward);
					SetArrayObjects(dic_userConquerorAward, "weekAward", root.userData.userConquerorAward.weekAward);
				}
				
				// userSigin.dayDetail
				if (dic_userData.ContainsKey("userSigin"))
				{
					Dictionary<string, object> dic_userSigin = (Dictionary<string, object>)dic_userData["userSigin"];
					//SetMapObjects(dic_userSigin, "dayDetail", root.userData.userSigin.dayDetail);
					//SetBaseMapObjects(dic_userSigin, "continueSigin", root.userData.userSigin.continueSigin);
					SetMapObjects(dic_userSigin, "lastDayDetail", root.userData.userSigin.lastDayDetail);
					SetSingleObject(dic_userSigin, "awardInfo", root.userData.userSigin.awardInfo);
					SetSingleObject(dic_userSigin, "lastAwardInfo", root.userData.userSigin.lastAwardInfo);					
				}
			}
			catch (Exception e)
			{
				upCall.DebugLog(e.StackTrace);
			}
		}
		
		private static Dictionary<string, string> dicValidFieldName = new Dictionary<string, string>()
		{
			{"intel", "int"},
			{"nEvent", "event"},
			{"groupId", "groupId "},
			{"nValue", "value"},
		};
		
		public string GetVaildFieldName(string field_name)
		{
			if (dicValidFieldName.ContainsKey(field_name))
			{
				return dicValidFieldName[field_name];
			}
			else
			{
				return field_name;
			}
		}
		
		public void SetSingleObject<T>(Dictionary<string, object> dic_parent, string key, T t_obj)
		{
			if (dic_parent == null)
			{
				return;
			}
			if (key == null)
			{
				SetSingleObject(dic_parent, t_obj);
			}
			else
			{
				if (!dic_parent.ContainsKey(key))
				{
					upCall.DebugLog(t_obj.ToString() + "无法从字典中获取 " + key + " 值");
					return;
				}
				Dictionary<string, object> dic = (Dictionary<string, object>)dic_parent[key];
				SetSingleObject(dic, t_obj);
			}
		}
		
		public void SetSingleObject<T>(Dictionary<string, object> dic, T t_obj)
		{
			if (dic == null)
			{
				return;
			}
			FieldInfo[] field_info = t_obj.GetType().GetFields();
			if (field_info == null)
			{
				return;
			}
			foreach (FieldInfo f in field_info)
			{
				string valid_name = GetVaildFieldName(f.Name);
				if (dic.ContainsKey(valid_name))
				{
					if (!f.FieldType.IsGenericType && f.FieldType.Namespace == "System")
					{
						if (f.FieldType.Name == "Int32")
						{
							f.SetValue(t_obj, Convert.ToInt32(dic[valid_name]));
						}
						else if (f.FieldType.Name == "Double")
						{
							f.SetValue(t_obj, Convert.ToDouble(dic[valid_name]));
						}
						else if (f.FieldType.Name == "String")
						{
							f.SetValue(t_obj, Convert.ToString(dic[valid_name]));
						}
						else if (f.FieldType.Name == "Boolean")
						{
							f.SetValue(t_obj, Convert.ToBoolean(dic[valid_name]));
						}
						else
						{
							upCall.DebugLog("无法设定" + f.FieldType.Name + "类型的数据");
						}
					}
				}
				else
				{
					upCall.DebugLog(t_obj.ToString() + "无法从字典中获取 " + valid_name + " 值");
				}
			}
		}
		
		public void SetArrayObjects<T>(Dictionary<string, object> dic_parent, string key, List<T> lst_t_obj) where T : new()
		{
			if (dic_parent == null)
			{
				return;
			}
			if (!dic_parent.ContainsKey(key))
			{
				upCall.DebugLog(lst_t_obj.ToString() + "无法从字典中获取 " + key + " 值");
				return;
			}
			lst_t_obj.Clear();
			object[] arr_obj = (object[])dic_parent[key];
			if (arr_obj == null)
			{
				return;
			}
			foreach (object o in arr_obj)
			{
				Dictionary<string, object> dic = (Dictionary<string, object>) o;
				T obj = new T();
				SetSingleObject(dic, obj);
				lst_t_obj.Add(obj);
			}
		}
		
		public void SetMapObjects<T>(Dictionary<string, object> dic_parent, string key, Dictionary<string, T> dic_t_obj) where T : new()
		{
			if (dic_parent == null)
			{
				return;
			}
			if (!dic_parent.ContainsKey(key))
			{
				upCall.DebugLog(dic_t_obj.ToString() + "无法从字典中获取 " + key + " 值");
				return;
			}
			dic_t_obj.Clear();
			Dictionary<string, object> dic = (Dictionary<string, object>)dic_parent[key];
			if (dic == null)
			{
				return;
			}
			foreach (KeyValuePair<string, object> pair in dic)
			{
				Dictionary<string, object> val = (Dictionary<string, object>)pair.Value;
				T obj = new T();
				SetSingleObject(val, obj);
				dic_t_obj.Add(pair.Key, obj);
			}
		}
		
		public void SetBaseArrayObjects<T>(Dictionary<string, object> dic_parent, string key, List<T> lst_t_obj)
		{
			if (dic_parent == null)
			{
				return;
			}
			if (!dic_parent.ContainsKey(key))
			{
				upCall.DebugLog(lst_t_obj.ToString() + "无法从字典中获取 " + key + " 值");
				return;
			}
			lst_t_obj.Clear();
			object[] arr_obj = (object[])dic_parent[key];
			if (arr_obj == null)
			{
				return;
			}
			foreach (T t in arr_obj)
			{
				lst_t_obj.Add(t);
			}
		}
		
		public void SetBaseMapObjects<T>(Dictionary<string, object> dic_parent, string key, Dictionary<string, T> dic_t_obj)
		{
			if (dic_parent == null)
			{
				return;
			}
			if (!dic_parent.ContainsKey(key))
			{
				upCall.DebugLog(dic_t_obj.ToString() + "无法从字典中获取 " + key + " 值");
				return;
			}
			dic_t_obj.Clear();
			Dictionary<string, T> dic = (Dictionary<string, T>)dic_parent[key];
			if (dic == null)
			{
				return;
			}
			foreach (KeyValuePair<string, T> pair in dic)
			{
				dic_t_obj.Add(pair.Key, pair.Value);
			}
		}
	}
}
