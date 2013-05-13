/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2013-5-13
 * 时间: 15:04
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace MJTool
{
	/// <summary>
	/// Description of UserRoot.
	/// </summary>
	public class UserRoot
	{
		public double serverTime;
		public UserData userData = new UserData();
	}
	
	public class UserData
	{
		public Dictionary<string, entityUserSend> userSendFeed = new Dictionary<string, entityUserSend>();
		public int msgBoxNum;
		public entityUser user = new entityUser();
		public List<entityUserGeneral> userGeneral = new List<entityUserGeneral>();
		public List<entityUserItem> userItem = new List<entityUserItem>();
		public List<entityUserEquip> userEquip = new List<entityUserEquip>();
		
		public void Clear()
		{
			userSendFeed.Clear();
			userGeneral.Clear();
			userItem.Clear();
			userEquip.Clear();
		}
	}
	
	public class entityUserSend
	{
		public int id;
		public int num;
		public double ct;
	}
	
	public class entityUser
	{
		public int id;
		public string name;
		public int sex;
		public string birthday;
		public string icon;
		public int level;
		public int exp;
		public int gold;
		public int cash;
		public int luck;
		public int luckTrend;
		public double luckModify;
		public double cdEndTime;
		public int cdTrend;
		public int smithLevel;
		public int maxFriendNum;
		public double friendLastUpdate;
		public double lastModify;
		public double registerTime;
		public int finishGuide;
		public int apiPermission;
		public string userSign;
		public int vouch_cash;
		public double lastLoginTime;
		public int increaseId;
		public int tollgateFormation;
		public int itemNum;
		public int unlockItemNum;
		public int masterGeneral;
		public int generalNum;
		public string tavernP;
		public int towerFormation;
		public int defendFormation;
		public int arenaFormation;
		public int raceFormation;
		public int leagueFormation;
		public int fightPower;
		public int honor;
		public int cashTrainSlot;
		public int generalMood;
		public double rapidCdEndTime;
		public int character;
		public string tavernG;
		public double tavernCdEndTime_1;
		public double tavernCdEndTime_2;
		public double tavernCdEndTime_3;
		public double tavernCdEndTime_4;
		public double tavernTotalP;
		public int guild;
		public int guildStatus;
		public int position;
		public int contribute;
		public double lastBoonTime;
		public double lastFeedTime;
		public int guildDonate;
		public double lastDonateTime;
		public int dayContribute;
		public int lastContributeTime;
		public int markGuildWar;
		public int inspire;
		public int inspireConsume;
		public int increaseContribute;
		public int markWarNumber;
		public string honorGoodsIds;
		public double honorRefreshCdEndTime_1;
		public int raceBigAreaId;
		public int raceBetUserId;
		public int raceBetNumber;
		public int generalCampLevel;
		public int tavernLevel;
		public string guildName;
		public int fourImages;
		public int arenaDayWins;
		public int yellowLevel;
		public int yearYellow;
		public int energy;
		public int maxEnergy;
		public int keepLoginDay;
		public double lastGetLoginAwardTime;
		public int vipPoint;
		public int vipEndTime_1;
		public double vipLastModify;
		public int vipType;
		public int bagExpandTimes;
		public double lastGetFertilizerTime;
		public int dayVisitEnergy;
		public int eventGetNumber;
		public double eventGetTime;
		public int eventCdEndTime;
		public int characterLevel;
		public int liveness;
		public double livenessLastModify;
		public string getLivenessLevels;
		public double honorRefreshCdEndTime_2;
		public double honorRefreshCdEndTime_3;
		public double honorRefreshCdEndTime_4;
		public int cas;
		public int increaseMaxEnergyNum;
		public int leaveGuildDate;
		public int newMailNumber;
		public double lastGetMessageTime;
		public int historyContribute;
		public int vipEndTime;
		public int lastPayTime;
		public double npcLastVisit;
		public double arenaCdEndTime;
		public double userInfoLastUpdateTime;
		public int qzoneInfoLastUpdateTime;
		public int bakName;
		public int bakIcon;
		public int qzoneFriendLastUpdate;
		public int lastTollgateId;
		public int qrjKeepLoginDays;
		public double arenaLastModify;
		public int consume;
		public int annouBlack;
		public int msgBlack;
		public string generalSpectrumIds;
		public double plantCdEndTime;
		public int generalSpectrumLevel;
		public int generalSpectrumBuff;
		public int beInvitUid;
		public int serverId;
		public int poolExpNumber;
		public double lastGetDayTreasureTime;
		public string getTreasureVipLevels;
		public int diamond;
		public int regionUid;
		public string announcement;
		public int copyFirstAward;
		public double escortLastRefresh;
		public int escortIsStart;
		public int escortGetPlantTimes;
		public double escortRefreshRobInfoTime;
		public int escortRobTimes;
		public string escortGeneralIds;
		public double escortBeginTime;
		public double escortLastRobTime;
		public int cardLoginTime;
		public double lastGetVipSeed;
		public int stargazingTeacherId;
		public double stargazingCdEndTime;
		public int stargazingEnergy;
		public int stargazingLevel;
		public int stargazingVisitTimes;
		public int stargazingVisitLastTime;
		public int lugNum;
		public double petFight;
		public int buyViped;
		public int isReceiveNoviceChest;
		public int verified_type;
		public int sinaBadge;
		public int identity_status;
		public double getSinaBadgeTime;
		public int sinaBadgeIsGetEquip;
		public int sinaBadgeIsGetGeneralSoul;
		public int sinaRecharge;
		public int lotteryNumber;
		public int lotteryResetNumber;
		public int spot;
		public int lotteryPayNumber;
		public int lastRobHook;
		public int diceExp;
		public int diceSpot;
		public int lotteryMaxNumber;
		public int lotteryResetMaxNumber;
		public int sinaFirstCharge;
		public int sinaFirstChargeGetTime;
		public int serverRaceStage3ServerAward;
		public double userRecallTime;
		public int awardTime;
		public int skillDot;
		public int leaveUseEnergy;
		public int leaveBuyEnergy;
	}
	
	public class entityUserGeneral
	{
		public int uid;
		public int id;
		public int generalId;
		public int generalType;
		public string name;
		public int hp;
		public int level;
		public int anger;
		public int str;
		public int intel;
		public int agi;
		public int vit;
		public int atk_1;
		public int def_1;
		public int atk_2;
		public int def_2;
		public int atk_3;
		public int def_3;
		public int atk_4;
		public int def_4;
		public int dodge;
		public int hit;
		public int cri;
		public int resist;
		public int pvedr;
		public int pvpdr;
		public int weapon;
		public int armor;
		public int cloak;
		public int belt;
		public int skillag;
		public int skillbg;
		public int new_ndot;
		public int skillpgo;
		public int skillpgo_1;
		public int new_str;
		public int new_int;
		public int new_agi;
		public int new_vit;
		public int re_task;
		public int ndot;
		public int exp;
		public int source;
		public double ct;
		public int iSkill;
		public int fSkill;
		public int rSkill;
		public int pSkill1;
		public int pSkill2;
		public int pSkill3;
		public int pSkill4;
		public int pSkill5;
		public int pSkill6;
		public int pSkill7;
		public int pSkill8;
		public int quality;
		public int breakLevel;
		public string iSkillList;
		public string fSkillList;
		public string rSkillList;
		public int spotLevel;
		public int hat;
		public int ring;
		public int necklace;
		public int gloves;
		public int avatar;
	}
	
	public class entityUserItem
	{
		public int categoryId;
		public int typeId;
		public int number;
	}
	
	public class entityUserEquip
	{
		public int id;
		public int generalId;
		public int typeId;
		public int strTimes;
		public int attrValue;
		public double lastStrength;
		public int slot1;
		public int slot2;
		public int slot3;
		public int atk_1;
		public int atk_2;
		public int atk_4;
		public int atk_3;
		public int def_1;
		public int def_2;
		public int def_4;
		public int def_3;
		public int hp;
	}
}
