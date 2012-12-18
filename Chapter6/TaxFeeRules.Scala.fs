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
let hundredPercent = 100.0

let calculateAs(trade: Trade) = function
    | TradeTax -> 5.0/hundredPercent * trade.Principal
    | Commission -> 20.0/hundredPercent * trade.Principal
    | Surcharge -> 7.0/hundredPercent * trade.Principal
    | VAT -> 7.0/hundredPercent * trade.Principal

let calculateTaxFee trade = 
    forTrade trade 
    |> List.map (fun taxfee -> taxfee, calculateAs trade taxfee)

let totalTaxFee trade =
    calculateTaxFee trade
    |> List.fold (fun acc (_, p)-> acc + p) 0.0

let accruedInterest _ = 100.0

let CashValue trade =
    match trade with
    | EquityTrade _ -> trade.Principal + totalTaxFee(trade)
    | FixedIncomeTrade _ -> trade.Principal + accruedInterest(trade) + totalTaxFee(trade)

type Money = M of float * Currency

type IQ = IQ of Instrument * Quantity
with member x.ForClient(a: Account) = match x with IQ(i, q) -> AIQ(a, i, q)

and AIQ = AIQ of Account * Instrument * Quantity
with member x.On(m: Market) = match x with AIQ(a, i, q) -> MAIQ(m, a, i, q)

and MAIQ = MAIQ of Market * Account * Instrument * Quantity
with member x.At(c: Money) = 
            match x, c with 
            | MAIQ(m, a, i, q), M(v, c) -> FixedIncomeTrade(a,i, c, DateTime.Today, m, q, v)

type System.Int32 with
     member q.DiscountBonds(i: Instrument) = IQ (i, float q)
     member v.CCY(c: Currency) = M(float v, c)

[<AutoOpen>]
module Operators =
    let inline DiscountBonds (i: Instrument) (f: float) = i, f
    let inline ForClient (a: Account) (i, f) = a, i, f
    let inline On (m: Market) (a, i, f) = m, a, i, f
    let inline CCY v (c: Currency) = v, c
    let inline At (v, c) (m, a, i, f) = FixedIncomeTrade(a,i, c, DateTime.Today, m, f, v)

    