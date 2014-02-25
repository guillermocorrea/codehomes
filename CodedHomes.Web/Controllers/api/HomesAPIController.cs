using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using CodedHomes.Data;
using CodedHomes.Models;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace CodedHomes.Web.Controllers
{
    [Authorize]
    public class HomesAPIController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Home> Get()
        {
            return _unit.Homes.GetAll();
        }

        [HttpGet]
        [Authorize(Roles = "admin, manager, user")]
        public Home Get(int id)
        {
            Home home = _unit.Homes.GetById(id);
            if (home == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            return home;
        }

        [Authorize(Roles = "admin, manager, user")]
        public HttpResponseMessage Put(int id, Home home)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != home.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Home existingHome = _unit.Homes.GetById(id);
            _unit.Homes.Detach(existingHome);

            // Keep original CreatedOn
            home.CreatedOn = existingHome.CreatedOn;

            _unit.Homes.Update(home);

            try
            {
                _unit.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "{success:'true', verb:'PUT'}");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Authorize(Roles = "admin, manager, user")]
        public HttpResponseMessage Post(Home home)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.Homes.Add(home);
                    this._unit.SaveChanges();
                    HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.Created, home);
                    result.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = home.Id }));
                    return result;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Authorize(Roles = "admin, manager")]
        public HttpResponseMessage Delete(int id)
        {
            Home home = _unit.Homes.GetById(id);
            if (home == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            this._unit.Homes.Delete(home);

            try
            {
                this._unit.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, home);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}