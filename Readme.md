DSLs in Action in F#
===
### Translation of Code and Examples from Debasish Ghosh's "[DSLs in Action](http://www.manning.com/ghosh/)" ###

---

### Purpose ###
This is an *unfaithful* translation of the book's examples to F#. 
Indeed translating examples from 5 different languages to another language is impossible.
Therefore, I tried to create roughly similar examples in F# and used original code as the source of ideas and inspiration.
Certain examples which cannot be expressed in F# have been omitted or updated to be F#-friendly.

---

### Setup / Installation ###

---

### Porting notes ###

The translated examples conform to the following conventions:
- Each example is named `XX.YY.fs` where `XX` is the name of the problem and `YY` is the language for which the original program is written, including Java, Ruby, Groovy, Clojure and Scala.
- Most of `XX.YY.fsx` files are the corresponding scripting versions of `XX.YY.fs` files.
- Many files have `// Listing X.Y ...` bits which are to reference the book's corresponding snippets.

For detailed notes about F#-specific features for DSL development, please refer to [A cheatsheet for F#'s DSL-friendly features](https://github.com/dungpa/dsls-in-action-fsharp/blob/master/DSLCheatsheet.md).

---
### TODO ###

1. Add listing reference to each example.
2. Revisit old examples to add new functionalities (e.g. after learning F# metaprogramming).
