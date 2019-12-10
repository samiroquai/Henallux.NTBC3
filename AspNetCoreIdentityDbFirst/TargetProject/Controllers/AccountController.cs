using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<MyUserClass> _userMgr;
        private readonly RoleManager<IdentityRole> _rolesMgr;
        private readonly Func<FakeAppDemoContext> _userMgrFactory;

        public AccountController(UserManager<MyUserClass> userMgr, RoleManager<IdentityRole> rolesMgr, Func<FakeAppDemoContext> userMgrFactory)
        {
            _userMgr = userMgr;
            _rolesMgr = rolesMgr;
            _userMgrFactory = userMgrFactory;
        }

        [HttpGet("role/{role}")]
        public async Task<ActionResult<IEnumerable<DTO.Account>>> GetByRole(string role)
        {
            IEnumerable<MyUserClass> usersInRole = await _userMgr.GetUsersInRoleAsync(role);
            //var mapTasks = usersInRole.Select(u => MapAsync(u));
            //await Task.WhenAll(mapTasks);
            //return Ok(mapTasks.Select(m => m.Result));
            List<DTO.Account> accounts = new List<DTO.Account>();
            foreach (MyUserClass user in usersInRole)
            {
                var dto = await MapAsync(user);
                accounts.Add(dto);
            }
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DTO.Account>> GetById(string id)
        {
            var userFound = await _userMgr.FindByIdAsync(id);
            if (userFound == null)
                return NotFound();
            return Ok(await MapAsync(userFound));
        }

        private async Task<DTO.Account> MapAsync(MyUserClass userFound)
        {
            using (FakeAppDemoContext mgr = _userMgrFactory())
            {
                var rolesIds = await mgr.UserRoles.Where(u => u.UserId == userFound.Id).Select(ur => ur.RoleId).ToArrayAsync();
                return new DTO.Account()
                {
                    Id = userFound.Id,
                    EMail = userFound.Email,
                    Username = userFound.UserName,
                    Roles = rolesIds
                };
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(DTO.CreateAccount account)
        {
            var newUser = new MyUserClass()
            {
                UserName = account.UserName,
                Email = account.EMail
            };
            var result = await _userMgr.CreateAsync(newUser, account.Password);
            if (result.Succeeded)
                return Created(newUser.Id.ToString(), null);
            return BadRequest(result.Errors);
        }
    }
}
