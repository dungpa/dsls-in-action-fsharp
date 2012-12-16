module FSharpx.Books.DSLsInAction.Chapter7.Java.Parser

open FParsec
open FParsec.Primitives 
open FParsec.CharParsers 

open System
open FSharpx.Books.DSLsInAction.Chapter7.Java.Order

let ws = spaces
let str = pstring

let identifier = many1SatisfyL isLetter "identifier"
let account = str "for" .>>. ws >>. identifier

let numeral = many1SatisfyL isDigit "digit" |>> Convert.ToInt32
let limitPrice = str "limitprice" .>>. ws .>>. str "=" .>>. ws >>. numeral
let price = str "@" .>>. ws >>. (numeral <|> limitPrice)

let security = identifier

let order = tuple4 ((str "buy" <|> str "sell") .>> ws) 
                    (security .>> ws)
                    (price .>> ws)
                    account
            |>> Order.Create

let orders = sepEndBy1 order newline .>> eof

let parseOrders str = 
    match run orders str with
    | Success(result, _, _)   -> result
    | Failure(errorMsg, _, _) -> failwithf "Failure: %s from \"%s\"" errorMsg str