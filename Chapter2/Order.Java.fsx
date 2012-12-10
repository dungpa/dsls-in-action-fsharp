#load "Order.Java.fs"

open FSharpx.Books.DSLsInAction.Chapter2.Java

let order = Order.Buy(
                      quantity = 100, 
                      security = "IBM", 
                      atLimitPrice = 300, 
                      allOrNone = true, 
                      valueAs = StandardOrderValuer
                        )