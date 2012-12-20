#load "Instrument.Scala.fs"
#load "Account.Scala.fs"
#load "Trade.Scala.fs"
#load "TaxFeeRules.Scala.fs"

open FSharpx.Books.DSLsInAction.Chapter6.Scala
open Instrument
open Account
open Trade
open TaxFeeRules

let fixedIncomeTrade1 =
    200.0 |> DiscountBonds IBM
          |> ForClient NOMURA
          |> On NYSE
          |> At (CCY 72.0 USD)

let fixedIncomeTrade2 =
    100.0 |> DiscountBonds IBM
          |> ForClient NOMURA
          |> On HKG
          |> At (CCY 77.0 USD)

let trades = [fixedIncomeTrade1; fixedIncomeTrade2]

// Stubs
let validate trade = true
let enrich trade = true
let journalize trade = true

let results = 
    seq {
        for trade in trades do
            if validate(trade) && enrich(trade) && journalize(trade) then
                yield trade
    }

printfn "Results: ";;
Seq.iter (printfn "%A, ") results