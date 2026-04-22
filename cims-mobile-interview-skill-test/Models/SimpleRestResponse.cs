using System.Net;

namespace cims_mobile_interview_skill_test.Models;

public class SimpleRestResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }

    public T Data { get; set; }
}
