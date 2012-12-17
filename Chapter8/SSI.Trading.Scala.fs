namespace FSharpx.Books.DSLsInAction.Chapter8.Scala.Trading.SSI

module AST =
    type Market = string
    type Security = string
    type CustomerCode = string
    type BrokerCode = string
    type AccountNo = string
    type Bank = string

    type SettlementModeRule =
        | SettleInternal of AccountNo
        | SettleExternal of Bank * AccountNo

    type SettleCashSecurityRule =
        | SettleCash
        | SettleSecurity

    type SettlementRule =
        | SettleCashSecuritySeparate of (SettleCashSecurityRule * SettlementModeRule) list
        | SettleAll of SettlementModeRule

    type CounterpartyRule = 
        | Customer of CustomerCode
        | Broker of BrokerCode

    type TradeTypeRule = TradeTypeRule of CounterpartyRule * Market option * Security option * AccountNo option

    type StandingRule = StandingRule of TradeTypeRule * SettlementRule

    type StandingRules = StandingRules of StandingRule list

module Parsing =

    open FParsec
    open FParsec.Primitives 
    open FParsec.CharParsers 

    open System
    open AST

    let ws = spaces1
    let str s = pstring s .>> ws
    let betweenStrings s1 s2 p = pstring s1 >>. p .>> pstring s2
    let inline const' x = fun _ -> x

    let stringLit = betweenStrings "\"" "\"" (manySatisfy ((<>) '"'))
    
    let keywords = set [ "at"; "us"; "of"; "on"; "in"; "and"; "with";
                         "internally"; "externally"; "safekeep";
                         "security"; "settle"; "cash"; "trades";
                         "account"; "customer"; "broker"; "market" ]

    type Parser<'a> = Parser<'a, unit>

    let resultSatisfies predicate msg (p: Parser<_>): Parser<_> =
        let error = messageError msg
        fun stream ->
          let state = stream.State
          let reply = p stream
          if reply.Status <> Ok || predicate reply.Result then reply
          else
              stream.BacktrackTo(state) // backtrack to beginning
              Reply(Error, error)

    let symbols = resultSatisfies (not << keywords.Contains) "Should not be a reserved word" stringLit

    let market = symbols .>> ws
    let security = symbols .>> ws
    let customer = symbols .>> ws
    let broker = symbols .>> ws
    let account = symbols .>> ws
    let bank = symbols .>> ws

    let settleMode = tuple2 (str "externally" .>>. str "at" >>. bank) account |>> SettleExternal
                         <|> (str "internally" .>>. str "with" .>>. str "us" .>>. str "at" >>. account |>> SettleInternal)

    let settleCashSecurity = (str "safekeep" >>. str "security" |>> const' SettleSecurity)
                             <|> (str "settle" >>. str "cash" |>> const' SettleCash)

    let settlement = settleMode |>> SettleAll
                     <|> (many (tuple2 settleCashSecurity settleMode) |>> SettleCashSecuritySeparate)

    let counterparty = (str "customer" >>. customer |>> Customer)
                        <|> (str "broker" >>. broker |>> Broker)

    
    let tradeType = tuple4 (str "for" >>. counterparty)
                           (opt (str "in" >>. market .>> str "market"))
                           (opt (str "of" >>. security))
                           (opt ( str "on" >>. str "account" >>. account))
                    |>> TradeTypeRule

    let standingRule = tuple2 (str "settle" >>. str "trades" >>. tradeType) settlement |>> StandingRule

    let standingRules = many standingRule |>> StandingRules

    let parseTradings str = 
        match run standingRules str with
        | Success(result, _, _)   -> result
        | Failure(errorMsg, _, _) -> failwithf "Failure: %s from \"%s\"" errorMsg str 
    



