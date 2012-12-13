#load "Trade.Ruby.fs"

open FSharpx.Books.DSLsInAction.Chapter4.Ruby.Trade

// Listing 4.1 DSL to create a client account  

let a =
    Account.Create { 
            Number = "CL-BXT-23765"
            Holders = ["John Doe"; "Phil McCay"]
            Address = "San Francisco"
            Type = "client"
            Email = "client@example.com"
    }

begin
    Registry.Register(a)
    Mailer.Send(To = a.Email, 
                CC = a.Email,
                Subject = "New Account Creation", 
                Body = sprintf "Client account created for %s" a.Number)
end

