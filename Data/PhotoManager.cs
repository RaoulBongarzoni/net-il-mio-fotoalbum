using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Data

{
    public class PhotoManager
    {


        public static List<PhotoModel> GetAllPhotos()
        {
            using PhotoContext context = new PhotoContext();
            return context.Photos.ToList();

        }

        public static List<CategoryModel> GetAllCategories()
        {
            using PhotoContext context = new PhotoContext();
            return context.Categories.ToList();

        }
        //restituisce una foto da db tramite ricerca per id, null se non trovato
        public static PhotoModel? GetPhotoById(int photoId, bool categoriesShown = true) { 

            using PhotoContext context = new PhotoContext();
            if (categoriesShown)
                return context.Photos.Where(p => p.Id == photoId).Include(p => p.CategoriesList).FirstOrDefault();
            return context.Photos.Where(p => p.Id == photoId).FirstOrDefault();

        }


       public static void GeneratePhoto(PhotoModel data, List<string> selecetdCategories = null )
       {
            using PhotoContext context = new PhotoContext();
            if (selecetdCategories != null)
            {
                data.CategoriesList = new List<CategoryModel>();
                foreach (var catId in selecetdCategories) {
                    int id = int.Parse(catId);
                    var cat = context.Categories.FirstOrDefault(c => c.Id == id);

                    data.CategoriesList.Add(cat);

                }
            }
            context.Photos.Add(data);
            context.SaveChanges();




       }
       



    }
}
