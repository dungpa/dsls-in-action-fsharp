module FSharpx.Books.DSLsInAction.Chapter6.Scala.Account

open System

// Listing 6.3 Account model in F#

type AccountType = AccountType of string

let CLIENT = AccountType("Client")
let BROKER = AccountType("Broker")

[<AbstractClass>]
type Account(no: string, name: string, openDate: DateTime) =    
    let mutable closeDate = DateTime.Today
    let mutable creditLimit = Convert.ToDecimal(100000)
    abstract member AccountType: AccountType
    member x.Close(date: DateTime) = closeDate <- date
        
type ClientAccount(no, name, ?openDate) =
    inherit Account(no, name, defaultArg openDate DateTime.Today)
    override x.AccountType = CLIENT

type BrokerAccount(no, name, ?openDate) =
    inherit Account(no, name, defaultArg openDate DateTime.Today)
    override x.AccountType = BROKER

let NOMURA = ClientAccount("Nom-123", "Nomura")