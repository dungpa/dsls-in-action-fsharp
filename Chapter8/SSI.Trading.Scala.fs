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

    type TradeTypeRule = TradeTypeRule of Market option * Security option * AccountNo option

    type StandingRule = StandingRule of TradeTypeRule * SettlementRule

    type StandingRules = StandingRules of StandingRule list

