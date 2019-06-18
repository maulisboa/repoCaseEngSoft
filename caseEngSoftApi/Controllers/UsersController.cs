using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caseEngSoftApi.Models;
using caseEngSoftApi.Database;
using System;



namespace caseEngSoftApi.Controllers
{
    [Route("api/users")]
    [ApiController]
  
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;

            if (_context.Usuarios.Count() == 0)
            {
                
                //List<User> userList = new User().Listar();
                //_context.Usuarios.AddRange(userList);
                //_context.SaveChanges();

                new t_log().Incluir("UsersController", "_context.Usuarios.Count() == 0", "INFO");

            }
        }


    }
}
