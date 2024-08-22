using System;
using System.Collections.Generic;

namespace API_PyFinal_SebastianS.Models;

public partial class TblMiembro
{
    public int MiembroId { get; set; }

    public int RolId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Telefono { get; set; }

    public virtual TblRol Rol { get; set; } = null!;

    public virtual ICollection<TblComentario> TblComentarios { get; set; } = new List<TblComentario>();

    public virtual ICollection<TblMiembrosTarea> TblMiembrosTareas { get; set; } = new List<TblMiembrosTarea>();
}
