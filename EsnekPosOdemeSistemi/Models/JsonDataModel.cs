namespace EsnekPosOdemeSistemi.Models
{
    public class JsonDataModel
    {
        public object Data { get; set; }
        public ResultType Result { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
    }

    public enum ResultType : short
    {
        Success = 1,
        Error = 2,
    }
}