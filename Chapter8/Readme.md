#### Reading notes ###

> #### Financial brokerage system: settlement standing instructions ####

> When trades take place, securities and currencies are exchanged between counterparties. 
This process, which takes place after the trade is done, is called the settlement of trade. 
Settlement involves transferring funds and securities between the accounts of the counterparties. 
There can be multiple accounts, depending on the trade type, the security traded, the counterparty involved, and a number of other factors.

> To facilitate a smooth transfer of funds, the investment manager maintains a database of standing rules that need to be looked up when a trade is made. 
These rules are the SSIs. 
They need to be published to the brokers and custodians from time to time.

> The settlement of a trade usually has two components: the security side and the cash side. 
You might have the same settlement instructions for both the security and cash side, or they might be settled differently. 
The SSI has to be explicit in case you want to settle security and cash separately.

> As an example, an investment bank might state: An equity trade executed in the Japan market has to be settled with us internally at account A-123. 
This rule needs to be applied to all the customers that the investment bank is safekeeping. 
The rules can be organized in a hierarchy and looked up from specialized to generalized form. 
There can be one more rule, as in an equity trade for Sony has to be settled externally with BOTM at account BO-234. 
This means that all Sony trades will be settled via BOTM, but all other equity trades will be settled internally by the investment bank.

#### Key takeaways & best practices ####
- Parser combinators are the most functional way to design external DSLs with- out going out of your language syntax.
- An external DSL designed using parser combinators tends to have a succinct implementation, because the combinators offer a declarative syntax through infix notation and type inference.
- Before you use the parser combinator library offered by your language, be aware of the special features the library offers like memoized parsers, packrat parsers, or other goodies. 
Being familiar with its features will help you design the most optimally performing grammar possible for your DSL.

---

### Implementation notes ###


This chapter implements a few DSLs in the increasing order of complexity.
- The `Parsing` module consists of a very basic DSL without any particular semantic.
- The `Semantic` module augments the module above with a concrete semantic based on a set of well-defined abstract syntax trees.
- The `SSI` module is originally for demonstrating packrat parsers dealing with left recursion. 
Expressing left-recursive languages in FParsec requires to rewrite their grammars; here I reduce the grammar to a very simple case with a specific order of fields.
- The `Validating` module in Scala should be trivial to implement upon `SSI` hence being skipped here. 
