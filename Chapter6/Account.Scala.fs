module FSharpx.Books.DSLsInAction.Chapter4.Scala.Account

open System

// Listing 6.3 Account model in F#

type AccountType = AccountType of string

let CLIENT = AccountType("Client")
let BROKER = AccountType("Broker")

type Account(no: string, name: string, openDate: DateTime) =    
    let mutable closeDate = DateTime.Today
    let mutable creditLimit = Convert.ToDecimal(100000)
    member x.AccountType = Unchecked.defaultof<AccountType>
    member x.Close(date: DateTime) = closeDate <- date
        
type ClientAccount(no, name, ?openDate) =
    inherit Account(no, name, defaultArg openDate DateTime.Today)
    member x.AccountType = CLIENT

type BrokerAccount(no, name, ?openDate) =
    inherit Account(no, name, defaultArg openDate DateTime.Today)
    member x.AccountType = BROKER

let NOMURA = ClientAccount("Nom-123", "Nomura")

