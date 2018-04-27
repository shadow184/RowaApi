﻿using Rowa.Api.Filters;
using Rowa.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Rowa.Api.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/members")]
    public class MembersController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserInformationRepository _userInformationRepository;

        public MembersController(IUserRepository userRepository, IUserInformationRepository userInformationRepository)
        {
            _userRepository = userRepository;
            _userInformationRepository = userInformationRepository;
        }

        [HttpGet]
        [Route("getmembers")]
        [JwtAuthentication]
        public IHttpActionResult GetMembers()
        {
            var members = new List<string>();

            var names = _userInformationRepository.GetMembers();

            foreach (var n in names)
            {
                members.Add(n);
            }

            return Ok(members);
        }
    }
}