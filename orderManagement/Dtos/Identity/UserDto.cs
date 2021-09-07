using orderManagement.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderManagement.Dtos.Identity
{
    public class UserDto
    {
        public int Id {  get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public int EmployeeId { get; set; }
        public IList<string> Roles { get; set; }
    }
}
