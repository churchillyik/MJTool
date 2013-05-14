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
		public List<entityUserFormation> userFormation = new List<entityUserFormation>();
		public int feedstoryovi;
		public List<entityUserFriend> userFriend = new List<entityUserFriend>();
		public List<entityUserEnemy> userEnemy = new List<entityUserEnemy>();
		public List<entityUserEmployNpc> userEmployNpc = new List<entityUserEmployNpc>();
		public List<entityUserPlant> userPlant = new List<entityUserPlant>();
		public List<entityUserRace> userRace = new List<entityUserRace>();
		public List<entityLastUserRace> lastUserRace = new List<entityLastUserRace>();
		public List<entityUserTrain> userTrain = new List<entityUserTrain>();
		public List<entityUserArena> userArena = new List<entityUserArena>();
		public List<entityUserSoul> userSoul = new List<entityUserSoul>();
		public entityUserTavern userTavern = new entityUserTavern();
		public List<entityUserFormationGeneral> userFormationGeneral = new List<entityUserFormationGeneral>();
		public entityUserDefend userDefend = new entityUserDefend();
		public entityUserTower userTower = new entityUserTower();
		public List<entityUserScene> userScene = new List<entityUserScene>();
		public List<entityUserTotem> userTotem = new List<entityUserTotem>();
		public List<entityUserUnlock> userUnlock = new List<entityUserUnlock>();
		public entityActivityInfo activityInfo = new entityActivityInfo();
		public entityActivitySendInfo activitySendInfo = new entityActivitySendInfo();
		
		public int warTally;
		public List<entityUserMission> userMission = new List<entityUserMission>();
		public List<entityUserLivenessEvent> userLivenessEvent = new List<entityUserLivenessEvent>();
		public entityUserTimeAward userTimeAward = new entityUserTimeAward();
		public entityUserSevenDayAward userSevenDayAward = new entityUserSevenDayAward();
		public entityUserYellow userYellow = new entityUserYellow();
		public List<entityUserOccupyTotem> userOccupyTotem = new List<entityUserOccupyTotem>();
		public List<entityUserRobbedTotems> userRobbedTotems = new List<entityUserRobbedTotems>();
		public entityUserLevelupChest userLevelupChest = new entityUserLevelupChest();
		public List<entityUserGeneralStar> userGeneralStar = new List<entityUserGeneralStar>();
		public List<entityUserGeneralSpectrum> userGeneralSpectrum = new List<entityUserGeneralSpectrum>();
		
		public void Clear()
		{
			userSendFeed.Clear();
			userGeneral.Clear();
			userItem.Clear();
			userEquip.Clear();
			userFormation.Clear();
			userFriend.Clear();
			userEnemy.Clear();
			userEmployNpc.Clear();
			userPlant.Clear();
			userRace.Clear();
			lastUserRace.Clear();
			userTrain.Clear();
			userArena.Clear();
			userSoul.Clear();
			userFormationGeneral.Clear();
			userScene.Clear();
			userTotem.Clear();
			userUnlock.Clear();
			userMission.Clear();
			userLivenessEvent.Clear();
			userOccupyTotem.Clear();
			userRobbedTotems.Clear();
			userGeneralStar.Clear();
			userGeneralSpectrum.Clear();
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
		public double lastContributeTime;
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
		public double eventCdEndTime;
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
		public double vipEndTime;
		public double lastPayTime;
		public double npcLastVisit;
		public double arenaCdEndTime;
		public double userInfoLastUpdateTime;
		public double qzoneInfoLastUpdateTime;
		public int bakName;
		public int bakIcon;
		public double qzoneFriendLastUpdate;
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
		public double stargazingVisitLastTime;
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
		public double sinaFirstChargeGetTime;
		public int serverRaceStage3ServerAward;
		public double userRecallTime;
		public double awardTime;
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
		public int intel;//int
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
	
	public class entityUserFormation
	{
		public int id;
		public int level;
		public string unlockGrid;
	}
	
	public class entityUserFriend
	{
		public string id;
		public string name;
		public string icon;
		public int sex;
		public string birthday;
		public int yellowLevel;
		public int yearYellow;
		public int level;
		public double lastModify;
		public int vipPoint;
		public double lastVisited;
		public int dayOperateTimes;
		public int lastOperateTime;
		public int maxSceneId;
		public int nEvent;
		public double eventTime;
		public int fourImages;
		public int guild;
		public string guildName;
		public int vipLevel;
		public string guildIcon;
		public int guildLevel;
		public int qzoneName;
		public int qzoneIcon;
		public int isQzone;
		public int isOther;
		public double lastLoginTime;
		public int tech2Level;
		public double lastGiftTime;
		public int attention;
		public string sid;
		public int serverId;
		public int dayGifted;
		public int verified_type;
		public int threeRacing;
		public int fightLevel;
	}
	
	public class entityUserEnemy
	{
		public string id;
		public string name;
		public string icon;
		public int sex;
		public string birthday;
		public int level;
		public string guildName;
		public int vipLevel;
		public string guildIcon;
		public int guildLevel;
		public int qzoneName;
		public int qzoneIcon;
		public int isQzone;
		public int isOther;
		public int tech2Level;
		public int attention;
		public int hatred;
		public double lasthatredTime;
		public int serverId;
	}
	
	public class entityUserEmployNpc
	{
		
	}
	
	public class entityUserPlant
	{
		public int landId;
		
		public double createTime;
		public int ripenTime;
		public int operateTimes;
		public string operateUsers;
		public string operateUserId1;
		public string operateUserId2;
		public string operateUserId3;
		public string operateUserId4;
		public string operateUserId5;
		public string operateUserIcon1;
		public string operateUserIcon2;
		public string operateUserIcon3;
		public string operateUserIcon4;
		public string operateUserIcon5;
		public string operateUserName1;
		public string operateUserName2;
		public string operateUserName3;
		public string operateUserName4;
		public string operateUserName5;
	}
	
	public class entityUserRace
	{
	}
	
	public class entityLastUserRace
	{
	}
	
	public class entityUserTrain
	{
		public int id;
		public int campId;
		public double beginTime;
		public int payType;
		public int trainType;
	}
	
	public class entityUserArena
	{
		public int tileX;
		public int tileY;
		
		public string playId;
		public string userName;
		public string userIcon;
		public int userLevel;
		
	}
	
	public class entityUserSoul
	{
		
	}
	
	public class entityUserTavern
	{
		public int id_1;
		public int id_2;
		public int id_3;
		public double ct;
		public int nomalRefreshTimes;
		public double nomalRefreshTime;
	}
	
	public class entityUserFormationGeneral
	{
		public int formationId;
		public int id;
		public int grid_0;
		public int grid_1;
		public int grid_2;
		public int grid_3;
		public int grid_4;
		public int grid_5;
		public int grid_6;
		public int grid_7;
		public int grid_8;
		public int grid_9;
		public int grid_10;
		public int grid_11;
	}
	
	public class entityUserDefend
	{
		public int lastLose;
		public int times;
		public double lastTime;
		
		public int maxLevel;
		public int propTimes;
	}
	
	public class entityUserTower
	{
		public int lastLevel;
		public int win;
		
		
		
		public int reviveTimes;
		
		public string getLevels;
		public double lastGetTime;
		public string awards;
		public int boss;
	}
	
	public class entityUserScene
	{
		public int sceneId;
		
		public int pass;
		
		public string award_1;
		public string award_2;
		public string award_3;
		public string award_4;
		public string award_5;
		public int star;
	}
	
	public class entityUserTotem
	{
		
		
		public int hasReap;
		public double lastReapTime;
		public int friendId_o;
		public int flastReapTime;
		public int occupyTime;
		public string friendId;
		public string friendIcon;
		public string friendName;
		public int friendLevel;
		public int remainNum;
		public int totemLevel;
	}
	
	public class entityUserUnlock
	{
		public int category;
		
		public double unlockTime;
	}
	
	public class entityActivityInfo
	{
		public string activityId;
		public int activityNormalNum;
		public int activitySpecialNum;
		public double activityStartTime;
		public double activityEndTime;
		public double couponStartTime;
		public double couponEndTime;
		public double loveStartTime;
		public double loveEndTime;
		public double yellowRegStartTime;
		public double yellowRegEndTime;
		public string turntableId;
		public string turntableBegTime;
		public string turntableEndTime;
		public string eggId;
		public string eggBegTime;
		public string eggEndTime;
		public double increaseTimesBegTime;
		public double increaseTimesEndTime;
		public int increaseTimesEscortRobTimes;
		public int increaseTimesTowerFreeMaxTimes;
		public int increaseTimesTowerPropMaxTimes;
		public int increaseTimesDefendFreeMaxTimes;
		public int increaseTimesDefendPropMaxTimes;
		public string serverRaceId;
		public string serverRacejoinTime;
		public string serverRacebegTime;
		public string serverRaceServerIdList;
		public string serverRaceStage1List;
		public string serverRaceStage2List;

		public string starTowerId;
		public string starTowerBegTime;
		public string starTowerEndTime;
		public string fishActId;
		public string fishBegTime;
		public string fishEndTime;
		public string fishCost1;
		public string fishCost2;
		public string fishCost3;
		public string guessId;
		public double guessBegTime;
		public double guessEndTime;
		public double levelupChestStartTime;
		public double levelupChestEndTime;
	}
	
	public class entityActivitySendInfo
	{
		
		public int activitySendNum;
		public int activityGetNum;
		
		
	}
	
	public class entityUnkown
	{
		public int memNumber;
		public int memLimit;
		public int leaderId;
		public string leaderName;
		public int announcement_1;

		public int order;
		public int recruitStatus;
		public int warStatus;

		public int tech_1;
		public int tech_2;
		public int tech_3;
		public int tech_4;
		public int tech_5;
		public int tech_6;
		public int tech_7;
		public int tech_8;
		public int tech_9;
		public int tech_10;
		public int petLevel;
		public int petExp;
		public int petFeedTimes;
		public double jadePropEndTime;
		public int jade;
		public double jadeLastModify;
		public int deputyLeader_1;
		public int deputyLeader_2;
		public double petWakeTime;
		public string techNeed;
		public string warRefresh;
		public double lastRefresh;
		public int atkGuild;
		public int defGuild;
		public int atkWinFlag;
		public int defWinFlag;
		public int increaseScore;
		public int increaseJade;
		public string tech_1_userId;
		public string tech_2_userId;
		public string tech_3_userId;
		public string tech_4_userId;
		public string tech_5_userId;
		public string tech_6_userId;
		public string tech_7_userId;
		public string tech_8_userId;
		public string tech_9_userId;
		public string tech_10_userId;
		public string tech_1_userName;
		public string tech_2_userName;
		public string tech_3_userName;
		public string tech_4_userName;
		public string tech_5_userName;
		public string tech_6_userName;
		public string tech_7_userName;
		public string tech_8_userName;
		public string tech_9_userName;
		public string tech_10_userName;
		public string tech_1_userIcon;
		public string tech_2_userIcon;
		public string tech_3_userIcon;
		public string tech_4_userIcon;
		public string tech_5_userIcon;
		public string tech_6_userIcon;
		public string tech_7_userIcon;
		public string tech_8_userIcon;
		public string tech_9_userIcon;
		public string tech_10_userIcon;
		public int reLevel;
		public int reLimit;
		public int reCurrNumber;
		public double reEndTime;
		public int winRate;
		public int totalWar;
		public int winWar;
		public string leaderIcon;
		public int warNumber;
		public int atkNumber;
		public int defNumber;
		public int missionReducePetTime;
		public int decreaseJade;
		public int leaderLvl;
		public int qqGroup;
		public int tech_11;
		public int tech_11_userId;
		public int tech_11_userName;
		public int tech_11_userIcon;
		public int position_2_number;
		public int position_3_number;
		public int position_5_number;
		public int position_6_number;
		public int position_7_number;
		public int position_8_number;
		public int position_9_number;
		public int donateGold;
		public int lastPetTime;
		public int callNumber;
		public int petChipNumber;
		public int donateGoldUserId;
		public string donateGoldUserName;
		public string donateGoldUserIcon;
		public int donateChipUserId;
		public string donateChipUserName;
		public string donateChipUserIcon;
		public double lastIncreaseCallCt;
		public int textDataId;
		public int donateSymbolNumber;
		public int groupId;
	}
	
	public class entityUserMission
	{
		public int missionId;
		public int missionClauseId;
		public int type;
		public int currentNumber;
		public int status;
		public int missionAwardId;
	}
	
	public class entityUserLivenessEvent
	{
		public int eventId;
		
		public int currentTimes;
		
	}
	
	public class entityUserTimeAward
	{
		public int timerId;
		
		public int nowItemId;
		public int nextItemId;
		public int dayReceiveTimes;
	}
	
	public class entityUserSevenDayAward
	{
		public int stat_1;
		public int stat_2;
		public int stat_3;
		public int stat_4;
		public int stat_5;
		public int stat_6;
		public int stat_7;
		
	}
	
	public class entityUserYellow
	{
		public int lastNewhandTime;
		public int lastDailyTime;
		public int lastLevelup_1;
		public int lastLevelup_2;
		public int lastLevelup_3;
		public int lastLevelup_4;
		public int lastLevelup_5;
		public int lastLevelup_6;
		public int lastLevelup_7;
		public int lastLevelup_8;
		public int lastLevelup_9;
		public int lastLevelup_10;
	}
	
	public class entityUserOccupyTotem
	{
		
	}
	
	public class entityUserRobbedTotems
	{
		
	}
	
	public class entityUserLevelupChest
	{
		public int levelup_10;
		public int levelup_20;
		public int levelup_30;
		public int levelup_45;
	}
	
	public class entityUserGeneralStar
	{
		
		
		
		public int soulNumber;
	}
	
	public class entityUserGeneralSpectrum
	{
		
		public int slot_1;
		public int slot_2;
		public int slot_3;
		public int slot_4;
		public int slot_5;
		public int slot_6;
		public int enable;
	}
}
