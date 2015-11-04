using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace MeusPedidos.Droid
{
	[Activity (Label = "Itens")]			
	public class ItensActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Itens);

			List<ItemPedido> itensPedido = new List<ItemPedido>();
			EditText nome = FindViewById<EditText> (Resource.Id.et_nome);
			EditText preco = FindViewById<EditText> (Resource.Id.et_preco);
			EditText quantidade = FindViewById<EditText> (Resource.Id.et_quantidade);
			Button addItem = FindViewById<Button> (Resource.Id.bt_adicionar_item);
			Button finalizar = FindViewById<Button> (Resource.Id.bt_finalizar);
			ListView itens = FindViewById<ListView> (Resource.Id.list_item);
			float total = 0; 

			addItem.Click += (object sender, EventArgs e) => {
				if (nome.Text.Trim() == "" && preco.Text.Trim() == "" && quantidade.Text.Trim() == ""){
					Toast.MakeText(this, "Preencha os campos acima", ToastLength.Long).Show();
				} else {
					itensPedido.Add(new ItemPedido(nome.Text, float.Parse(preco.Text), float.Parse(quantidade.Text), new Pedido("eu")));
					itens.Adapter = new AdapterItensMain (this, itensPedido);
					total =  total + (float.Parse(preco.Text) * float.Parse(quantidade.Text));
				}
			};

			finalizar.Click += (object sender, EventArgs e) => {
				itens.Adapter = new AdapterItens (this, itensPedido);
				Intent intent = new Intent(this, typeof(MainActivity));
				intent.PutExtra("itens", JsonConvert.SerializeObject(itensPedido));
				intent.PutExtra("total", total.ToString()); 
				StartActivity(intent);
				Finish();
			};
		}
	}
}

