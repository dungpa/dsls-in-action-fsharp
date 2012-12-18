module FSharpx.Books.DSLsInAction.Chapter6.Scala.Trade

open System

open Account
open Instrument

type Market = NYSE | TOKYO | HKG | SGP

// Listing 6.4 Trade model in F#

[<AbstractClass>]
type Trade =
    abstract member TradingAccount: Account
    abstract member Instrument: Instrument
    abstract member Currency: Currency
    abstract member TradeDate: DateTime
    abstract member UnitPrice: decimal
    abstract member Quantity: decimal
    abstract member Market: Market
    abstract member CashValue: decimal
    abstract member Taxes: Map<TaxFee, decimal>
    member x.Principal = x.UnitPrice * x.Quantity

and TaxFee = TaxFee of string

[<AbstractClass>]
type FixedIncomeTrade =
    inherit Trade
    abstract member Instrument: FixedIncome
    abstract member AccruedInterest: decimal

[<AbstractClass>]
type EquityTrade =
    inherit Trade
    abstract member Instrument: Equity

