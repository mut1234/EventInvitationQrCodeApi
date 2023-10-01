using EventInvitationQrCodeApi.Data;
using EventInvitationQrCodeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System.Drawing;


namespace EventInvitationQrCodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EventController(ApplicationDbContext db)
        {
            _db = db;
        }
                
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> Getclients()
        {
            var result = await _db.Users.Include(e=>e.QrCode).ToListAsync();

            return Ok(result);

        }
       

        [HttpGet("{id:int}", Name = "GetClientById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetClientId(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }

            var Client = await _db.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (Client == null)
            {
                return NotFound();
            }
            return Ok(Client);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> CreateClient([FromBody] User User)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(User);
            }
            if (User == null)
            {
                return BadRequest(User);
            }
            if (User.UserId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            await _db.Users.AddAsync(User);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetUserById", new { id = User.UserId }, User);

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)//IActionResult you can not return with it
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _db.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (result != null)
            {
                _db.Users.Remove(result);
                await _db.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("GenrateQRCode")]
        public async Task<IActionResult> GenrateQRCode(String QRcCodeText)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();

            QRCodeData _qrCodeData = _qrCode.CreateQrCode(QRcCodeText, QRCodeGenerator.ECCLevel.Q);

            BitmapByteQRCode qrCode = new BitmapByteQRCode(_qrCodeData);

            string base64String = Convert.ToBase64String(qrCode.GetGraphic(20));
        
            byte[] bytes = Convert.FromBase64String(base64String);
         
            return File(bytes, "image/bmp");
        }

    }
}
