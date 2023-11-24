using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence;

namespace Infrastructure.Identity
{
    public class CustomUserStore : UserStore<ApplicationUser>  // important to use custom Identity user object here!  
    {
        public CustomUserStore(ApplicationDbContext context)
        : base(context)
        {
            AutoSaveChanges = false;
        }
    }
}
