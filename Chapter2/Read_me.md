### Notes on Chapter 2 ###

---

This chapter consists of two DSLs for order processing: the first one in Java and the second one in Groovy. 
While the Java version uses the fluent style which is quite common in OO world, the Groovy variant employs metaprogramming to achieve a more concise DSL.

To express these DSLs in F#, the fluent style in Java is replaced by named arguments in F# constructors and the Groovy variant is mimicked by F#'s record syntax.
There is a limitation where `300.` is parsed as a float literal, so one has to use `(300).Shares.Of` or `300 .Shares.Of`, which slightly deviate from the original version.

Some enhancements are left for the use of F#'s reflection-based techniques later.
