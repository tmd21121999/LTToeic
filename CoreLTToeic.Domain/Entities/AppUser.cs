using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLTToeic.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime? LastLogin { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
    }
}
