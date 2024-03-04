﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? IdTarea { get; set; }

    public virtual Tarea? IdTareaNavigation { get; set; }
}
