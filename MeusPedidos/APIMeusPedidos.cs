using System;
//using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;

namespace MeusPedidos
{
	public class APIMeusPedidos
	{
		const string ENDPOINT = "http://localhost:8000/";
		public APIMeusPedidos ()
		{
		}

//		public List<Pedido> MakePedido (Pedido pedido) {
//			//adiciona ou atualiza um pedido
//
////			var client = new RestClient(ENDPOINT);
//			// client.Authenticator = new HttpBasicAuthenticator(username, password);
//
////			var request = new RestRequest("pedido/{id}", HttpMethod.Post);
////			request.AddParameter("cliente", pedido.Cliente); // adds to POST or URL querystring based on Method
////			// request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
//
////			var response = client.Execute(request);
//			using (var client = new RestClient(new Uri(ENDPOINT))) {
//				var request = new RestRequest("pedido/{id}", HttpMethod.Post);
//				request.AddUrlSegment("id", "123");
////				return client.Execute<List<Pedido>>(request);
//			}
//			return null;
//
//		}
//
//		public Pedido SelectPedido (int id = 0) {
//			var client = new RestClient(ENDPOINT);
//			if (id == 0) {
//				var request = new RestRequest ("pedido/", HttpMethod.Get);
////				RestResponse response = client.Execute (request);
//				return null;
//			} else {
//				var request = new RestRequest ("resource/{id}", HttpMethod.Get);
//				request.AddUrlSegment ("id", id);
////				RestResponse response = client.Execute (request);
//				return null;
//			}
//		}
//
//		public void DeletePedido(Pedido pedido) {
//			var client = new RestClient(ENDPOINT);
//			var request = new RestRequest("resource/{id}", HttpMethod.Post);
//		}
//
//		public void MakeItemPedido (ItemPedido item) {
//			//adiciona ou atualiza um pedido
//			var client = new RestClient(ENDPOINT);
//			var request = new RestRequest("resource/{id}", HttpMethod.Post);
//			request.AddParameter("name", "value");
//			request.AddUrlSegment("id", "123");
//			request.AddHeader("header", "value");
//		}
//
//		public void DeleteItemPedido(ItemPedido item) {
//			var client = new RestClient(ENDPOINT);
//			var request = new RestRequest("resource/{id}", HttpMethod.Post);
//		}

	}
}

