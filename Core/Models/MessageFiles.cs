namespace Core.Models;

public class MessageFiles : Base
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public Message Message { get; set; }
    public int MessageId { get; set; }
}
