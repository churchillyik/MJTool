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
			this.components = new System.ComponentModel.Container();
			this.btEmployGeneral = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btRefreshGeneral = new System.Windows.Forms.Button();
			this.btGetLuckInfo = new System.Windows.Forms.Button();
			this.btGetLoginAward = new System.Windows.Forms.Button();
			this.btMsgBox = new System.Windows.Forms.Button();
			this.btGetMessage = new System.Windows.Forms.Button();
			this.btGetGift = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lvAccount = new System.Windows.Forms.ListView();
			this.chLoginAccount = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.loginAccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addAccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.delAccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editAccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tbLog = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btClearLog = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lvGenSoul = new System.Windows.Forms.ListView();
			this.chSoulQuality = new System.Windows.Forms.ColumnHeader();
			this.chSoulName = new System.Windows.Forms.ColumnHeader();
			this.chSoulNum = new System.Windows.Forms.ColumnHeader();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btOneKeyForSoul = new System.Windows.Forms.Button();
			this.lbTavern = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btEmployGeneral
			// 
			this.btEmployGeneral.Enabled = false;
			this.btEmployGeneral.Location = new System.Drawing.Point(97, 12);
			this.btEmployGeneral.Name = "btEmployGeneral";
			this.btEmployGeneral.Size = new System.Drawing.Size(75, 30);
			this.btEmployGeneral.TabIndex = 2;
			this.btEmployGeneral.Text = "获取将魂";
			this.btEmployGeneral.UseVisualStyleBackColor = true;
			this.btEmployGeneral.Click += new System.EventHandler(this.BtEmployGeneral);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(71, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "解析数据";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.BtParseLocalDataClick);
			// 
			// btRefreshGeneral
			// 
			this.btRefreshGeneral.Enabled = false;
			this.btRefreshGeneral.Location = new System.Drawing.Point(12, 12);
			this.btRefreshGeneral.Name = "btRefreshGeneral";
			this.btRefreshGeneral.Size = new System.Drawing.Size(75, 30);
			this.btRefreshGeneral.TabIndex = 2;
			this.btRefreshGeneral.Text = "刷新酒馆";
			this.btRefreshGeneral.UseVisualStyleBackColor = true;
			this.btRefreshGeneral.Click += new System.EventHandler(this.BtRefreshGeneral);
			// 
			// btGetLuckInfo
			// 
			this.btGetLuckInfo.Enabled = false;
			this.btGetLuckInfo.Location = new System.Drawing.Point(383, 4);
			this.btGetLuckInfo.Name = "btGetLuckInfo";
			this.btGetLuckInfo.Size = new System.Drawing.Size(71, 23);
			this.btGetLuckInfo.TabIndex = 2;
			this.btGetLuckInfo.Text = "幸运消息";
			this.btGetLuckInfo.UseVisualStyleBackColor = true;
			this.btGetLuckInfo.Click += new System.EventHandler(this.BtGetLuckInfo);
			// 
			// btGetLoginAward
			// 
			this.btGetLoginAward.Enabled = false;
			this.btGetLoginAward.Location = new System.Drawing.Point(306, 4);
			this.btGetLoginAward.Name = "btGetLoginAward";
			this.btGetLoginAward.Size = new System.Drawing.Size(71, 23);
			this.btGetLoginAward.TabIndex = 2;
			this.btGetLoginAward.Text = "登录奖励";
			this.btGetLoginAward.UseVisualStyleBackColor = true;
			this.btGetLoginAward.Click += new System.EventHandler(this.BtGetLoginAward);
			// 
			// btMsgBox
			// 
			this.btMsgBox.Enabled = false;
			this.btMsgBox.Location = new System.Drawing.Point(537, 4);
			this.btMsgBox.Name = "btMsgBox";
			this.btMsgBox.Size = new System.Drawing.Size(71, 23);
			this.btMsgBox.TabIndex = 2;
			this.btMsgBox.Text = "消息盒";
			this.btMsgBox.UseVisualStyleBackColor = true;
			this.btMsgBox.Click += new System.EventHandler(this.BtMsgBox);
			// 
			// btGetMessage
			// 
			this.btGetMessage.Enabled = false;
			this.btGetMessage.Location = new System.Drawing.Point(460, 4);
			this.btGetMessage.Name = "btGetMessage";
			this.btGetMessage.Size = new System.Drawing.Size(71, 23);
			this.btGetMessage.TabIndex = 2;
			this.btGetMessage.Text = "获取消息";
			this.btGetMessage.UseVisualStyleBackColor = true;
			this.btGetMessage.Click += new System.EventHandler(this.BtGetMessage);
			// 
			// btGetGift
			// 
			this.btGetGift.Enabled = false;
			this.btGetGift.Location = new System.Drawing.Point(229, 4);
			this.btGetGift.Name = "btGetGift";
			this.btGetGift.Size = new System.Drawing.Size(71, 23);
			this.btGetGift.TabIndex = 2;
			this.btGetGift.Text = "获取礼物";
			this.btGetGift.UseVisualStyleBackColor = true;
			this.btGetGift.Click += new System.EventHandler(this.BtGetGift);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.5F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.lvAccount, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(941, 463);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// lvAccount
			// 
			this.lvAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chLoginAccount});
			this.lvAccount.ContextMenuStrip = this.contextMenuStrip1;
			this.lvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvAccount.FullRowSelect = true;
			this.lvAccount.GridLines = true;
			this.lvAccount.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvAccount.Location = new System.Drawing.Point(3, 3);
			this.lvAccount.MultiSelect = false;
			this.lvAccount.Name = "lvAccount";
			this.lvAccount.Size = new System.Drawing.Size(158, 457);
			this.lvAccount.TabIndex = 0;
			this.lvAccount.UseCompatibleStateImageBehavior = false;
			this.lvAccount.View = System.Windows.Forms.View.Details;
			this.lvAccount.DoubleClick += new System.EventHandler(this.LvAccountDoubleClick);
			// 
			// chLoginAccount
			// 
			this.chLoginAccount.Text = "新浪微博账号";
			this.chLoginAccount.Width = 150;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.loginAccToolStripMenuItem,
									this.logoutToolStripMenuItem,
									this.addAccToolStripMenuItem,
									this.delAccToolStripMenuItem,
									this.editAccToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 136);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
			// 
			// loginAccToolStripMenuItem
			// 
			this.loginAccToolStripMenuItem.Name = "loginAccToolStripMenuItem";
			this.loginAccToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loginAccToolStripMenuItem.Text = "&L. 登录帐号";
			this.loginAccToolStripMenuItem.Click += new System.EventHandler(this.LoginAccToolStripMenuItemClick);
			// 
			// logoutToolStripMenuItem
			// 
			this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
			this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.logoutToolStripMenuItem.Text = "&O. 登出帐号";
			this.logoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItemClick);
			// 
			// addAccToolStripMenuItem
			// 
			this.addAccToolStripMenuItem.Name = "addAccToolStripMenuItem";
			this.addAccToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.addAccToolStripMenuItem.Text = "&A. 添加帐号";
			this.addAccToolStripMenuItem.Click += new System.EventHandler(this.AddAccToolStripMenuItemClick);
			// 
			// delAccToolStripMenuItem
			// 
			this.delAccToolStripMenuItem.Name = "delAccToolStripMenuItem";
			this.delAccToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.delAccToolStripMenuItem.Text = "&D. 删除帐号";
			this.delAccToolStripMenuItem.Click += new System.EventHandler(this.DelAccToolStripMenuItemClick);
			// 
			// editAccToolStripMenuItem
			// 
			this.editAccToolStripMenuItem.Name = "editAccToolStripMenuItem";
			this.editAccToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.editAccToolStripMenuItem.Text = "E. 编辑帐号";
			this.editAccToolStripMenuItem.Click += new System.EventHandler(this.EditAccToolStripMenuItemClick);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.tbLog, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(167, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(771, 457);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// tbLog
			// 
			this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbLog.Location = new System.Drawing.Point(3, 358);
			this.tbLog.Multiline = true;
			this.tbLog.Name = "tbLog";
			this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbLog.Size = new System.Drawing.Size(765, 96);
			this.tbLog.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btGetLoginAward);
			this.panel1.Controls.Add(this.btClearLog);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.btGetLuckInfo);
			this.panel1.Controls.Add(this.btGetGift);
			this.panel1.Controls.Add(this.btGetMessage);
			this.panel1.Controls.Add(this.btMsgBox);
			this.panel1.Location = new System.Drawing.Point(3, 322);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(765, 30);
			this.panel1.TabIndex = 1;
			// 
			// btClearLog
			// 
			this.btClearLog.Location = new System.Drawing.Point(92, 4);
			this.btClearLog.Name = "btClearLog";
			this.btClearLog.Size = new System.Drawing.Size(71, 23);
			this.btClearLog.TabIndex = 2;
			this.btClearLog.Text = "清空日志";
			this.btClearLog.UseVisualStyleBackColor = true;
			this.btClearLog.Click += new System.EventHandler(this.BtClearLogClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(765, 313);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lvGenSoul);
			this.tabPage1.Controls.Add(this.panel2);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(757, 288);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "将魂";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// lvGenSoul
			// 
			this.lvGenSoul.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chSoulQuality,
									this.chSoulName,
									this.chSoulNum});
			this.lvGenSoul.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvGenSoul.FullRowSelect = true;
			this.lvGenSoul.GridLines = true;
			this.lvGenSoul.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvGenSoul.Location = new System.Drawing.Point(3, 3);
			this.lvGenSoul.MultiSelect = false;
			this.lvGenSoul.Name = "lvGenSoul";
			this.lvGenSoul.Size = new System.Drawing.Size(442, 282);
			this.lvGenSoul.TabIndex = 1;
			this.lvGenSoul.UseCompatibleStateImageBehavior = false;
			this.lvGenSoul.View = System.Windows.Forms.View.Details;
			// 
			// chSoulQuality
			// 
			this.chSoulQuality.Text = "将魂品质";
			this.chSoulQuality.Width = 70;
			// 
			// chSoulName
			// 
			this.chSoulName.Text = "将魂名称";
			this.chSoulName.Width = 150;
			// 
			// chSoulNum
			// 
			this.chSoulNum.Text = "将魂数量";
			this.chSoulNum.Width = 80;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tableLayoutPanel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(445, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(309, 282);
			this.panel2.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.lbTavern, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(309, 282);
			this.tableLayoutPanel3.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btOneKeyForSoul);
			this.panel3.Controls.Add(this.btEmployGeneral);
			this.panel3.Controls.Add(this.btRefreshGeneral);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 228);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(303, 51);
			this.panel3.TabIndex = 0;
			// 
			// btOneKeyForSoul
			// 
			this.btOneKeyForSoul.Location = new System.Drawing.Point(197, 12);
			this.btOneKeyForSoul.Name = "btOneKeyForSoul";
			this.btOneKeyForSoul.Size = new System.Drawing.Size(97, 30);
			this.btOneKeyForSoul.TabIndex = 3;
			this.btOneKeyForSoul.Text = "一键刷新并获取";
			this.btOneKeyForSoul.UseVisualStyleBackColor = true;
			this.btOneKeyForSoul.Click += new System.EventHandler(this.BtOneKeyForSoulClick);
			// 
			// lbTavern
			// 
			this.lbTavern.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbTavern.FormattingEnabled = true;
			this.lbTavern.ItemHeight = 12;
			this.lbTavern.Location = new System.Drawing.Point(3, 3);
			this.lbTavern.Name = "lbTavern";
			this.lbTavern.Size = new System.Drawing.Size(303, 219);
			this.lbTavern.TabIndex = 1;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(757, 288);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "角色";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 21);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(757, 288);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "种植";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(941, 463);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "MainForm";
			this.Text = "MJTool";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btClearLog;
		private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editAccToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem delAccToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addAccToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loginAccToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Button btOneKeyForSoul;
		private System.Windows.Forms.ListBox lbTavern;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ColumnHeader chSoulNum;
		private System.Windows.Forms.ColumnHeader chSoulName;
		private System.Windows.Forms.ColumnHeader chSoulQuality;
		private System.Windows.Forms.ListView lvGenSoul;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ColumnHeader chLoginAccount;
		private System.Windows.Forms.ListView lvAccount;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btEmployGeneral;
		private System.Windows.Forms.Button btRefreshGeneral;
		private System.Windows.Forms.Button btGetLuckInfo;
		private System.Windows.Forms.Button btGetLoginAward;
		private System.Windows.Forms.Button btMsgBox;
		private System.Windows.Forms.Button btGetMessage;
		private System.Windows.Forms.Button btGetGift;
		private System.Windows.Forms.TextBox tbLog;
	}
}
