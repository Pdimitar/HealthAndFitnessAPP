using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class HealthAndFitnesDb : IdentityDbContext<IdentityUser>
    {
        public HealthAndFitnesDb()
            : base("healthAndFitnesDb")
        {

        }
        public DbSet<Client> Clients { get; set; }  
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ExcercisesType> ExcercisesTypes { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
    }
}
