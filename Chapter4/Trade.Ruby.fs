module FSharpx.Books.DSLsInAction.Chapter4.Ruby.Trade

open System

// Listing 4.2 Expressive domain vocabulary in implementation of Account

type Account = {
    Number: string;
    Holders: string list;
    Address: string;
    Type: string;
    Email: string;
}
with static member Create x = x
     override x.ToString() = 
        sprintf "No: %s / Names: (%s) / Address: %s" x.Number (String.Join(", ", x.Holders)) x.Address

type Registry =
    static member Register (a: Account) = printfn "Registering  %O" a

// Listing 4.4 Mailer class with fluent interfaces 

#nowarn "49"

type Mailer private (``to``: string, cc: string, subject: string, body: string) =
    member x.To = ``to``
    member x.CC = cc
    member x.Subject = subject
    member x.Body = body

    static member Send(To, CC, Subject, Body) =
            let m = Mailer(To, CC, Subject, Body)
            printfn "Sending mail to %O" m.To
            m