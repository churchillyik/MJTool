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
			string end_str = "userEmployNpc";
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
				root.serverTime = Convert.ToDouble(dic_root["serverTime"]);
				
				// userData.userSendFeed
				Dictionary<string, object> dic_userData = (Dictionary<string, object>)dic_root["userData"];
				Dictionary<string, object> dic_userSendFeed = (Dictionary<string, object>)dic_userData["userSendFeed"];
				foreach (KeyValuePair<string, object> pair in dic_userSendFeed)
				{
					Dictionary<string, object> val = (Dictionary<string, object>)pair.Value;
					entityUserSend us = new entityUserSend();
					us.id = Convert.ToInt32(val["id"]);
					us.num = Convert.ToInt32(val["num"]);
					us.ct = Convert.ToDouble(val["ct"]);
					root.userData.userSendFeed.Add(pair.Key, us);
				}
				
				// userData.msgBoxNum
				root.userData.msgBoxNum = (int)dic_userData["msgBoxNum"];
				
				// userData.user
				Dictionary<string, object> dic_user = (Dictionary<string, object>)dic_userData["user"];
				root.userData.user.id = Convert.ToInt32(dic_user["id"]);
				root.userData.user.name = Convert.ToString(dic_user["name"]);
				root.userData.user.sex = Convert.ToInt32(dic_user["sex"]);
				root.userData.user.birthday = Convert.ToString(dic_user["birthday"]);
				root.userData.user.icon = Convert.ToString(dic_user["icon"]);
				root.userData.user.level = Convert.ToInt32(dic_user["level"]);
				root.userData.user.exp = Convert.ToInt32(dic_user["exp"]);
				root.userData.user.gold = Convert.ToInt32(dic_user["gold"]);
				root.userData.user.cash = Convert.ToInt32(dic_user["cash"]);
				root.userData.user.luck = Convert.ToInt32(dic_user["luck"]);
				root.userData.user.luckTrend = Convert.ToInt32(dic_user["luckTrend"]);
				root.userData.user.luckModify = Convert.ToDouble(dic_user["luckModify"]);
				root.userData.user.cdEndTime = Convert.ToDouble(dic_user["cdEndTime"]);
				root.userData.user.cdTrend = Convert.ToInt32(dic_user["cdTrend"]);
				root.userData.user.smithLevel = Convert.ToInt32(dic_user["smithLevel"]);
				root.userData.user.maxFriendNum = Convert.ToInt32(dic_user["maxFriendNum"]);
				root.userData.user.friendLastUpdate = Convert.ToDouble(dic_user["friendLastUpdate"]);
				root.userData.user.lastModify = Convert.ToDouble(dic_user["lastModify"]);
				root.userData.user.registerTime = Convert.ToDouble(dic_user["registerTime"]);
				root.userData.user.finishGuide = Convert.ToInt32(dic_user["finishGuide"]);
				root.userData.user.apiPermission = Convert.ToInt32(dic_user["apiPermission"]);
				root.userData.user.userSign = Convert.ToString(dic_user["userSign"]);
				root.userData.user.vouch_cash = Convert.ToInt32(dic_user["vouch_cash"]);
				root.userData.user.lastLoginTime = Convert.ToDouble(dic_user["lastLoginTime"]);
				root.userData.user.increaseId = Convert.ToInt32(dic_user["increaseId"]);
				root.userData.user.tollgateFormation = Convert.ToInt32(dic_user["tollgateFormation"]);
				root.userData.user.itemNum = Convert.ToInt32(dic_user["itemNum"]);
				root.userData.user.unlockItemNum = Convert.ToInt32(dic_user["unlockItemNum"]);
				root.userData.user.masterGeneral = Convert.ToInt32(dic_user["masterGeneral"]);
				root.userData.user.generalNum = Convert.ToInt32(dic_user["generalNum"]);
				root.userData.user.tavernP = Convert.ToString(dic_user["tavernP"]);
				root.userData.user.towerFormation = Convert.ToInt32(dic_user["towerFormation"]);
				root.userData.user.defendFormation = Convert.ToInt32(dic_user["defendFormation"]);
				root.userData.user.arenaFormation = Convert.ToInt32(dic_user["arenaFormation"]);
				root.userData.user.raceFormation = Convert.ToInt32(dic_user["raceFormation"]);
				root.userData.user.leagueFormation = Convert.ToInt32(dic_user["leagueFormation"]);
				root.userData.user.fightPower = Convert.ToInt32(dic_user["fightPower"]);
				root.userData.user.honor = Convert.ToInt32(dic_user["honor"]);
				root.userData.user.cashTrainSlot = Convert.ToInt32(dic_user["cashTrainSlot"]);
				root.userData.user.generalMood = Convert.ToInt32(dic_user["generalMood"]);
				root.userData.user.rapidCdEndTime = Convert.ToDouble(dic_user["rapidCdEndTime"]);
				root.userData.user.character = Convert.ToInt32(dic_user["character"]);
				root.userData.user.tavernG = Convert.ToString(dic_user["tavernG"]);
				root.userData.user.tavernCdEndTime_1 = Convert.ToDouble(dic_user["tavernCdEndTime_1"]);
				root.userData.user.tavernCdEndTime_2 = Convert.ToDouble(dic_user["tavernCdEndTime_2"]);
				root.userData.user.tavernCdEndTime_3 = Convert.ToDouble(dic_user["tavernCdEndTime_3"]);
				root.userData.user.tavernCdEndTime_4 = Convert.ToDouble(dic_user["tavernCdEndTime_4"]);
				root.userData.user.tavernTotalP = Convert.ToDouble(dic_user["tavernTotalP"]);
				root.userData.user.guild = Convert.ToInt32(dic_user["guild"]);
				root.userData.user.guildStatus = Convert.ToInt32(dic_user["guildStatus"]);
				root.userData.user.position = Convert.ToInt32(dic_user["position"]);
				root.userData.user.contribute = Convert.ToInt32(dic_user["contribute"]);
				root.userData.user.lastBoonTime = Convert.ToDouble(dic_user["lastBoonTime"]);
				root.userData.user.lastFeedTime = Convert.ToDouble(dic_user["lastFeedTime"]);
				root.userData.user.guildDonate = Convert.ToInt32(dic_user["guildDonate"]);
				root.userData.user.lastDonateTime = Convert.ToDouble(dic_user["lastDonateTime"]);
				root.userData.user.dayContribute = Convert.ToInt32(dic_user["dayContribute"]);
				root.userData.user.lastContributeTime = Convert.ToDouble(dic_user["lastContributeTime"]);
				root.userData.user.markGuildWar = Convert.ToInt32(dic_user["markGuildWar"]);
				root.userData.user.inspire = Convert.ToInt32(dic_user["inspire"]);
				root.userData.user.inspireConsume = Convert.ToInt32(dic_user["inspireConsume"]);
				root.userData.user.increaseContribute = Convert.ToInt32(dic_user["increaseContribute"]);
				root.userData.user.markWarNumber = Convert.ToInt32(dic_user["markWarNumber"]);
				root.userData.user.honorGoodsIds = Convert.ToString(dic_user["honorGoodsIds"]);
				root.userData.user.honorRefreshCdEndTime_1 = Convert.ToDouble(dic_user["honorRefreshCdEndTime_1"]);
				root.userData.user.raceBigAreaId = Convert.ToInt32(dic_user["raceBigAreaId"]);
				root.userData.user.raceBetUserId = Convert.ToInt32(dic_user["raceBetUserId"]);
				root.userData.user.raceBetNumber = Convert.ToInt32(dic_user["raceBetNumber"]);
				root.userData.user.generalCampLevel = Convert.ToInt32(dic_user["generalCampLevel"]);
				root.userData.user.tavernLevel = Convert.ToInt32(dic_user["tavernLevel"]);
				root.userData.user.guildName = Convert.ToString(dic_user["guildName"]);
				root.userData.user.fourImages = Convert.ToInt32(dic_user["fourImages"]);
				root.userData.user.arenaDayWins = Convert.ToInt32(dic_user["arenaDayWins"]);
				root.userData.user.yellowLevel = Convert.ToInt32(dic_user["yellowLevel"]);
				root.userData.user.yearYellow = Convert.ToInt32(dic_user["yearYellow"]);
				root.userData.user.energy = Convert.ToInt32(dic_user["energy"]);
				root.userData.user.maxEnergy = Convert.ToInt32(dic_user["maxEnergy"]);
				root.userData.user.keepLoginDay = Convert.ToInt32(dic_user["keepLoginDay"]);
				root.userData.user.lastGetLoginAwardTime = Convert.ToDouble(dic_user["lastGetLoginAwardTime"]);
				root.userData.user.vipPoint = Convert.ToInt32(dic_user["vipPoint"]);
				root.userData.user.vipEndTime_1 = Convert.ToInt32(dic_user["vipEndTime_1"]);
				root.userData.user.vipLastModify = Convert.ToDouble(dic_user["vipLastModify"]);
				root.userData.user.vipType = Convert.ToInt32(dic_user["vipType"]);
				root.userData.user.bagExpandTimes = Convert.ToInt32(dic_user["bagExpandTimes"]);
				root.userData.user.lastGetFertilizerTime = Convert.ToDouble(dic_user["lastGetFertilizerTime"]);
				root.userData.user.dayVisitEnergy = Convert.ToInt32(dic_user["dayVisitEnergy"]);
				root.userData.user.eventGetNumber = Convert.ToInt32(dic_user["eventGetNumber"]);
				root.userData.user.eventGetTime = Convert.ToDouble(dic_user["eventGetTime"]);
				root.userData.user.eventCdEndTime = Convert.ToDouble(dic_user["eventCdEndTime"]);
				root.userData.user.characterLevel = Convert.ToInt32(dic_user["characterLevel"]);
				root.userData.user.liveness = Convert.ToInt32(dic_user["liveness"]);
				root.userData.user.livenessLastModify = Convert.ToDouble(dic_user["livenessLastModify"]);
				root.userData.user.getLivenessLevels = Convert.ToString(dic_user["getLivenessLevels"]);
				root.userData.user.honorRefreshCdEndTime_2 = Convert.ToDouble(dic_user["honorRefreshCdEndTime_2"]);
				root.userData.user.honorRefreshCdEndTime_3 = Convert.ToDouble(dic_user["honorRefreshCdEndTime_3"]);
				root.userData.user.honorRefreshCdEndTime_4 = Convert.ToDouble(dic_user["honorRefreshCdEndTime_4"]);
				root.userData.user.cas = Convert.ToInt32(dic_user["cas"]);
				root.userData.user.increaseMaxEnergyNum = Convert.ToInt32(dic_user["increaseMaxEnergyNum"]);
				root.userData.user.leaveGuildDate = Convert.ToInt32(dic_user["leaveGuildDate"]);
				root.userData.user.newMailNumber = Convert.ToInt32(dic_user["newMailNumber"]);
				root.userData.user.lastGetMessageTime = Convert.ToDouble(dic_user["lastGetMessageTime"]);
				root.userData.user.historyContribute = Convert.ToInt32(dic_user["historyContribute"]);
				root.userData.user.vipEndTime = Convert.ToDouble(dic_user["vipEndTime"]);
				root.userData.user.lastPayTime = Convert.ToDouble(dic_user["lastPayTime"]);
				root.userData.user.npcLastVisit = Convert.ToDouble(dic_user["npcLastVisit"]);
				root.userData.user.arenaCdEndTime = Convert.ToDouble(dic_user["arenaCdEndTime"]);
				root.userData.user.userInfoLastUpdateTime = Convert.ToDouble(dic_user["userInfoLastUpdateTime"]);
				root.userData.user.qzoneInfoLastUpdateTime = Convert.ToDouble(dic_user["qzoneInfoLastUpdateTime"]);
				root.userData.user.bakName = Convert.ToInt32(dic_user["bakName"]);
				root.userData.user.bakIcon = Convert.ToInt32(dic_user["bakIcon"]);
				root.userData.user.qzoneFriendLastUpdate = Convert.ToDouble(dic_user["qzoneFriendLastUpdate"]);
				root.userData.user.lastTollgateId = Convert.ToInt32(dic_user["lastTollgateId"]);
				root.userData.user.qrjKeepLoginDays = Convert.ToInt32(dic_user["qrjKeepLoginDays"]);
				root.userData.user.arenaLastModify = Convert.ToDouble(dic_user["arenaLastModify"]);
				root.userData.user.consume = Convert.ToInt32(dic_user["consume"]);
				root.userData.user.annouBlack = Convert.ToInt32(dic_user["annouBlack"]);
				root.userData.user.msgBlack = Convert.ToInt32(dic_user["msgBlack"]);
				root.userData.user.generalSpectrumIds = Convert.ToString(dic_user["generalSpectrumIds"]);
				root.userData.user.plantCdEndTime = Convert.ToDouble(dic_user["plantCdEndTime"]);
				root.userData.user.generalSpectrumLevel = Convert.ToInt32(dic_user["generalSpectrumLevel"]);
				root.userData.user.generalSpectrumBuff = Convert.ToInt32(dic_user["generalSpectrumBuff"]);
				root.userData.user.beInvitUid = Convert.ToInt32(dic_user["beInvitUid"]);
				root.userData.user.serverId = Convert.ToInt32(dic_user["serverId"]);
				root.userData.user.poolExpNumber = Convert.ToInt32(dic_user["poolExpNumber"]);
				root.userData.user.lastGetDayTreasureTime = Convert.ToDouble(dic_user["lastGetDayTreasureTime"]);
				root.userData.user.getTreasureVipLevels = Convert.ToString(dic_user["getTreasureVipLevels"]);
				root.userData.user.diamond = Convert.ToInt32(dic_user["diamond"]);
				root.userData.user.regionUid = Convert.ToInt32(dic_user["regionUid"]);
				root.userData.user.announcement = Convert.ToString(dic_user["announcement"]);
				root.userData.user.copyFirstAward = Convert.ToInt32(dic_user["copyFirstAward"]);
				root.userData.user.escortLastRefresh = Convert.ToDouble(dic_user["escortLastRefresh"]);
				root.userData.user.escortIsStart = Convert.ToInt32(dic_user["escortIsStart"]);
				root.userData.user.escortGetPlantTimes = Convert.ToInt32(dic_user["escortGetPlantTimes"]);
				root.userData.user.escortRefreshRobInfoTime = Convert.ToDouble(dic_user["escortRefreshRobInfoTime"]);
				root.userData.user.escortRobTimes = Convert.ToInt32(dic_user["escortRobTimes"]);
				root.userData.user.escortGeneralIds = Convert.ToString(dic_user["escortGeneralIds"]);
				root.userData.user.escortBeginTime = Convert.ToDouble(dic_user["escortBeginTime"]);
				root.userData.user.escortLastRobTime = Convert.ToDouble(dic_user["escortLastRobTime"]);
				root.userData.user.cardLoginTime = Convert.ToInt32(dic_user["cardLoginTime"]);
				root.userData.user.lastGetVipSeed = Convert.ToDouble(dic_user["lastGetVipSeed"]);
				root.userData.user.stargazingTeacherId = Convert.ToInt32(dic_user["stargazingTeacherId"]);
				root.userData.user.stargazingCdEndTime = Convert.ToDouble(dic_user["stargazingCdEndTime"]);
				root.userData.user.stargazingEnergy = Convert.ToInt32(dic_user["stargazingEnergy"]);
				root.userData.user.stargazingLevel = Convert.ToInt32(dic_user["stargazingLevel"]);
				root.userData.user.stargazingVisitTimes = Convert.ToInt32(dic_user["stargazingVisitTimes"]);
				root.userData.user.stargazingVisitLastTime = Convert.ToDouble(dic_user["stargazingVisitLastTime"]);
				root.userData.user.lugNum = Convert.ToInt32(dic_user["lugNum"]);
				root.userData.user.petFight = Convert.ToDouble(dic_user["petFight"]);
				root.userData.user.buyViped = Convert.ToInt32(dic_user["buyViped"]);
				root.userData.user.isReceiveNoviceChest = Convert.ToInt32(dic_user["isReceiveNoviceChest"]);
				root.userData.user.verified_type = Convert.ToInt32(dic_user["verified_type"]);
				root.userData.user.sinaBadge = Convert.ToInt32(dic_user["sinaBadge"]);
				root.userData.user.identity_status = Convert.ToInt32(dic_user["identity_status"]);
				root.userData.user.getSinaBadgeTime = Convert.ToDouble(dic_user["getSinaBadgeTime"]);
				root.userData.user.sinaBadgeIsGetEquip = Convert.ToInt32(dic_user["sinaBadgeIsGetEquip"]);
				root.userData.user.sinaBadgeIsGetGeneralSoul = Convert.ToInt32(dic_user["sinaBadgeIsGetGeneralSoul"]);
				root.userData.user.sinaRecharge = Convert.ToInt32(dic_user["sinaRecharge"]);
				root.userData.user.lotteryNumber = Convert.ToInt32(dic_user["lotteryNumber"]);
				root.userData.user.lotteryResetNumber = Convert.ToInt32(dic_user["lotteryResetNumber"]);
				root.userData.user.spot = Convert.ToInt32(dic_user["spot"]);
				root.userData.user.lotteryPayNumber = Convert.ToInt32(dic_user["lotteryPayNumber"]);
				root.userData.user.lastRobHook = Convert.ToInt32(dic_user["lastRobHook"]);
				root.userData.user.diceExp = Convert.ToInt32(dic_user["diceExp"]);
				root.userData.user.diceSpot = Convert.ToInt32(dic_user["diceSpot"]);
				root.userData.user.lotteryMaxNumber = Convert.ToInt32(dic_user["lotteryMaxNumber"]);
				root.userData.user.lotteryResetMaxNumber = Convert.ToInt32(dic_user["lotteryResetMaxNumber"]);
				root.userData.user.sinaFirstCharge = Convert.ToInt32(dic_user["sinaFirstCharge"]);
				root.userData.user.sinaFirstChargeGetTime = Convert.ToDouble(dic_user["sinaFirstChargeGetTime"]);
				root.userData.user.serverRaceStage3ServerAward = Convert.ToInt32(dic_user["serverRaceStage3ServerAward"]);
				root.userData.user.userRecallTime = Convert.ToDouble(dic_user["userRecallTime"]);
				root.userData.user.awardTime = Convert.ToDouble(dic_user["awardTime"]);
				root.userData.user.skillDot = Convert.ToInt32(dic_user["skillDot"]);
				root.userData.user.leaveUseEnergy = Convert.ToInt32(dic_user["leaveUseEnergy"]);
				root.userData.user.leaveBuyEnergy = Convert.ToInt32(dic_user["leaveBuyEnergy"]);
				
				// userData.userGeneral
				object[] lstUserGeneral = (object[])dic_userData["userGeneral"];
				foreach (object o in lstUserGeneral)
				{
					Dictionary<string, object> dic_gen = (Dictionary<string, object>) o;
					entityUserGeneral ug = new entityUserGeneral();
					ug.uid = Convert.ToInt32(dic_gen["uid"]);
					ug.id = Convert.ToInt32(dic_gen["id"]);
					ug.generalId = Convert.ToInt32(dic_gen["generalId"]);
					ug.generalType = Convert.ToInt32(dic_gen["generalType"]);
					ug.name = Convert.ToString(dic_gen["name"]);
					ug.hp = Convert.ToInt32(dic_gen["hp"]);
					ug.level = Convert.ToInt32(dic_gen["level"]);
					ug.anger = Convert.ToInt32(dic_gen["anger"]);
					ug.str = Convert.ToInt32(dic_gen["str"]);
					ug.intel = Convert.ToInt32(dic_gen["int"]);
					ug.agi = Convert.ToInt32(dic_gen["agi"]);
					ug.vit = Convert.ToInt32(dic_gen["vit"]);
					ug.atk_1 = Convert.ToInt32(dic_gen["atk_1"]);
					ug.def_1 = Convert.ToInt32(dic_gen["def_1"]);
					ug.atk_2 = Convert.ToInt32(dic_gen["atk_2"]);
					ug.def_2 = Convert.ToInt32(dic_gen["def_2"]);
					ug.atk_3 = Convert.ToInt32(dic_gen["atk_3"]);
					ug.def_3 = Convert.ToInt32(dic_gen["def_3"]);
					ug.atk_4 = Convert.ToInt32(dic_gen["atk_4"]);
					ug.def_4 = Convert.ToInt32(dic_gen["def_4"]);
					ug.dodge = Convert.ToInt32(dic_gen["dodge"]);
					ug.hit = Convert.ToInt32(dic_gen["hit"]);
					ug.cri = Convert.ToInt32(dic_gen["cri"]);
					ug.resist = Convert.ToInt32(dic_gen["resist"]);
					ug.pvedr = Convert.ToInt32(dic_gen["pvedr"]);
					ug.pvpdr = Convert.ToInt32(dic_gen["pvpdr"]);
					ug.weapon = Convert.ToInt32(dic_gen["weapon"]);
					ug.armor = Convert.ToInt32(dic_gen["armor"]);
					ug.cloak = Convert.ToInt32(dic_gen["cloak"]);
					ug.belt = Convert.ToInt32(dic_gen["belt"]);
					ug.skillag = Convert.ToInt32(dic_gen["skillag"]);
					ug.skillbg = Convert.ToInt32(dic_gen["skillbg"]);
					ug.new_ndot = Convert.ToInt32(dic_gen["new_ndot"]);
					ug.skillpgo = Convert.ToInt32(dic_gen["skillpgo"]);
					ug.skillpgo_1 = Convert.ToInt32(dic_gen["skillpgo_1"]);
					ug.new_str = Convert.ToInt32(dic_gen["new_str"]);
					ug.new_int = Convert.ToInt32(dic_gen["new_int"]);
					ug.new_agi = Convert.ToInt32(dic_gen["new_agi"]);
					ug.new_vit = Convert.ToInt32(dic_gen["new_vit"]);
					ug.re_task = Convert.ToInt32(dic_gen["re_task"]);
					ug.ndot = Convert.ToInt32(dic_gen["ndot"]);
					ug.exp = Convert.ToInt32(dic_gen["exp"]);
					ug.source = Convert.ToInt32(dic_gen["source"]);
					ug.ct = Convert.ToDouble(dic_gen["ct"]);
					ug.iSkill = Convert.ToInt32(dic_gen["iSkill"]);
					ug.fSkill = Convert.ToInt32(dic_gen["fSkill"]);
					ug.rSkill = Convert.ToInt32(dic_gen["rSkill"]);
					ug.pSkill1 = Convert.ToInt32(dic_gen["pSkill1"]);
					ug.pSkill2 = Convert.ToInt32(dic_gen["pSkill2"]);
					ug.pSkill3 = Convert.ToInt32(dic_gen["pSkill3"]);
					ug.pSkill4 = Convert.ToInt32(dic_gen["pSkill4"]);
					ug.pSkill5 = Convert.ToInt32(dic_gen["pSkill5"]);
					ug.pSkill6 = Convert.ToInt32(dic_gen["pSkill6"]);
					ug.pSkill7 = Convert.ToInt32(dic_gen["pSkill7"]);
					ug.pSkill8 = Convert.ToInt32(dic_gen["pSkill8"]);
					ug.quality = Convert.ToInt32(dic_gen["quality"]);
					ug.breakLevel = Convert.ToInt32(dic_gen["breakLevel"]);
					ug.iSkillList = Convert.ToString(dic_gen["iSkillList"]);
					ug.fSkillList = Convert.ToString(dic_gen["fSkillList"]);
					ug.rSkillList = Convert.ToString(dic_gen["rSkillList"]);
					ug.spotLevel = Convert.ToInt32(dic_gen["spotLevel"]);
					ug.hat = Convert.ToInt32(dic_gen["hat"]);
					ug.ring = Convert.ToInt32(dic_gen["ring"]);
					ug.necklace = Convert.ToInt32(dic_gen["necklace"]);
					ug.gloves = Convert.ToInt32(dic_gen["gloves"]);
					ug.avatar = Convert.ToInt32(dic_gen["avatar"]);
					root.userData.userGeneral.Add(ug);
				}
				
				// userData.userItem
				object[] lstUserItem = (object[])dic_userData["userItem"];
				foreach (object o in lstUserItem)
				{
					Dictionary<string, object> dic_item = (Dictionary<string, object>) o;
					entityUserItem ui = new entityUserItem();
					ui.categoryId = Convert.ToInt32(dic_item["categoryId"]);
					ui.typeId = Convert.ToInt32(dic_item["typeId"]);
					ui.number = Convert.ToInt32(dic_item["number"]);
					root.userData.userItem.Add(ui);
				}
				
				// userData.userEquip
				object[] lstUserEquip = (object[])dic_userData["userEquip"];
				foreach (object o in lstUserEquip)
				{
					Dictionary<string, object> dic_equip = (Dictionary<string, object>) o;
					entityUserEquip ue = new entityUserEquip();
					ue.id = Convert.ToInt32(dic_equip["id"]);
					ue.generalId = Convert.ToInt32(dic_equip["generalId"]);
					ue.typeId = Convert.ToInt32(dic_equip["typeId"]);
					ue.strTimes = Convert.ToInt32(dic_equip["strTimes"]);
					ue.attrValue = Convert.ToInt32(dic_equip["attrValue"]);
					ue.lastStrength = Convert.ToDouble(dic_equip["lastStrength"]);
					ue.slot1 = Convert.ToInt32(dic_equip["slot1"]);
					ue.slot2 = Convert.ToInt32(dic_equip["slot2"]);
					ue.slot3 = Convert.ToInt32(dic_equip["slot3"]);
					ue.atk_1 = Convert.ToInt32(dic_equip["atk_1"]);
					ue.atk_2 = Convert.ToInt32(dic_equip["atk_2"]);
					ue.atk_4 = Convert.ToInt32(dic_equip["atk_4"]);
					ue.atk_3 = Convert.ToInt32(dic_equip["atk_3"]);
					ue.def_1 = Convert.ToInt32(dic_equip["def_1"]);
					ue.def_2 = Convert.ToInt32(dic_equip["def_2"]);
					ue.def_4 = Convert.ToInt32(dic_equip["def_4"]);
					ue.def_3 = Convert.ToInt32(dic_equip["def_3"]);
					ue.hp = Convert.ToInt32(dic_equip["hp"]);
					root.userData.userEquip.Add(ue);
				}
				
				// userData.userFormation
				object[] lstUserFormation = (object[])dic_userData["userFormation"];
				foreach (object o in lstUserFormation)
				{
					Dictionary<string, object> dic_userFmt = (Dictionary<string, object>) o;
					entityUserFormation uf = new entityUserFormation();
					uf.id = Convert.ToInt32(dic_userFmt["id"]);
					uf.level = Convert.ToInt32(dic_userFmt["level"]);
					uf.unlockGrid = Convert.ToString(dic_userFmt["unlockGrid"]);
					root.userData.userFormation.Add(uf);
				}
				
				// userData.feedstoryovi
				root.userData.feedstoryovi = Convert.ToInt32(dic_userData["feedstoryovi"]);
				
				// userData.userFriend
				object[] lstUserFriend = (object[])dic_userData["userFriend"];
				foreach (object o in lstUserFriend)
				{
					Dictionary<string, object> dic_userFriend = (Dictionary<string, object>) o;
					entityUserFriend uf = new entityUserFriend();
					uf.id = Convert.ToString(dic_userFriend["id"]);
					uf.name = Convert.ToString(dic_userFriend["name"]);
					uf.icon = Convert.ToString(dic_userFriend["icon"]);
					uf.sex = Convert.ToInt32(dic_userFriend["sex"]);
					uf.birthday = Convert.ToString(dic_userFriend["birthday"]);
					uf.yellowLevel = Convert.ToInt32(dic_userFriend["yellowLevel"]);
					uf.yearYellow = Convert.ToInt32(dic_userFriend["yearYellow"]);
					uf.level = Convert.ToInt32(dic_userFriend["level"]);
					uf.lastModify = Convert.ToDouble(dic_userFriend["lastModify"]);
					uf.vipPoint = Convert.ToInt32(dic_userFriend["vipPoint"]);
					uf.lastVisited = Convert.ToDouble(dic_userFriend["lastVisited"]);
					uf.dayOperateTimes = Convert.ToInt32(dic_userFriend["dayOperateTimes"]);
					uf.lastOperateTime = Convert.ToInt32(dic_userFriend["lastOperateTime"]);
					uf.maxSceneId = Convert.ToInt32(dic_userFriend["maxSceneId"]);
					uf.nEvent = Convert.ToInt32(dic_userFriend["event"]);
					uf.eventTime = Convert.ToDouble(dic_userFriend["eventTime"]);
					uf.fourImages = Convert.ToInt32(dic_userFriend["fourImages"]);
					uf.guild = Convert.ToInt32(dic_userFriend["guild"]);
					uf.guildName = Convert.ToString(dic_userFriend["guildName"]);
					uf.vipLevel = Convert.ToInt32(dic_userFriend["vipLevel"]);
					uf.guildIcon = Convert.ToString(dic_userFriend["guildIcon"]);
					uf.guildLevel = Convert.ToInt32(dic_userFriend["guildLevel"]);
					uf.qzoneName = Convert.ToInt32(dic_userFriend["qzoneName"]);
					uf.qzoneIcon = Convert.ToInt32(dic_userFriend["qzoneIcon"]);
					uf.isQzone = Convert.ToInt32(dic_userFriend["isQzone"]);
					uf.isOther = Convert.ToInt32(dic_userFriend["isOther"]);
					uf.lastLoginTime = Convert.ToDouble(dic_userFriend["lastLoginTime"]);
					uf.tech2Level = Convert.ToInt32(dic_userFriend["tech2Level"]);
					uf.lastGiftTime = Convert.ToDouble(dic_userFriend["lastGiftTime"]);
					uf.attention = Convert.ToInt32(dic_userFriend["attention"]);
					uf.sid = Convert.ToString(dic_userFriend["sid"]);
					uf.serverId = Convert.ToInt32(dic_userFriend["serverId"]);
					uf.dayGifted = Convert.ToInt32(dic_userFriend["dayGifted"]);
					uf.verified_type = Convert.ToInt32(dic_userFriend["verified_type"]);
					uf.threeRacing = Convert.ToInt32(dic_userFriend["threeRacing"]);
					uf.fightLevel = Convert.ToInt32(dic_userFriend["fightLevel"]);
					root.userData.userFriend.Add(uf);
				}
				
				// userData.userEnemy
				object[] lstUserEnemy = (object[])dic_userData["userEnemy"];
				foreach (object o in lstUserEnemy)
				{
					Dictionary<string, object> dic_userEnmy = (Dictionary<string, object>) o;
					entityUserEnemy ue = new entityUserEnemy();
					ue.id = Convert.ToString(dic_userEnmy["id"]);
					ue.name = Convert.ToString(dic_userEnmy["name"]);
					ue.icon = Convert.ToString(dic_userEnmy["icon"]);
					ue.sex = Convert.ToInt32(dic_userEnmy["sex"]);
					ue.birthday = Convert.ToString(dic_userEnmy["birthday"]);
					ue.level = Convert.ToInt32(dic_userEnmy["level"]);
					ue.guildName = Convert.ToString(dic_userEnmy["guildName"]);
					ue.vipLevel = Convert.ToInt32(dic_userEnmy["vipLevel"]);
					ue.guildIcon = Convert.ToString(dic_userEnmy["guildIcon"]);
					ue.guildLevel = Convert.ToInt32(dic_userEnmy["guildLevel"]);
					ue.qzoneName = Convert.ToInt32(dic_userEnmy["qzoneName"]);
					ue.qzoneIcon = Convert.ToInt32(dic_userEnmy["qzoneIcon"]);
					ue.isQzone = Convert.ToInt32(dic_userEnmy["isQzone"]);
					ue.isOther = Convert.ToInt32(dic_userEnmy["isOther"]);
					ue.tech2Level = Convert.ToInt32(dic_userEnmy["tech2Level"]);
					ue.attention = Convert.ToInt32(dic_userEnmy["attention"]);
					ue.hatred = Convert.ToInt32(dic_userEnmy["hatred"]);
					ue.lasthatredTime = Convert.ToDouble(dic_userEnmy["lasthatredTime"]);
					ue.serverId = Convert.ToInt32(dic_userEnmy["serverId"]);
					root.userData.userEnemy.Add(ue);
				}
			}
			catch (Exception e)
			{
				upCall.DebugLog(e.StackTrace);
			}
		}
	}
}
