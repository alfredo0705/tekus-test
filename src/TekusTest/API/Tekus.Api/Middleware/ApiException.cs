namespace Tekus.Api.Middleware
{
    internal class ApiException
    {
        private int statusCode;
        private string message;
        private string? v;

        public ApiException(int statusCode, string message, string? v)
        {
            this.statusCode = statusCode;
            this.message = message;
            this.v = v;
        }
    }
}