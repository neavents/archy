using System;
using Spectre.Console;

namespace Archy.CLI.UI.Models.Elements;

public class ExampleElements
{
    public async ValueTask Execute()
    {
        AnsiConsole.Write(
    new FigletText("archy")
        .LeftJustified()
        .Color(Color.White));

        await AnsiConsole.Progress()
    .AutoRefresh(false) // Turn off auto refresh
    .AutoClear(false)   // Do not remove the task list when done
    .HideCompleted(false)   // Hide tasks as they are completed
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
        // Omitted
        // Define tasks
        var task1 = ctx.AddTask("[green]Reticulating splines[/]");
        var task2 = ctx.AddTask("[green]Folding space[/]");

        while (task2.Value < 100)
        {
            // Simulate some work
            await Task.Delay(25);

            // Increment
            task1.Increment(1.5);
            task2.Increment(0.5);
            ctx.Refresh();
        }
        await Task.Delay(3000);
    });

        var columns = new List<Text>(){
    new Text("Item 1", new Style(Color.Red, Color.Black)),
    new Text("Item 2", new Style(Color.Green, Color.Black)),
    new Text("Item 3", new Style(Color.Blue, Color.Black))
};
        AnsiConsole.Write(new Columns(columns));

        var table = new Table();

        // Add some columns
        table.AddColumn("Foo");
        table.AddColumn(new TableColumn("Bar").Centered());

        // Add some rows
        table.AddRow("Baz", "[green]Qux[/]");
        table.AddRow(new Markup("[blue]Corgi[/]"), new Panel("Waldo"));

        // Render the table to the console
        AnsiConsole.Write(table);

        var root = new Tree("Root");

        // Add some nodes
        var foo = root.AddNode("[yellow]Foo[/]");
        var table2 = foo.AddNode(new Table()
            .RoundedBorder()
            .AddColumn("First")
            .AddColumn("Second")
            .AddRow("1", "2")
            .AddRow("3", "4")
            .AddRow("5", "6"));

        table2.AddNode("[blue]Baz[/]");
        foo.AddNode("Qux");

        var bar = root.AddNode("[yellow]Bar[/]");
        bar.AddNode(new Calendar(2020, 12)
            .AddCalendarEvent(2020, 12, 12)
            .HideHeader());

        // Render the tree
        AnsiConsole.Write(root);

        // Create a list of fruits
        var items = new List<(string Label, double Value)>
{
    ("Apple", 12),
    ("Orange", 54),
    ("Banana", 33),
};

        // Render bar chart
        AnsiConsole.Write(new BarChart()
            .Width(60)
            .Label("[green bold underline]Number of fruits[/]")
            .CenterLabel()
            .AddItems(items, (item) => new BarChartItem(
                item.Label, item.Value, Color.Yellow)));


        var grid = new Grid();

        // Add columns 
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();

        // Add header row 
        grid.AddRow(new Text[]{
    new Text("Header 1", new Style(Color.Red, Color.Black)).LeftJustified(),
    new Text("Header 2", new Style(Color.Green, Color.Black)).Centered(),
    new Text("Header 3", new Style(Color.Blue, Color.Black)).RightJustified()
});

        // Add content row 
        grid.AddRow(new Text[]{
    new Text("Row 1").LeftJustified(),
    new Text("Row 2").Centered(),
    new Text("Row 3").RightJustified()
});

        // Write centered cell grid contents to Console
        AnsiConsole.Write(grid);

        // Create the layout
        var layout = new Layout("Root")
            .SplitColumns(
                new Layout("Left"),
                new Layout("Right")
                    .SplitRows(
                        new Layout("Top"),
                        new Layout("Bottom")));

        // Update the left column
        layout["Left"].Update(
            new Panel(
                Align.Center(
                    new Markup("Hello [blue]World![/]"),
                    VerticalAlignment.Middle))
                .Expand());

        // Render the layout
        AnsiConsole.Write(layout);


    }
}
