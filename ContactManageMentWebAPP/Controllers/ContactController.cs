using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//using ContactManageMentWebAPP.DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceRepositories;


namespace ContactManageMentWebAPP.Controllers
{
    public class ContactController : Controller
    {

        private IContact _IcontactService;

        // GET: Contact
        
        public ContactController(IContact contacservice)
        {
            _IcontactService = contacservice;
          

        }

        


        public async Task<ActionResult> Index()
        {
            
            
            HttpResponseMessage responseMessage = _IcontactService.GetAllContacts();
            if (responseMessage.IsSuccessStatusCode)
            {
                //var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var responseData = _IcontactService.GetAllContacts();

                var Employees = JsonConvert.DeserializeObject<List<ServiceRepositories.Contact>>(responseData.Content.ReadAsStringAsync().Result);

                return View(Employees);
            }
            
             return RedirectToAction("Create", "Contact");
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ServiceRepositories.Contact conObj)
        {
            

            var response = _IcontactService.PostContact(conObj);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");
        }

        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = _IcontactService.Edit(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = _IcontactService.Edit(id);

                var Employee = JsonConvert.DeserializeObject<ServiceRepositories.Contact>(responseData.Content.ReadAsStringAsync().Result);

                return View(Employee);
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, ServiceRepositories.Contact contact)
        {

            HttpResponseMessage responseMessage = _IcontactService.Edit(id,contact);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
           
            HttpResponseMessage responseMessage = _IcontactService.Delete(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }
}