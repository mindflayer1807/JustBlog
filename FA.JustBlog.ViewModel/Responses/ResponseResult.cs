namespace FA.JustBlog.ViewModel.Responses
{
    public class ResponseResult<T> where T : class
    {
        public ResponseResult() { }
        public ResponseResult(string message)
        {
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccessed { get; set; }
        public T Data { get; set; }
        public List<T> DataList { get; set; }
    }
}
