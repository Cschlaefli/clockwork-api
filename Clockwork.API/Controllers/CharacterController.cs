
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clockwork.Models;
using tephraAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace tephraApi.Controllers
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
