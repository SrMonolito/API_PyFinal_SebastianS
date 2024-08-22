using System;
using System.Collections.Generic;

namespace API_PyFinal_SebastianS.Models;

public partial class TblProyecto
{
    public int ProyectoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<TblTarea> TblTareas { get; set; } = new List<TblTarea>();
}
