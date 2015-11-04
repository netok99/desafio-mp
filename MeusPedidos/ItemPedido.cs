using System;

namespace MeusPedidos
{
	public class ItemPedido
	{
		public ItemPedido (string nome, float preco, float quantidade, Pedido pedido) {
			Nome = nome;
			Preco = preco;
			Quantidade = quantidade;
			Pedido = pedido;
		}

		public string Nome { get; set; }
		public float Preco { get; set; }
		public float Quantidade { get; set; }
		public Pedido Pedido{ get; set; }
		public DateTime Created { get; set; }
	}
}

