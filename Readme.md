DSLs in Action in F#
===
### Translation of [Code and Examples](https://github.com/debasishg/dsls_in_action) from Debasish Ghosh's "[DSLs in Action](http://www.manning.com/ghosh/)" ###

---

### Purpose ###
This is an *unfaithful* translation of the book's examples to F#. 
Indeed translating examples from 5 different languages to another language is impossible.
Therefore, we tried to create roughly similar examples in F# and used original code as the source of ideas and inspiration.
Certain examples which cannot be expressed in F# have been omitted or modified to be F#-friendly.

---

### Setup / Installation ###
The code base contains one solution: `FSharpx.Books.DSLsInAction.sln`. The solution targets F# 6.0, and so require VS 2022, VS for Mac 2022 (currently preview), or Ionide for VS Code.

To start, simply open the solution, or run `dotnet build`.

---

### Porting notes ###

The translated examples conform to the following conventions:
- Each example is named `XX.YY.fs` where `XX` is the name of the problem and `YY` is the language for which the original program is written, including Java, Ruby, Groovy, Clojure and Scala.
- There are a few examples with Fsharp suffix. They are written from scratch and more F#-ish in implementing DSLs.
- `XX.YY.fsx` files are often the corresponding scripting versions of `XX.YY.fs` files.
- Many files have `// Listing X.Y ...` bits which are to reference the book's corresponding snippets.

For detailed notes about F#-specific features for DSL development, please refer to [A cheatsheet for F#'s DSL-friendly features](DSLCheatsheet.md).

