using Discord.Commands;

namespace API.Modules;

public class DiscordCommands : ModuleBase<ShardedCommandContext>
{
    public CommandService CommandService { get; set; }


}
