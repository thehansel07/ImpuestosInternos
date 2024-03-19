namespace ImpuestosInternosBackEnd.Domain.Entities;

public partial class Contribuyente
{
    public string RncCedula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Tipo { get; set; }

    public bool Estatus { get; set; }

    public virtual ICollection<ComprobantesFiscale> ComprobantesFiscales { get; set; } = new List<ComprobantesFiscale>();
}
