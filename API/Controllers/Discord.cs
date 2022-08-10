using Discord;
using Discord.WebSocket;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class Discord : BaseApiController
{
    public Discord()
    {
    }

    [HttpGet("disc")]
    public async Task Announce()
    {
        DiscordSocketClient _client = new DiscordSocketClient();
        ulong id = 0;
        var chnl = _client.GetChannel(id) as IMessageChannel;
        await chnl.SendMessageAsync("Announcement!!!");

        // return Ok();
    }
}
