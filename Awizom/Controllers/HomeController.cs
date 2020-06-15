using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.ComponentModel;
using System.Configuration;
using System.Net.Mail;
using System.Net;


namespace Awizom.Controllers
{
    public class HomeController : Controller
    {
        AwizomSiteEntities db = new AwizomSiteEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]

        public ActionResult Contact(ContactForm contact, string savestaus = null)
        {
            string Status = "NA";
            try
            {
                var exist = db.ContactForms.Find(contact.ContactID);
                if (exist == null)
                {
                    ContactForm ct = new ContactForm();


                    ct.Name = contact.Name;
                    ct.Email = contact.Email;
                    ct.Subject = contact.Subject;
                    ct.Message = contact.Message;

                    db.ContactForms.Add(ct);

                    int result = db.SaveChanges();
                    if (result == 1)
                    {


                        var msg = "<span style='font-weight:bold;color:#900C3F;text-decoration:underline;font-size:Large'>New Contact</span>" +
                            "<br><br><span style='font-weight:bold'>Name :</span>" + " " + "<span style='color:#5D311B;font-weight:bold'>" + contact.Name + "</span>" +
                            "<br><span style='font-weight:bold'> Email :</span>" + " " + "<span style='color:#5D311B;font-weight:bold'>" + contact.Email + "</span>" +
                             "<br/><span style='font-weight:bold'>Subject :</span> " + "<span style='color:#5D311B;font-weight:bold'>" + contact.Subject + "</span>" +
                           "<br/><span style='font-weight:bold'>Message :</span>" + "<span style='color:#5D311B;font-weight:bold'>" + contact.Message + "</span>" +
                             "<br/><br/>Thank you for Contacting with us" + "<br><span style='color:#2867DE;font-weight:bold;font-size:medium'>Awizom Tech Support !</span>";
                        var sub = contact.Name;
                        var name = contact.Name;
                        string res = SendEmail("info@awizomtech.com", sub, msg, name);
                        Status = "Succeeded";

                    }
                    else
                    {
                        Status = "UnSucceeded";
                    }
                }

                else
                {
                    exist.Name = contact.Name;
                    exist.Email = contact.Email;
                    exist.Subject = contact.Subject;
                    exist.Message = contact.Message;

                    int result = db.SaveChanges();
                    if (result == 1)
                    {
                        Status = "Succeeded";
                    }
                    else
                    {
                        Status = "UnSucceeded";
                    }
                }

            }
            catch (Exception ex)
            {
                Status = "UnSucceeded" + ex;
            }


            ViewBag.Status = Status;
            return RedirectToAction("Contact", "Home", new { savestatus = Status });
        }


        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Career()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Appointment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Appointment(Appointment apointment, string savestaus = null)
         {
            string Status = "NA";
            try
            {
                var exist = db.Appointments.Find(apointment.AppointmentID);
                if (exist == null)
                {
                    Appointment ap = new Appointment();


                    ap.Name = apointment.Name;
                    ap.Email = apointment.Email;
                    ap.Phone = apointment.Phone;
                    ap.FTV = "No";
                    ap.Date = apointment.Date;
                    ap.Time = apointment.Time;
                    ap.Message = apointment.Message;


                    db.Appointments.Add(ap);

                    int result = db.SaveChanges();
                    if (result == 1)
                    {


                        var msg = "<span style='font-weight:bold;color:#900C3F;text-decoration:underline;font-size:Large'>New Appointment Request</span>" +
                            "<br><br><span style='font-weight:bold'>Name :</span>" + " " + "<span style='color:#5D311B;font-weight:bold'>" + apointment.Name + "</span>" +
                            "<br><span style='font-weight:bold'> Email :</span>" + " " + "<span style='color:#5D311B;font-weight:bold'>" + apointment.Email + "</span>" +
                             "<br/><span style='font-weight:bold'>Mobile No. :</span> " + "<span style='color:#5D311B;font-weight:bold'>" + apointment.Phone + "</span>" +
                              "<br/><span style='font-weight:bold'>First Time Visit :</span> " + "<span style='color:#5D311B;font-weight:bold'>" + apointment.FTV + "</span>" +
                               "<br/><span style='font-weight:bold'>Date :</span> " + "<span style='color:#5D311B;font-weight:bold'>" + apointment.Date + "</span>" +
                                "<br/><span style='font-weight:bold'>Time :</span> " + "<span style='color:#5D311B;font-weight:bold'>" + apointment.Time + "</span>" +
                           "<br/><span style='font-weight:bold'>Message :</span>" + "<span style='color:#5D311B;font-weight:bold'>" + apointment.Message + "</span>" +
                             "<br/><br/>Thank you for Contacting with us" + "<br><span style='color:#2867DE;font-weight:bold;font-size:medium'>Awizom Tech Support !</span>";
                        var sub = apointment.Name;
                        var name = apointment.Name;
                        string res = SendEmail("info@awizomtech.com", sub, msg, name);
                        Status = "Succeeded";

                    }
                    else
                    {
                        Status = "UnSucceeded";
                    }
                }

                else
                {
                    exist.Name = apointment.Name;
                    exist.Email = apointment.Email;
                    exist.Phone = apointment.Phone;
                    exist.FTV = apointment.FTV;
                    exist.Date = apointment.Date;
                    exist.Time = apointment.Time;
                    exist.Message = apointment.Message;

                    int result = db.SaveChanges();
                    if (result == 1)
                    {
                        Status = "Succeeded";
                    }
                    else
                    {
                        Status = "UnSucceeded";
                    }
                }

            }
            catch (Exception ex)
            {
                Status = "UnSucceeded" + ex;
            }
            ViewBag.Status = Status;


            return RedirectToAction("Appointment", "Home", new { savestatus = Status });

        }

        public ActionResult Events()
        {
            return View();
        }



        public string SendEmail(string EmailId = null, string subject = null, string msg = null, string Name = null, string Email = null)
        {
            var senderEmail = new MailAddress("smswebhelp@gmail.com", "Awizom Support");
            var receiverEmail = new MailAddress(EmailId, "Receiver");
            var password = "smsweb@2019";
            var sub = subject;
            var body = msg;
            var Cname = Name;
            var cemail = Email;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body

            })
            {
                mess.IsBodyHtml = true;
                smtp.Send(mess);
            }
            return "Done";
        }





    }
}


//-----End of Code---------------