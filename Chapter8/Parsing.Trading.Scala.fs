module FSharpx.Books.DSLsInAction.Chapter8.Scala.Trading.Parsing

open FParsec
open FParsec.Primitives 
open FParsec.CharParsers 

open System

// Listing 8.2 A sample external DSL using Parser Combinators

type Parser<'a> = Parser<'a, unit>

let ws = spaces
let str = pstring
let betweenStrings s1 s2 p = str s1 >>. p .>> str s2

let identifier = many1SatisfyL isLetter "identifier"
let stringLit = betweenStrings "\"" "\"" (manySatisfy ((<>) '"'))
let account = str "for" .>>. ws .>>. str "account" .>>. ws >>. stringLit

let min_max = str "min" <|> str "max"
let numeral = many1SatisfyL isDigit "digit" |>> Convert.ToInt32
let price = tuple2 (str "at" >>. ws >>. min_max .>> ws) numeral

let security = tuple2 (numeral .>> ws) (identifier .>> ws .>> str "shares")

let buy_sell = str "to" >>. ws >>. (str "buy" <|> str "sell")

let line_item = tuple3 (security .>> ws) (buy_sell .>> ws) price

let items = betweenStrings "(" ")" (sepEndBy1 line_item (str "," .>> ws))

let order: Parser<_> = tuple2 (items .>> ws) account

let parseTradings str = 
    match run order str with
    | Success(result, _, _)   -> result
    | Failure(errorMsg, _, _) -> failwithf "Failure: %s from \"%s\"" errorMsg str



