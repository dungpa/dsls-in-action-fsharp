module FSharpx.Books.DSLsInAction.Chapter4.Scala.Instrument

open System

// Listing 6.2 Instrument model in F#

type Currency = Currency of string

let (|USD|_|) = function Currency("US Dollar") -> Some () | _ -> None
let (|JPY|_|) = function Currency("Japanese Yen") -> Some () | _ -> None
let (|HKD|_|) = function Currency("Hong Kong Dollar") -> Some () | _ -> None

type Instrument =
    abstract member IsIn: unit -> string

type Equity(isIn: string, dateOfIssue: DateTime) =
    interface Instrument with
        member x.IsIn() = isIn

type FixedIncome =
    abstract member DateOfIssue: DateTime
    abstract member DateOfMaturity: DateTime
    abstract member Nominal: decimal

type CouponBond(isIn: string) =
    member x.PaymentSchedule: Map<string, decimal> = Map.empty
    interface Instrument with
        member x.IsIn() = isIn
    interface FixedIncome with
        member x.DateOfIssue = DateTime.Today
        member x.DateOfMaturity = DateTime.Today
        member x.Nominal = Convert.ToDecimal(0)

type DiscountBond(isIn: string) =
    member x.Percent = Convert.ToDecimal(0)
    interface Instrument with
        member x.IsIn() = isIn
    interface FixedIncome with
        member x.DateOfIssue = DateTime.Today
        member x.DateOfMaturity = DateTime.Today
        member x.Nominal = Convert.ToDecimal(0)