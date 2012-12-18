module FSharpx.Books.DSLsInAction.Chapter6.Scala.TaxFee

open Trade

type TaxFee = TaxFee of string

let TradeTax = TaxFee("Trade Tax")
let Commisson = TaxFee("Commission")
let Surcharge = TaxFee("Surcharge")
let VAT = TaxFee("VAT")

type TaxFeeCalculator =
    abstract member calculateTaxFee: Trade -> Map<TaxFee, decimal>



