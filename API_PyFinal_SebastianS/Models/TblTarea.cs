using System;
using System.Collections.Generic;

namespace API_PyFinal_SebastianS.Models;

public partial class TblTarea
{
    public int TareaId { get; set; }

    public int ProyectoId { get; set; }

    public string? Nombre { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Estado { get; set; }

    public virtual TblProyecto Proyecto { get; set; } = null!;

    public virtual ICollection<TblComentario> TblComentarios { get; set; } = new List<TblComentario>();

    public virtual ICollection<TblMiembrosTarea> TblMiembrosTareas { get; set; } = new List<TblMiembrosTarea>();
}
