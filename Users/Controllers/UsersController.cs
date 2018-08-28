using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Users.Controllers.Dtos;
using Users.Core.Models;
using Users.Persistence;

namespace Users.Controllers
{
    [Route("/api/users")]
    public class UsersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserRepository repository;
        private readonly IUnitOfWork uow;

        public UsersController(IMapper mapper, IUserRepository repository, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.uow = uow;
        }

        [HttpGet]
        public async Task<QueryResultDto<UserDto>> GetUsers(UserQueryDto userQueryDto)
        {
            var userQuery = mapper.Map<UserQueryDto, UserQuery>(userQueryDto);
            var queryResult = await repository.GetUsers(userQuery);

            return mapper.Map<QueryResult<User>, QueryResultDto<UserDto>>(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await repository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<User, UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] SaveUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<SaveUserDto, User>(userDto);
            user.RegistrationDate = DateTime.Now;

            repository.Add(user);
            await uow.CompleteAsync();

            user = await repository.GetUser(user.Id);
            return Ok(mapper.Map<User, UserDto>(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] SaveUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await repository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            mapper.Map<SaveUserDto, User>(userDto, user);

            await uow.CompleteAsync();

            user = await repository.GetUser(user.Id);
            return Ok(mapper.Map<User, UserDto>(user));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await repository.GetUser(id, false);
            if (user == null)
            {
                return NotFound();
            }

            repository.Remove(user);
            await uow.CompleteAsync();

            return Ok(id);
        }



    }
}
