using System;
using Newtonsoft.Json;

namespace MeusPedidos
{
	public class Pedido
	{
		public Pedido (string cliente) {
			Cliente = cliente;
		}

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("cliente")]
		public string Cliente { get; set; }

		[JsonProperty("created")]
		public DateTime Created { get; set; }
	}
}

