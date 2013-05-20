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
		
		private QueryManager sInsMgr = new QueryManager();
		private Account curAcc= null;
		
		void MainFormLoad(object sender, EventArgs e)
		{
			sInsMgr.OnUIUpdate += new EventHandler<UIUpdateArgs>(CallBack_UIUpdate);
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
		
		private void Buttonbehaviour(bool bLogined)
		{
			this.btLogin.Enabled = (!bLogined);
			this.btLogout.Enabled = bLogined;
			
			this.btGetGift.Enabled = bLogined;
			this.btGetMessage.Enabled = bLogined;
			this.btMsgBox.Enabled = bLogined;
			this.btGetLoginAward.Enabled = bLogined;
			this.btGetLuckInfo.Enabled = bLogined;
			this.btRefreshGeneral.Enabled = bLogined;
			this.btEmployGeneral.Enabled = bLogined;
		}
		
		void BtLoginClick(object sender, EventArgs e)
		{
			curAcc = new Account(this.tbAccount.Text, this.tbPassword.Text);
			curAcc.upCall = sInsMgr;
			sInsMgr.Login(curAcc);
			
			Buttonbehaviour(true);
		}
		
		void BtLogoutClick(object sender, EventArgs e)
		{
			sInsMgr.Logout(curAcc);
			
			Buttonbehaviour(false);
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
			sInsMgr.SendCommand(new RfsGenCmdArg(CmdIDs.USER_REFRESH_GENERAL, curAcc, 1));
		}
		
		void BtEmployGeneral(object sender, EventArgs e)
		{
			sInsMgr.SendCommand(new EplGenCmdArg(CmdIDs.USER_EMPLOY_GENERAL, curAcc, 0, 1));
		}
	}
}
