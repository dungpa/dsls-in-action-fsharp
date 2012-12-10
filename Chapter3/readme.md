### Notes on Chapter 3 ###

---

The order-processing DSL in Groovy is pushed further with scripting capability using Java scripting engine. 
In F#, we have a great built-in REPL, namely F# Interactive, so this complex feature is no longer needed.

The trading DSL demonstrates Scala's implicit keyword and uses it to enrich a Java class. 
Here we use an F# class and type augmentation.
Although there is no implicit-equivalent feature in F#, the intention is kept as-is.

There is no short-cut for `fun x -> x.FirstName` like that in Scala. 
A potential fix is to use reflection and add equivalent module functions for those properties.

In F#, `fun x -> x > threshold` is the same as `(<) threshold` or `flip (>) threshold`, which are not as clear as Scala one.
The `<<-` operator is utilized instead of `<<` since `<<` is a widely-used combinator in F#.