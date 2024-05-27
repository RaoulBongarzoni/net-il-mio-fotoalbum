using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;

namespace net_il_mio_fotoalbum.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult Index()
        {
            var ans = PhotoManager.GetAllPhotos();
            return View(ans);
        }


        public IActionResult Detail(int id)
        {
            var ans = PhotoManager.GetPhotoById(id);
            if(ans == null) {
                return NotFound();
            }
            return View(ans);
        }



    }
}
