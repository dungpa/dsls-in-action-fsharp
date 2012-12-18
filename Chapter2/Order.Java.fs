module FSharpx.Books.DSLsInAction.Chapter2.Java

open System.Text

type BuySell = Bought | Sold
with override x.ToString() = match x with Bought -> "Bought" | Sold -> "Sold"

/// Implement an order type using named arguments.
/// The constructor is kept private to use factory methods instead.
type Order private (boughtOrSold, quantity, security: string, atLimitPrice, allOrNone, valueAs: int -> int -> int) = 
    member x.BoughtOrSold = boughtOrSold
    member x.Quantity = quantity
    member x.Security = security
    member x.LimitPrice = atLimitPrice
    member x.AllOrNone = allOrNone
    member x.Value = valueAs quantity atLimitPrice

    static member Buy(quantity, security, atLimitPrice, allOrNone, valueAs) =
            Order(Bought, quantity, security, atLimitPrice, allOrNone, valueAs)

    static member Sell(quantity, security, atLimitPrice, allOrNone, valueAs) =
            Order(Sold, quantity, security, atLimitPrice, allOrNone, valueAs)

    override x.ToString() =
            StringBuilder().AppendFormat("{0}", x.BoughtOrSold)
                           .AppendFormat(" {0} shares of {1}", x.Quantity, x.Security)
                           .AppendFormat(" with limit price {0} ", x.LimitPrice)
                           .Append(if x.AllOrNone then "ALL OR NONE" else "")
                           .ToString()

let StandardOrderValuer = fun quantity unitPrice -> unitPrice * quantity
