namespace ImpuestosInternosBackEnd.Application.Dtos.Request
{
    public class ComprobantesFiscalesRequestDto
    {
        public string RncCedula { get; set; } = null!;
        public string Ncf { get; set; } = null!;
        public decimal? Monto { get; set; }
    }
}
