using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BusinessEntities;
using WebApi.BusinessServices;
using WebApi.DataModels;

namespace WebApi.Api.Controllers
{
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
        public ActionResult<IEnumerable<ValueEntity>> Get()
        {
            return _services.GetValuesList().ToList();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ValueEntity> AddValue(ValueEntity value)
        {
            return _services.Add(value);
        }
    }
}
