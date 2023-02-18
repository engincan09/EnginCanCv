using EnginCan.Bll.EntityCore.Abstract.Systems;
using EnginCan.Bll.EntityCore.Concrete.Systems;
using EnginCan.Entity.Models.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnginCan.Api.Controllers.Systems
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingRepository _service;

        /// <summary>
        /// Yapıcı method.
        /// </summary>
        /// <param name="service"></param>
        public SettingController(ISettingRepository service)
        {
            _service = service;
        }

        /// <summary>
        /// Tekil bilgisine göre sistem ayarı döndürür
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
        /// Sistem ayarı Günceller
        /// </summary>
        [HttpPost, Route("UpdateSetting")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult Update([FromBody] Setting Setting)
        {
            var result = _service.UpdateSetting(Setting);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

    }
}
