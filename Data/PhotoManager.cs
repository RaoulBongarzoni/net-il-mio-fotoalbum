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
        //funzione che restituisce tutti i post visibili

        public static List<PhotoModel> GetAllVisiblePhotos()
        {
                using PhotoContext context = new PhotoContext();
                return context.Photos.Where(p => p.Visible == true).ToList();
        }

        //funzione per ricerca 

        public static List<PhotoModel> GetVisiblePhotosSearch(string input)
        {
            using PhotoContext context = new PhotoContext();
            return context.Photos.Where(x => (x.Title.ToLower().Contains(input.ToLower())) && (x.Visible == true)).ToList();
        }


       public static void GeneratePhoto(PhotoModel data,  List<string> selecetdCategories = null )
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
            Console.WriteLine(context.Photos);
            context.SaveChanges();




       }

        public static bool UpdatePhoto(int id, string title, string? desc, bool visibility, List<string>? categories, byte[]? newByteImg)
        {
            using PhotoContext context = new PhotoContext();
            var selectedPhoto = context.Photos.Where(x => x.Id == id).Include(x => x.CategoriesList).FirstOrDefault();

            if (selectedPhoto == null)
            {
                return false;

            }

            selectedPhoto.Title = title;
            selectedPhoto.Description = desc;
            selectedPhoto.Visible = visibility;
            if(newByteImg != null)
            {
                selectedPhoto.ImgFile = newByteImg;
            }
            selectedPhoto.CategoriesList.Clear();
            if(categories != null)
            {

                foreach (var category in categories)
                {
                    int catId = int.Parse(category);
                    var categoryModel = context.Categories.FirstOrDefault(x => x.Id == catId);
                    selectedPhoto.CategoriesList.Add(categoryModel);
                }
            }
            context.SaveChanges();
            return true;
           }


        public static bool HardDeleteFromId(int id)
        {
            using PhotoContext context = new PhotoContext();
            var photoToDelete = context.Photos.FirstOrDefault( p => p.Id == id);

            if (photoToDelete == null) {
                return false;
            }

            context.Photos.Remove(photoToDelete);
            context.SaveChanges()
;
            return true;

        }
        public static bool SoftDeleteFromId(int id)
        {
            using PhotoContext context = new PhotoContext();
            var photoToDelete=context.Photos.FirstOrDefault(p => p.Id == id);

            if (photoToDelete == null)
            {
                return false;
            }
            context.Photos.FirstOrDefault(p => p.Id == id).Visible = false;

            context.SaveChanges()
;
            return true;

        }

        public static void InsertMessage(MessageModel message)
        {
            using PhotoContext context = new PhotoContext();
            context.Messages.Add(message);
            context.SaveChanges();
        }




    }
}
