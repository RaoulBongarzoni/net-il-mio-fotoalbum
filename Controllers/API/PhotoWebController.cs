using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;

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

        [HttpGet]
        public IActionResult GetItemById(int id)
        {
            var Post = PhotoManager.GetPhotoById(id);
            if (Post == null)
                return NotFound("ERRORE");
            return Ok(Post);
        }

        [HttpPost]
        public IActionResult InsertMessage([FromBody] MessageModel model ) {
            PhotoManager.InsertMessage(model);
            return Ok();
        }

    }
}
