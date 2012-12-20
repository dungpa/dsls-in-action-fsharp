### Notes on Chapter 6 ###

---

This chapter talks about internal DSL design in Scala. 
While Scala tends to use object hierarchies to create extensive DSLs, F#'s philosophy is quite different. 
F#' DSLs lean towards declarative style where minimality and conciseness are important features.

Many concepts used in this chapter don't even exist in F$ (e.g. implicits, traits, etc). 
I made some efforts to translate the most basic DSL in the chapter and the monadic extension to F#.
However, the translation has some serious limitations such as poor extensiblity and verbose syntax.
That said an F# DSL should be designed from scratch following the declarative style closely.