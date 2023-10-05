using Model;
using MyToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelWrapper
{
    public class BookVM : BaseViewModel<Book>
    {

        public string Title
        {
          get => Model.Title;
          set
            {
                if (Model == null)
                    return;
                SetProperty(Model?.Title, value, v => Model.Title = v);
            }
        }

        public BookVM()
        {
        }

    }
}
