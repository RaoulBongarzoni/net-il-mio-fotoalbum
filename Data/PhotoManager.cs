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

        public static List<CategoryModel> GetAllcategories()
        {
            using PhotoContext context = new PhotoContext();
            return context.Categories.ToList();

        }

        public static PhotoModel? GetPhotoById(int photoId, bool categoriesShown = true) { 

            using PhotoContext context = new PhotoContext();
            if (categoriesShown)
                return context.Photos.Where(p => p.Id == photoId).Include(p => p.CategoriesList).FirstOrDefault();
            return context.Photos.Where(p => p.Id == photoId).FirstOrDefault();

        }

    }
}
