/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2012-9-2
 * Time: 13:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MJTool
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btEmployGeneral = new System.Windows.Forms.Button();
			this.btRefreshGeneral = new System.Windows.Forms.Button();
			this.btGetLuckInfo = new System.Windows.Forms.Button();
			this.btGetLoginAward = new System.Windows.Forms.Button();
			this.btMsgBox = new System.Windows.Forms.Button();
			this.btGetMessage = new System.Windows.Forms.Button();
			this.btGetGift = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btLogout = new System.Windows.Forms.Button();
			this.btLogin = new System.Windows.Forms.Button();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.tbAccount = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tbLog = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(667, 359);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btEmployGeneral);
			this.tabPage1.Controls.Add(this.btRefreshGeneral);
			this.tabPage1.Controls.Add(this.btGetLuckInfo);
			this.tabPage1.Controls.Add(this.btGetLoginAward);
			this.tabPage1.Controls.Add(this.btMsgBox);
			this.tabPage1.Controls.Add(this.btGetMessage);
			this.tabPage1.Controls.Add(this.btGetGift);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(659, 334);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "挂机";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btEmployGeneral
			// 
			this.btEmployGeneral.Enabled = false;
			this.btEmployGeneral.Location = new System.Drawing.Point(245, 45);
			this.btEmployGeneral.Name = "btEmployGeneral";
			this.btEmployGeneral.Size = new System.Drawing.Size(164, 23);
			this.btEmployGeneral.TabIndex = 2;
			this.btEmployGeneral.Text = "雇佣武将";
			this.btEmployGeneral.UseVisualStyleBackColor = true;
			this.btEmployGeneral.Click += new System.EventHandler(this.BtEmployGeneral);
			// 
			// btRefreshGeneral
			// 
			this.btRefreshGeneral.Enabled = false;
			this.btRefreshGeneral.Location = new System.Drawing.Point(245, 16);
			this.btRefreshGeneral.Name = "btRefreshGeneral";
			this.btRefreshGeneral.Size = new System.Drawing.Size(164, 23);
			this.btRefreshGeneral.TabIndex = 2;
			this.btRefreshGeneral.Text = "刷新武将";
			this.btRefreshGeneral.UseVisualStyleBackColor = true;
			this.btRefreshGeneral.Click += new System.EventHandler(this.BtRefreshGeneral);
			// 
			// btGetLuckInfo
			// 
			this.btGetLuckInfo.Enabled = false;
			this.btGetLuckInfo.Location = new System.Drawing.Point(28, 277);
			this.btGetLuckInfo.Name = "btGetLuckInfo";
			this.btGetLuckInfo.Size = new System.Drawing.Size(164, 23);
			this.btGetLuckInfo.TabIndex = 2;
			this.btGetLuckInfo.Text = "获取幸运消息";
			this.btGetLuckInfo.UseVisualStyleBackColor = true;
			this.btGetLuckInfo.Click += new System.EventHandler(this.BtGetLuckInfo);
			// 
			// btGetLoginAward
			// 
			this.btGetLoginAward.Enabled = false;
			this.btGetLoginAward.Location = new System.Drawing.Point(28, 248);
			this.btGetLoginAward.Name = "btGetLoginAward";
			this.btGetLoginAward.Size = new System.Drawing.Size(164, 23);
			this.btGetLoginAward.TabIndex = 2;
			this.btGetLoginAward.Text = "获取登录奖励";
			this.btGetLoginAward.UseVisualStyleBackColor = true;
			this.btGetLoginAward.Click += new System.EventHandler(this.BtGetLoginAward);
			// 
			// btMsgBox
			// 
			this.btMsgBox.Enabled = false;
			this.btMsgBox.Location = new System.Drawing.Point(28, 219);
			this.btMsgBox.Name = "btMsgBox";
			this.btMsgBox.Size = new System.Drawing.Size(164, 23);
			this.btMsgBox.TabIndex = 2;
			this.btMsgBox.Text = "消息盒";
			this.btMsgBox.UseVisualStyleBackColor = true;
			this.btMsgBox.Click += new System.EventHandler(this.BtMsgBox);
			// 
			// btGetMessage
			// 
			this.btGetMessage.Enabled = false;
			this.btGetMessage.Location = new System.Drawing.Point(28, 190);
			this.btGetMessage.Name = "btGetMessage";
			this.btGetMessage.Size = new System.Drawing.Size(164, 23);
			this.btGetMessage.TabIndex = 2;
			this.btGetMessage.Text = "获取消息";
			this.btGetMessage.UseVisualStyleBackColor = true;
			this.btGetMessage.Click += new System.EventHandler(this.BtGetMessage);
			// 
			// btGetGift
			// 
			this.btGetGift.Enabled = false;
			this.btGetGift.Location = new System.Drawing.Point(28, 161);
			this.btGetGift.Name = "btGetGift";
			this.btGetGift.Size = new System.Drawing.Size(164, 23);
			this.btGetGift.TabIndex = 2;
			this.btGetGift.Text = "获取礼物";
			this.btGetGift.UseVisualStyleBackColor = true;
			this.btGetGift.Click += new System.EventHandler(this.BtGetGift);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btLogout);
			this.groupBox1.Controls.Add(this.btLogin);
			this.groupBox1.Controls.Add(this.tbPassword);
			this.groupBox1.Controls.Add(this.tbAccount);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(205, 127);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "登录";
			// 
			// btLogout
			// 
			this.btLogout.Enabled = false;
			this.btLogout.Location = new System.Drawing.Point(109, 98);
			this.btLogout.Name = "btLogout";
			this.btLogout.Size = new System.Drawing.Size(75, 23);
			this.btLogout.TabIndex = 2;
			this.btLogout.Text = "登出";
			this.btLogout.UseVisualStyleBackColor = true;
			this.btLogout.Click += new System.EventHandler(this.BtLogoutClick);
			// 
			// btLogin
			// 
			this.btLogin.Location = new System.Drawing.Point(20, 98);
			this.btLogin.Name = "btLogin";
			this.btLogin.Size = new System.Drawing.Size(75, 23);
			this.btLogin.TabIndex = 2;
			this.btLogin.Text = "登录";
			this.btLogin.UseVisualStyleBackColor = true;
			this.btLogin.Click += new System.EventHandler(this.BtLoginClick);
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(71, 58);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(113, 21);
			this.tbPassword.TabIndex = 1;
			this.tbPassword.Text = "1qaz@WSX";
			// 
			// tbAccount
			// 
			this.tbAccount.Location = new System.Drawing.Point(71, 22);
			this.tbAccount.Name = "tbAccount";
			this.tbAccount.Size = new System.Drawing.Size(113, 21);
			this.tbAccount.TabIndex = 1;
			this.tbAccount.Text = "kill1028@126.com";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "密码";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "帐号";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(659, 334);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "数据";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.tbLog);
			this.tabPage3.Location = new System.Drawing.Point(4, 21);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(659, 334);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "日志";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tbLog
			// 
			this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbLog.Location = new System.Drawing.Point(3, 3);
			this.tbLog.Multiline = true;
			this.tbLog.Name = "tbLog";
			this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbLog.Size = new System.Drawing.Size(653, 328);
			this.tbLog.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(667, 359);
			this.Controls.Add(this.tabControl1);
			this.Name = "MainForm";
			this.Text = "MJTool";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btEmployGeneral;
		private System.Windows.Forms.Button btRefreshGeneral;
		private System.Windows.Forms.Button btGetLuckInfo;
		private System.Windows.Forms.Button btGetLoginAward;
		private System.Windows.Forms.Button btMsgBox;
		private System.Windows.Forms.Button btGetMessage;
		private System.Windows.Forms.Button btGetGift;
		private System.Windows.Forms.Button btLogout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbAccount;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Button btLogin;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbLog;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
	}
}
