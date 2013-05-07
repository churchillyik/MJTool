using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace MJTool
{
	public partial class QueryManager
	{
		public event EventHandler<UIUpdateArgs> OnUIUpdate;
		private object SycLock = new object();
		
		public QueryManager()
		{
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			init_cmd();
		}
		
		public void DebugLog(string log)
		{
			LogArgs arg = new LogArgs();
			arg.strLog = log;
			arg.uiType = UIUpdateTypes.LogAppending;
			OnUIUpdate(this, arg);
		}
		
		public void ClearLog()
		{
			UIUpdateArgs arg = new UIUpdateArgs();
			arg.uiType = UIUpdateTypes.LogClear;
			OnUIUpdate(this, arg);
		}
		
		void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = e.ExceptionObject as Exception;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(DateTime.Now.ToString());
			sb.AppendLine(ex.Message);
			sb.AppendLine(ex.StackTrace);
			
			FileStream fs = new FileStream("Crash.log", FileMode.Create, FileAccess.Write);
			StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
			sw.Write(sb.ToString());
			sw.Close();
		}
		
		public void Login(string name, string pwd)
		{
			Thread t = new Thread(new ParameterizedThreadStart(doLogin));
			t.Name = "Login";
			t.Start(new LoginParam() { strName = name, strPwd = pwd });
		}
		
		public void SendCommand(CmdArg arg)
		{
			Thread t = new Thread(new ParameterizedThreadStart(doUserCommand));
			t.Name = "SendCommand";
			t.Start(arg);
		}
	}
	
	public enum UIUpdateTypes
	{
		None,
		LogAppending,
		LogClear,
	};
	
	public class UIUpdateArgs : EventArgs
	{
		public UIUpdateTypes uiType;
	};
	
	public class LogArgs : UIUpdateArgs
	{
		public string strLog;
	};
	
	public class LoginParam
	{
		public string strName;
		public string strPwd;
	}
}
