using System;
using Model;
using MyToolKit;

namespace ViewModelWrapper
{
	public class AuthorVM : BaseViewModel<Author>
	{

        public string Name
        {
            get => Model.Name;
            set
            {
                if (Model == null)
                    return;
                SetProperty(Model?.Name, value, v => Model.Name = v);
            }
        }

        public AuthorVM(Author model)
            : base(model)
        {
		}
	}
}

