module FSharpx.Books.DSLsInAction.Chapter6.Scala.TaxFeeRules

open System

open FSharpx.Books.DSLsInAction.Chapter6.Scala
open Instrument
open Account
open Trade

let market = function
    | HKG -> [TradeTax; Commission; Surcharge]
    | SGP -> [TradeTax; Commission; Surcharge; VAT]
    | _ -> [TradeTax; Commission]

let forTrade (trade: Trade) = market trade.Market

type [<Measure>] percent
let hundredPercent = 100.0<percent>

let calculateAs (trade: Trade) = function
    | TradeTax -> 5.0<percent>/hundredPercent * trade.Principal
    | Commission -> 20.0<percent>/hundredPercent * trade.Principal
    | Surcharge -> 7.0<percent>/hundredPercent * trade.Principal
    | VAT -> 7.0<percent>/hundredPercent * trade.Principal

let calculateTaxFee trade = 
    forTrade trade 
    |> List.map (fun taxfee -> taxfee, calculateAs trade taxfee)

let totalTaxFee trade =
    calculateTaxFee trade
    |> List.fold (fun acc (_, p) -> acc + p) 0.0

let accruedInterest _ = 100.0

let CashValue trade =
    match trade with
    | EquityTrade _ -> trade.Principal + totalTaxFee(trade)
    | FixedIncomeTrade _ -> trade.Principal + accruedInterest(trade) + totalTaxFee(trade)

[<AutoOpen>]
module Operators =
    let inline DiscountBonds (i: Instrument) (f: float) = i, f
    let inline ForClient (a: Account) (i, f) = a, i, f
    let inline On (m: Market) (a, i, f) = m, a, i, f
    let inline CCY v (c: Currency) = v, c
    let inline At (v, c) (m, a, i, f) = FixedIncomeTrade(a, i, c, DateTime.Today, m, f, v)