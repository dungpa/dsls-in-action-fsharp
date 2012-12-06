#load "Order.Groovy.fs"
open FSharpx.Books.DSLsInAction.Chapter2.Order.Groovy
fsi.AddPrinter(fun (ra: ResizeArray<Order>) -> sprintf "%A" ra)

// Yet another F# script for Order Placement
(
    let orders = Empty

    let order1 = NewOrder.To.Buy(100 .Shares.Of "IBM") {
      limitPrice = 300
      allOrNone = true
      valueAs = fun qty unitPrice -> qty * unitPrice - 500
    }
    orders <<- order1

    let order2 = NewOrder.To.Buy(150 .Shares.Of "GOOG") {
      limitPrice = 300
      allOrNone = true
      valueAs = fun qty unitPrice -> qty * unitPrice - 500
    }
    orders <<- order2

    let order3 = NewOrder.To.Buy(200 .Shares.Of "MSOFT") {
      limitPrice = 300
      allOrNone = true
      valueAs = fun qty unitPrice -> qty * unitPrice - 500
    }
    orders <<- order3

    printfn "Orders..."
    orders
)