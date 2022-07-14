
namespace AutoGTP2Tests
{
    public class ServiceData
    {
        public ServiceData(string quantity)
        {
            Quantity = quantity;                        
        }
                
        public string FileName { get; set; }
        public string SubjectArea { get; set; }
        public string SourceLanguage { get; set; }
        public string TargetLanguage { get; set; }
        public string Quantity { get; set; }

    }
}
