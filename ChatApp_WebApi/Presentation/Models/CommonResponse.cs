namespace Presentation.Models
{
    public class CommonResponse
    {
        public bool IsSuccess { get; set; }

        public object Value { get; set; }

        public IEnumerable<string> Messages { get; set; }

        public static CommonResponse Success(object value = null)
        {
            return new()
            {
                IsSuccess = true,
                Value = value
            };
        }
        public static CommonResponse Failed(IEnumerable<string> messages)
        {
            return new CommonResponse
            {
                IsSuccess = false,
                Messages = messages
            };
        }
    }
}
