using System.Net;

namespace MagicVilla_VillaAPI.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccsss { get; set; } = true;
        public List<string> ErrorsMessages { get; set; }
        public object Result { get; set; }
    }
}
