using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {

            return View();
        }

        public ActionResult form(ML.Usuario usuario)
        {
            Dictionary<string, object> result = BL.Usuario.Add(usuario);
            bool resultado = (bool)result["Resultado"];
            if (resultado)
            {
                
                ViewBag.Mensaje = "El Usuario ha sido insertado";
                return PartialView("Modal");
            }
            else
            {
                string exepcion = (string)result["Exepcion"];
                ViewBag.Mensaje = "El Usuario no se pudo registrar " + exepcion;
                return PartialView("Modal");
            }

        }

        [HttpPost]
        public ActionResult login(ML.Usuario usuario, string password)
        {
            usuario.Password = password;

            Dictionary<string, object> resultado = BL.Usuario.Add(usuario);


            bool result = (bool)resultado["Resultado"];
            if (result)
            {
                ViewBag.mensaje = "Se ha creado el usuario exitosamente";
                return PartialView("Modal");
            }
            else
            {

            }
            return View();
        }
        //[HttpPost]
        //public ActionResult Login(string Email, string password)
        //{
        //    Dictionary<string, object> diccionario = BL.Usuario.GetByEmail(Email);
        //    bool resultado = (bool)diccionario["Resultado"];
        //    if (resultado == true)//el metodo funciono
        //    {
        //        ML.Usuario usuario = (ML.Usuario)diccionario["Usuario"];
        //        if (usuario.Email != "")
        //        {
        //            if (usuario.Password == password)
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Mensaje = "El email no existe";
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.Mensaje = "El email no existe";
        //        return PartialView("Modal");
        //    }
        //    return View();

        //}
    }
}
