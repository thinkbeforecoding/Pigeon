Pigeon uses the same HOCON notation configuration files as real Akka does.
However, we currently only utilize a few of the configuration values.
The configuration library and parser does however support reading and using the full configuration, we just have to catch up with configurable Akka features.

    # we use real Akka Hocon notation configs
    akka {
        actor {
            default-dispatcher.throughput = 20
        }
        remote {
            #this is the host and port the ActorSystem will listen to for connections
            server {
                host : 127.0.0.1
                port : 8080
            }
        }
    }

Using the config:
```csharp
var config = ConfigurationFactory.ParseString(@"
akka.remote.server {
            host : 127.0.0.1
            port : 8080
        }");

var system = ActorSystem.Create("Mysystem",config);
```
