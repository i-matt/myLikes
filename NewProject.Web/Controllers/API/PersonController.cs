using NewProject.Models.Domain;
using NewProject.Models.Requests;
using NewProject.Models.Response;
using NewProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewProject.Web.Controllers.API
{
    [RoutePrefix("api/people")]
    public class PersonController : ApiController
    {
        // GET api/<controller>
        [Route("getall")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                PersonService svc = new PersonService();
                ItemListResponse<Person> resp = new ItemListResponse<Person>();
                resp.Items = svc.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

        // GET api/<controller>/5
        [Route("getbyid/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Get By Id");
        }

        // POST api/<controller>
        [Route]
        public HttpResponseMessage Post(PersonAddRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = "me";
                    PersonService svc = new PersonService();
                    ItemResponse<int> resp = new ItemResponse<int>();
                    resp.Item = svc.Insert(model);
                    return Request.CreateResponse(HttpStatusCode.OK, resp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}