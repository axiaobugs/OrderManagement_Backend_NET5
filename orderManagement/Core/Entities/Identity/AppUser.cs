using Microsoft.AspNetCore.Identity;
using orderManagement.Core.Entities.Employees;
using System.Collections.Generic;

namespace orderManagement.Core.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string DisplayName { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
