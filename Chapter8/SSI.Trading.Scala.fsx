#I @"../packages/FParsec.0.9.2.0/lib/net40"
#r "FParsecCS"
#r "FParsec"

#load "SSI.Trading.Scala.fs"

open FSharpx.Books.DSLsInAction.Chapter8.Scala.Trading.SSI

let example =  """settle trades for broker "icici" in "JPN" market safekeep security internally with us at "us-123" settle cash externally at "BOJ" "b-954"
"""
