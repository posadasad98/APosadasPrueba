using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Tarea
    {
        public int IdTarea { get; set; }
        public string Descripcion {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ML.Status Status { get; set; }
    }
}
