#load "Order.Groovy.fs"
open FSharpx.Books.DSLsInAction.Chapter3.Groovy
fsi.AddPrinter(fun (ra: ResizeArray<Order>) -> sprintf "%A" ra)

// F# script for Order Placement

let orders = Empty

orders <<- NewOrder.To.Buy(100 .Shares.Of "IBM") {
  limitPrice = 300
  allOrNone = true
  valueAs = fun qty unitPrice -> qty * unitPrice - 500
}

orders <<- NewOrder.To.Buy(150 .Shares.Of "GOOG") {
  limitPrice = 300
  allOrNone = true
  valueAs = fun qty unitPrice -> qty * unitPrice - 500
}

orders <<- NewOrder.To.Buy(200 .Shares.Of "MSOFT") {
  limitPrice = 300
  allOrNone = true
  valueAs = fun qty unitPrice -> qty * unitPrice - 500
}

orders