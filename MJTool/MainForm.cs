using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MJTool
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private delegate void dlgWriteLog(string log);
		private delegate void dlgClearLog();
		private delegate void dlgRefreshAll();
		
		private QueryManager sInsMgr = new QueryManager();
		private List<Account> lstAccs = new List<Account>();
		private Account curAcc= null;
		
		void MainFormLoad(object sender, EventArgs e)
		{
			sInsMgr.OnUIUpdate += new EventHandler<UIUpdateArgs>(CallBack_UIUpdate);
			sInsMgr.init();
			sInsMgr.LoadAccounts(lstAccs);
			RefreshAccounts();
		}
		
		void CallBack_UIUpdate(object sender, UIUpdateArgs e)
		{
			try
			{
				if (e.uiType == UIUpdateTypes.LogAppending)
				{
					LogArgs e_log = e as LogArgs;
					Invoke(new dlgWriteLog(WriteLog)
					       , new object[] { e_log.strLog });
				}
				else if (e.uiType == UIUpdateTypes.LogClear)
				{
					Invoke(new dlgClearLog(ClearLog));
				}
				else if (e.uiType == UIUpdateTypes.RefreshAll)
				{
					Invoke(new dlgRefreshAll(RefreshAll));
				}
			}
			catch (Exception)
			{ }
		}
		
		private int nLogCnt = 0;
		private void WriteLog(string log)
		{
			if (nLogCnt >= 100)
			{
				this.tbLog.Text = "";
				nLogCnt = 0;
			}
			this.tbLog.AppendText("[" + DateTime.Now.ToString() + "] " + log + "\r\n");
			nLogCnt++;
		}
		
		private void ClearLog()
		{
			this.tbLog.Text = "";
		}
		
		private void RefreshAll()
		{
			RefreshGenSouls();
			RefreshTavern();
		}
		
		private void Buttonbehaviour(bool bLogined)
		{
			this.btGetGift.Enabled = bLogined;
			this.btGetMessage.Enabled = bLogined;
			this.btMsgBox.Enabled = bLogined;
			this.btGetLoginAward.Enabled = bLogined;
			this.btGetLuckInfo.Enabled = bLogined;
			this.btRefreshGeneral.Enabled = bLogined;
			this.btEmployGeneral.Enabled = bLogined;
			this.btOneKeyForSoul.Enabled = bLogined;
		}
		
		void BtGetGift(object sender, EventArgs e)
		{
			sInsMgr.SendCommand(new CmdArg(CmdIDs.USER_GET_GIFT, curAcc));
		}
		
		void BtGetMessage(object sender, EventArgs e)
		{
			sInsMgr.SendCommand(new CmdArg(CmdIDs.USER_GET_MESSAGE, curAcc));
		}
		
		void BtMsgBox(object sender, EventArgs e)
		{
			sInsMgr.SendCommand(new CmdArg(CmdIDs.FEED_MSG_BOX, curAcc));
		}
		
		void BtGetLoginAward(object sender, EventArgs e)
		{
			sInsMgr.SendCommand(new CmdArg(CmdIDs.USER_GET_LOGIN_AWARD, curAcc));
		}
		
		void BtGetLuckInfo(object sender, EventArgs e)
		{
			sInsMgr.SendCommand(new CmdArg(CmdIDs.USER_GET_LUCK_INFO, curAcc));
		}
		
		void BtRefreshGeneral(object sender, EventArgs e)
		{
			DateTime dt;
			if (curAcc.CheckGeneralRefreshAvailable(1, out dt))
			{
				sInsMgr.SendCommand(new RfsGenCmdArg(CmdIDs.USER_REFRESH_GENERAL, curAcc, 1));
			}
			else
			{
				sInsMgr.DebugLog("武将刷新在CD结束时刻为：" + dt.ToString());
			}
		}
		
		void BtEmployGeneral(object sender, EventArgs e)
		{
			sInsMgr.SendCommand(new EplGenCmdArg(CmdIDs.USER_EMPLOY_GENERAL, curAcc, 0, 1));
		}
		
		void BtParseLocalDataClick(object sender, EventArgs e)
		{
			sInsMgr.ParseLocalData();
		}
		
		void BtOneKeyForSoulClick(object sender, EventArgs e)
		{
			
		}
		
		private void LoginOrFocusAccount(Account acc)
		{
			curAcc = acc;
			this.Text = "MJTool - " + "焦点帐号[" + curAcc.strUserName + "]";
			if (!curAcc.bIsLogined)
			{
				sInsMgr.Login(curAcc);
			}
			else
			{
				RefreshAll();
			}
			Buttonbehaviour(true);
		}
		
		private void LogoutAccount(Account acc)
		{
			sInsMgr.Logout(acc);
			
			Buttonbehaviour(false);
		}
		
		void LoginAccToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (this.lvAccount.SelectedIndices.Count < 1)
			{
				return;
			}
			for (int i = 0; i < this.lvAccount.Items.Count; i++)
			{
				if (i == this.lvAccount.SelectedIndices[0])
				{
					ListViewItem lvi = this.lvAccount.Items[i];
					lvi.BackColor = Color.Blue;
				}
				else
				{
					ListViewItem lvi = this.lvAccount.Items[i];
					lvi.BackColor = SystemColors.Window;
				}
			}
			LoginOrFocusAccount(this.lstAccs[this.lvAccount.SelectedIndices[0]]);
		}
		
		
		void LogoutToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (this.lvAccount.SelectedIndices.Count < 1)
			{
				return;
			}
			LogoutAccount(this.lstAccs[this.lvAccount.SelectedIndices[0]]);
		}
		
		void AddAccToolStripMenuItemClick(object sender, EventArgs e)
		{
			AccEditForm acc_form = new AccEditForm();
			if (acc_form.ShowDialog() == DialogResult.OK && acc_form.accResult != null)
			{
				acc_form.accResult.upCall = sInsMgr;
				this.lstAccs.Add(acc_form.accResult);
				RefreshAccounts();
				sInsMgr.SaveAccounts(this.lstAccs);
			}
		}
		
		void DelAccToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (this.lvAccount.SelectedIndices.Count < 1)
			{
				return;
			}
			this.lstAccs.RemoveAt(this.lvAccount.SelectedIndices[0]);
			RefreshAccounts();
			sInsMgr.SaveAccounts(this.lstAccs);
		}
		
		void EditAccToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (this.lvAccount.SelectedIndices.Count < 1)
			{
				return;
			}
			AccEditForm acc_form = new AccEditForm();
			acc_form.accResult = this.lstAccs[this.lvAccount.SelectedIndices[0]];
			if (acc_form.ShowDialog() == DialogResult.OK)
			{
				RefreshAccounts();
				sInsMgr.SaveAccounts(this.lstAccs);
			}
		}
		
		void BtClearLogClick(object sender, EventArgs e)
		{
			this.tbLog.Text = "";
		}
		
		private void RefreshAccounts()
		{
			if (this.lstAccs == null)
			{
				return;
			}
			this.lvAccount.Items.Clear();
			for (int  i = 0; i < this.lstAccs.Count; i++)
			{
				this.lvAccount.Items.Add(this.lstAccs[i].strUserName);
			}
		}
		
		private static string[] strQualityNames = new string[] {"杂兵", "普通", "优秀", "稀有", "完美", };
		private void RefreshGenSouls()
		{
			if (curAcc == null)
			{
				return;
			}
			
			this.lvGenSoul.Items.Clear();
			for (int i = 0; i < curAcc.root.userData.userSoul.Count; i++)
			{
				entityUserSoul soul = curAcc.root.userData.userSoul[i];
				DBGeneralType gen_type = QueryManager.gGameDB.GetGeneralType(soul.generalType);
				if (gen_type == null)
				{
					continue;
				}
				ListViewItem lvi = this.lvGenSoul.Items.Add(strQualityNames[gen_type.quality]);
				lvi.SubItems.Add(gen_type.name);
				lvi.SubItems.Add(soul.number.ToString());
				if (gen_type.quality == 4)
				{
					lvi.BackColor = Color.GreenYellow;
				}
			}
		}
		
		private void RefreshTavern()
		{
			if (curAcc == null)
			{
				return;
			}
			
			this.lbTavern.Items.Clear();
			this.lbTavern.Items.Add("酒馆将魂：");
			DBGeneral gen_1 = QueryManager.gGameDB.GetGeneral(curAcc.root.userData.userTavern.id_1);
			if (gen_1 != null)
			{
				DBGeneralType gen_type = QueryManager.gGameDB.GetGeneralType(gen_1.type);
				this.lbTavern.Items.Add(strQualityNames[gen_type.quality] + "\t" + gen_1.name + "\t" + gen_1.soul + "个");
			}
			else
			{
				this.lbTavern.Items.Add("将魂已招募");
			}
			
			DBGeneral gen_2 = QueryManager.gGameDB.GetGeneral(curAcc.root.userData.userTavern.id_2);
			if (gen_2 != null)
			{
				DBGeneralType gen_type = QueryManager.gGameDB.GetGeneralType(gen_2.type);
				this.lbTavern.Items.Add(strQualityNames[gen_type.quality] + "\t" + gen_2.name + "\t" + gen_2.soul + "个");
			}
			else
			{
				this.lbTavern.Items.Add("将魂已招募");
			}
			
			DBGeneral gen_3 = QueryManager.gGameDB.GetGeneral(curAcc.root.userData.userTavern.id_2);
			if (gen_3 != null)
			{
				DBGeneralType gen_type = QueryManager.gGameDB.GetGeneralType(gen_3.type);
				this.lbTavern.Items.Add(strQualityNames[gen_type.quality] + "\t" + gen_3.name + "\t" + gen_3.soul + "个");
			}
			else
			{
				this.lbTavern.Items.Add("将魂已招募");
			}
			
			this.lbTavern.Items.Add("--------------------");
			this.lbTavern.Items.Add("酒馆刷新冷却：");
			DateTime cd_dt_1 = QueryManager.SecondsToDateTime(curAcc.root.userData.user.tavernCdEndTime_1);
			if (cd_dt_1 < DateTime.Now)
			{
				this.lbTavern.Items.Add("普通刷新：冷却完毕！\t次数：" + curAcc.root.userData.userTavern.nomalRefreshTimes + "/10");
			}
			else
			{
				TimeSpan ts = cd_dt_1.Subtract(DateTime.Now);
				this.lbTavern.Items.Add(String.Format("普通刷新：{0}:{1}:{2} 后冷却", ts.Hours , ts.Minutes, ts.Seconds) 
				                        + "\t次数：" + curAcc.root.userData.userTavern.nomalRefreshTimes + "/10");
			}
			
			DateTime cd_dt_2 = QueryManager.SecondsToDateTime(curAcc.root.userData.user.tavernCdEndTime_2);
			if (cd_dt_2 < DateTime.Now)
			{
				this.lbTavern.Items.Add("中级刷新：冷却完毕！");
			}
			else
			{
				TimeSpan ts = cd_dt_2.Subtract(DateTime.Now);
				this.lbTavern.Items.Add(String.Format("中级刷新：{0}:{1}:{2} 后冷却", ts.Hours , ts.Minutes, ts.Seconds));
			}
			
			DateTime cd_dt_3 = QueryManager.SecondsToDateTime(curAcc.root.userData.user.tavernCdEndTime_3);
			if (cd_dt_3 < DateTime.Now)
			{
				this.lbTavern.Items.Add("高级刷新：冷却完毕！");
			}
			else
			{
				TimeSpan ts = cd_dt_3.Subtract(DateTime.Now);
				this.lbTavern.Items.Add(String.Format("高级刷新：{0}:{1}:{2} 后冷却", ts.Hours , ts.Minutes, ts.Seconds));
			}
			
			DateTime cd_dt_4 = QueryManager.SecondsToDateTime(curAcc.root.userData.user.tavernCdEndTime_4);
			if (cd_dt_4 < DateTime.Now)
			{
				this.lbTavern.Items.Add("完美刷新：冷却完毕！");
			}
			else
			{
				TimeSpan ts = cd_dt_4.Subtract(DateTime.Now);
				this.lbTavern.Items.Add(String.Format("完美刷新：{0}:{1}:{2} 后冷却", ts.Hours , ts.Minutes, ts.Seconds));
			}
		}
		
		void ContextMenuStrip1Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.lvAccount.SelectedIndices.Count < 1)
			{
				this.loginAccToolStripMenuItem.Enabled = false;
				this.logoutToolStripMenuItem.Enabled = false;
				this.delAccToolStripMenuItem.Enabled = false;
				this.editAccToolStripMenuItem.Enabled = false;
				return;
			}
			Account acc = this.lstAccs[this.lvAccount.SelectedIndices[0]];
			if (acc.bIsLogined)
			{
				this.loginAccToolStripMenuItem.Text = "&S. 切换帐号";
				this.loginAccToolStripMenuItem.Enabled = true;
				this.logoutToolStripMenuItem.Enabled = true;
				this.delAccToolStripMenuItem.Enabled = true;
				this.editAccToolStripMenuItem.Enabled = true;
			}
			else
			{
				this.loginAccToolStripMenuItem.Text = "&L. 登录帐号";
				this.loginAccToolStripMenuItem.Enabled = true;
				this.logoutToolStripMenuItem.Enabled = false;
				this.delAccToolStripMenuItem.Enabled = true;
				this.editAccToolStripMenuItem.Enabled = true;
			}
		}
		
		void LvAccountDoubleClick(object sender, EventArgs e)
		{
			if (this.lvAccount.SelectedIndices.Count < 1)
			{
				return;
			}
			Account acc = this.lstAccs[this.lvAccount.SelectedIndices[0]];
			for (int i = 0; i < this.lvAccount.Items.Count; i++)
			{
				if (i == this.lvAccount.SelectedIndices[0])
				{
					ListViewItem lvi = this.lvAccount.Items[i];
					lvi.BackColor = Color.LightBlue;
				}
				else
				{
					ListViewItem lvi = this.lvAccount.Items[i];
					lvi.BackColor = SystemColors.Window;
				}
			}
			this.LoginOrFocusAccount(acc);
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			this.RefreshTavern();
		}
	}
}
