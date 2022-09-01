namespace TurboJsMVC.Common
{
    [Serializable]
    public class ToastMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string ToastType { get; set; }
        public bool IsSticky { get; set; }
    }
}
