#load "Order.Fsharp.fs"

open FSharpx.Books.DSLsInAction.Chapter7.Fsharp.Order

let order1 = 
    order {
        buy "IBM" At Price 100 For "NOMURA"
        sell "GOOGLE" At LimitPrice 70 For "CHASE"
    }
    |> Seq.toList