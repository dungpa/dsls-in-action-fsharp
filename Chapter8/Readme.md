### Notes on Chapter 8 ###

---

This chapter implements a few DSLs in the increasing order of complexity.
- The `Parsing` module consists of a very basic DSL without any particular semantic.
- The `Semantic` module augments the module above with a concrete semantic based on a set of well-defined abstract syntax trees.
- The `SSI` module is originally for demonstrating packrat parsers dealing with left recursion. 
Expressing left-recursive languages in FParsec requires to rewrite their grammars; here I reduce the grammar to a very simple case with a specific order of fields.
- The `Validating` module in Scala should be trivial to implement upon `SSI` hence being skipped here. 
