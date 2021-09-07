namespace CRM_side_project.Application.Common
{
    public struct BasicResponse<T>
    {
        public int code { get; set; }
        public string desc { get; set; }
        public T data { get; set; }
    }

    public struct BasicResponse
    {
        public int code { get; set; }
        public string desc { get; set; }
    }
}
