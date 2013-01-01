#load "Semantic.Trading.Fsharp.fs"

open FSharpx.Books.DSLsInAction.Chapter8.Fsharp.Trading.Semantic

let example = 
    trade {
        buy 100 "IBM" Shares At Max 45
        sell 40 "Sun" Shares At Min 24
        buy 25 "CISCO" Shares At Max 56 
    }
    |> applyFor Account "A1234"

