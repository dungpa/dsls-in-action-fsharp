module FSharpx.Books.DSLsInAction.Chapter6.Scala.Instrument

open System

// Listing 6.2 Instrument model in F#

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
let IBMEQ = Equity("ISIN-3456", DateTime.Today)