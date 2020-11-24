using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ContactAPI.Models;
using System.Data.Entity;
using ServiceRepositories;

namespace ContactAPI.Controllers
{
    public class ContactController : ApiController
    {
        // GET: Contact
        [HttpGet]
        public IHttpActionResult GetAllContacts()
        {
            IList<Contact> contacts = null;
            ContactContext db = new ContactContext();
            contacts=db.Contact.ToList();

            if (contacts.Count == 0)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        public IHttpActionResult PostContact(Contact contact)
        {
            ContactContext db = new ContactContext();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contact.Add(contact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);
        }

        [HttpGet]
        public IHttpActionResult Edit(int id)
        {
            ContactContext db = new ContactContext();
            Contact contact = null;

            contact = db.Contact.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        
        

        [HttpPut]
        public void Edit(int id, Contact entity)
        {

            ContactContext db = new ContactContext();
            var con = db.Contact.Find(id);
            if (con != null)
            {
                con.Email = entity.Email;
                con.FirstName = entity.FirstName;
                con.LastName = entity.LastName;
                con.PhoneNumber = entity.PhoneNumber;
                con.Status = entity.Status;
               

                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            ContactContext db = new ContactContext();
            Contact contact = db.Contact.Find(id);
            db.Contact.Remove(contact);
            db.SaveChanges();
           
        }
    }
}