using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;

namespace WebApp.Controllers
{
    public class ConfirmationsController : Controller
    {
        private ICustomerManager CustomerManager { get; set; }
        private IStaffManager StaffManager { get; set; }
        private IRestaurantManager RestaurantManager { get; set; }


        public ConfirmationsController(ICustomerManager customerManager,IStaffManager staffManager, IRestaurantManager restaurantManager)
        {
            CustomerManager = customerManager;
            StaffManager = staffManager;
            RestaurantManager = restaurantManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        //accessible by the confirmation link sent by email
        public IActionResult ConfirmCustomer(int id)
        {
            //get the customer
            var customer = CustomerManager.GetCustomer(id);
            
            if(customer!=null)
            {
                customer.confirmed = true;

                //update his confirmed state to true
                CustomerManager.UpdateCustomer(customer.ID_CUSTOMER, customer);

                //since he accessed the link with his email, connect him to the platform
                HttpContext.Session.SetInt32("ID_CUSTOMER", customer.ID_CUSTOMER);
            }

            return View(customer);
        }

        
        public static void sendEmailCustomer(Customer receiver)
        {

            //open smtp on gmail.com
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                //send an email with the created email address for vseat
                Credentials = new NetworkCredential("vseat.noreply@gmail.com", "AdminHevs01"),
                EnableSsl = true,
            };



            //send the e-mail with the confirmation link in it
            smtpClient.Send("vseat.noreply@gmail.com", receiver.EMAIL, "Confirmation of account creation", "Bonjour " + receiver.FIRSTNAME + " " + receiver.LASTNAME + "\n Merci de confirmer votre adresse e - mail en appuyant sur le lien ci - dessous.\nhttps://localhost:44330/Confirmations/ConfirmCustomer?id="+receiver.ID_CUSTOMER);
        }

    }
}
