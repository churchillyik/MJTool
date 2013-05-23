
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MJTool
{
	/// <summary>
	/// Description of AccEditForm.
	/// </summary>
	public partial class AccEditForm : Form
	{
		public AccEditForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public Account accResult = null;
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			if (accResult == null)
			{
				accResult = new Account(this.tbName.Text, this.tbPswd.Text);
			}
			else
			{
				accResult.strUserName = this.tbName.Text;
				accResult.strPassword = this.tbPswd.Text;
			}
		}
		
		void AccEditFormLoad(object sender, EventArgs e)
		{
			if (accResult == null)
			{
				return;
			}
			
			this.tbName.Text = accResult.strUserName;
			this.tbPswd.Text = accResult.strPassword;
		}
	}
}
