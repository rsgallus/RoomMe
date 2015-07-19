﻿using RoomMe.Webservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RoomMe.Webservice.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {

        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET: api/Account
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("register")]
        // POST: api/Account
        public async Task<HttpResponseMessage> Register([FromUri] string email, [FromUri] string name, [FromUri] int age, [FromUri] int gender, [FromUri] string phone, [FromUri] string authToken)
        {
            User newUser = new User()
            {
                Email = email,
                Name = name,
                Age = age,
                Bio = "",
                Gender = (Gender) gender,
                PhoneNumber = phone,
                Status = Status.NeedsHousingAndRoommate,
                AuthToken = authToken
            };

            var context = new RoomMeWebserviceContext();

            try
            {
                context.Users.Add(newUser);
                await context.SaveChangesAsync();
                return Request.CreateResponse(HttpStatusCode.OK, newUser.UserID);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, false);
            }

        }

        // POST: api/Account
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
