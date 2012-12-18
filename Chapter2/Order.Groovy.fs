module FSharpx.Books.DSLsInAction.Chapter2.Groovy

open System
open System.Text

type BuySell = Bought | Sold
with override x.ToString() = match x with Bought -> "Bought" | Sold -> "Sold"

type PartialOrder = {
    limitPrice: int
    allOrNone: bool
    valueAs: int -> int -> int
}

type Order private (boughtOrSold, quantity, security, limitPrice, allOrNone, valueAs) = 
    member x.BoughtOrSold = boughtOrSold
    member x.Quantity = quantity
    member x.Security = security
    member x.LimitPrice = limitPrice
    member x.AllOrNone = allOrNone
    member x.Value = valueAs quantity limitPrice

    static member Default = new Order(Bought, quantity = 0, security = "", limitPrice = 0, 
                                 allOrNone = true, valueAs = Unchecked.defaultof<_>)

    member x.To = x
    member x.Buy (qty, sec) po =
            Order(Bought, qty, sec, po.limitPrice, po.allOrNone, po.valueAs)
    member x.Sell (qty, sec) po =
            Order(Sold, qty, sec, po.limitPrice, po.allOrNone, po.valueAs)
    
    override x.ToString() =
            StringBuilder().AppendFormat("{0}", x.BoughtOrSold)
                           .AppendFormat(" {0} shares of {1}", x.Quantity, x.Security)
                           .AppendFormat(" with limit price {0} ", x.LimitPrice)
                           .Append(if x.AllOrNone then "ALL OR NONE" else "")
                           .ToString()

let NewOrder = Order.Default

type Int32 with
    member x.Shares = x
    member x.Of (s: string) = x, s
    
