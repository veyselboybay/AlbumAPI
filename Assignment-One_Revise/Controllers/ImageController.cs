using Assignment_One_Revise.Dto;
using Assignment_One_Revise.Models;
using Assignment_One_Revise.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_One_Revise.Controllers
{
    [ApiController]
    [Route("albums/{album_id}")]
    public class ImageController : BaseController<ImageController>
    {
        private readonly IImageService _imageService;
        private readonly IAlbumService _albumService;
        public ImageController(ILogger<ImageController> logger, IImageService imageService, IAlbumService albumService) : base(logger)
        {
            _imageService = imageService;
            _albumService = albumService;
        }

        [HttpPost("images")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UploadImage(Guid album_id, [FromBody] string caption)
        {
            var album = await _albumService.FindById(album_id);
            if(album== null)
            {
                _logger.LogError("Album not found");
                return NotFound();
            }
            NewImageDto newImage = new NewImageDto();
            newImage.AlbumId = album_id;
            newImage.Caption = caption;
            try
            {
                _logger.LogInformation("New image is uploaded:");
                return Ok(_imageService.Add(newImage));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("images/{image_id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteImage(Guid album_id, Guid image_id)
        {
            //check if albums exists
            var album = await _albumService.FindById(album_id);
            if (album == null)
            {
                _logger.LogError("Album not found");
                return NotFound();
            }
            //check if image exists
            var image = await _imageService.FindById(image_id);
            if (image == null)
            {
                _logger.LogError("Image not found");
                return NotFound();
            }
            //check if image belongs to album
            if(image.AlbumId != album_id)
            {
                _logger.LogError("Unatuhorized!");
                return Unauthorized();
            }
            //Delete image
            try
            {
                _logger.LogInformation("Image is deleted:"+image_id);
                return Ok(_imageService.Delete(image));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImages(Guid album_id)
        {
            //check if albums exists
            var album = await _albumService.FindById(album_id);
            if (album == null)
            {
                _logger.LogError("Album not found");
                return NotFound();
            }
            IEnumerable<Image> images = await _imageService.GetAll();
            if(images == null)
            {
                _logger.LogError("No Images");
                return NotFound();
            }

            try
            {
                return Ok(images.Where(i => i.AlbumId == album_id).ToList());
                
            } catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("images/{image_id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetImage(Guid album_id, Guid image_id)
        {
            //check if albums exists
            var album = await _albumService.FindById(album_id);
            if (album == null)
            {
                _logger.LogError("Album not found");
                return NotFound();
            }
            //check if image exists
            var image = await _imageService.FindById(image_id);
            if (image == null)
            {
                _logger.LogError("Image not found");
                return NotFound();
            }
            //check if image belongs to album
            if (image.AlbumId != album_id)
            {
                _logger.LogError("Unatuhorized!");
                return Unauthorized();
            }
            //Return Image
            try
            {
                return Ok(image);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
