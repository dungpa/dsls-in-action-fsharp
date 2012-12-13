A cheatsheet for F#'s DSL-friendly features
===

This document gives you an overview of F#'s goodies for DSL development. 
It assumes you are familiar with F# syntax; the features are introduced in the order of their encounters by the author.

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
### Discriminated unions ###
---
### Infix functions ###
---
### Pipe operators ###

  Pipe operators (`|>`, `<|`, `||>`, `<||`, etc) are commonly-used in F#. 
  They help to reorder functions to show flow of processing and give good hints to F# type checker. 
  An appropriate use of pipe operators can give a look of small DSL in manipulating data.
  
  ```fsharp
  /// Using pipe operators (from Chapter3/Account.Scala.fs)
  accounts 
  |> Seq.filter (Account.belongsTo "John S.")
  |> Seq.map Account.calculateInterest
  |> Seq.filter (flip (>) threshold)
  |> Seq.fold (+) 0.0
  ```       
---
### Type augmentation ###
---
### Type constraints ###
