using EnginCan.Bll.EntityCore.Abstract.Skills;
using EnginCan.Entity.Models.Skills;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnginCan.Api.Controllers.Skills
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository _service;

        /// <summary>
        /// Yapıcı method.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="SkillPermissionRepository"></param>
        /// <param name="customHttpContextAccessor"></param>
        public SkillController(ISkillRepository service)
        {
            _service = service;
        }

        /// <summary>
        /// Tüm Skill verilerini getirir.
        /// </summary>
        /// <param name="sicilId">Bordro tekil bilgisidir.</param>
        /// <returns>Istenen bordro detay bilgisini döndürür.</returns>
        [HttpGet, Route("GetAllSkill")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult GetAllSkills()
        {
            var result = _service.GetAllSkill();
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Tekil bilgisine göre Skill döndürür
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
        /// Yeni Skill oluşturur
        /// </summary>
        [HttpPost, Route("PostSkill")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult PostSkill([FromBody] Skill Skill)
        {
            var result = _service.AddSkill(Skill);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Skill Günceller
        /// </summary>
        [HttpPost, Route("UpdateSkill")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult Update([FromBody] Skill Skill)
        {
            var result = _service.UpdateSkill(Skill);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Skill Siler
        /// </summary>
        [HttpGet, Route("DeleteSkill/{key:int}")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult DeleteSkill([FromRoute] int id)
        {
            var result = _service.DeleteSkill(id);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }
    }
}
