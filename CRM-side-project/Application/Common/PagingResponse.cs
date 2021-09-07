namespace CRM_side_project.Application.Common
{
    public struct PagingResponse<T>
    {
        public int code { get; set; }
        public string desc { get; set; }
        public T data { get; set; }
        public Paging paging { get; set; }
    }
}