using System;
using System.Collections.Generic;

namespace MJTool
{
	partial class QueryManager
	{
		private MyWebClient webClient = null;
		
		enum QueryStatus
		{
			NotLogined,
			Logined,
			QueryReady,
			QueryFinish,
		};
		
		private QueryStatus QrySta = QueryStatus.NotLogined;
		public string PageQuery(string strSvr, string strURL, Dictionary<string, string> dicPostData)
		{
			DebugLog(strSvr + "/" + strURL);
			if (this.webClient == null)
			{
				this.webClient = new MyWebClient(strSvr, null);
			}
			
			webClient.strSvrURL = strSvr;
			
			if (this.QrySta != QueryStatus.NotLogined)
			{
				this.QrySta = QueryStatus.QueryReady;
			}
			
			
			string strEx = "";
			string result;
			
			//	直到访问网页有返回时结束
			while (true)
			{
				result = webClient.HttpQuery(strURL, dicPostData, out strEx);
				if (strEx != "")
				{
					DebugLog("访问：[" + strURL + "]时发生异常，接着重试");
					DebugLog(strEx.Substring(0, strEx.IndexOfAny(new char [] {'\r', '\n'})));
				}
				else
				{
					break;
				}
			}
			
			if (CheckIfLogined(result))
			{
				this.QrySta = QueryStatus.QueryFinish;
			}
			else
			{
				this.QrySta = QueryStatus.NotLogined;
			}
			
			return result;
		}

	}
}