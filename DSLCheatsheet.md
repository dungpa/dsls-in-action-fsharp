A cheatsheet for F#'s DSL-friendly features
===

This document gives you an overview of F#'s goodies for DSL development. 
It assumes you are familiar with F# syntax; the features are introduced in the order of their encounters by the author.
This is by no means a complete reference of F#'s DSL-friendly functionalities. 
These features are mostly emerged in the translation of the book 's examples.

---

### Named arguments ###

F# class constructors and methods accept named arguments. 
This is an advantage to shorten a chain of method calls and avoid the need of fluent style.

```fsharp
/// Using named arguments (from Chapter2/Order.Java.fsx)
let order = Order.Buy(
                    quantity = 100, 
                    security = "IBM", 
                    atLimitPrice = 300, 
                    allOrNone = true, 
                    valueAs = StandardOrderValuer
                    )
/// Using fluent style
let order = Order()
            .Buy(100, "IBM")
            .AtLimitPrice(300)
            .AllOrNone(true)
            .ValueAs(StandardOrderValuer)
```
---
### Records ###
---

### Discriminated unions & pattern matching ###
Discriminated unions is a concise and typesafe way to model sum types. 
Its combination with pattern matching does give a look of a DSL in processing data.
```fsharp
/// (from Chapter3/Account.Scala.fs)
type Status = Open | Closed
type Type = Trading | Settlement | Both

match status with
| Open -> printfn "open"
| Closed -> printfn "closed"
```
---
### Active patterns ###
---
### Unit of measures ###
---

### Infix functions ###
Using infix functions is a great way to derive concise and composable DSLs. 
Since F# only allows symbolic infix operators, the use of infix operators is more limited than that in other functional programming languages.
```fsharp
/// (from Chapter3/Account.Scala.fs)
type Account with
    static member (<<-)(x: Account, name) = x.addName(name)
            
let acc1 = Account("acc-1", "David P.")
acc1 <<- "Mary R." <<- "Shawn P." <<- "John S."
```
---

### Pipepline operators ###

Pipepline operators (`|>`, `<|`, `||>`, `<||`, etc) are commonly-used in F#. 
They help to reorder functions to show flow of processing and give good hints to F# type checker. 
An appropriate use of pipepline operators can give a look of a small DSL in manipulating data.
  
```fsharp
/// Using pipepline operators (from Chapter3/Account.Scala.fs)
accounts 
|> Seq.filter (Account.belongsTo "John S.")
|> Seq.map Account.calculateInterest
|> Seq.filter (flip (>) threshold)
|> Seq.fold (+) 0.0
```       
---
### High-order functions & function composition ###
---
### Computation expressions ###
---

### Type augmentation ###
You can easily add extension methods to a built-in or user-define type in F#. 
This is very helpful to inject new functionalities to known types and make DSLs more readable.
```fsharp
/// (from Chapter2/Order.Groovy.fs)
type Int32 with
    member x.Shares = x
    member x.Of (s: string) = x, s
    
let order = 
    NewOrder.To.Buy(100 .Shares.Of "IBM") {
        limitPrice = 300
        allOrNone = true
        valueAs = fun quantity unitPrice -> quantity * unitPrice - 500
}    
```
---
### Type constraints ###
