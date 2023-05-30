using HealthHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Factories
{
    public class HospitalContextFactory : IDesignTimeDbContextFactory<HospitalContext>
    {
        private readonly ICurrentUserService _currentUserService;
        public HospitalContextFactory(ICurrentUserService currentUserService) 
        {
            _currentUserService = currentUserService;
        }
        public HospitalContext CreateDbContext(string[] args)
        {
            var userRole = _currentUserService.CurrentRole;
            string? connectionString = userRole switch
            {
                "unauthorized" => ConfigurationManager.ConnectionStrings["unauthorizedRole"].ConnectionString,
                "doctor" => ConfigurationManager.ConnectionStrings["doctorRole"].ConnectionString,
                "admin" => ConfigurationManager.ConnectionStrings["adminRole"].ConnectionString,
                _ => null,
            };

            var optionsBuilder = new DbContextOptionsBuilder<HospitalContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new HospitalContext(optionsBuilder.Options, _currentUserService);
        }
    }
}
