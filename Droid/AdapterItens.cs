
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

namespace MeusPedidos.Droid
{
	public class AdapterItensMain : BaseAdapter {

		List<ItemPedido> items;
		Activity context;

		public AdapterItensMain(Activity context, List<ItemPedido> items) : base() {
			this.context = context;
			this.items = items;
		}

//		public override Object GetItem(int position) {  
////			return items[position];
//		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId(int position) {
			return position;
		}

		public override int Count {
			get { return items.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent) {
			ItemPedido item = items [position];
//			LayoutInflater inflater = context.GetSystemService (Context.LayoutInflaterService);
//			View view = inflater.Inflate (Resource.Layout.Item, null);
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.Item, null);
			view.FindViewById<TextView>(Resource.Id.tv_nome).Text = item.Nome;
			view.FindViewById<TextView>(Resource.Id.tv_quantidade).Text = item.Quantidade.ToString();
			view.FindViewById<TextView>(Resource.Id.tv_preco).Text = item.Preco.ToString();
//			TextView nome = FindViewById<TextView> (Resource.Id.tv_nome);
//			nome.Text = item.Nome;
//			TextView quantidade = FindViewById<TextView> (Resource.Id.tv_quantidade);
//			quantidade.Text = item.Quantidade;
//			TextView preco = FindViewById<TextView> (Resource.Id.tv_preco);
//			preco.Text = item.Preco;
			 return view;
		}

	}
}

