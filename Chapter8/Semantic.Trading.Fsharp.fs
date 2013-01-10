module FSharpx.Books.DSLsInAction.Chapter8.Fsharp.Trading.Semantic

type PriceType = Min | Max
    
type Price = Price of PriceType * int

type Security = Security of int * string

type BuySell = Buy | Sell

type LineItem = LineItem of Security * BuySell * Price

type Items = Items of LineItem list

type Account = Account of string

type Order = Order of Items * Account

type At = At
type Shares = Shares

type TradeBuilder() =
    member x.Yield (()) = Items []

    [<CustomOperation("buy")>]
    member x.Buy (Items sources, i: int, s: string, sh: Shares, a: At, m: PriceType, p: int) =
        Items [ yield! sources
                yield LineItem(Security(i, s), Buy, Price(m, p)) ]
  
    [<CustomOperation("sell")>]
    member x.Sell (Items sources, i: int, s: string, sh: Shares, a: At, m: PriceType, p: int) =
        Items [ yield! sources
                yield LineItem(Security(i, s), Sell, Price(m, p)) ]  

let trade = TradeBuilder()

let inline applyFor constr s items = Order(items, constr s)

