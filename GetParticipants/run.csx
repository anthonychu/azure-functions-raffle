#load "../Shared/Participant.csx"
using System.Net;

public static HttpResponseMessage Run(HttpRequestMessage req, IQueryable<Participant> inputTable, TraceWriter log)
{
    var password = req.Headers.GetValues("Password").First();
    if (password != Environment.GetEnvironmentVariable("AdminPassword", EnvironmentVariableTarget.Process))
    {
        return req.CreateResponse(HttpStatusCode.Unauthorized);
    }
    return req.CreateResponse(HttpStatusCode.OK, inputTable);
}
