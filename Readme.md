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
The code base contains two solutions: `FSharpx.Books.DSLsInAction.sln` and `FSharpx.Books.DSLsInAction.Mono.sln` for Visual Studio 2012 and MonoDevelop 3.0 respectively.
These solutions target F# 3.0 since there are a few F# 3.0's features we use in the codebase. 

NuGet is used to manage external packages. 
If you do not have NuGet, or are running a version prior to 2.0, you must install or upgrade it before you will be able to build the projects.
In Visual Studio, the easiest way to install NuGet is by downloading it (for free) from the [Visual Studio Extension Gallery](http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c).
On Mono, you can use the bootstrapped version of `NuGet.exe` in `.nuget` folder or [NuGet add-in for MonoDevelop](http://community.sharpdevelop.net/blogs/mattward/archive/2013/01/07/MonoDevelopNuGetAddin.aspx) to install and update packages manually.

The VS2012 solution uses the *Package Restore* feature of NuGet to automatically download any missing packages when the projects are built. 
This requires that you have the "[Allow NuGet to download missing packages during build](http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages)" setting enabled; 
in Visual Studio, you can find the setting under `Options -> Package Manager -> General`.

*Package Restore* feature hasn't worked in MonoDevelop (yet). 
In the project root directory (`dsls-in-action-fsharp`), you can issue the command `sh .nuget/nuget.sh` in order that NuGet downloads necessary packages.

Once NuGet is installed and configured, you should be able to build the solution.

---

### Porting notes ###

The translated examples conform to the following conventions:
- Each example is named `XX.YY.fs` where `XX` is the name of the problem and `YY` is the language for which the original program is written, including Java, Ruby, Groovy, Clojure and Scala.
- There are a few examples with Fsharp suffix. They are written from scratch and more F#-ish in implementing DSLs.
- `XX.YY.fsx` files are often the corresponding scripting versions of `XX.YY.fs` files.
- Many files have `// Listing X.Y ...` bits which are to reference the book's corresponding snippets.

For detailed notes about F#-specific features for DSL development, please refer to [A cheatsheet for F#'s DSL-friendly features](DSLCheatsheet.md).

