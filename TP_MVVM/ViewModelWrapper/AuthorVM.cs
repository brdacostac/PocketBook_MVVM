using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;


namespace ViewModelWrapper
{
	public class AuthorVM : ObservableObject
	{
        public Author Model { get; }
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
        {
            Model = model;
		}
	}
}

