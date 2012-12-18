#load "AST.Scala.fs"
open FSharpx.Books.DSLsInAction.Chapter6.Scala.AST

let fixedIncomeTrade =
        200 .DiscountBonds(IBM)
            .ForClient(NOMURA)
            .On(NYSE)
            .At(72 .CCY USD)

let v = cashValue(200 .DiscountBonds(IBM)
                      .ForClient(NOMURA)
                      .On(NYSE)
                      .At(72 .CCY USD))
