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
			string end_str = "userEnemy";
			for (int i = 1; i < bs_result.Length; i++)
			{
				lst_byte_res.Add(bs_result[i]);
				if (bs_result[i + 1] == (byte)(end_str.Length * 2 + 1))
				{
					bool bEqual = true;
					for (int j = 0; j < end_str.Length; j++)
					{
						if (bs_result[i + 2 + j] != (byte)end_str[j])
						{
							bEqual = false;
							break;
						}
					}
					if (bEqual)
					{
						break;
					}
				}
			}
			lst_byte_res.Add(0x01);
			lst_byte_res.Add(0x01);
			byte[] b_res = lst_byte_res.ToArray();
			
//			bool bStart = false;
//			string start_str = "userGeneral";
//			List<byte> my_lst = new List<byte>();
//			for (int i = 1; i < bs_result.Length; i++)
//			{
//				if (!bStart)
//				{
//					if (bs_result[i + 1] == (byte)(start_str.Length * 2 + 1))
//					{
//						bool bEqual = true;
//						for (int j = 0; j < start_str.Length; j++)
//						{
//							if (bs_result[i + 2 + j] != (byte)start_str[j])
//							{
//								bEqual = false;
//								break;
//							}
//						}
//						if (bEqual)
//						{
//							bStart = true;
//						}
//					}
//				}
//				else
//				{
//					my_lst.Add(bs_result[i]);
//					if (bs_result[i + 1] == (byte)(end_str.Length * 2 + 1))
//					{
//						bool bEqual = true;
//						for (int j = 0; j < end_str.Length; j++)
//						{
//							if (bs_result[i + 2 + j] != (byte)end_str[j])
//							{
//								bEqual = false;
//								break;
//							}
//						}
//						if (bEqual)
//						{
//							break;
//						}
//					}
//				}
//			}
//			my_lst.Add(0x01);
//			my_lst.Add(0x01);
//			upCall.Print(my_lst.ToArray());
//			return;
			
			try
			{
				Dictionary<string, object> dic_root = QueryManager.AMF_Deserializer<Dictionary<string, object>>(b_res, b_res.Length);
				
				root.userData.Clear();
				
				// serverTime
				root.serverTime = (double)dic_root["serverTime"];
				
				// userData.userSendFeed
				Dictionary<string, object> dic_userData = (Dictionary<string, object>)dic_root["userData"];
				Dictionary<string, object> dic_userSendFeed = (Dictionary<string, object>)dic_userData["userSendFeed"];
				foreach (KeyValuePair<string, object> pair in dic_userSendFeed)
				{
					Dictionary<string, object> val = (Dictionary<string, object>)pair.Value;
					root.userData.userSendFeed.Add(pair.Key,
					                               new entityUserSend()
					                               {
					                               	id = (int)val["id"],
					                               	num = (int)val["num"],
					                               	ct = (double)val["ct"],
					                               });

				}
				
				// userData.msgBoxNum
				root.userData.msgBoxNum = (int)dic_userData["msgBoxNum"];
				
				// userData.user
				Dictionary<string, object> dic_user = (Dictionary<string, object>)dic_userData["user"];
				root.userData.user.id = (int)dic_user["id"];
				root.userData.user.name = (string)dic_user["name"];
				root.userData.user.sex = (int)dic_user["sex"];
				root.userData.user.birthday = (string)dic_user["birthday"];
				root.userData.user.icon = (string)dic_user["icon"];
				root.userData.user.level = (int)dic_user["level"];
				root.userData.user.exp = (int)dic_user["exp"];
				root.userData.user.gold = (int)dic_user["gold"];
				root.userData.user.cash = (int)dic_user["cash"];
				root.userData.user.luck = (int)dic_user["luck"];
				root.userData.user.luckTrend = (int)dic_user["luckTrend"];
				root.userData.user.luckModify = (double)dic_user["luckModify"];
				root.userData.user.cdEndTime = (double)dic_user["cdEndTime"];
				root.userData.user.cdTrend = (int)dic_user["cdTrend"];
				root.userData.user.smithLevel = (int)dic_user["smithLevel"];
				root.userData.user.maxFriendNum = (int)dic_user["maxFriendNum"];
				root.userData.user.friendLastUpdate = (double)dic_user["friendLastUpdate"];
				root.userData.user.lastModify = (double)dic_user["lastModify"];
				root.userData.user.registerTime = (double)dic_user["registerTime"];
				root.userData.user.finishGuide = (int)dic_user["finishGuide"];
				root.userData.user.apiPermission = (int)dic_user["apiPermission"];
				root.userData.user.userSign = (string)dic_user["userSign"];
				root.userData.user.vouch_cash = (int)dic_user["vouch_cash"];
				root.userData.user.lastLoginTime = (double)dic_user["lastLoginTime"];
				root.userData.user.increaseId = (int)dic_user["increaseId"];
				root.userData.user.tollgateFormation = (int)dic_user["tollgateFormation"];
				root.userData.user.itemNum = (int)dic_user["itemNum"];
				root.userData.user.unlockItemNum = (int)dic_user["unlockItemNum"];
				root.userData.user.masterGeneral = (int)dic_user["masterGeneral"];
				root.userData.user.generalNum = (int)dic_user["generalNum"];
				root.userData.user.tavernP = (string)dic_user["tavernP"];
				root.userData.user.towerFormation = (int)dic_user["towerFormation"];
				root.userData.user.defendFormation = (int)dic_user["defendFormation"];
				root.userData.user.arenaFormation = (int)dic_user["arenaFormation"];
				root.userData.user.raceFormation = (int)dic_user["raceFormation"];
				root.userData.user.leagueFormation = (int)dic_user["leagueFormation"];
				root.userData.user.fightPower = (int)dic_user["fightPower"];
				root.userData.user.honor = (int)dic_user["honor"];
				root.userData.user.cashTrainSlot = (int)dic_user["cashTrainSlot"];
				root.userData.user.generalMood = (int)dic_user["generalMood"];
				root.userData.user.rapidCdEndTime = (double)dic_user["rapidCdEndTime"];
				root.userData.user.character = (int)dic_user["character"];
				root.userData.user.tavernG = (string)dic_user["tavernG"];
				root.userData.user.tavernCdEndTime_1 = (double)dic_user["tavernCdEndTime_1"];
				root.userData.user.tavernCdEndTime_2 = (double)dic_user["tavernCdEndTime_2"];
				root.userData.user.tavernCdEndTime_3 = (double)dic_user["tavernCdEndTime_3"];
				root.userData.user.tavernCdEndTime_4 = (double)dic_user["tavernCdEndTime_4"];
				root.userData.user.tavernTotalP = (double)dic_user["tavernTotalP"];
				root.userData.user.guild = (int)dic_user["guild"];
				root.userData.user.guildStatus = (int)dic_user["guildStatus"];
				root.userData.user.position = (int)dic_user["position"];
				root.userData.user.contribute = (int)dic_user["contribute"];
				root.userData.user.lastBoonTime = (double)dic_user["lastBoonTime"];
				root.userData.user.lastFeedTime = (double)dic_user["lastFeedTime"];
				root.userData.user.guildDonate = (int)dic_user["guildDonate"];
				root.userData.user.lastDonateTime = (double)dic_user["lastDonateTime"];
				root.userData.user.dayContribute = (int)dic_user["dayContribute"];
				root.userData.user.lastContributeTime = (int)dic_user["lastContributeTime"];
				root.userData.user.markGuildWar = (int)dic_user["markGuildWar"];
				root.userData.user.inspire = (int)dic_user["inspire"];
				root.userData.user.inspireConsume = (int)dic_user["inspireConsume"];
				root.userData.user.increaseContribute = (int)dic_user["increaseContribute"];
				root.userData.user.markWarNumber = (int)dic_user["markWarNumber"];
				root.userData.user.honorGoodsIds = (string)dic_user["honorGoodsIds"];
				root.userData.user.honorRefreshCdEndTime_1 = (double)dic_user["honorRefreshCdEndTime_1"];
				root.userData.user.raceBigAreaId = (int)dic_user["raceBigAreaId"];
				root.userData.user.raceBetUserId = (int)dic_user["raceBetUserId"];
				root.userData.user.raceBetNumber = (int)dic_user["raceBetNumber"];
				root.userData.user.generalCampLevel = (int)dic_user["generalCampLevel"];
				root.userData.user.tavernLevel = (int)dic_user["tavernLevel"];
				root.userData.user.guildName = (string)dic_user["guildName"];
				root.userData.user.fourImages = (int)dic_user["fourImages"];
				root.userData.user.arenaDayWins = (int)dic_user["arenaDayWins"];
				root.userData.user.yellowLevel = (int)dic_user["yellowLevel"];
				root.userData.user.yearYellow = (int)dic_user["yearYellow"];
				root.userData.user.energy = (int)dic_user["energy"];
				root.userData.user.maxEnergy = (int)dic_user["maxEnergy"];
				root.userData.user.keepLoginDay = (int)dic_user["keepLoginDay"];
				root.userData.user.lastGetLoginAwardTime = (double)dic_user["lastGetLoginAwardTime"];
				root.userData.user.vipPoint = (int)dic_user["vipPoint"];
				root.userData.user.vipEndTime_1 = (int)dic_user["vipEndTime_1"];
				root.userData.user.vipLastModify = (double)dic_user["vipLastModify"];
				root.userData.user.vipType = (int)dic_user["vipType"];
				root.userData.user.bagExpandTimes = (int)dic_user["bagExpandTimes"];
				root.userData.user.lastGetFertilizerTime = (double)dic_user["lastGetFertilizerTime"];
				root.userData.user.dayVisitEnergy = (int)dic_user["dayVisitEnergy"];
				root.userData.user.eventGetNumber = (int)dic_user["eventGetNumber"];
				root.userData.user.eventGetTime = (double)dic_user["eventGetTime"];
				root.userData.user.eventCdEndTime = (int)dic_user["eventCdEndTime"];
				root.userData.user.characterLevel = (int)dic_user["characterLevel"];
				root.userData.user.liveness = (int)dic_user["liveness"];
				root.userData.user.livenessLastModify = (double)dic_user["livenessLastModify"];
				root.userData.user.getLivenessLevels = (string)dic_user["getLivenessLevels"];
				root.userData.user.honorRefreshCdEndTime_2 = (double)dic_user["honorRefreshCdEndTime_2"];
				root.userData.user.honorRefreshCdEndTime_3 = (double)dic_user["honorRefreshCdEndTime_3"];
				root.userData.user.honorRefreshCdEndTime_4 = (double)dic_user["honorRefreshCdEndTime_4"];
				root.userData.user.cas = (int)dic_user["cas"];
				root.userData.user.increaseMaxEnergyNum = (int)dic_user["increaseMaxEnergyNum"];
				root.userData.user.leaveGuildDate = (int)dic_user["leaveGuildDate"];
				root.userData.user.newMailNumber = (int)dic_user["newMailNumber"];
				root.userData.user.lastGetMessageTime = (double)dic_user["lastGetMessageTime"];
				root.userData.user.historyContribute = (int)dic_user["historyContribute"];
				root.userData.user.vipEndTime = (int)dic_user["vipEndTime"];
				root.userData.user.lastPayTime = (int)dic_user["lastPayTime"];
				root.userData.user.npcLastVisit = (double)dic_user["npcLastVisit"];
				root.userData.user.arenaCdEndTime = (double)dic_user["arenaCdEndTime"];
				root.userData.user.userInfoLastUpdateTime = (double)dic_user["userInfoLastUpdateTime"];
				root.userData.user.qzoneInfoLastUpdateTime = (int)dic_user["qzoneInfoLastUpdateTime"];
				root.userData.user.bakName = (int)dic_user["bakName"];
				root.userData.user.bakIcon = (int)dic_user["bakIcon"];
				root.userData.user.qzoneFriendLastUpdate = (int)dic_user["qzoneFriendLastUpdate"];
				root.userData.user.lastTollgateId = (int)dic_user["lastTollgateId"];
				root.userData.user.qrjKeepLoginDays = (int)dic_user["qrjKeepLoginDays"];
				root.userData.user.arenaLastModify = (double)dic_user["arenaLastModify"];
				root.userData.user.consume = (int)dic_user["consume"];
				root.userData.user.annouBlack = (int)dic_user["annouBlack"];
				root.userData.user.msgBlack = (int)dic_user["msgBlack"];
				root.userData.user.generalSpectrumIds = (string)dic_user["generalSpectrumIds"];
				root.userData.user.plantCdEndTime = (double)dic_user["plantCdEndTime"];
				root.userData.user.generalSpectrumLevel = (int)dic_user["generalSpectrumLevel"];
				root.userData.user.generalSpectrumBuff = (int)dic_user["generalSpectrumBuff"];
				root.userData.user.beInvitUid = (int)dic_user["beInvitUid"];
				root.userData.user.serverId = (int)dic_user["serverId"];
				root.userData.user.poolExpNumber = (int)dic_user["poolExpNumber"];
				root.userData.user.lastGetDayTreasureTime = (double)dic_user["lastGetDayTreasureTime"];
				root.userData.user.getTreasureVipLevels = (string)dic_user["getTreasureVipLevels"];
				root.userData.user.diamond = (int)dic_user["diamond"];
				root.userData.user.regionUid = (int)dic_user["regionUid"];
				root.userData.user.announcement = (string)dic_user["announcement"];
				root.userData.user.copyFirstAward = (int)dic_user["copyFirstAward"];
				root.userData.user.escortLastRefresh = (double)dic_user["escortLastRefresh"];
				root.userData.user.escortIsStart = (int)dic_user["escortIsStart"];
				root.userData.user.escortGetPlantTimes = (int)dic_user["escortGetPlantTimes"];
				root.userData.user.escortRefreshRobInfoTime = (double)dic_user["escortRefreshRobInfoTime"];
				root.userData.user.escortRobTimes = (int)dic_user["escortRobTimes"];
				root.userData.user.escortGeneralIds = (string)dic_user["escortGeneralIds"];
				root.userData.user.escortBeginTime = (double)dic_user["escortBeginTime"];
				root.userData.user.escortLastRobTime = (double)dic_user["escortLastRobTime"];
				root.userData.user.cardLoginTime = (int)dic_user["cardLoginTime"];
				root.userData.user.lastGetVipSeed = (double)dic_user["lastGetVipSeed"];
				root.userData.user.stargazingTeacherId = (int)dic_user["stargazingTeacherId"];
				root.userData.user.stargazingCdEndTime = (double)dic_user["stargazingCdEndTime"];
				root.userData.user.stargazingEnergy = (int)dic_user["stargazingEnergy"];
				root.userData.user.stargazingLevel = (int)dic_user["stargazingLevel"];
				root.userData.user.stargazingVisitTimes = (int)dic_user["stargazingVisitTimes"];
				root.userData.user.stargazingVisitLastTime = (int)dic_user["stargazingVisitLastTime"];
				root.userData.user.lugNum = (int)dic_user["lugNum"];
				root.userData.user.petFight = (double)dic_user["petFight"];
				root.userData.user.buyViped = (int)dic_user["buyViped"];
				root.userData.user.isReceiveNoviceChest = (int)dic_user["isReceiveNoviceChest"];
				root.userData.user.verified_type = (int)dic_user["verified_type"];
				root.userData.user.sinaBadge = (int)dic_user["sinaBadge"];
				root.userData.user.identity_status = (int)dic_user["identity_status"];
				root.userData.user.getSinaBadgeTime = (double)dic_user["getSinaBadgeTime"];
				root.userData.user.sinaBadgeIsGetEquip = (int)dic_user["sinaBadgeIsGetEquip"];
				root.userData.user.sinaBadgeIsGetGeneralSoul = (int)dic_user["sinaBadgeIsGetGeneralSoul"];
				root.userData.user.sinaRecharge = (int)dic_user["sinaRecharge"];
				root.userData.user.lotteryNumber = (int)dic_user["lotteryNumber"];
				root.userData.user.lotteryResetNumber = (int)dic_user["lotteryResetNumber"];
				root.userData.user.spot = (int)dic_user["spot"];
				root.userData.user.lotteryPayNumber = (int)dic_user["lotteryPayNumber"];
				root.userData.user.lastRobHook = (int)dic_user["lastRobHook"];
				root.userData.user.diceExp = (int)dic_user["diceExp"];
				root.userData.user.diceSpot = (int)dic_user["diceSpot"];
				root.userData.user.lotteryMaxNumber = (int)dic_user["lotteryMaxNumber"];
				root.userData.user.lotteryResetMaxNumber = (int)dic_user["lotteryResetMaxNumber"];
				root.userData.user.sinaFirstCharge = (int)dic_user["sinaFirstCharge"];
				root.userData.user.sinaFirstChargeGetTime = (int)dic_user["sinaFirstChargeGetTime"];
				root.userData.user.serverRaceStage3ServerAward = (int)dic_user["serverRaceStage3ServerAward"];
				root.userData.user.userRecallTime = (double)dic_user["userRecallTime"];
				root.userData.user.awardTime = (int)dic_user["awardTime"];
				root.userData.user.skillDot = (int)dic_user["skillDot"];
				root.userData.user.leaveUseEnergy = (int)dic_user["leaveUseEnergy"];
				root.userData.user.leaveBuyEnergy = (int)dic_user["leaveBuyEnergy"];
				
				// userData.userGeneral
				object[] lstUserGeneral = (object[])dic_userData["userGeneral"];
				foreach (object o in lstUserGeneral)
				{
					Dictionary<string, object> dic_gen = (Dictionary<string, object>) o;
					root.userData.userGeneral.Add(
						new entityUserGeneral()
						{
							uid = (int)dic_gen["uid"],
							id = (int)dic_gen["id"],
							generalId = (int)dic_gen["generalId"],
							generalType = (int)dic_gen["generalType"],
							name = (string)dic_gen["name"],
							hp = (int)dic_gen["hp"],
							level = (int)dic_gen["level"],
							anger = (int)dic_gen["anger"],
							str = (int)dic_gen["str"],
							intel = (int)dic_gen["int"],
							agi = (int)dic_gen["agi"],
							vit = (int)dic_gen["vit"],
							atk_1 = (int)dic_gen["atk_1"],
							def_1 = (int)dic_gen["def_1"],
							atk_2 = (int)dic_gen["atk_2"],
							def_2 = (int)dic_gen["def_2"],
							atk_3 = (int)dic_gen["atk_3"],
							def_3 = (int)dic_gen["def_3"],
							atk_4 = (int)dic_gen["atk_4"],
							def_4 = (int)dic_gen["def_4"],
							dodge = (int)dic_gen["dodge"],
							hit = (int)dic_gen["hit"],
							cri = (int)dic_gen["cri"],
							resist = (int)dic_gen["resist"],
							pvedr = (int)dic_gen["pvedr"],
							pvpdr = (int)dic_gen["pvpdr"],
							weapon = (int)dic_gen["weapon"],
							armor = (int)dic_gen["armor"],
							cloak = (int)dic_gen["cloak"],
							belt = (int)dic_gen["belt"],
							skillag = (int)dic_gen["skillag"],
							skillbg = (int)dic_gen["skillbg"],
							new_ndot = (int)dic_gen["new_ndot"],
							skillpgo = (int)dic_gen["skillpgo"],
							skillpgo_1 = (int)dic_gen["skillpgo_1"],
							new_str = (int)dic_gen["new_str"],
							new_int = (int)dic_gen["new_int"],
							new_agi = (int)dic_gen["new_agi"],
							new_vit = (int)dic_gen["new_vit"],
							re_task = (int)dic_gen["re_task"],
							ndot = (int)dic_gen["ndot"],
							exp = (int)dic_gen["exp"],
							source = (int)dic_gen["source"],
							ct = (double)dic_gen["ct"],
							iSkill = (int)dic_gen["iSkill"],
							fSkill = (int)dic_gen["fSkill"],
							rSkill = (int)dic_gen["rSkill"],
							pSkill1 = (int)dic_gen["pSkill1"],
							pSkill2 = (int)dic_gen["pSkill2"],
							pSkill3 = (int)dic_gen["pSkill3"],
							pSkill4 = (int)dic_gen["pSkill4"],
							pSkill5 = (int)dic_gen["pSkill5"],
							pSkill6 = (int)dic_gen["pSkill6"],
							pSkill7 = (int)dic_gen["pSkill7"],
							pSkill8 = (int)dic_gen["pSkill8"],
							quality = (int)dic_gen["quality"],
							breakLevel = (int)dic_gen["breakLevel"],
							iSkillList = (string)dic_gen["iSkillList"],
							fSkillList = (string)dic_gen["fSkillList"],
							rSkillList = (string)dic_gen["rSkillList"],
							spotLevel = (int)dic_gen["spotLevel"],
							hat = (int)dic_gen["hat"],
							ring = (int)dic_gen["ring"],
							necklace = (int)dic_gen["necklace"],
							gloves = (int)dic_gen["gloves"],
							avatar = (int)dic_gen["avatar"],
						});
				}
				
				// userData.userItem
				object[] lstUserItem = (object[])dic_userData["userItem"];
				foreach (object o in lstUserItem)
				{
					Dictionary<string, object> dic_item = (Dictionary<string, object>) o;
					root.userData.userItem.Add(
						new entityUserItem()
						{
							categoryId = (int)dic_item["categoryId"],
							typeId = (int)dic_item["typeId"],
							number = (int)dic_item["number"],
						});
				}
				
				// userData.userEquip
				object[] lstUserEquip = (object[])dic_userData["userEquip"];
				foreach (object o in lstUserEquip)
				{
					Dictionary<string, object> dic_equip = (Dictionary<string, object>) o;
					root.userData.userEquip.Add(
						new entityUserEquip()
						{
							id = (int)dic_equip["id"],
							generalId = (int)dic_equip["generalId"],
							typeId = (int)dic_equip["typeId"],
							strTimes = (int)dic_equip["strTimes"],
							attrValue = (int)dic_equip["attrValue"],
							lastStrength = (double)dic_equip["lastStrength"],
							slot1 = (int)dic_equip["slot1"],
							slot2 = (int)dic_equip["slot2"],
							slot3 = (int)dic_equip["slot3"],
							atk_1 = (int)dic_equip["atk_1"],
							atk_2 = (int)dic_equip["atk_2"],
							atk_4 = (int)dic_equip["atk_4"],
							atk_3 = (int)dic_equip["atk_3"],
							def_1 = (int)dic_equip["def_1"],
							def_2 = (int)dic_equip["def_2"],
							def_4 = (int)dic_equip["def_4"],
							def_3 = (int)dic_equip["def_3"],
							hp = (int)dic_equip["hp"],
						});
				}
				
				// userData.userFormation
				object[] lstUserFormation = (object[])dic_userData["userFormation"];
				foreach (object o in lstUserFormation)
				{
					Dictionary<string, object> dic_userFmt = (Dictionary<string, object>) o;
					root.userData.userFormation.Add(
						new entityUserFormation()
						{
							id = (int)dic_userFmt["id"],
							level = (int)dic_userFmt["level"],
							unlockGrid = (string)dic_userFmt["unlockGrid"],
						});
				}
				
				// userData.feedstoryovi
				root.userData.feedstoryovi = (int)dic_userData["feedstoryovi"];
				
				// userData.userFriend
				object[] lstUserFriend = (object[])dic_userData["userFriend"];
				foreach (object o in lstUserFriend)
				{
					Dictionary<string, object> dic_userFriend = (Dictionary<string, object>) o;
					root.userData.userFriend.Add(
						new entityUserFriend()
						{
							id = (string)dic_userFriend["id"],
							name = (string)dic_userFriend["name"],
							icon = (string)dic_userFriend["icon"],
							sex = (int)dic_userFriend["sex"],
							birthday = (string)dic_userFriend["birthday"],
							yellowLevel = (int)dic_userFriend["yellowLevel"],
							yearYellow = (int)dic_userFriend["yearYellow"],
							level = (int)dic_userFriend["level"],
							lastModify = Convert.ToDouble(dic_userFriend["lastModify"]),
							vipPoint = (int)dic_userFriend["vipPoint"],
							lastVisited = Convert.ToDouble(dic_userFriend["lastVisited"]),
							dayOperateTimes = (int)dic_userFriend["dayOperateTimes"],
							lastOperateTime = (int)dic_userFriend["lastOperateTime"],
							maxSceneId = (int)dic_userFriend["maxSceneId"],
							nEvent = (int)dic_userFriend["event"],
							eventTime = Convert.ToDouble(dic_userFriend["eventTime"]),
							fourImages = (int)dic_userFriend["fourImages"],
							guild = (int)dic_userFriend["guild"],
							guildName = (string)dic_userFriend["guildName"],
							vipLevel = (int)dic_userFriend["vipLevel"],
							guildIcon = (string)dic_userFriend["guildIcon"],
							guildLevel = (int)dic_userFriend["guildLevel"],
							qzoneName = (int)dic_userFriend["qzoneName"],
							qzoneIcon = (int)dic_userFriend["qzoneIcon"],
							isQzone = (int)dic_userFriend["isQzone"],
							isOther = (int)dic_userFriend["isOther"],
							lastLoginTime = Convert.ToDouble(dic_userFriend["lastLoginTime"]),
							tech2Level = (int)dic_userFriend["tech2Level"],
							lastGiftTime = (int)dic_userFriend["lastGiftTime"],
							attention = (int)dic_userFriend["attention"],
							sid = (string)dic_userFriend["sid"],
							serverId = (int)dic_userFriend["serverId"],
							dayGifted = (int)dic_userFriend["dayGifted"],
							verified_type = (int)dic_userFriend["verified_type"],
							threeRacing = (int)dic_userFriend["threeRacing"],
							fightLevel = (int)dic_userFriend["fightLevel"],
						});
				}
			}
			catch (Exception e)
			{
				upCall.DebugLog(e.StackTrace);
			}
		}
	}
}
