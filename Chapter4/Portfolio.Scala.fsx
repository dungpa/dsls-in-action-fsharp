#load "Portfolio.Scala.fs"

open FSharpx.Books.DSLsInAction.Chapter4.Scala.Portfolio

let activityReport = 
    ActivityReport("john doe", 
      tradeList [("IBM", 1200); ("GOOGLE", 2000); ("GOOGLE", 350); ("VERIZON", 350); ("IBM", 2100); ("GOOGLE", 1200)])
      
printfn "Activity Report grouping by instrument:\n %A" <| activityReport.groupBy(instrument)
printfn "Activity Report grouping by quantity:\n %A" <| activityReport.groupBy(quantity)
