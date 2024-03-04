using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static Dictionary<string, object> Add(ML.Usuario usuario)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", exepcion }, { "Resultado", false } };

            try
            {
                using (DL.AposadasPruebaContext context = new DL.AposadasPruebaContext())
                {
                    int filasAfectadas = context.Database.ExecuteSqlRaw($"AddUsuario '{usuario.Nombre}','{usuario.Email}',{usuario.Password}");

                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;
            }
            return diccionario;
        }
        //public static Dictionary<string, object> GetByEmail(string email)
        //{

        //    string exepcion = "";
        //    Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Usuario", null }, { "Exepcion", exepcion }, { "Resultado", false } };

        //    try
        //    {
        //        using (DL.AposadasPruebaContext context = new DL.AposadasPruebaContext())
        //        {
        //            var objeto = context.UsuarioGetByEmail(email).SingleOrDefault();
        //            //SingleOrDefault -- devuelve el unico valor 
        //            //FirstOrDefault -- devuelve el primero devuleve un valor por defecto

        //            if (objeto != null)
        //            {
        //                ML.Usuario usuario = new ML.Usuario(objeto.Email, objeto.Password);

        //                diccionario["Resultado"] = true;
        //                diccionario["Usuario"] = usuario;
        //            }
        //            else
        //            {
        //                diccionario["Resultado"] = false;
        //            }
        //            //ToList()
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return diccionario;
        //}
    }
}
