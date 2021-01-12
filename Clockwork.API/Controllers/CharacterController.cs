
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clockwork.Models;
using Clockwork.API.Data;
using Microsoft.AspNetCore.Cors;

namespace Clockwork.API.Controllers
{
    public partial class CharacterController : ControllerBase
    {
        [HttpPost("test")]
        [EnableCors("Permissive")]
        public async Task<ActionResult<int>> Test()
        {
            return await _context.Characters.Include(_context).CountAsync();
        }
        
    }
}
