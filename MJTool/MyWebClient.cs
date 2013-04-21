using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Collections;
using System.Net;
using System.Web;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MJTool
{
	public class MyWebClient
	{
		public string strSvrURL;
		private WebProxy pxy = null;
		
		private HttpWebRequest request;
		private CookieContainer cookies = null;
		public string strCurCookie = null;
		private string strLastQueryPageURI = null;
		public MyWebClient(string svr_url, string pxy_addr)
		{
			strSvrURL = svr_url;
			if (pxy != null)
			{
				pxy = new WebProxy(pxy_addr);
			}
		}
		
		private void CreateRequest(string Uri)
		{
			request = (HttpWebRequest)WebRequest.Create(Uri);
			if (pxy != null)
			{
				request.Proxy = pxy;
			}
			if (cookies == null)
			{
				cookies = new CookieContainer();
			}
			request.CookieContainer = cookies;
			if (strLastQueryPageURI != null)
			{
				request.Referer = strLastQueryPageURI;
			}
			strLastQueryPageURI = Uri;
			request.Timeout = 30000;
			request.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:13.0) Gecko/20100101 Firefox/13.0.1";
			request.Accept = "application/json, text/javascript, */*; q=0.01";
			request.Headers.Add("Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3");
			request.Headers.Add("Accept-Encoding", "gzip, deflate");
			request.Headers.Add("Accept-Charset", "GB2312,utf-8;q=0.7,*;q=0.7");
			request.ServicePoint.Expect100Continue = false;
			request.KeepAlive = true;
		}
		
		public string HttpQuery(string Uri, Dictionary<string, string> Data, out string strEx)
		{
			strEx = "";
			try
			{
				string BaseAddress = string.Format("http://{0}/", strSvrURL);
				CreateRequest(BaseAddress + Uri);
				if (Data == null)
				{
					return HttpGet();
				}
				else
				{
					return HttpPost(Data);
				}
			}
			catch (Exception e)
			{
				strEx = e.ToString();
				return "";
			}
		}
		
		private string HttpGet()
		{
			request.Method = "GET";
			return FetchResponse();
		}
		
		private string HttpPost(Dictionary<string, string> Data)
		{
			request.Method = "POST";
			
			string QueryString = null;
			StringBuilder sb = new StringBuilder();
			foreach(KeyValuePair<string, string> x in Data)
			{
				if (sb.Length != 0)
				{
					sb.Append("&");
				}

				// Got to support some weired form data, like arrays
				if (x.Key == "!!!RawData!!!")
				{
					sb.Append(x.Value);
					continue;
				}

				sb.Append(HttpUtility.UrlEncode(x.Key));
				sb.Append("=");
				sb.Append(HttpUtility.UrlEncode(x.Value));
			}
			QueryString = sb.ToString();
			request.ContentType = "application/x-www-form-urlencoded";
			
			ASCIIEncoding encoding = new ASCIIEncoding ();
			byte[] qry_bytes = encoding.GetBytes(QueryString);
			request.ContentLength = qry_bytes.Length;
			
			Stream newStream = request.GetRequestStream();
			newStream.Write(qry_bytes, 0, qry_bytes.Length);
			newStream.Close();
			
			return FetchResponse();
		}
		
		private string FetchResponse()
		{
			string result = null;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			response.Cookies = cookies.GetCookies(request.RequestUri);
			
			foreach (Cookie cook in response.Cookies)
			{
				this.strCurCookie = cook.Value;
			}
			
			if (response.ContentEncoding == "gzip")
			{
				using(Stream streamReceive = response.GetResponseStream())
				{
					using(GZipStream zipStream = new GZipStream(streamReceive, CompressionMode.Decompress))
						using (StreamReader sr = new StreamReader(zipStream, Encoding.UTF8))
							result = sr.ReadToEnd();
				}
			}
			else
			{
				using(Stream streamReceive = response.GetResponseStream())
				{
					using(StreamReader sr = new StreamReader(streamReceive, Encoding.UTF8))
						result = sr.ReadToEnd();
				}
			}

			return result;
		}
	}
}