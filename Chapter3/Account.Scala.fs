module FSharpx.Books.DSLsInAction.Chapter3.Scala

open System.Text

type Status = Open | Closed
type Type = Trading | Settlement | Both
with override x.ToString() = match x with Trading -> "Trading" | Settlement -> "Settlement" | Both -> "Both"

/// Base type, equivalent to Java code fragment
type Account(number: string, firstName: string, accountType) =

    let mutable names = ResizeArray<string>()
    let mutable status = Open
    let mutable interestAccrued = 0.0

    new (number, firstName) = Account(number, firstName, Trading)

    member x.Number = number
    member x.FirstName = firstName
    member x.AccountType = accountType

    member x.Names = names
    member x.Status = status
    member x.InterestAccrued = interestAccrued
      
    member x.IsOpen() = status = Open
    member x.AddName(name) = names.Add(name); x
    member x.Calculate(fn) = interestAccrued <- fn x; interestAccrued
    member x.BelongsTo(name) = name = x.FirstName || Seq.exists ((=) name) x.Names

    override x.ToString() =
        StringBuilder().AppendFormat("{0}", x.Number)
                        .AppendFormat(" has name {0} with account type {1}", x.FirstName, x.AccountType)
                        .ToString()

let calculatorImpl = fun (x: Account) -> 100.0
let inline flip f x y = f y x

/// Augmented type, equivalent to Scala code fragment
type Account with
    static member (<<-)(x: Account, name) = x.AddName(name)
    
let belongsTo name (x: Account) = x.BelongsTo(name)
    
let calculateInterest (x: Account) =
    let fn = fun _ -> 100.0
    x.Calculate fn
