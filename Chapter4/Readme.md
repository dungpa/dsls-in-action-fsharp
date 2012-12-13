### Notes on Chapter 4 ###

---

There is no implicit context in F#, so we use records to mimic the scope of an implicit context. 
We may revisit this issue by some reflection-based techniques.

The Decorator example in Ruby is twisted by using mutable property in F#.

For the porfolio example in Scala, we only translate the generic version.

The trade example in Scala is for demonstrating the idea of type constraints. 
Type constraints and inheritance are not as popular in F# as they are in Scala, so the approach in `Trade.Scala.fs` isn't recommended.

The Clojure example is currently ignored due to the lack of macro facility in F#.