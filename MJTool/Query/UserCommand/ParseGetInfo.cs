using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MJTool
{
	/// <summary>
	/// Description of ParseGetInfo.
	/// </summary>
	public partial class Account
	{
		public void ParseGetInfo(byte[] bs_result)
		{
			try
			{
				Dictionary<string, object> dic_root = upCall.GetRootDic(bs_result);
				upCall.SetSingleObject(dic_root, null, root);
				
				// userData
				if (!dic_root.ContainsKey("userData"))
				{
					upCall.DebugLog("dic_root不存在userData键值");
					return;
				}
				Dictionary<string, object> dic_userData = (Dictionary<string, object>)dic_root["userData"];
				upCall.SetSingleObject(dic_root, "userData", root.userData);

				upCall.SetMapObjects(dic_userData, "userSendFeed", root.userData.userSendFeed);
				upCall.SetSingleObject(dic_userData, "user", root.userData.user);
				upCall.SetArrayObjects(dic_userData, "userGeneral", root.userData.userGeneral);
				upCall.SetArrayObjects(dic_userData, "userItem", root.userData.userItem);
				upCall.SetArrayObjects(dic_userData, "userEquip", root.userData.userEquip);
				upCall.SetArrayObjects(dic_userData, "userFormation", root.userData.userFormation);
				upCall.SetArrayObjects(dic_userData, "userFriend", root.userData.userFriend);
				upCall.SetArrayObjects(dic_userData, "userEnemy", root.userData.userEnemy);
				upCall.SetArrayObjects(dic_userData, "userBuff", root.userData.userBuff);
				upCall.SetArrayObjects(dic_userData, "userGuildFriend", root.userData.userGuildFriend);
				upCall.SetArrayObjects(dic_userData, "userEmployNpc", root.userData.userEmployNpc);
				upCall.SetArrayObjects(dic_userData, "userPlant", root.userData.userPlant);
				upCall.SetArrayObjects(dic_userData, "userRace", root.userData.userRace);
				upCall.SetArrayObjects(dic_userData, "lastUserRace", root.userData.lastUserRace);
				upCall.SetArrayObjects(dic_userData, "userTrain", root.userData.userTrain);
				upCall.SetArrayObjects(dic_userData, "userArena", root.userData.userArena);
				upCall.SetArrayObjects(dic_userData, "userSoul", root.userData.userSoul);
				upCall.SetSingleObject(dic_userData, "userTavern", root.userData.userTavern);
				upCall.SetArrayObjects(dic_userData, "userFormationGeneral", root.userData.userFormationGeneral);
				upCall.SetSingleObject(dic_userData, "userDefend", root.userData.userDefend);
				upCall.SetSingleObject(dic_userData, "userTower", root.userData.userTower);
				upCall.SetArrayObjects(dic_userData, "userScene", root.userData.userScene);
				upCall.SetArrayObjects(dic_userData, "userTotem", root.userData.userTotem);
				upCall.SetArrayObjects(dic_userData, "userUnlock", root.userData.userUnlock);
				upCall.SetSingleObject(dic_userData, "activityInfo", root.userData.activityInfo);
				upCall.SetSingleObject(dic_userData, "activitySendInfo", root.userData.activitySendInfo);
				upCall.SetSingleObject(dic_userData, "guild", root.userData.guild);
				upCall.SetArrayObjects(dic_userData, "userMission", root.userData.userMission);
				upCall.SetArrayObjects(dic_userData, "userLivenessEvent", root.userData.userLivenessEvent);
				upCall.SetSingleObject(dic_userData, "userTimeAward", root.userData.userTimeAward);
				upCall.SetSingleObject(dic_userData, "userSevenDayAward", root.userData.userSevenDayAward);
				upCall.SetSingleObject(dic_userData, "userYellow", root.userData.userYellow);
				upCall.SetArrayObjects(dic_userData, "userOccupyTotem", root.userData.userOccupyTotem);
				upCall.SetArrayObjects(dic_userData, "userRobbedTotems", root.userData.userRobbedTotems);
				upCall.SetSingleObject(dic_userData, "userLevelupChest", root.userData.userLevelupChest);
				upCall.SetArrayObjects(dic_userData, "userGeneralStar", root.userData.userGeneralStar);
				upCall.SetArrayObjects(dic_userData, "userGeneralSpectrum", root.userData.userGeneralSpectrum);
				upCall.SetArrayObjects(dic_userData, "userCopy", root.userData.userCopy);
				upCall.SetArrayObjects(dic_userData, "copyOrderInfo", root.userData.copyOrderInfo);
				upCall.SetArrayObjects(dic_userData, "honorAnnoun", root.userData.honorAnnoun);
				upCall.SetArrayObjects(dic_userData, "userEscorts", root.userData.userEscorts);
				upCall.SetArrayObjects(dic_userData, "userRobbeds", root.userData.userRobbeds);
				upCall.SetArrayObjects(dic_userData, "userRess", root.userData.userRess);
				upCall.SetSingleObject(dic_userData, "userExchangeCode", root.userData.userExchangeCode);
				upCall.SetArrayObjects(dic_userData, "userCards", root.userData.userCards);
				upCall.SetSingleObject(dic_userData, "cardActivity", root.userData.cardActivity);
				upCall.SetArrayObjects(dic_userData, "userStargazings", root.userData.userStargazings);
				upCall.SetArrayObjects(dic_userData, "userStargazingGenerals", root.userData.userStargazingGenerals);
				upCall.SetSingleObject(dic_userData, "userConquerorInfo", root.userData.userConquerorInfo);
				upCall.SetArrayObjects(dic_userData, "userConquerorCityInfo", root.userData.userConquerorCityInfo);
				upCall.SetArrayObjects(dic_userData, "userConquerorLugInfo", root.userData.userConquerorLugInfo);
				upCall.SetSingleObject(dic_userData, "userConquerorAward", root.userData.userConquerorAward);
				upCall.SetArrayObjects(dic_userData, "userPetFight", root.userData.userPetFight);
				upCall.SetSingleObject(dic_userData, "userTurntable", root.userData.userTurntable);
				upCall.SetArrayObjects(dic_userData, "userGood", root.userData.userGood);
				upCall.SetArrayObjects(dic_userData, "serverGood", root.userData.serverGood);
				upCall.SetSingleObject(dic_userData, "userDice", root.userData.userDice);
				upCall.SetArrayObjects(dic_userData, "userHook", root.userData.userHook);
				upCall.SetArrayObjects(dic_userData, "userShadow", root.userData.userShadow);
				upCall.SetSingleObject(dic_userData, "userPropLock", root.userData.userPropLock);
				upCall.SetSingleObject(dic_userData, "userServerRace", root.userData.userServerRace);
				upCall.SetArrayObjects(dic_userData, "userServerRaceStage3ServerCounts", root.userData.userServerRaceStage3ServerCounts);
				upCall.SetArrayObjects(dic_userData, "userServerRace1s", root.userData.userServerRace1s);
				upCall.SetSingleObject(dic_userData, "userServerRace3", root.userData.userServerRace3);
				upCall.SetArrayObjects(dic_userData, "serverRace4s", root.userData.serverRace4s);
				upCall.SetSingleObject(dic_userData, "userStarTower", root.userData.userStarTower);
				upCall.SetSingleObject(dic_userData, "userRich", root.userData.userRich);
				upCall.SetArrayObjects(dic_userData, "userThreeRacing", root.userData.userThreeRacing);
				upCall.SetArrayObjects(dic_userData, "userThreeRacingItem", root.userData.userThreeRacingItem);
				upCall.SetSingleObject(dic_userData, "userPetBaby", root.userData.userPetBaby);
				upCall.SetSingleObject(dic_userData, "functionOpen", root.userData.functionOpen);
				upCall.SetSingleObject(dic_userData, "userSigin", root.userData.userSigin);
				upCall.SetSingleObject(dic_userData, "userEggAward", root.userData.userEggAward);
				upCall.SetArrayObjects(dic_userData, "userFish", root.userData.userFish);
				upCall.SetSingleObject(dic_userData, "userGuess", root.userData.userGuess);
				upCall.SetBaseArrayObjects(dic_userData, "VipShadowWin", root.userData.VipShadowWin);
				
				// userData.userConquerorCityInfo
				if (dic_userData.ContainsKey("userConquerorCityInfo"))
				{
					object[] arr_obj = (object[]) dic_userData["userConquerorCityInfo"];
					for (int i = 0; i < arr_obj.Length; i++)
					{
						Dictionary<string, object> dic = (Dictionary<string, object>) arr_obj[i];
						upCall.SetArrayObjects(dic, "guildName", root.userData.userConquerorCityInfo[i].guildName);
						upCall.SetArrayObjects(dic, "cityBuff", root.userData.userConquerorCityInfo[i].cityBuff);
					}
				}
				
				// userData.userConquerorAward
				if (dic_userData.ContainsKey("userConquerorAward"))
				{
					Dictionary<string, object> dic_userConquerorAward = (Dictionary<string, object>)dic_userData["userConquerorAward"];
					upCall.SetArrayObjects(dic_userConquerorAward, "dayAward", root.userData.userConquerorAward.dayAward);
					upCall.SetArrayObjects(dic_userConquerorAward, "weekAward", root.userData.userConquerorAward.weekAward);
				}
				
				// userSigin.dayDetail
				if (dic_userData.ContainsKey("userSigin"))
				{
					Dictionary<string, object> dic_userSigin = (Dictionary<string, object>)dic_userData["userSigin"];
					upCall.SetMapObjects(dic_userSigin, "dayDetail", root.userData.userSigin.dayDetail);
					upCall.SetBaseMapObjects(dic_userSigin, "continueSigin", root.userData.userSigin.continueSigin);
					upCall.SetMapObjects(dic_userSigin, "lastDayDetail", root.userData.userSigin.lastDayDetail);
					upCall.SetMapArrayObjects(dic_userSigin, "awardInfo", root.userData.userSigin.awardInfo);
					upCall.SetMapArrayObjects(dic_userSigin, "lastAwardInfo", root.userData.userSigin.lastAwardInfo);
				}
				
				// 更新本地和服务器时间差
				RefreshTimeDiff(this.root.serverTime);
					
				upCall.UIUpdateRefreshAll();
				
				PrintTavern();
			}
			catch (Exception e)
			{
				upCall.DebugLog(e.StackTrace);
			}
		}
		
		private void RefreshTimeDiff(double svr_time)
		{
			root.serverTime = svr_time;
			ServerParam.secDiff = root.serverTime - (double)(QueryManager.UnixTimeStamp(DateTime.Now) / 1000);
			upCall.DebugLog("服务器时间更新为：" + QueryManager.SecondsToDateTime(root.serverTime).ToString());
			upCall.DebugLog("与本地时间差为：" + ServerParam.secDiff + "秒");
		}
		
		private void PrintTavern()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("--------------serverTime---------------");
			sb.AppendLine("serverTime: " + QueryManager.SecondsToDateTime(root.serverTime));
			
			sb.AppendLine("--------------user---------------");
			sb.AppendLine("tavernG: " + root.userData.user.tavernG);
			sb.AppendLine("tavernCdEndTime_1: " + QueryManager.SecondsToDateTime(root.userData.user.tavernCdEndTime_1));
			sb.AppendLine("tavernCdEndTime_2: " + QueryManager.SecondsToDateTime(root.userData.user.tavernCdEndTime_2));
			sb.AppendLine("tavernCdEndTime_3: " + QueryManager.SecondsToDateTime(root.userData.user.tavernCdEndTime_3));
			sb.AppendLine("tavernCdEndTime_4: " + QueryManager.SecondsToDateTime(root.userData.user.tavernCdEndTime_4));
			sb.AppendLine("tavernTotalP: " + root.userData.user.tavernTotalP);

			sb.AppendLine("--------------userTavern---------------");
			sb.AppendLine("id_1: " + root.userData.userTavern.id_1);
			sb.AppendLine("id_2: " + root.userData.userTavern.id_2);
			sb.AppendLine("id_3: " + root.userData.userTavern.id_3);
			sb.AppendLine("ct: " + QueryManager.SecondsToDateTime(root.userData.userTavern.ct));
			sb.AppendLine("nomalRefreshTimes: " + root.userData.userTavern.nomalRefreshTimes);
			sb.AppendLine("nomalRefreshTime: " + QueryManager.SecondsToDateTime(root.userData.userTavern.nomalRefreshTime));
			upCall.DebugLog(sb.ToString());
		}
	}
}
