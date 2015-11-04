using System;

namespace MeusPedidos
{
	public class Pedido
	{
		
		public Pedido (string cliente) {
			Cliente = cliente;
		}

		public string Cliente { get; set; }
		public DateTime Created { get; set; }
	}
}

