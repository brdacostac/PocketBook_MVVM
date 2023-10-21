using System;
using Model;
using MyToolKit;

namespace ViewModelWrapper
{
	public class AuthorVM : BaseViewModel<Author>
	{

        private int nbBooksByAuthor { get; set; }

        public int NbBooksByAuthor
        {
            get => nbBooksByAuthor;
            set
            {
                nbBooksByAuthor = value;
            }
        }

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

