module FSharpx.Books.DSLsInAction.Chapter6.Scala.Instrument

open System

// Listing 6.2 Instrument model in F#

type Currency = Currency of string

let USD = Currency("US Dollar")
let JPY = Currency("Japanese Yen")
let HKD = Currency("Hong Kong Dollar")

type Instrument =
    abstract member IsIn: string

type Equity(isIn: string, ?dateOfIssue: DateTime) =    
    interface Instrument with
        member x.IsIn = isIn
    member x.DateOfIssue = defaultArg dateOfIssue DateTime.Today
    member x.IsIn = isIn

let (|Equity|_|) (e: Equity) = Some(e.IsIn, e.DateOfIssue)
    
type FixedIncome =
    abstract member DateOfIssue: DateTime
    abstract member DateOfMaturity: DateTime
    abstract member Nominal: decimal

type CouponBond(isIn: string, dateOfMaturity: DateTime, nominal: decimal, 
                paymentSchedule: Map<string, decimal>, ?dateOfIssue: DateTime) =
    member x.PaymentSchedule: Map<string, decimal> = Map.empty
    interface Instrument with
        member x.IsIn = isIn
    interface FixedIncome with
        member x.DateOfIssue = DateTime.Today
        member x.DateOfMaturity = DateTime.Today
        member x.Nominal = Convert.ToDecimal(0)

type DiscountBond(isIn: string) =
    member x.Percent = Convert.ToDecimal(0)
    interface Instrument with
        member x.IsIn = isIn
    interface FixedIncome with
        member x.DateOfIssue = DateTime.Today
        member x.DateOfMaturity = DateTime.Today
        member x.Nominal = Convert.ToDecimal(0)

//let IBM = DiscountBond("ISIN-1234", DateTime.Today, DateTime.Today, 10000, 4)
let IBM_EQ = Equity("ISIN-3456")