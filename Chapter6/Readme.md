### Reading notes ###

> #### A DSL needs only to be expressive enough for the user ####

> It’s not always necessary to make DSLs feel like natural English. 
I reiterate: make your DSLs expressive enough for your users. 
In this case, the code snippet will be used by a programmer; 
making the intent of the rule clear and expressive is suffi- cient for a programmer to maintain it and for a domain user to comprehend it.

---

### Implementation notes ###

This chapter talks about internal DSL design in Scala. 
While Scala tends to use object hierarchies to create extensive DSLs, F#'s philosophy is quite different. 
F#' DSLs lean towards declarative style where minimality and conciseness are important features.

Many concepts used in this chapter don't even exist in F$ (e.g. implicits, traits, etc). 
I made some efforts to translate the most basic DSL in the chapter and its monadic extension to F#.
However, the translation has some serious limitations such as poor extensiblity and verbose syntax.
That said, an F# DSL should be designed from scratch following the declarative style more closely.
