using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teleperformance_back_api.Models;

namespace teleperformance_back_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityTypeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            using(var context = new teleperformanceContext())
            {
                return context.IdentityTypes.ToList().Select(u => new {
                    ID = u.Id,
                    Type = u.Type1
                });
            }
        }
    }
}
