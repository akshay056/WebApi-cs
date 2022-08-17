using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Data
{
    public class UserApiContext : DbContext
    {
        public UserApiContext (DbContextOptions<UserApiContext> options)
            : base(options)
        {
        }

        public DbSet<UserApi.Models.User> User { get; set; } = default!;
    }
}
