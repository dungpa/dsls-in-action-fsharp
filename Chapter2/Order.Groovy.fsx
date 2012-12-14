#load "Order.Groovy.fs"

open FSharpx.Books.DSLsInAction.Chapter2.Groovy

let order = 
    NewOrder.To.Buy(100 .Shares.Of "IBM") {
        limitPrice = 300
        allOrNone = true
        valueAs = fun quantity unitPrice -> quantity * unitPrice - 500
}