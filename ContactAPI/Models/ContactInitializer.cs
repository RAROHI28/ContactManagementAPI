
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactAPI.Models
{
    public class ContactInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<ContactContext>
    {
    }
}