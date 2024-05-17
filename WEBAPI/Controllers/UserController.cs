using WEBAPI.DTO;
using WEBAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DBContext DBContext;

        public UserController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var List = await DBContext.Users.Select(
                s => new UserDTO
                {
                    id = s.id,
                    username = s.username,
                    mail = s.mail,
                    phone = s.phone,
                    skill = s.skill,
                    hobby = s.hobby
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            UserDTO User = await DBContext.Users.Select(
                    s => new UserDTO
                    {
                        id = s.id,
                        username = s.username,
                        mail = s.mail,
                        phone = s.phone,
                        skill = s.skill,
                        hobby = s.hobby
                    })
                .FirstOrDefaultAsync(s => s.id == id);

            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return User;
            }
        }

        [HttpPost("InsertUser")]
        public async Task<HttpStatusCode> InsertUser(UserDTO User)
        {
            var entity = new User()
            {
                id = User.id,
                username = User.username,
                mail = User.mail,
                phone = User.phone,
                skill = User.skill,
                hobby = User.hobby
            };

            DBContext.Users.Add(entity);
            await DBContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> UpdateUser(UserDTO User)
        {
            var entity = await DBContext.Users.FirstOrDefaultAsync(s => s.id == User.id);

            entity.username = User.username;
            entity.mail = User.mail;
            entity.phone = User.phone;
            entity.skill = User.skill;
            entity.hobby = User.hobby;

            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("DeleteUser/{Id}")]
        public async Task<HttpStatusCode> DeleteUser(int id)
        {
            var entity = new User()
            {
                id = id
            };
            DBContext.Users.Attach(entity);
            DBContext.Users.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
