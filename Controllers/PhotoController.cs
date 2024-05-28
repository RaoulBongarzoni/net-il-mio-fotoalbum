using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;
using System.Reflection;


namespace net_il_mio_fotoalbum.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult Index()
        {
            
            return View("Index",PhotoManager.GetAllPhotos());
        }


        public IActionResult Detail(int id)
        {
            var ans = PhotoManager.GetPhotoById(id);
            if(ans == null) {
                return NotFound();
            }
            return View(ans);
        }


        [HttpGet] //restituisce alla view la foto da creare tramite form
        public IActionResult Create()
        {
            PhotoFormModel model = new PhotoFormModel();
            model.Photo = new PhotoModel();
            model.GetCategories(); //in questo punto 
            return View(model);

        }


        [HttpPost]

        public IActionResult Create(PhotoFormModel model) //qui mi prendo il modello con i dati della foto e le categorie selezionate
        {
            if (!ModelState.IsValid)
            {
                
                //se i dati che ci vengono passati non sono validi ritorno alla view create con i dati appena inseriti
                model.GetCategories();
                return View("Create", model);
            }
            model.SetImageFileFromFile();
            //se i dati sono validi e corretti inserisco la foto nel db
            PhotoManager.GeneratePhoto(model.Photo , model.SelectedCategories );

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Update(int id) {

            var photoToUpdate = PhotoManager.GetPhotoById(id);

            if(photoToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                PhotoFormModel model = new PhotoFormModel(photoToUpdate);
                model.GetCategories();
                return View(model);
            }
        
        }






        [HttpPost]
        public IActionResult Update(int id, PhotoFormModel data) {
        
            if(ModelState.IsValid)
            {
                data.GetCategories();
                return View("update", data);


            }
            var imgFile = data.SetImageFileFromFile();
            if (PhotoManager.UpdatePhoto(id, data.Photo.Title, data.Photo.Description, data.Photo.Visible, data.SelectedCategories, imgFile))
                return RedirectToAction("index");
            else
                return NotFound();

        
        }














    }
}
