module FSharpx.Books.DSLsInAction.Chapter8.Scala.Trading.Parsing

open FParsec
open FParsec.Primitives 
open FParsec.CharParsers 

open System

// Listing 8.2 A sample external DSL using Parser Combinators

type Parser<'a> = Parser<'a, unit>

let ws = spaces
let str s = pstring s .>> ws
let betweenStrings s1 s2 p = pstring s1 >>. p .>> pstring s2

let identifier = many1SatisfyL isLetter "identifier" .>> ws
let stringLit = betweenStrings "\"" "\"" (manySatisfy ((<>) '"'))
let account = str "for" >>. str "account" >>. stringLit

let minMax = str "min" <|> str "max"
let numeral = many1SatisfyL isDigit "digit" .>> ws |>> Convert.ToInt32
let price = tuple2 (str "at" >>. opt minMax) numeral

let security = tuple2 numeral (identifier .>> str "shares")

let buySell = str "to" >>. (str "buy" <|> str "sell")

let lineItem = tuple3 security buySell price

let items = betweenStrings "(" ")" (sepBy1 lineItem (str ",")) .>> ws

let order: Parser<_> = tuple2 items account

let parseTradings str = 
    match run order str with
    | Success(result, _, _)   -> result
    | Failure(errorMsg, _, _) -> failwithf "Failure: %s from \"%s\"" errorMsg str

