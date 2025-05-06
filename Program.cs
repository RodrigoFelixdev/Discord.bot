using System;
using System.Threading.Tasks;
using System.Net.Sockets;
using Discord;
using Discord.WebSocket;
using DotNetEnv;
Env.Load();
var discordToken = Environment.GetEnvironmentVariable("DiscordToken");

async Task Runbotasync(){
    
    var client =  new DiscordSocketClient(new DiscordSocketConfig{
        LogLevel = LogSeverity.Debug
    });

     await client.LoginAsync(TokenType.Bot, discordToken);

     Console.WriteLine(client.LoginState);
     
     await client.StartAsync();

     client.Ready += async () => 
     {
        var guild = client.GetGuild(1058834781598666772);
        var channel = guild.GetTextChannel(1058834782177464371);
        if (channel != null)
        {
            await channel.SendMessageAsync("olá");
        }

          await channel.SendMessageAsync("Olá mundo");

        var embed = new EmbedBuilder();
        embed.WithImageUrl("https://i.pinimg.com/736x/4a/69/f9/4a69f919d54deb48439a26e0e8260cc2.jpg");
        await channel.SendMessageAsync(embed: embed.Build());

        
     };
     client.Log +=  (log) => {
        Console.WriteLine($"{DateTime.Now} -> {log.Message}");
        return Task.CompletedTask;
     };
     var exitSignal =  new TaskCompletionSource<bool>();
     await exitSignal.Task;



}
await Runbotasync();

Console.ReadKey();
