module FSharpx.Books.DSLsInAction.Chapter3.Scala

type Status = Open | Closed
type Type = Trading | Settlement | Both

/// Base type, equivalent to Java code fragment
type Account(number: string, firstName: string, accountType) =
    let mutable number = number
    let mutable firstName = firstName
    let mutable accountType = accountType

    let mutable names = ResizeArray<string>()
    let mutable status = Open
    let mutable interestAccrued = 0.0

    new (number, firstName) = Account(number, firstName, Trading)

    member x.Number with get() = number
    member x.FirstName with get() = firstName
    member x.AccountType with get() = accountType

    member x.Names with get() = names
    member x.Status with get() = status
    member x.InterestAccrued with get() = interestAccrued
      
    member x.isOpen() = status = Open
    member x.addName(name) = names.Add(name); x
    member x.calculate(fn) = interestAccrued <- fn x; interestAccrued

let calculatorImpl = fun (x: Account) -> 100.0
let inline flip f x y = f y x

/// Augmented type, equivalent to Scala code fragment
type Account with
    static member belongsTo name (x: Account) = name = x.FirstName || Seq.exists ((=) name) x.Names
    static member (<<-)(x: Account, name) = x.addName(name)
    static member calculateInterest (x: Account) =
            let fn = fun _ -> 100.0
            x.calculate fn