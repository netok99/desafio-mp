using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using RestSharp;
using System.Collections.Generic;
using System.Json;
using System.Net;
//using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;


namespace MeusPedidos.Droid
{
	[Activity (Label = "MeusPedidos", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity {

		List<ItemPedido> itens = new List<ItemPedido>();
		TextView total;
		EditText cliente;
		ListView itensPedido;
		float count = 0;

		protected override void OnCreate (Bundle bundle) {
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			itensPedido = FindViewById<ListView> (Resource.Id.list_itens);
			cliente = FindViewById<EditText> (Resource.Id.et_cliente);
			Button adicionarItens = FindViewById<Button> (Resource.Id.bt_itens);
			total = FindViewById<TextView> (Resource.Id.tv_total);
			Button adicionarPedido = FindViewById<Button> (Resource.Id.btn_add);
			Button cancelarPedido = FindViewById<Button> (Resource.Id.btn_cancelar);

			adicionarItens.Click += (object sender, EventArgs e) => {
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				FragmentDialog dialog = new FragmentDialog();
				if (cliente.Text.Trim() == "") {
					Toast.MakeText(this, "Informe o nome do cliente", ToastLength.Long).Show();
				} else {
					dialog.Show(transaction, "dialog fragment");
					//retorno do dialog
					dialog.dialogComplete += (object s, OnDialogEventArgs ev) => {
						itens.Add(new ItemPedido(ev.Nome, float.Parse(ev.Preco), int.Parse(ev.Quantidade), 1));
						itensPedido.Adapter = new AdapterItensMain (this, itens);
						count += float.Parse(ev.Preco) * float.Parse(ev.Quantidade);   
						total.Text = "R$" + count.ToString();   
					};
				}
			};

			cancelarPedido.Click += (object sender, EventArgs e) => {
				Clear();
			};

			adicionarPedido.Click += (object sender, EventArgs e) => {
				Api api = new Api();
				Pedido retorno = JsonConvert.DeserializeObject<Pedido>(api.HttpPostRequest("pedidos/", JsonConvert.SerializeObject(new Pedido(cliente.Text))));
				foreach (ItemPedido item in itens) {
					api.HttpPostRequest("itenspedidos/", JsonConvert.SerializeObject(new ItemPedido(item.Nome, item.Preco, item.Quantidade, retorno.Id)));
				}
				Toast.MakeText(this, "Pedido Cadastrado com sucesso.", ToastLength.Long).Show();
				Clear();
			};
		}

		void Clear() {
			cliente.Text = "";
			total.Text = "Total : ";
			itens.Clear();
			itensPedido.Adapter = new AdapterItensMain (this, itens);
		}
	}
}


