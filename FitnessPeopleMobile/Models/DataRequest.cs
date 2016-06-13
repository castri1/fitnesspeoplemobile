namespace FitnessPeopleMobile.Models
{
    public class DataRequest
    {
        public DataRequest()
        {
            Page = 1;
            PageSize = int.MaxValue;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}