﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public int? IdStatus { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechadeVencimiento { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
