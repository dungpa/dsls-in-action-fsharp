### Reading notes ###

> #### Key takeaways & best practices ###
- When you’re designing a DSL, you need to have a clean separation of the syn- tax and the underlying semantic model.
- In an external DSL, the semantic model can be implemented by host language structures. 
For syntax parsing, you need to have a parser generator that integrates with the host language. 
ANTLR is a typical parser generator that inte- grates well with Java.
- Choose the appropriate parser class for what you need before you design external DSLs that need moderate language-processing capabilities. 
Making the correct choice will help you moderate the complexity of your implementation.
- Choose the right level of complexity that does the job. For an external DSL, you might not need the full complexity of a general language design.

---

### Implementation notes ###

This chapter discusses implementation of an external DSL using a parser generator, particularly ANTLR. 
In F#, `fslex/fsyacc` is the most promising candidate when ANTLR's F# support is quite limited.
However, to avoid dependency to external tools, we choose to implement the DSL using a parser combinator, namely `FParsec`.
All the primitive parsers have the same names as in Java counterpart so that the idea is still clearly demonstrated.
