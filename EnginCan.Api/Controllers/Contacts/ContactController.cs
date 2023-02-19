using EnginCan.Bll.EntityCore.Abstract.Contacts;
using EnginCan.Dto.Contacts;
using EnginCan.Entity.Models.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnginCan.Api.Controllers.Contacts
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _service;

        /// <summary>
        /// Yapıcı method.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="ContactPermissionRepository"></param>
        /// <param name="customHttpContextAccessor"></param>
        public ContactController(IContactRepository service)
        {
            _service = service;
        }

        /// <summary>
        /// Tüm Contact verilerini getirir.
        /// </summary>
        /// <param name="sicilId">Bordro tekil bilgisidir.</param>
        /// <returns>Istenen bordro detay bilgisini döndürür.</returns>
        [HttpGet, Route("GetAllContact")]
        [Produces("application/json")]
        public IActionResult GetAllContacts()
        {
            var result = _service.GetAllContact();
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Tekil bilgisine göre Contact döndürür
        /// </summary>
        [HttpGet, Route("GetById/{key:int}")]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] int key)
        {
            var result = _service.GetById(key);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Yeni Contact oluşturur
        /// </summary>
        [HttpPost, Route("PostContact")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult PostContact([FromBody] Contact contact)
        {
            var result = _service.AddContact(contact);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Contact Günceller
        /// </summary>
        [HttpPost, Route("UpdateContact")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult Update([FromBody] Contact contact)
        {
            var result = _service.UpdateContact(contact);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Contact Siler
        /// </summary>
        [HttpGet, Route("DeleteContact/{id:int}")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult DeleteContact([FromRoute] int id)
        {
            var result = _service.DeleteContact(id);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// İletişim yanıtını mail olarak gönderir.
        /// </summary>
        [HttpPost, Route("PostResponse")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult PostResponse([FromBody] ResponseDto responseDto)
        {
            var result = _service.PostResponse(responseDto);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }
    }
}
