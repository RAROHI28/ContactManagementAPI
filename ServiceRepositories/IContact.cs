using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServiceRepositories
{
    public interface IContact
    {
        HttpResponseMessage GetAllContacts();

        HttpResponseMessage PostContact(Contact conObj);

        HttpResponseMessage Edit(int id);

        HttpResponseMessage Edit(int id, Contact conObj);

        HttpResponseMessage Delete(int id);
    }
}
