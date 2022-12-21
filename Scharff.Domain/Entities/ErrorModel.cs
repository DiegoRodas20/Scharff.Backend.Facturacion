namespace Scharff.Domain.Entities
{
    public class ErrorModel
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public string? Exception { get; set; }
        public dynamic? Data { get; set; }
    }
}
