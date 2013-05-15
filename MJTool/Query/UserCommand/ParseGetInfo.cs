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
			for (int i = 1; i < bs_result.Length; i++)
			{
				lst_byte_res.Add(bs_result[i]);
			}

			try
			{
				byte[] b_res = lst_byte_res.ToArray();
				Dictionary<string, object> dic_root = QueryManager.AMF_Deserializer<Dictionary<string, object>>(b_res, b_res.Length);
				
				root.userData.Clear();
				object[] arr_obj = null;
				
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
				
				// userData.user
				if (dic_userData.ContainsKey("user"))
				{
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
				}
				
				// userData.userGeneral
				if (dic_userData.ContainsKey("userGeneral"))
				{
					arr_obj = (object[])dic_userData["userGeneral"];
					foreach (object o in arr_obj)
					{
						Dictionary<string, object> dic = (Dictionary<string, object>) o;
						entityUserGeneral ent = new entityUserGeneral();
						ent.uid = Convert.ToInt32(dic["uid"]);
						ent.id = Convert.ToInt32(dic["id"]);
						ent.generalId = Convert.ToInt32(dic["generalId"]);
						ent.generalType = Convert.ToInt32(dic["generalType"]);
						ent.name = Convert.ToString(dic["name"]);
						ent.hp = Convert.ToInt32(dic["hp"]);
						ent.level = Convert.ToInt32(dic["level"]);
						ent.anger = Convert.ToInt32(dic["anger"]);
						ent.str = Convert.ToInt32(dic["str"]);
						ent.intel = Convert.ToInt32(dic["int"]);
						ent.agi = Convert.ToInt32(dic["agi"]);
						ent.vit = Convert.ToInt32(dic["vit"]);
						ent.atk_1 = Convert.ToInt32(dic["atk_1"]);
						ent.def_1 = Convert.ToInt32(dic["def_1"]);
						ent.atk_2 = Convert.ToInt32(dic["atk_2"]);
						ent.def_2 = Convert.ToInt32(dic["def_2"]);
						ent.atk_3 = Convert.ToInt32(dic["atk_3"]);
						ent.def_3 = Convert.ToInt32(dic["def_3"]);
						ent.atk_4 = Convert.ToInt32(dic["atk_4"]);
						ent.def_4 = Convert.ToInt32(dic["def_4"]);
						ent.dodge = Convert.ToInt32(dic["dodge"]);
						ent.hit = Convert.ToInt32(dic["hit"]);
						ent.cri = Convert.ToInt32(dic["cri"]);
						ent.resist = Convert.ToInt32(dic["resist"]);
						ent.pvedr = Convert.ToInt32(dic["pvedr"]);
						ent.pvpdr = Convert.ToInt32(dic["pvpdr"]);
						ent.weapon = Convert.ToInt32(dic["weapon"]);
						ent.armor = Convert.ToInt32(dic["armor"]);
						ent.cloak = Convert.ToInt32(dic["cloak"]);
						ent.belt = Convert.ToInt32(dic["belt"]);
						ent.skillag = Convert.ToInt32(dic["skillag"]);
						ent.skillbg = Convert.ToInt32(dic["skillbg"]);
						ent.new_ndot = Convert.ToInt32(dic["new_ndot"]);
						ent.skillpgo = Convert.ToInt32(dic["skillpgo"]);
						ent.skillpgo_1 = Convert.ToInt32(dic["skillpgo_1"]);
						ent.new_str = Convert.ToInt32(dic["new_str"]);
						ent.new_int = Convert.ToInt32(dic["new_int"]);
						ent.new_agi = Convert.ToInt32(dic["new_agi"]);
						ent.new_vit = Convert.ToInt32(dic["new_vit"]);
						ent.re_task = Convert.ToInt32(dic["re_task"]);
						ent.ndot = Convert.ToInt32(dic["ndot"]);
						ent.exp = Convert.ToInt32(dic["exp"]);
						ent.source = Convert.ToInt32(dic["source"]);
						ent.ct = Convert.ToDouble(dic["ct"]);
						ent.iSkill = Convert.ToInt32(dic["iSkill"]);
						ent.fSkill = Convert.ToInt32(dic["fSkill"]);
						ent.rSkill = Convert.ToInt32(dic["rSkill"]);
						ent.pSkill1 = Convert.ToInt32(dic["pSkill1"]);
						ent.pSkill2 = Convert.ToInt32(dic["pSkill2"]);
						ent.pSkill3 = Convert.ToInt32(dic["pSkill3"]);
						ent.pSkill4 = Convert.ToInt32(dic["pSkill4"]);
						ent.pSkill5 = Convert.ToInt32(dic["pSkill5"]);
						ent.pSkill6 = Convert.ToInt32(dic["pSkill6"]);
						ent.pSkill7 = Convert.ToInt32(dic["pSkill7"]);
						ent.pSkill8 = Convert.ToInt32(dic["pSkill8"]);
						ent.quality = Convert.ToInt32(dic["quality"]);
						ent.breakLevel = Convert.ToInt32(dic["breakLevel"]);
						ent.iSkillList = Convert.ToString(dic["iSkillList"]);
						ent.fSkillList = Convert.ToString(dic["fSkillList"]);
						ent.rSkillList = Convert.ToString(dic["rSkillList"]);
						ent.spotLevel = Convert.ToInt32(dic["spotLevel"]);
						ent.hat = Convert.ToInt32(dic["hat"]);
						ent.ring = Convert.ToInt32(dic["ring"]);
						ent.necklace = Convert.ToInt32(dic["necklace"]);
						ent.gloves = Convert.ToInt32(dic["gloves"]);
						ent.avatar = Convert.ToInt32(dic["avatar"]);
						root.userData.userGeneral.Add(ent);
					}
				}
				
				// userData.userItem
				if (dic_userData.ContainsKey("userItem"))
				{
					arr_obj = (object[])dic_userData["userItem"];
					foreach (object o in arr_obj)
					{
						Dictionary<string, object> dic = (Dictionary<string, object>) o;
						entityUserItem ent = new entityUserItem();
						ent.categoryId = Convert.ToInt32(dic["categoryId"]);
						ent.typeId = Convert.ToInt32(dic["typeId"]);
						ent.number = Convert.ToInt32(dic["number"]);
						root.userData.userItem.Add(ent);
					}
				}
				
				// userData.userEquip
				if (dic_userData.ContainsKey("userEquip"))
				{
					arr_obj = (object[])dic_userData["userEquip"];
					foreach (object o in arr_obj)
					{
						Dictionary<string, object> dic = (Dictionary<string, object>) o;
						entityUserEquip ent = new entityUserEquip();
						ent.id = Convert.ToInt32(dic["id"]);
						ent.generalId = Convert.ToInt32(dic["generalId"]);
						ent.typeId = Convert.ToInt32(dic["typeId"]);
						ent.strTimes = Convert.ToInt32(dic["strTimes"]);
						ent.attrValue = Convert.ToInt32(dic["attrValue"]);
						ent.lastStrength = Convert.ToDouble(dic["lastStrength"]);
						ent.slot1 = Convert.ToInt32(dic["slot1"]);
						ent.slot2 = Convert.ToInt32(dic["slot2"]);
						ent.slot3 = Convert.ToInt32(dic["slot3"]);
						ent.atk_1 = Convert.ToInt32(dic["atk_1"]);
						ent.atk_2 = Convert.ToInt32(dic["atk_2"]);
						ent.atk_4 = Convert.ToInt32(dic["atk_4"]);
						ent.atk_3 = Convert.ToInt32(dic["atk_3"]);
						ent.def_1 = Convert.ToInt32(dic["def_1"]);
						ent.def_2 = Convert.ToInt32(dic["def_2"]);
						ent.def_4 = Convert.ToInt32(dic["def_4"]);
						ent.def_3 = Convert.ToInt32(dic["def_3"]);
						ent.hp = Convert.ToInt32(dic["hp"]);
						root.userData.userEquip.Add(ent);
					}
				}
				
				// userData.userFormation
				if (dic_userData.ContainsKey("userFormation"))
				{
					arr_obj = (object[])dic_userData["userFormation"];
					foreach (object o in arr_obj)
					{
						Dictionary<string, object> dic = (Dictionary<string, object>) o;
						entityUserFormation ent = new entityUserFormation();
						ent.id = Convert.ToInt32(dic["id"]);
						ent.level = Convert.ToInt32(dic["level"]);
						ent.unlockGrid = Convert.ToString(dic["unlockGrid"]);
						root.userData.userFormation.Add(ent);
					}
				}
				
				// userData.feedstoryovi
				if (dic_userData.ContainsKey("feedstoryovi"))
				{
					root.userData.feedstoryovi = Convert.ToInt32(dic_userData["feedstoryovi"]);
				}
				
				// userData.userFriend
				if (dic_userData.ContainsKey("userFriend"))
				{
					arr_obj = (object[])dic_userData["userFriend"];
					foreach (object o in arr_obj)
					{
						Dictionary<string, object> dic = (Dictionary<string, object>) o;
						entityUserFriend ent = new entityUserFriend();
						ent.id = Convert.ToString(dic["id"]);
						ent.name = Convert.ToString(dic["name"]);
						ent.icon = Convert.ToString(dic["icon"]);
						ent.sex = Convert.ToInt32(dic["sex"]);
						ent.birthday = Convert.ToString(dic["birthday"]);
						ent.yellowLevel = Convert.ToInt32(dic["yellowLevel"]);
						ent.yearYellow = Convert.ToInt32(dic["yearYellow"]);
						ent.level = Convert.ToInt32(dic["level"]);
						ent.lastModify = Convert.ToDouble(dic["lastModify"]);
						ent.vipPoint = Convert.ToInt32(dic["vipPoint"]);
						ent.lastVisited = Convert.ToDouble(dic["lastVisited"]);
						ent.dayOperateTimes = Convert.ToInt32(dic["dayOperateTimes"]);
						ent.lastOperateTime = Convert.ToInt32(dic["lastOperateTime"]);
						ent.maxSceneId = Convert.ToInt32(dic["maxSceneId"]);
						ent.nEvent = Convert.ToInt32(dic["event"]);
						ent.eventTime = Convert.ToDouble(dic["eventTime"]);
						ent.fourImages = Convert.ToInt32(dic["fourImages"]);
						ent.guild = Convert.ToInt32(dic["guild"]);
						ent.guildName = Convert.ToString(dic["guildName"]);
						ent.vipLevel = Convert.ToInt32(dic["vipLevel"]);
						ent.guildIcon = Convert.ToString(dic["guildIcon"]);
						ent.guildLevel = Convert.ToInt32(dic["guildLevel"]);
						ent.qzoneName = Convert.ToInt32(dic["qzoneName"]);
						ent.qzoneIcon = Convert.ToInt32(dic["qzoneIcon"]);
						ent.isQzone = Convert.ToInt32(dic["isQzone"]);
						ent.isOther = Convert.ToInt32(dic["isOther"]);
						ent.lastLoginTime = Convert.ToDouble(dic["lastLoginTime"]);
						ent.tech2Level = Convert.ToInt32(dic["tech2Level"]);
						ent.lastGiftTime = Convert.ToDouble(dic["lastGiftTime"]);
						ent.attention = Convert.ToInt32(dic["attention"]);
						ent.sid = Convert.ToString(dic["sid"]);
						ent.serverId = Convert.ToInt32(dic["serverId"]);
						ent.dayGifted = Convert.ToInt32(dic["dayGifted"]);
						ent.verified_type = Convert.ToInt32(dic["verified_type"]);
						ent.threeRacing = Convert.ToInt32(dic["threeRacing"]);
						ent.fightLevel = Convert.ToInt32(dic["fightLevel"]);
						root.userData.userFriend.Add(ent);
					}
				}
				
				// userData.userEnemy
				if (dic_userData.ContainsKey("userEnemy"))
				{
					arr_obj = (object[])dic_userData["userEnemy"];
					foreach (object o in arr_obj)
					{
						Dictionary<string, object> dic = (Dictionary<string, object>) o;
						entityUserEnemy ent = new entityUserEnemy();
						ent.id = Convert.ToString(dic["id"]);
						ent.name = Convert.ToString(dic["name"]);
						ent.icon = Convert.ToString(dic["icon"]);
						ent.sex = Convert.ToInt32(dic["sex"]);
						ent.birthday = Convert.ToString(dic["birthday"]);
						ent.level = Convert.ToInt32(dic["level"]);
						ent.guildName = Convert.ToString(dic["guildName"]);
						ent.vipLevel = Convert.ToInt32(dic["vipLevel"]);
						ent.guildIcon = Convert.ToString(dic["guildIcon"]);
						ent.guildLevel = Convert.ToInt32(dic["guildLevel"]);
						ent.qzoneName = Convert.ToInt32(dic["qzoneName"]);
						ent.qzoneIcon = Convert.ToInt32(dic["qzoneIcon"]);
						ent.isQzone = Convert.ToInt32(dic["isQzone"]);
						ent.isOther = Convert.ToInt32(dic["isOther"]);
						ent.tech2Level = Convert.ToInt32(dic["tech2Level"]);
						ent.attention = Convert.ToInt32(dic["attention"]);
						ent.hatred = Convert.ToInt32(dic["hatred"]);
						ent.lasthatredTime = Convert.ToDouble(dic["lasthatredTime"]);
						ent.serverId = Convert.ToInt32(dic["serverId"]);
						root.userData.userEnemy.Add(ent);
					}
				}
				
				// userData.userBuff
				if (dic_userData.ContainsKey("userBuff"))
				{
					arr_obj = (object[])dic_userData["userBuff"];
				}
				
				// userData.userGuildFriend
				if (dic_userData.ContainsKey("userGuildFriend"))
				{
					arr_obj = (object[])dic_userData["userGuildFriend"];
				}
				
				// userData.userEmployNpc
				if (dic_userData.ContainsKey("userEmployNpc"))
				{
					arr_obj = (object[])dic_userData["userEmployNpc"];
				}
				
				// userData.userPlant
				if (dic_userData.ContainsKey("userPlant"))
				{
					arr_obj = (object[])dic_userData["userPlant"];
				}
				
				// userData.userRace
				if (dic_userData.ContainsKey("userRace"))
				{
					arr_obj = (object[])dic_userData["userRace"];
				}
				
				// userData.lastUserRace
				if (dic_userData.ContainsKey("lastUserRace"))
				{
					arr_obj = (object[])dic_userData["lastUserRace"];
				}
				
				// userData.userTrain
				if (dic_userData.ContainsKey("userTrain"))
				{
					arr_obj = (object[])dic_userData["userTrain"];
				}
				
				// userData.userArena
				if (dic_userData.ContainsKey("userArena"))
				{
					arr_obj = (object[])dic_userData["userArena"];
				}
				
				// userData.userSoul
				if (dic_userData.ContainsKey("userSoul"))
				{
					arr_obj = (object[])dic_userData["userSoul"];
				}
				
				// userData.userTavern
				if (dic_userData.ContainsKey("userTavern"))
				{
					Dictionary<string, object> dic_userTavern = (Dictionary<string, object>)dic_userData["userTavern"];
				}
				
				// userData.userFormationGeneral
				if (dic_userData.ContainsKey("userFormationGeneral"))
				{
					arr_obj = (object[])dic_userData["userFormationGeneral"];
				}
				
				// userData.userDefend
				if (dic_userData.ContainsKey("userDefend"))
				{
					Dictionary<string, object> dic_userDefend = (Dictionary<string, object>)dic_userData["userDefend"];
				}
				
				// userData.userTower
				if (dic_userData.ContainsKey("userTower"))
				{
					Dictionary<string, object> dic_userTower = (Dictionary<string, object>)dic_userData["userTower"];
				}
				
				// userData.userScene
				if (dic_userData.ContainsKey("userScene"))
				{
					arr_obj = (object[])dic_userData["userScene"];
				}
				
				// userData.userTotem
				if (dic_userData.ContainsKey("userTotem"))
				{
					arr_obj = (object[])dic_userData["userTotem"];
				}
				
				// userData.userUnlock
				if (dic_userData.ContainsKey("userUnlock"))
				{
					arr_obj = (object[])dic_userData["userUnlock"];
				}
				
				// userData.activityInfo
				if (dic_userData.ContainsKey("activityInfo"))
				{
					Dictionary<string, object> dic_activityInfo = (Dictionary<string, object>)dic_userData["activityInfo"];
				}
				
				// userData.activitySendInfo
				if (dic_userData.ContainsKey("activitySendInfo"))
				{
					Dictionary<string, object> dic_activitySendInfo = (Dictionary<string, object>)dic_userData["activitySendInfo"];
				}
				
				// userData.guild
				if (dic_userData.ContainsKey("guild"))
				{
					Dictionary<string, object> dic_guild = (Dictionary<string, object>)dic_userData["guild"];
				}
				
				// userData.warTally
				if (dic_userData.ContainsKey("warTally"))
				{
					root.userData.warTally = Convert.ToInt32(dic_userData["warTally"]);
				}
				
				
				
				// userData.VipShadowWin
				if (dic_userData.ContainsKey("VipShadowWin"))
				{
					arr_obj = (object[])dic_userData["VipShadowWin"];
					foreach (object o in arr_obj)
					{
						int ent = Convert.ToInt32(o);
						root.userData.VipShadowWin.Add(ent);
					}
				}
				
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
	}
}
