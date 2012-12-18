#load "Instrument.Scala.fs"
#load "Account.Scala.fs"
#load "Trade.Scala.fs"
#load "TaxFeeRules.Scala.fs"

open FSharpx.Books.DSLsInAction.Chapter6.Scala
open Instrument
open Account
open Trade
open TaxFeeRules

let fixedIncomeTrade =
    200.0 |> DiscountBonds IBM
          |> ForClient NOMURA
          |> On NYSE
          |> At (CCY 72.0 USD)

let v = 200.0 |> DiscountBonds IBM
              |> ForClient NOMURA
              |> On NYSE
              |> At (CCY 72.0 USD)
              |> CashValue
