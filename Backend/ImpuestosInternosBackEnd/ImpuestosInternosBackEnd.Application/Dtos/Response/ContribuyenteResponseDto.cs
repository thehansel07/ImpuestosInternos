
namespace ImpuestosInternosBackEnd.Application.Dtos.Response
{
    public class ContribuyenteResponseDto
    {
        public string RncCedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string? Tipo { get; set; }
        public string? Estatus { get; set; }
    }
}
