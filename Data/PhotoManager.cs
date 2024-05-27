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


    }
}
