module FSharpx.Books.DSLsInAction.Chapter4.Ruby.Decorator

// Reference Decorator pattern at http://fsharp3sample.codeplex.com/wikipage?title=Decorate%20pattern
type Trade (refNo: string, account: string, instrument: string, principal: float) =
    let mutable invoke = fst

    member x.RefNo = refNo
    member x.Account = account
    member x.Instrument = instrument
    member x.Principal = principal

    member x.Invoke
        with get() = invoke
        and set(v) = invoke <- v

    member x.Value = x.Invoke(x.Principal, x.Principal)
    member x.With fn = x.Invoke <- fn >> x.Invoke; x

let taxfee (super, principal) = super + principal * 0.2, principal
let commission (super, principal) = super - principal * 0.1, principal

let tr = Trade("r-123", "a-123", "i-123", 200.0).With (taxfee >> commission)
printfn "Value = %O" tr.Value