A cheatsheet for F#'s DSL-friendly features
===

This document gives you an overview of F#'s goodies for DSL development. 
It assumes you are familiar with F# syntax; the features are introduced in the order of their encounters by the author.

---

- **Named arguments**

  F# class constructors and methods accept named arguments. 
  This is an advantage to shorten a chain of method calls and avoid the need of fluent style.

  ```fsharp
  /// Using named arguments
  let order = Order.Buy(
                      quantity = 100, 
                      security = "IBM", 
                      atLimitPrice = 300, 
                      allOrNone = true, 
                      valueAs = StandardOrderValuer
                        )
  /// Using fluent style
  let order = Order().Buy(100, "IBM")
                     .AtLimitPrice(300)
                     .AllOrNone(true)
                     .ValueAs(StandardOrderValuer)
  ```
