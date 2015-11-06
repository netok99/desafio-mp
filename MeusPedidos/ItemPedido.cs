using System;
using Newtonsoft.Json;

namespace MeusPedidos
{
	public class ItemPedido
	{
		public ItemPedido (string nome, float preco, int quantidade, int pedido) {
			Nome = nome;
			Preco = preco;
			Quantidade = quantidade;
			Pedido = pedido;
		}

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("nome")]
		public string Nome { get; set; }

		[JsonProperty("preco")]
		public float Preco { get; set; }

		[JsonProperty("quantidade")]
		public int Quantidade { get; set; }

		[JsonProperty("pedido")]
		public int Pedido{ get; set; }

		[JsonProperty("created")]
		public DateTime Created { get; set; } 
	}
}