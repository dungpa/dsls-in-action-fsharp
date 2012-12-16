### Notes on Chapter 7 ###

---

This chapter discusses implementation of an external DSL using a parser generator, particularly ANTLR. 
In F#, `fslex/fsyacc` is the most promising candidate when ANTLR's F# support is quite limited.
However, to avoid dependency to external tools, we choose to implement the DSL using a parser combinator, namely `FParsec`.
All the primitive parsers have the same names as in Java counterpart so that the idea is still clearly demonstrated.
