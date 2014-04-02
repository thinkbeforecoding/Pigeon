(*** hide ***) 
#r @"..\..\bin\Akka.FSharp\Akka.dll"
#r @"..\..\bin\Akka.FSharp\Akka.FSharp.dll"

(** Akka.NET comes with an extended F# API.
This extension lets you send and ask messages using the <! tell and <? ask operators.
*)
open Akka
open Akka.FSharp

type SomeActorMessages =
    | Greet of string
    | Hi

type SomeActor() =
    inherit Actor()

    override x.OnReceive message =
        match message with
        | :? SomeActorMessages as m ->  
            match m with
            | Greet(name) -> Console.WriteLine("Hello {0}",name)
            | Hi -> Console.WriteLine("Hello from F#!")
        | _ -> failwith "unknown message"

let system = ActorSystem.Create("FSharpActors")
let actor = system.ActorOf<SomeActor>("MyActor")

actor <! Greet "Roger"
actor <! Hi
