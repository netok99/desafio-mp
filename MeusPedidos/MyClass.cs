using System;

namespace MeusPedidos
{
	public class MyClass
	{
		public MyClass ()
		{
		}

		public string HelloWorld (){
			#if __IOS__
				return null;
			#endif

			#if __ANDROID__
				return null;
			#endif
			return null;
		}
	}
}


