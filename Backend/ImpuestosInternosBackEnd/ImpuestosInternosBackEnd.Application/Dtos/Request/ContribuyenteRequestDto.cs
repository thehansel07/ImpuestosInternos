
namespace ImpuestosInternosBackEnd.Application.Dtos.Request
{
    public class ContribuyenteRequestDto
    {
        public string RncCedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Tipo { get; set; }
        public bool Estatus { get; set; }

    }
}
