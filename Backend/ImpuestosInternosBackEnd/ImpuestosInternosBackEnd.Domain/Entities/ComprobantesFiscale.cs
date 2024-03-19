namespace ImpuestosInternosBackEnd.Domain.Entities;

public partial class ComprobantesFiscale
{
    public int IdComprobanteFiscal { get; set; }

    public string RncCedula { get; set; } = null!;

    public string Ncf { get; set; } = null!;

    public decimal? Monto { get; set; }

    public decimal? Itbis18 { get; set; }

    public virtual Contribuyente RncCedulaNavigation { get; set; } = null!;
}
