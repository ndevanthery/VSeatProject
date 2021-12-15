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

        public IActionResult ConfirmCustomer(int id)
        {
            var customer = CustomerManager.GetCustomer(id);
            if(customer!=null)
            {
                customer.confirmed = true;

                CustomerManager.UpdateCustomer(customer.ID_CUSTOMER, customer);
                HttpContext.Session.SetInt32("ID_CUSTOMER", customer.ID_CUSTOMER);
            }

            return View(customer);
        }

        public IActionResult ConfirmStaff(int id)
        {
            
            var staff = StaffManager.GetStaff(id);
            if(staff!=null)
            {
                staff.confirmed = true;
                StaffManager.UpdateStaff(staff.ID_STAFF, staff);
                HttpContext.Session.SetInt32("ID_STAFF", staff.ID_STAFF);

            }


            return View(staff);
        }

        public IActionResult ConfirmRestaurant(int id)
        {
            var resto = RestaurantManager.GetRestaurant(id);
            if(resto!=null)
            {
                resto.confirmed = true;
                RestaurantManager.UpdateRestaurant(resto.ID_RESTAURANT, resto);
                HttpContext.Session.SetInt32("ID_RESTAURANT", resto.ID_RESTAURANT);

            }

            return View(resto);
        }


        public static void sendEmailCustomer(Customer receiver)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("vseat.noreply@gmail.com", "AdminHevs01"),
                EnableSsl = true,
            };




            smtpClient.Send("vseat.noreply@gmail.com", receiver.EMAIL, "Confirmation of account creation", "Bonjour " + receiver.FIRSTNAME + " " + receiver.LASTNAME + "\n Merci de confirmer votre adresse e - mail en appuyant sur le lien ci - dessous.\nhttps://localhost:44330/Confirmations/ConfirmCustomer?id="+receiver.ID_CUSTOMER);
        }

    }
}
