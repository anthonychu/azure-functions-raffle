#r "Microsoft.WindowsAzure.Storage"
using Microsoft.WindowsAzure.Storage.Table;

public class Participant : TableEntity
{
    public string Name { get; set; }

    public bool IsValid() =>
        !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(RowKey);
}