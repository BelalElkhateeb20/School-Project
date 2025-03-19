using System.Net;

namespace SchoolProject.Core.Basies
{
    public class Response<T>
    {
        public Response(T data, string message = null)//When process is Done 
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(string message)//when Process is Fail 
        {
            Succeeded = false;
            Message = message;
        }
        public Response(string message, bool succeeded)//create a response with a message Manually
        {
            Succeeded = succeeded;
            Message = message;
        }

        public Response()
        {
        }

        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        //public Dictionary<string, List<string>> ErrorsBag { get; set; }
        public T Data { get; set; }
    }
}
