namespace Core.Interfaces;

public interface ICommandHandler
{
    Task SendMessageToWebHook();
}
