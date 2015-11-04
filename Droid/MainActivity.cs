using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RestSharp;
using System.Collections.Generic;
using System.Json;
using System.Net;
using Newtonsoft.Json;


namespace MeusPedidos.Droid
{
	[Activity (Label = "MeusPedidos", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		Pedido pedido;
		List<ItemPedido> itens = new List<ItemPedido>();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			EditText cliente = FindViewById<EditText> (Resource.Id.et_cliente);
			Button adicionarItens = FindViewById<Button> (Resource.Id.bt_itens);
			ListView itensPedido = FindViewById<ListView> (Resource.Id.list_itens);
			TextView total = FindViewById<TextView> (Resource.Id.tv_total);
			Button adicionarPedido = FindViewById<Button> (Resource.Id.btn_add);
			Button cancelarPedido = FindViewById<Button> (Resource.Id.btn_cancelar);

			try {
				List<ItemPedido> list = JsonConvert.DeserializeObject<List<ItemPedido>>(Intent.GetStringExtra("itens"));
				total.Text = Intent.GetStringExtra("total");
				if (list != null) {
					itensPedido.Adapter = new AdapterItensMain (this, list);
				}
			} catch (Exception e) { }

			adicionarItens.Click += (object sender, EventArgs e) => {
				if ( cliente.Text.Trim() != "" ){
					pedido = new Pedido(cliente.Text);
					Intent intent = new Intent(this, typeof(ItensActivity));
					StartActivity(intent); 
				} else
					Toast.MakeText(this, "Informe o nome do cliente", ToastLength.Long).Show();
			};

			cancelarPedido.Click += (object sender, EventArgs e) => {
				itens.Clear();
				itensPedido.Adapter = new AdapterItensMain (this, itens);
			};

			adicionarPedido.Click += (object sender, EventArgs e) => {
				Api api = new Api();
				//salvar pedido
//				pedido = new Pedido (cliente.Text);
				string result = api.HttpPostRequest("pedido/", new Dictionary<string, string>() { {"cliente", cliente.Text} });

				foreach (ItemPedido item in itens) { //save itenns Pedidos
//					api.HttpPostRequest("itenspedidos",new Dictionary<string, string>(){
//						{"nome", item.Nome},
//						{"preco", item.Preco.ToString()},
//						{"quantidade", item.Quantidade.ToString()},
//						{"pedido", pedido}
//					});  	
				}

//				if (response.StatusCode > 399) {
//					Toast.MakeText(this, "Erro ao processar o pedido", ToastLength.Long).Show();
//				}
				Toast.MakeText(this, "Pedido Cadastrado com sucesso.", ToastLength.Long).Show();
			};
		}
	}
}


