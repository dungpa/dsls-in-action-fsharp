module FSharpx.Books.DSLsInAction.Chapter4.Scala.Trade

// Listing 4.11 Trade with typed constraints                                                                     

type Account = class end
type Trading = class inherit Account end
type Settlement = class inherit Account end

type Trade<'A when 'A :> Trading> =
    abstract member Account: 'A
    abstract member ValueOf: unit -> unit

// Listing 4.12 Equity Trade and Fixed Income Trade

type Instrument = class end
type Stock = class inherit Account end
type FixedIncome = class inherit Account end

[<AbstractClass>]
type EquityTrade<'S when 'S :> Stock> =
    abstract member Equity: 'S
    interface Trade<Trading> with
        member x.Account = failwith "Not implemented yet"
        member x.ValueOf() = ()

[<AbstractClass>]
type FixedIncomeTrade<'F when 'F :> Stock> =
    abstract member FI: 'F
    interface Trade<Trading> with
        member x.Account = failwith "Not implemented yet"
        member x.ValueOf() = ()