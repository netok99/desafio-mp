using System;
//using RestSharp;
using System.Collections.Generic;
using RestSharp.Extensions.MonoHttp;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MeusPedidos.Droid
{
	public class Api
	{
		private const string ENDPOINT = "http://192.168.10.71:8000/";

		public Api () {}

		public string HttpPostRequest(string uri, string postParameters){
			string url = ENDPOINT + uri;
			try {
				HttpWebRequest request = WebRequest.Create (url) as HttpWebRequest;
				request.Method = "POST";
				request.ContentType = "application/json";

				request.Headers ["Authorization"] = "Basic YWRtaW46YWRtaW4=";
				request.Timeout = 1 * 60 * 1000;

				using (StreamWriter writer = new StreamWriter(request.GetRequestStream())) {
					writer.Write(postParameters);
				}

				using (WebResponse response = request.GetResponse())
				using (Stream responseStream = response.GetResponseStream())
				using (StreamReader streamReader = new StreamReader( responseStream )) {
					var retorno = (JObject.Parse(streamReader.ReadToEnd()) as JObject);
					if(retorno == null){
						throw new JsonReaderException("ExecutarMetodoServidor: Não conseguiu fazer Parse do JSON retornado pelo servidor.");
					}
					return JsonConvert.SerializeObject( retorno );
				}
					
				return "";
			} catch ( Exception e ) {
				Android.Util.Log.Error("http errror", e.Message );
				return(e.Message);
			}
		}
	}

}

