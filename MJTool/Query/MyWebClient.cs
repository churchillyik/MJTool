using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Collections;
using System.Net;
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
		
		public string HttpQuery(string Uri, byte[] qry_bytes, Encoding enc, out string strEx)
		{
			strEx = "";
			try
			{
				string BaseAddress = string.Format("http://{0}/", strSvrURL);
				CreateRequest(BaseAddress + Uri);
				if (qry_bytes == null)
				{
					return HttpGet(enc);
				}
				else
				{
					return HttpPost(qry_bytes, enc);
				}
			}
			catch (Exception e)
			{
				strEx = e.ToString();
				return "";
			}
		}
		
		private string HttpGet(Encoding enc)
		{
			request.Method = "GET";
			return FetchResponse(enc);
		}
		
		private string HttpPost(byte[] qry_bytes, Encoding enc)
		{
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = qry_bytes.Length;
			
			Stream newStream = request.GetRequestStream();
			newStream.Write(qry_bytes, 0, qry_bytes.Length);
			newStream.Close();
			
			return FetchResponse(enc);
		}
		
		private string FetchResponse(Encoding enc)
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
						using (StreamReader sr = new StreamReader(zipStream, enc))
							result = sr.ReadToEnd();
				}
			}
			else
			{
				using(Stream streamReceive = response.GetResponseStream())
				{
					using(StreamReader sr = new StreamReader(streamReceive, enc))
						result = sr.ReadToEnd();
				}
			}

			return result;
		}
	}
}