
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ServiceRepositories;

namespace ContactAPI.Models
{
    public class ContactContext :DbContext
    {
        public ContactContext():base("name=ContactContext")
        {

        }
        public DbSet<Contact> Contact { get; set; }

        
    }
}