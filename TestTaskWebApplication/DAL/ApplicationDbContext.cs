using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TestTaskWebApplication.DAL.Entities;

namespace TestTaskWebApplication.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
    }
}