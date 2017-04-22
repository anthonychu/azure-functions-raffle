#load "../Shared/Participant.csx"
using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, IAsyncCollector<Participant> outputTable, TraceWriter log)
{
    var participant = await req.Content.ReadAsAsync<Participant>();
    participant.RowKey = "1";

    if (!participant.IsValid())
    {
        return req.CreateResponse(HttpStatusCode.BadRequest, "Invalid participant");
    }

    await outputTable.AddAsync(participant);

    return req.CreateResponse(HttpStatusCode.OK);
}
