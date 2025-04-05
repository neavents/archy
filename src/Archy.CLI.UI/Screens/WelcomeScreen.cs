using System;
using Archy.CLI.UI.Elements;
using Archy.CLI.UI.HyperElements;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Models.Contexts;
using Archy.CLI.UI.Models.Progresses;
using SharedKernel.Extensions;

namespace Archy.CLI.UI.Screens;

public class WelcomeScreen : IScreen
{
    public int Priority {get; init;}
    public WelcomeScreen(int priority = 0){
        Priority = priority;
    }

    public async ValueTask Render()
    {
        string selectionName = "domain";
        List<string> domains = ["database", "messaging", "security", "auth", "blabla"];

        var element = new SearchingProgress();
        await element.Execute();

        FuncMenuContext<string> menuContext = new FuncMenuContext<string>(){Value = "domain",
            Childs = [
                new(){Value = "database",
                    Childs = [
                        new(){Value = "sql",
                            Childs = [
                                new(){Value = "postgresql"},
                                new(){Value = "mysql"},
                                new(){Value = "mssql"},
                                new(){Value = "oracle"}
                            ]},
                        new(){Value = "nosql",
                            Childs = [
                                new(){Value = "mongodb"},
                                new(){Value = "cassandra"}
                            ]},
                        new(){Value = "graph",
                            Childs = [
                                new(){Value = "neo4j"}
                            ]}
                    ]},
                new(){Value = "messaging",
                    Childs = [
                        new(){Value = "local",
                            Childs = [
                                new(){Value = "activemq"},
                                new(){Value = "apache-pulsar"},
                                new(){Value = "kafka"},
                                new(){Value = "memcached-(pub/sub)"},
                                new(){Value = "rabbitmq"},
                                new(){Value = "redis-(pub/sub)"}
                            ]},
                        new(){Value = "cloud",
                            Childs = [
                                new(){Value = "amazon=sns"},
                                new(){Value = "amazon-sqs"},
                                new(){Value = "aws-eventbridge"},
                                new(){Value = "azure-service-bus"},
                                new(){Value = "google-pubsub"}
                            ]}
                    ]},
                new(){Value = "security"},
                new(){Value = "auth"}
            ]};

        IHyperElement<FuncMenuContext<string>> hyperElement = new FunctionalMenu();
        await hyperElement.Render(new(){Value = menuContext, Header = "Selector"});

        IElement<List<string>,List<string>> element1 = new Selectables();
        await element1.Render(new(){
            Value = domains, 
            Header = $"[blue]{selectionName.CapitalizeFirst()}s[/] to be configured",
            StringExtras = [$"[grey](Move up and down to reveal more {selectionName}s)[/]",$"[grey](Press [blue]<space>[/] to toggle a {selectionName}, " + 
            "[green]<enter>[/] to accept)[/]"]
            });

        IElement<List<string>, string> element2 = new Selectable();
        await element2.Render(new(){
            Value = domains,
            Header = $"[blue]{selectionName.CapitalizeFirst()}s[/] to be configured",
            StringExtras = [$"[grey](Move up and down to reveal more {selectionName}s)[/]",$"[grey](Press [blue]<space>[/] to toggle a {selectionName}, " + 
            "[green]<enter>[/] to accept)[/]"]
        });
    }
}
