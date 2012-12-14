#load "Account.Scala.fs"
open FSharpx.Books.DSLsInAction.Chapter3.Scala

let acc1 = Account("acc-1", "David P.")
let acc2 = Account("acc-2", "John S.")
let acc3 = Account("acc-3", "Fried T.")

acc1 <<- "Mary R." <<- "Shawn P." <<- "John S."

let accounts = [acc1; acc2; acc3]
accounts |> Seq.filter (Account.belongsTo "John S.")
         |> Seq.map (fun x -> x.FirstName)
         |> Seq.iter (printfn "%O")
let threshold = 0.0

/// Application of high-order functions / combinators
accounts |> Seq.filter (Account.belongsTo "John S.")
         |> Seq.map (fun x -> x.calculate calculatorImpl)
         |> Seq.filter (flip (>) threshold)
         |> Seq.fold (+) 0.0

accounts |> Seq.filter (Account.belongsTo "John S.")
         |> Seq.map Account.calculateInterest
         |> Seq.filter (flip (>) threshold)
         |> Seq.fold (+) 0.0