module FSharpx.Books.DSLsInAction.Chapter7.Fsharp.Order

open System.Text

type BuySell = Buy | Sell
type At = At
type For = For
type PriceType = Price | LimitPrice

type Order (buySell: BuySell, security: string, price: int, account: string) = 
    member x.BuySell = buySell
    member x.Security = security
    member x.Price = price
    member x.Account = account

    static member Create(buySell, security, price, account) =
        Order(buySell, security, price, account)

    override x.ToString() =
        sprintf "Order is {%A} / {%A} / {%A} / {%A}" x.BuySell x.Security x.Price x.Account
                     
type OrderBuilder() =
    member x.Yield (()) = Seq.empty

    [<CustomOperation("buy")>]
    member x.Buy (source : seq<_>, s: string, a: At, p: PriceType, i: int, f: For, acc: string) : seq<Order> =
        seq { yield! source
              yield Order(Buy, s, i, acc) }
  
    [<CustomOperation("sell")>]
    member x.Sell (source : seq<_>, s: string, a: At, p: PriceType, i: int, f: For, acc: string) : seq<Order> =
        seq { yield! source
              yield Order(Sell, s, i, acc) }
  
let order = OrderBuilder()