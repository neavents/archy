using System;
using Spectre.Console;

namespace Archy.CLI.UI.Models.Progresses;

public class SearchingProgress
{
    public async ValueTask Execute()
    {
        await AnsiConsole.Progress()
        .AutoClear(false)
        .AutoRefresh(false)
        .HideCompleted(false)
        .Columns(new ProgressColumn[]
    {
        new TaskDescriptionColumn(),    // Task description
        new ProgressBarColumn(),        // Progress bar
        new PercentageColumn(),         // Percentage
        new RemainingTimeColumn(),      // Remaining time
        new SpinnerColumn(),            // Spinner
        new DownloadedColumn(),         // Downloaded
        new TransferSpeedColumn(),      // Transfer speed
    })
        .StartAsync(async ctx =>
        {
            var t1 = ctx.AddTask("[red]naber[/] [blue]babotelli[/]");
            while (t1.Value < 100)
            {
                // Simulate some work
                await Task.Delay(25);

                // Increment
                t1.Increment(1.5);
                ctx.Refresh();
            }
            await Task.Delay(3000);
        });
    }
}
