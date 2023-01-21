using EnginCan.Bll.EntityCore.Abstract.Qualifications;
using EnginCan.Entity.Models.Qualifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnginCan.Api.Controllers.Qualifications
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationRepository _service;

        /// <summary>
        /// Yapıcı method.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="QualificationPermissionRepository"></param>
        /// <param name="customHttpContextAccessor"></param>
        public QualificationController(IQualificationRepository service)
        {
            _service = service;
        }

        /// <summary>
        /// Tüm Qualification verilerini getirir.
        /// </summary>
        /// <param name="sicilId">Bordro tekil bilgisidir.</param>
        /// <returns>Istenen bordro detay bilgisini döndürür.</returns>
        [HttpGet, Route("GetAllQualification")]
        [Produces("application/json")]
        public IActionResult GetAllQualifications()
        {
            var result = _service.GetAllQualification();
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Tekil bilgisine göre Qualification döndürür
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
        /// Yeni Qualification oluşturur
        /// </summary>
        [HttpPost, Route("PostQualification")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult PostQualification([FromBody] Qualification Qualification)
        {
            var result = _service.AddQualification(Qualification);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Qualification Günceller
        /// </summary>
        [HttpPost, Route("UpdateQualification")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult Update([FromBody] Qualification Qualification)
        {
            var result = _service.UpdateQualification(Qualification);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Qualification Siler
        /// </summary>
        [HttpGet, Route("DeleteQualification/{id:int}")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult DeleteQualification([FromRoute] int id)
        {
            var result = _service.DeleteQualification(id);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }
    }
}
