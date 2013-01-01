A cheatsheet for F#'s DSL-friendly features
===

This document gives you an overview of F#'s goodies for DSL development. 
It assumes you are familiar with F# syntax; the features are introduced in the order of their encounters by the author.
This is by no means a complete reference of F#'s DSL-friendly functionalities. 
Most of the features are introduced in the context of internal DSLs; however, some of them are helpful in making external DSLs as well. 
These features are mostly emerged in the translation of [the book](http://www.manning.com/ghosh/)'s examples.

---

### Named arguments ###

F# class constructors and methods accept named arguments. 
This is an advantage to shorten a chain of method calls and avoid the need of fluent style.

```fsharp
/// from Chapter2/Order.Java.fsx
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
Records are very natural in expressing DSLs.
They create associations between names and values.
Since a value is required for each field, sometimes augmenting a record from default values `{Default with ...}` is very handy to create an implicit context.

```fsharp
/// from Chapter3/Order.Groovy1.fsx
let orders = Empty

orders <<- NewOrder.To.Buy(100 .Shares.Of "IBM") {
  limitPrice = 300
  allOrNone = true
  valueAs = fun qty unitPrice -> qty * unitPrice - 500
}
```
---

### Discriminated unions & pattern matching ###
Discriminated unions is a concise and type-safe way to model sum types. 
Its combination with pattern matching does give a look of a DSL in processing data.
Along the line of DUs, [active patterns](http://msdn.microsoft.com/en-us/library/dd233248.aspx) is also a cool feature for DSLing.
Active patterns give different *views* on the same data, which may be convenient if you implement DSLs on top of other F#/C# assemblies. 

```fsharp
/// from Chapter3/Account.Scala.fs
type Status = Open | Closed
type Type = Trading | Settlement | Both

match status with
| Open -> printfn "open"
| Closed -> printfn "closed"
```
---
### Unit of measures ###

This feature is not used very often in the translated examples, but it is worth mentioning anyway.
UoMs are extremely nice to create DSLs in domains of science, engineering, etc. 
One of the nice DSLs using UoMs is ODSL which is [Microsoft SolverFoundation's DSL for optimization domain](http://blogs.msdn.com/b/lengningliu/archive/2009/09/04/optimization-domain-specific-language-in-f-with-units-of-measure.aspx).
This DSL uses F# quotations to make placeholders for language elements and utilizes UoMs for expressing different kinds of units.

---

### Infix functions ###
Using infix functions is a great way to derive concise and composable DSLs. 
Since F# only allows symbolic infix operators, the use of infix operators is more limited than that in other functional programming languages.
```fsharp
/// from Chapter3/Account.Scala.fs
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
/// from Chapter3/Account.Scala.fs
accounts 
|> Seq.filter (Account.belongsTo "John S.")
|> Seq.map Account.calculateInterest
|> Seq.filter (flip (>) threshold)
|> Seq.fold (+) 0.0
```       
---
### High-order functions & function composition ###
High-order functions and function composition are important to create DSLs in a declarative style.
Note that the example in *pipeline operators* section above also demonstrates these concepts.
In Chapter 7 and Chapter 8, we use [FParsec](http://www.quanttec.com/fparsec/), an F# parser combinator library to implement external DSLs.
FParsec can be considered as an DSL for writing parsers. 
The library is a beautiful example of crafting combinators for composition, succinctness, readability, etc; which are main goals of declarative DSLs.

---
### Computation expressions ###
Computation expressions is a blessing to making DSLs in F#.
In F# 3.0, the opportunities are even bigger with extended keywords thanks to the use of [CustomOperation](http://msdn.microsoft.com/en-us/library/hh289709.aspx) attribute.
Here is an excerpt of producing and consuming custom keywords.

```fsharp
/// from Chapter8/Semantic.Trading.Fsharp.fs
type TradeBuilder() =
    member x.Yield (()) = Items []

    [<CustomOperation("buy")>]
    member x.Buy (Items sources, i: int, s: string, sh: Shares, a: At, m: PriceType, p: int) : Items =
        Items [ yield! sources
                yield LineItem(Security(i, s), Buy, Price(m, p)) ]
  
    [<CustomOperation("sell")>]
    member x.Sell (Items sources, i: int, s: string, sh: Shares, a: At, m: PriceType, p: int) : Items =
        Items [ yield! sources
                yield LineItem(Security(i, s), Sell, Price(m, p)) ]  

let trade = TradeBuilder()

let example = 
    trade {
        buy 100 "IBM" Shares At Max 45
        sell 40 "Sun" Shares At Min 24
        buy 25 "CISCO" Shares At Max 56 
    }
```

---
### Code quotations ###
Code quotations is an F#-ish facility for metaprogramming. 
It's easy to turn a function or a value to an F# Abstract Syntax Tree (AST) with quotations.
DSL implementation often uses quotations as placeholders to build a nice surface API and manipulates ASTs behind the scene in an appropriate way.
In this project, we do not use quotations; however, many F# DSLs are built upon this technique e.g. [the query language in F# 2.0](http://blogs.msdn.com/b/dsyme/archive/2009/10/23/a-quick-refresh-on-query-support-in-the-f-power-pack.aspx).

---

### Type augmentation ###
You can easily add extension methods to a built-in or user-defined type in F#. 
This is very handy to inject new functionalities to known types and make DSLs more readable.
```fsharp
/// from Chapter2/Order.Groovy.fs
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
[Type constraints and *inline* keyword](http://msdn.microsoft.com/en-us/library/dd548046.aspx) are used to stretch F#'s type system for some advance features such as duck typing, etc.
They are really helpful if what you're trying to express is beyond capabilities of F# static type system. 
However, these features are not recommended since they can lead to incomprehensible programs and obscure error messages.
