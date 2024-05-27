using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using net_il_mio_fotoalbum.Data;
namespace net_il_mio_fotoalbum.Models
{
    public class PhotoFormModel
    {

        public PhotoModel Photo { get; set; }

        public List<SelectListItem>? Categories { get; set; }
        public List<string>? SelectedCategories { get; set; }

        public IFormFile? ImageFormFile { get; set; }


        public PhotoFormModel() { }



        public void GetCategories() //funzione che mi genera tutte le categorie collegate ad una singola foto
        {
            this.Categories = new List<SelectListItem>();
            this.SelectedCategories = new List<string>();

            var categoriesFromDb = PhotoManager.GetAllCategories();
            foreach (var category in categoriesFromDb)
            {
                bool isSelected = this.Photo.CategoriesList?.Any(c => c.Id == category.Id) == true;
                //se la categoria è PRESENTE nella lista nella foto me la restituisce con il valore "selezionata" = true
                this.Categories.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString(),
                    Selected = isSelected
                });
                if (isSelected)
                {
                    this.SelectedCategories.Add(category.Id.ToString());
                }
            }
        }

        //(da IFromFile a byte[])
        public void SetImageFileFromFile()

        {
            if(this.ImageFormFile == null)
            {
                return;
            }
            using var stream = new MemoryStream();
            this.ImageFormFile?.CopyTo(stream);
            Photo.ImgFile = stream.ToArray();

;
        }

    }
}
