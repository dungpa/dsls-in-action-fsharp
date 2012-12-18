module FSharpx.Books.DSLsInAction.Chapter6.Scala.Trade

open System

open FSharpx.Books.DSLsInAction.Chapter6.Scala
open Account
open Instrument

// Listing 6.5 FixedIncomeTrade Implementation and Instantiation

type Currency = USD | HKD | JPY
type TaxFee = TradeTax | Commission | Surcharge | VAT
type Market = NYSE | TOKYO | HKG | SGP

type TradingAccount = Account
type TradeDate = DateTime
type UnitPrice = float
type Quantity = float
type CashValue = float

type Trade =
    | EquityTrade of TradingAccount * Instrument * Currency * TradeDate * Market * Quantity * UnitPrice
    | FixedIncomeTrade of TradingAccount * Instrument * Currency * TradeDate * Market * Quantity * UnitPrice
with member x.Market = match x with (EquityTrade(_, _, _, _, m, _, _) | FixedIncomeTrade(_, _, _, _, m, _, _)) -> m
     member x.Principal = match x with (EquityTrade(_, _, _, _, _, q, u) | FixedIncomeTrade(_, _, _, _, _, q, u)) -> q * u
            
let trade = FixedIncomeTrade(NOMURA, IBM, USD, DateTime.Today, NYSE, 100.0, 42.0)


