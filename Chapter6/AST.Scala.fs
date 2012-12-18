module FSharpx.Books.DSLsInAction.Chapter6.Scala.AST

open System

type Currency = USD | HKD | JPY

type IsIn = string
type DateOfIssue = DateTime
type DateOfMaturity = DateTime
type Nominal = float
type Percent = float
type PaymentSchedule = Map<string, float>

type Instrument =
    | Equity of IsIn * DateOfIssue
    | CouponBond of IsIn * DateOfIssue * DateOfMaturity * Nominal * PaymentSchedule
    | DiscountBond of IsIn * DateOfIssue * DateOfMaturity * Nominal * Percent

let IBM = DiscountBond("ISIN-1234", DateTime.Today, DateTime.Today, 10000.0, 4.0)
let IBM_EQ = Equity("ISIN-3456", DateTime.Today)

type Number = string
type Name = string
type OpenDate = DateTime

type Account =
    | ClientAccount of Number * Name * OpenDate
    | BrokerAccount of Number * Name * OpenDate

let NOMURA = ClientAccount("Nom-123", "Nomura", DateTime.Today)

type TaxFee = TradeTax | Commission | Surcharge | VAT
type Market = NYSE | TOKYO | HKG | SGP

type TradingAccount = Account
type TradeDate = DateTime
type UnitPrice = float
type Quantity = float
type CashValue = float
type Taxes = Map<TaxFee, float>

// Listing 6.5 FixedIncomeTrade Implementation and Instantiation

type Trade =
    | EquityTrade of TradingAccount * Instrument * Currency * TradeDate * Market * Quantity * UnitPrice
    | FixedIncomeTrade of TradingAccount * Instrument * Currency * TradeDate * Market * Quantity * UnitPrice
with member x.Market = match x with (EquityTrade(_, _, _, _, m, _, _) | FixedIncomeTrade(_, _, _, _, m, _, _)) -> m
     member x.Principal = match x with (EquityTrade(_, _, _, _, _, q, u) | FixedIncomeTrade(_, _, _, _, _, q, u)) -> q * u
            
let trade = FixedIncomeTrade(NOMURA, IBM, USD, DateTime.Today, NYSE, 100.0, 42.0)

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

let cashValue trade =
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

    