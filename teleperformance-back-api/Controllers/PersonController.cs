using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using teleperformance_back_api.Models;

namespace teleperformance_back_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public Object Get(int identity_number)
        {
            var dict = new Dictionary<string, string>();
            using (var context = new teleperformanceContext())
            {
                
                var found_person = context.People.ToList().Where(p => p.IdentityNumber == identity_number && p.IdentityTypeId == 2).FirstOrDefault();
                if (found_person == null)
                {
                    dict["error"] = "La identificación de la empresa no está registrada";
                    return dict;
                }
                else if (found_person.CanRegister == false)
                {
                    dict["error"] = "La identificación de la empresa no está habilitada para registro";
                    return dict;
                }
                return found_person;
            }
        }

        [HttpPut]
        public String Put()
        {
            try
            {
                using (var context = new teleperformanceContext())
                {
                    var reqObj = new Dictionary<string, string>();
                    using (var reader = new StreamReader(Request.Body))
                    {
                        var body = reader.ReadToEnd();
                        reqObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(body);
                    }
                    var found_person = context.People.ToList().Where(p => p.Id == Convert.ToInt32(reqObj["person_id"])).FirstOrDefault();
                    found_person.AllowEmailMessage = Convert.ToBoolean(reqObj["allow_email_message"]);
                    found_person.AllowPhoneMessage = Convert.ToBoolean(reqObj["allow_phone_message"]);
                    found_person.CompanyName = reqObj["company_name"];
                    found_person.FirstName = reqObj["first_name"];
                    found_person.SecondName = reqObj["second_name"];
                    found_person.FirstLastName = reqObj["first_last_name"];
                    found_person.SecondName = reqObj["second_last_name"];
                    found_person.Email = reqObj["email"];
                    found_person.IdentityTypeId = Convert.ToInt32(reqObj["identity_type_id"]);
                    found_person.IdentityNumber = Convert.ToInt32(reqObj["identity_number"]);
                    context.SaveChanges();
                    return "0";
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }
    }
}
