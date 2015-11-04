using System;
//using RestSharp;
using System.Collections.Generic;
using RestSharp.Extensions.MonoHttp;
using System.Net;
using System.Text;
using System.IO;

namespace MeusPedidos.Droid
{
	public class Api
	{

		private const string ENDPOINT = "http://localhost:8000/";

		public Api () {}

		public string HttpPostRequest(string uri, Dictionary<string,string> postParameters)
		{
			string url = ENDPOINT + uri;
			string postData = "";
			foreach (string key in postParameters.Keys) {
				postData += HttpUtility.UrlEncode (key) + "=" + HttpUtility.UrlEncode (postParameters [key]) + "&";
			}

			try {
				byte[] data = System.Text.Encoding.ASCII.GetBytes(postData);
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create( url );
				myHttpWebRequest.Method = "POST";
				myHttpWebRequest.ContentType = "application/json";
				myHttpWebRequest.ContentLength = data.Length;
				Stream requestStream = myHttpWebRequest.GetRequestStream();
				requestStream.Write(data, 0, data.Length);
				requestStream.Close();
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
				Stream responseStream = myHttpWebResponse.GetResponseStream();
				StreamReader myStreamReader = new StreamReader(responseStream, System.Text.Encoding.Default);
				string pageContent = myStreamReader.ReadToEnd();
				myStreamReader.Close();
				responseStream.Close();
				myHttpWebResponse.Close();
//				return pageContent;
				return myHttpWebResponse.StatusCode.ToString();
			} catch ( Exception e ) {
				Android.Util.Log.Error("http errror", e.Message );
				return(e.Message);
			}
		}
	}

}

