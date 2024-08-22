using System;
using System.Collections.Generic;

namespace API_PyFinal_SebastianS.Models;

public partial class TblMiembrosTarea
{
    public int MiembTareaId { get; set; }

    public int MiembroId { get; set; }

    public int TareaId { get; set; }

    public virtual TblMiembro Miembro { get; set; } = null!;

    public virtual TblTarea Tarea { get; set; } = null!;
}
