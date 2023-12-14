namespace VassaSpraket_TW.Models
{
    public class ApiResponse<T>
    {
        public T Payload { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
