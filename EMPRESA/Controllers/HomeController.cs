using EMPRESA.Models;
using EMPRESA.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace EMPRESA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["img_title"] = "Floristeria";
            ViewData["img1_text"] = "Las mejores flores de Gipuzkoa";
            ViewData["img2_text"] = "Descuentos en flores de interior";
            ViewData["img3_text"] = "Abonos al 50% de descuento";
            ViewData["img4_text"] = "Plantas para navidades";

            return View(await _context.Producto.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            ViewBag.titulo = "Contactos";
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(string nombre, string apellido, string correo, string comentario) //estas variables deben coincidir con el atributo name del formulario
        {
            enviarCorreo(nombre, apellido, correo, comentario);
            ViewBag.titulo = "¡Gracias por contactar!";
            return View();
        }

        public void enviarCorreo(string nombre, string apellido, string correo, string comentario)
        {
            string destino = "micorreo@gmail.com";
            MailMessage msg = new MailMessage();

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "micorreo@gmail.com",
                Password = "mipassword"
            };

            smtp.EnableSsl = true;

            msg.From = new MailAddress(destino);
            msg.To.Add(destino);
            msg.Subject = "Contacto de " + nombre + " " + apellido;
            msg.IsBodyHtml = true;
            msg.Body = "Comentario de " + nombre + " " + apellido + "<br>" + comentario + "<br>Para responder, enviar un correo a: " + correo;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
           
            smtp.Send(msg);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
