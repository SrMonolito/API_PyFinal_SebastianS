using System;
using System.Collections.Generic;

namespace API_PyFinal_SebastianS.Models;

public partial class TblRol
{
    public int RolId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<TblMiembro> TblMiembros { get; set; } = new List<TblMiembro>();
}
