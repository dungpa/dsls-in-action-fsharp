module FSharpx.Books.DSLsInAction.Chapter6.Scala.Account

open System

// Listing 6.3 Account model in F#

type Number = string
type Name = string
type OpenDate = DateTime

type Account =
    | ClientAccount of Number * Name * OpenDate
    | BrokerAccount of Number * Name * OpenDate

let NOMURA = ClientAccount("Nom-123", "Nomura", DateTime.Today)