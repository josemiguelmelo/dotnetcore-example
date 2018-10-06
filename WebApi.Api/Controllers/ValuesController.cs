using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi.Api.Exceptions;
using WebApi.BusinessEntities;
using WebApi.BusinessServices;
using WebApi.DataModels;

namespace WebApi.Api.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValueService _services;

        public ValuesController(IValueService _services)
        {
            this._services = _services;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<List<ValueEntity>> Get()
        {
            return Ok(_services.GetValuesList().ToList());
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ValueEntity> AddValue([FromBody] ValueEntity value)
        {
            try
            {
                return CreatedAtAction("POST", _services.Add(value));
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorMessage() { message = "Could not create value.", code = ErrorCodes.NotCreatedModel });
            }
        }
    }
}
