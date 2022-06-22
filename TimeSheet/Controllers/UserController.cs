using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.UserDto;
using TimeSheet.Entities;
using VoltekApi.Helper;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [EnableCors("AllowOrigin")]
    public class userController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<UserGetDto> getFinishObject;
        public userController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Answer<UserGetDto>> GetAll()
        {
            List<User> users = _context.Users.Where(x => x.isDeleted == false).ToList();

            List<UserGetDto> UserGetList = new List<UserGetDto>();
            foreach (var user in users)
            {
                UserGetList.Add(_mapper.Map<UserGetDto>(user));
            }

            if (users.Count > 0)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "Ok", UserGetList);
            }
            else
            {
                return getFinishObject = new Answer<UserGetDto>(200, "User is empty", null);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Answer<UserGetDto>> Get(string id)
        {
            var exist = _context.Users.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);

            if (exist != null)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "Ok", new List<UserGetDto> { _mapper.Map<UserGetDto>(exist) });

            }
            else
            {
                return getFinishObject = new Answer<UserGetDto>(200, "User doesn't exist", null);
            }
        }

        [HttpPost]
        public ActionResult<Answer<UserGetDto>> CreateUser(UserPostDto UserPostDto)
        {

            User newUser = new User()
            {
                uuid = Guid.NewGuid().ToString(),
                cid = UserPostDto.cid,
                email = UserPostDto.email,
                fin = UserPostDto.fin.ToLower(),
                firstName = UserPostDto.firstName,
                lastName = UserPostDto.lastName,
                fullName = UserPostDto.firstName + " " + UserPostDto.lastName,
                Password = Hashing.ToSHA256(UserPostDto.password),
                positionId = UserPostDto.positionId,
                isDeleted = false,
                createdTime = DateTime.UtcNow,
                departmentId = UserPostDto.departmentId,
                dateOfBirthday = UserPostDto.dateOfBirthday,
                age = 24
                
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return getFinishObject = new Answer<UserGetDto>(201, "User created", null);
        }

        [HttpPut]
        public ActionResult<Answer<UserGetDto>> UpdateUser(UserUpdateDto UserUpdateDto)
        {
            var exist = _context.Users.FirstOrDefault(x => x.id == UserUpdateDto.id && x.isDeleted == false);

            if (exist == null)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "User not found", null);
            }
            var position = _context.Positions.FirstOrDefault(x => x.id == UserUpdateDto.positionId);

            if (position == null)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "Position id is not correct", null);
            }

            exist.uuid = UserUpdateDto.uuid;
            exist.cid = UserUpdateDto.cid;
            exist.fin = UserUpdateDto.fin;
            exist.email = UserUpdateDto.email;
            exist.firstName = UserUpdateDto.firstName;
            exist.lastName = UserUpdateDto.lastName;
            exist.positionId = UserUpdateDto.positionId;
            exist.fullName = UserUpdateDto.firstName + " " + UserUpdateDto.lastName;

            _context.SaveChanges();

            return getFinishObject = new Answer<UserGetDto>(204, "no Content", null);
        }

        [HttpDelete("{id}")]
        public ActionResult<Answer<UserGetDto>> DeletedUser(int id)
        {
            var exist = _context.Users.FirstOrDefault(x => x.id == id && x.isDeleted == false);
            if (exist == null)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "User not found", null);
            }
            exist.isDeleted = true;
            _context.SaveChanges();
            return getFinishObject = new Answer<UserGetDto>(204, "No Content", null);
        }

        [HttpPost()]
        [Route("changePass")]
        public ActionResult<Answer<UserGetDto>> ChangePassword(PasswordChangeDto ChangeDto)
        {
            var exist = _context.Users.FirstOrDefault(x => x.id == ChangeDto.id && x.isDeleted == false);

            if (exist == null)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "User not found", null);
            }
            if (ChangeDto.NewPassword != ChangeDto.ConfirmPassword)
            {
                return getFinishObject = new Answer<UserGetDto>(409, "Password and ConfirmPassword isn't match", null);
            }
            exist.Password = Hashing.ToSHA256(ChangeDto.NewPassword);

            _context.SaveChanges();

            return getFinishObject = new Answer<UserGetDto>(204, "Password changed", null);
        }



    }
}
