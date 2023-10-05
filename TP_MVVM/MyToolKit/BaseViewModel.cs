using System;
namespace MyToolKit
{
	public class BaseViewModel < TModel > : ObservableObject
	{

		private TModel model;
		public TModel Model
		{
			get => model;
			private set
			{
				SetProperty(ref model, value);
			}
		}

		public BaseViewModel(TModel model)
		{
			Model = model;
		}
		public BaseViewModel()
		{
			Model = default(TModel);
		}
	}

    public class BaseViewModel : ObservableObject { }

}

