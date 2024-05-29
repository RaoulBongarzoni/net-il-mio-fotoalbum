using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;

namespace net_il_mio_fotoalbum.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotoWebController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllPosts(string? name)
        {
            if (name == null)
                return Ok(PhotoManager.GetAllVisiblePhotos());
            return Ok(PhotoManager.GetVisiblePhotosSearch(name)); // ritorna soltanto i post che contengono name nel titolo
        }

    }
}
