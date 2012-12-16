module FSharpx.Books.DSLsInAction.Chapter7.Java.Order

open System.Text

type Order (buySell: string, security: string, price: int, account: string) = 
    member x.BuySell = buySell
    member x.Security = security
    member x.Price = price
    member x.Account = account

    static member Create(buySell, security, price, account) =
           Order(buySell, security, price, account)

    override x.ToString() =
            StringBuilder().AppendFormat("Order is {0} / {1} / {2} / {3}", x.BuySell, x.Security, x.Price, x.Account)
                           .ToString()
