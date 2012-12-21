#load "Account.Fsharp.fs"
open FSharpx.Books.DSLsInAction.Chapter3.Fsharp

let acc1 = Account("acc-1", "David P.")
let acc2 = Account("acc-2", "John S.")
let acc3 = Account("acc-3", "Fried T.")

acc1 <<- "Mary R." <<- "Shawn P." <<- "John S."

let accounts = [acc1; acc2; acc3]

sequence {
    for acc in accounts do
    map acc.FirstName
}
|> Seq.iter (printfn "%O")

let threshold = 0.0

sequence {
    for acc in accounts do
    filter (acc.BelongsTo "John S.")
    map (acc.Calculate calculatorImpl) into x
    filter (x > threshold)
}
|> Seq.fold (+) 0.0

sequence {
    for acc in accounts do
    filter (acc.BelongsTo "John S.")
    map (Account.calculateInterest acc) into x
    filter (x > threshold)
}
|> Seq.fold (+) 0.0
