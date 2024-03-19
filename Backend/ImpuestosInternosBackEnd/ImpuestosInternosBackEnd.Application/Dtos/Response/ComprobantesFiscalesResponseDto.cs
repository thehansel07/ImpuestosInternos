namespace ImpuestosInternosBackEnd.Application.Dtos.Response
{
    public class ComprobantesFiscalesResponseDto
    {
        public int IdComprobanteFiscal { get; set; }

        public string RncCedula { get; set; } = null!;

        public string Ncf { get; set; } = null!;

        public decimal? Monto { get; set; }

        public decimal? Itbis18 { get; set; }

    }
}
