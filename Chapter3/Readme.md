### Reading notes ###

> #### Financial brokerage systems: client account ####
In order to trade, a client needs to open an account (called the trading account)
with the Stock Trading Organization (STO). All trades for the client are booked in
that account and recorded by the STO. When the trade is done, the settlement process
has to be initiated. That process does the final balancing of the securities and
currencies that were exchanged between the two parties.

> For example: client XXX buys 100 shares of SONY @50 USD per share through STO
Nomura Securities. The STO gets those securities from the stock exchange where
a broker does the sell. After the trade is made, there’s a settlement process during
which 100 shares of SONY and approximately 5000 USD are exchanged between
the two counterparties. This settlement is done through an account (the settlement
account), which can be same as the trading account of the client or it can
be a different account.

> To review, the trading account is used for doing the trade, and the settlement
account is used for settling the trade. They can be the same account or different
ones.


> ####Key takeaways & best practices ####

> - DSLs never stand alone. They have to be integrated with your core application.
Let this be your golden rule when you're planning a DSL design, beginning at
day one.
- When you design an internal DSL, choose the language that has the best integration
capabilities with the core language of your application.
- External DSLs often need additional infrastructure, like parser generators.
Keep this in mind when you’re planning the implementation phase so that you
have appropriate development resources on your team.
- Follow established best while you integrate your DSL with your
core application.

---

### Implementation notes ###

The order-processing DSL in Groovy is pushed further with scripting capability using Java scripting engine. 
In F#, we have a great built-in REPL, namely F# Interactive, so this complex feature is no longer needed.

The trading DSL demonstrates Scala's implicit keyword and uses it to enrich a Java class. 
Here we use an F# class and type augmentation.
Although there is no implicit-equivalent feature in F#, the intention is kept as-is.

There is no short-cut for `fun x -> x.FirstName` like that in Scala. 
A potential fix is to use reflection and add equivalent module functions for those properties.

In F#, `fun x -> x > threshold` is the same as `(<) threshold` or `flip (>) threshold`, which are not as clear as Scala one.
The `<<-` operator is utilized instead of `<<` since `<<` is a widely-used combinator in F#.

We created a little query language using *extended* computation expressions. 
Following the same principle as query expression, non-composable operators like iter, fold aren't included.
Whenever you have a declarative DSL which can be chained through pipeline, it is easy to turn it into query expression.
The syntax is a bit nicer thanks to auto-conversion of lambda expression.
