using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Users.Controllers.Dtos;
using Users.Core.Models;
using Users.Persistence;

namespace Users.Controllers
{
    public class InterestsController : Controller
    {
        private readonly IMapper mapper;
        private readonly UsersDbContext context;

        public InterestsController(IMapper mapper, UsersDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/interests")]
        public IEnumerable<InterestDto> GetInterests()
        {
            var interests = context.Interests.ToList();
            return mapper.Map<IEnumerable<Interest>, IEnumerable<InterestDto>>(interests);
        }
    }
}
