using System;
using System.Collections.Generic;

namespace API_PyFinal_SebastianS.Models;

public partial class TblComentario
{
    public int TareaId { get; set; }

    public int MiembroId { get; set; }

    public int ComentarioId { get; set; }

    public DateOnly Fecha { get; set; }

    public string Comentario { get; set; } = null!;

    public virtual TblMiembro Miembro { get; set; } = null!;

    public virtual TblTarea Tarea { get; set; } = null!;
}
