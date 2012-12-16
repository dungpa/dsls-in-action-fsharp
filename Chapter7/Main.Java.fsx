#I @"../packages/FParsec.0.9.2.0/lib/net40"
#r "FParsecCS"
#r "FParsec"

#load "Order.Java.fs"
#load "Parser.Java.fs"

open FSharpx.Books.DSLsInAction.Chapter7.Java.Parser

let example = """buy IBM @ 100 for NOMURA
sell GOOGLE @ limitprice = 70 for CHASE"""

let result = parseOrders example
