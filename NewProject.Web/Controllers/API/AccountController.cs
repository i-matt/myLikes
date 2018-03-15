using NewProject.Models.Domain;
using NewProject.Models.Requests;
using NewProject.Models.Response;
using NewProject.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewProject.Web.Controllers.API
{
    [RoutePrefix("api/accounts")]
    public class AccountController : ApiController
    {
        // GET api/<controller>
        [Route("getall")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                AccountService svc = new AccountService();
                ItemListResponse<Account> resp = new ItemListResponse<Account>();
                resp.Items = svc.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET api/<controller>/5
        [Route("{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                AccountService svc = new AccountService();
                ItemResponse<Account> resp = new ItemResponse<Account>();
                resp.Item = svc.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST api/<controller>
        [Route, HttpPost]
        public HttpResponseMessage Post(AccountAddRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = "me";
                    AccountService svc = new AccountService();
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
        [Route("{id:int}")]
        public HttpResponseMessage Put(AccountUpdateRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = "you";
                    AccountService svc = new AccountService();
                    svc.Update(model);
                    SuccessResponse resp = new SuccessResponse();
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

        // DELETE api/<controller>/5
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                AccountService svc = new AccountService();
                svc.Delete(id);
                SuccessResponse resp = new SuccessResponse();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}