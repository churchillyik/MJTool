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
		
		private void LoginAccount(Account acc)
		{
			curAcc = acc;
			this.Text = "MJTool - " + "焦点帐号[" + curAcc.strUserName + "]";
			sInsMgr.Login(curAcc);
			
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
			LoginAccount(this.lstAccs[this.lvAccount.SelectedIndices[0]]);
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
				ListViewItem lvi = this.lvGenSoul.Items.Add(gen_type.quality.ToString());
				lvi.SubItems.Add(gen_type.name);
				lvi.SubItems.Add(soul.number.ToString());
				if (gen_type.quality == 4)
				{
					lvi.BackColor = Color.GreenYellow;
				}
			}
		}
		
		void ContextMenuStrip1Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.lvAccount.SelectedIndices.Count < 1)
			{
				return;
			}
			Account acc = this.lstAccs[this.lvAccount.SelectedIndices[0]];
			if (acc.bIsLogined)
			{
				this.loginAccToolStripMenuItem.Enabled = false;
				this.logoutToolStripMenuItem.Enabled = true;
			}
			else
			{
				this.loginAccToolStripMenuItem.Enabled = true;
				this.logoutToolStripMenuItem.Enabled = false;
			}
		}
		
		void LvAccountDoubleClick(object sender, EventArgs e)
		{
			if (this.lvAccount.SelectedIndices.Count < 1)
			{
				return;
			}
			Account acc = this.lstAccs[this.lvAccount.SelectedIndices[0]];
			if (acc.bIsLogined)
			{
				this.LogoutAccount(acc);
			}
			else
			{
				this.LoginAccount(acc);
			}
		}
	}
}
