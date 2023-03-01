using Assignment_One_Revise.Dto;
using Assignment_One_Revise.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_One_Revise.Controllers
{
    [ApiController]
    [Route("albums")]
    public class AlbumController : BaseController<AlbumController>
    {
        private readonly IAlbumService _albumService;
        public AlbumController(ILogger<AlbumController> logger, IAlbumService albumService) : base(logger)
        {
            _albumService = albumService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAlbum([FromBody] string name)
        {
            NewAlbumDto newAlbum = new NewAlbumDto();
            newAlbum.Name = name;
            try
            {
                _logger.LogInformation("New Album is created:");
                return Ok(_albumService.Add(newAlbum));
            }catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{album_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAlbum(Guid album_id)
        {
            var album = await _albumService.FindById(album_id);
            if(album == null)
            {
                return NotFound();
            }
            try
            {                
                _logger.LogInformation("New Album is deleted:"+album_id);
               return (IActionResult)await _albumService.Delete(album);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListAlbums()
        {
            try
            {
                return await _albumService.GetAll();
            }catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
