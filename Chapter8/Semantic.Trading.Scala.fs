namespace FSharpx.Books.DSLsInAction.Chapter8.Scala.Trading.Semantic

module AST =
    // Listing 8.5 Semantic Model for Order Processing

    type PriceType = Min | Max
    
    type Price = Price of PriceType option * int

    type Security = Security of int * string

    type BuySell = Buy | Sell

    type LineItem = LineItem of Security * BuySell * Price

    type Items = Items of LineItem list

    type Account = Account of string

    type Order = Order of Items * Account

module Parsing =
    open FParsec
    open FParsec.Primitives 
    open FParsec.CharParsers 

    open System
    open AST

    // Listing 8.6 AST for Order Processing DSL

    type Parser<'a> = Parser<'a, unit>

    let ws = spaces
    let str = pstring
    let betweenStrings s1 s2 p = str s1 >>. p .>> str s2
    let const' x = fun _ -> x

    let identifier = many1SatisfyL isLetter "identifier"
    let stringLit = betweenStrings "\"" "\"" (manySatisfy ((<>) '"'))
    let account = str "for" .>>. ws .>>. str "account" .>>. ws >>. stringLit |>> Account

    let minMax = (str "min" |>> const' Min) <|> (str "max" |>> const' Max)

    let numeral = many1SatisfyL isDigit "digit" |>> Convert.ToInt32
    let price = tuple2 (str "at" >>. ws >>. opt minMax .>> ws) numeral
                |>> fun (po, p) -> if p > 20 then Price(po, p) 
                                   else failwith "Price needs to be > 20"

    let security = tuple2 (numeral .>> ws) (identifier .>> ws .>> str "shares") |>> Security

    let buySell = str "to" >>. ws >>. ((str "buy" |>> const' Buy) <|> (str "sell" |>> const' Sell))

    let lineItem = tuple3 (security .>> ws) (buySell .>> ws) price |>> LineItem

    let items = betweenStrings "(" ")" (sepEndBy1 lineItem (str "," .>> ws)) |>> Items

    let order: Parser<_> = tuple2 (items .>> ws) account |>> Order

    let parseTradings str = 
        match run order str with
        | Success(result, _, _)   -> result
        | Failure(errorMsg, _, _) -> failwithf "Failure: %s from \"%s\"" errorMsg str    


