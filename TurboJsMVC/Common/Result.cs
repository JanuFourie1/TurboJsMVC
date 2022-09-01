namespace TurboJsMVC.Common
{
    public class Result<T>
    {
        public T Data { get; set; }
        public Boolean IsSuccess { get; set; }
        public String Message { get; set; }
        public Exception Exception { get; set; }
        public Guid? Id { get; set; }
        public int TotalCount { get; set; }
    }
}
