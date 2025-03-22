Console.WriteLine("Hello, World!");

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