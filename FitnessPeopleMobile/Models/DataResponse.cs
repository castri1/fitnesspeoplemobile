using System.Collections;

namespace FitnessPeopleMobile.Models
{
    public class DataResponse
    {
        public object ExtraData { get; set; }
        public IEnumerable Data { get; set; }
        public object Errors { get; set; }
        public int Total { get; set; }
    }
}