using Archy.CLI.Services;
using Microsoft.Extensions.Hosting;
using Archy.Application;
using Archy.Infrastructure.Core;
using Archy.Infrastructure.Execution;
using Archy.Infrastructure.Selecting;
using Archy.Infrastructure.Tracking;
using Microsoft.Extensions.Configuration;
using Archy.CLI;
using Serilog;

// {
//      loki: {
//          type: logging
//          compatible_dependencies:{
//              monitoring: [grafana]
//              tracing: []
//          }
//      },
//      grafana: {
//          type: monitoring
//          supported_dependencies:{
//              logging: [loki]
//              tracing: []
//          }
//      },
// }

//locate the target project directory and print it
//ask user for correctness and get acutal one

//ask for simple or detailed setup

//get solution name from user

//get project name from user

//ask for observability
//if yes 
//ask for picking one: file, loki, seq, elasticsearch (elk), Azure App insights, Aws cloudwatch, Google Cloud Logging, Postgres, MongoDB, Splunk, No extra logging (short circuit)
//install and configure, then ask user is it okay or do you want to choose extra one
//if yes repeat

//ask for monitoring

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

ConfigurationLoader.Load(builder);

Log.Logger = LoggingSetup.SerilogConfiguration(builder.Configuration);
builder.Services.AddSerilogSetup();

builder.Services.AddApplication();
builder.Services.AddCoreInfrastructure()
                .AddExecution()
                .AddSelecting()
                .AddTracking();

using IHost host = builder.Build();

EntryPoint app = new(host.Services);
app.Run();