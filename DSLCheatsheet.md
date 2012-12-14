A cheatsheet for F#'s DSL-friendly features
===

This document gives you an overview of F#'s goodies for DSL development. 
It assumes you are familiar with F# syntax; the features are introduced in the order of their encounters by the author.
This is by no means a complete reference of F#'s DSL-friendly features. 
These features are mostly emerged in the translation of the book's examples.

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

---

### Infix functions ###
Using infix functions is a great way to derive concise and composable DSLs. 
Since F# only allows symbolic infix operators, the use of infix operators is more limited than other functional programming languages.
```fsharp
/// (from Chapter3/Order.Groovy.fs)
let Empty = new ResizeArray<Order>()
let (<<-) (ra: ResizeArray<_>) el = ra.Add el

let orders = Empty
let order1 = NewOrder.To.Buy(100 .Shares.Of "IBM") {
    limitPrice = 300
    allOrNone = true
    valueAs = fun qty unitPrice -> qty * unitPrice - 500
}
orders <<- order1
```

---

### Pipepline operators ###

Pipepline operators (`|>`, `<|`, `||>`, `<||`, etc) are commonly-used in F#. 
They help to reorder functions to show flow of processing and give good hints to F# type checker. 
An appropriate use of pipepline operators can give a look of small DSL in manipulating data.
  
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
---
### Type constraints ###
