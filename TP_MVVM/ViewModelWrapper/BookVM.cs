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

        public string Id
        {
            get => Model.Id;
            set
            {
                if (Model == null)
                    return;
                SetProperty(Model?.Id, value, v => Model.Id = v);
            }
        }

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

        public string ImageSmall
        {
            get => Model.ImageSmall;

        }

        public string ImageMedium
        {
            get => Model.ImageMedium;

        }

        public string ImageLarge
        {
            get => Model.ImageLarge;

        }



        public List<string> Publishers
        {
            get => Model.Publishers;

        }

        public DateTime PublishDate
        {
            get => Model.PublishDate;
            set
            {
                if (Model == null)
                    return;
                SetProperty(Model.PublishDate, value, v => Model.PublishDate = value);

            }
        }

        public string Author => Model.Authors.Count > 0 ? Model.Authors.First().Name : "Auteur inconnu";

        public List<AuthorVM> Authors
        {
            get => Model.Authors.Select(v => new AuthorVM(v)).ToList();
        }



        public Status Status
        {
            get => Model.Status;
            set
            {
                if (Model == null)
                    return;
                SetProperty(Model.Status, value, v => Model.Status = value);

            }
        }

        public float? UserRating
        {
            get => Model?.UserRating;
            set
            {
                if (Model == null)
                    return;
                SetProperty(Model.UserRating, value, rating => Model.UserRating = rating);
            }
        }


        public BookVM(Book model)
            : base(model)
        {
        }

    }
}
