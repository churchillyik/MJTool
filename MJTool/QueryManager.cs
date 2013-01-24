/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2012-7-8
 * Time: 11:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MJTool
{
	public partial class QueryManager
	{
		public event EventHandler<UIUpdateArgs> OnUIUpdate;
		private object SycLock = new object();
		
		public QueryManager()
		{
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
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
}
