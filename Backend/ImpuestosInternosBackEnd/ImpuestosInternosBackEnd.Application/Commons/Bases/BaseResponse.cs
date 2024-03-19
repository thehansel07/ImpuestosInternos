using FluentValidation.Results;

namespace ImpuestosInternosBackEnd.Application.Commons.Bases
{
    public class BaseResponse<T>
    {
        public bool isSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
