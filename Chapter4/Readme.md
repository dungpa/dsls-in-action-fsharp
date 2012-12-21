### Reading notes ###

> #### Financial brokerage systems: the cash value of a trade ####

> Every trade has a cash value that the counterparty receiving the securities needs
to pay to the counterparty delivering the securities. This final value is known as the
net settlement value (NSV). The NSV has two main components: the gross cash
value and the tax and fees. The gross cash value depends on the unit price of the
security that was traded, the type of the security, and additional components like
the yield price for bonds. The additional tax and fee amounts include the taxes,
duties, levies, commissions, and accrued interest involved in the trading process.
The gross cash value calculation depends on the type of the security (equity or
fixed income), but is fundamentally a function of the unit price and the quantity
traded.

> The additional tax and fee amounts vary with the country of trade, the exchange
where the trading takes place, and the security that’s traded. In Hong Kong, for
example, a stamp duty of 0.125% and a transaction levy of 0.007% are payable on
equity purchases and sales.

> #### Financial brokerage systems: instrument types ####

> Instruments that are traded can be of various types designed to meet the needs of
the investors and issuers. Depending on the type, every instrument follows a different
lifecycle in the trading and settlement process.

> The two main classifications are equity and fixed income.

> Equities can again be classified as common stock, preferred stock, cumulative
stock, equity warrants, or depository receipts. The types of fixed income securities
(also known as bonds) include straight bonds, zero coupon bonds, and floating rate
notes. For the purpose of our discussion, it’s not essential to be familiar with all
these details. What is important is that the Trade abstractions will vary, depending
on the type of instrument that’s being traded.

> #### Thinking in types: key takeaways ####

> The main purpose of this section was to make you think in types. For each abstraction
that’s in your domain model, make it a typed one and organize the related business
rules around that type. Many of the business rules will be automatically
enforced by the compiler, which means you won’t have to write explicit code for
them. If your implementation language has a proper type system, your DSL will be
as concise as ones written using dynamic languages.

> #### Key takeaways & best practices ####

> When you design an internal DSL, follow the best practices for the language concerned.
Using the language idiomatically always results in the optimal mix of
expressiveness and performance.

> A dynamic language like Ruby or Groovy gives you strong metaprogramming capabilities.
Design your DSL abstractions and the underlying semantic model that rely
on these capabilities. You’ll end up with a beautifully concise syntax, leaving the
boilerplates to the underlying language runtime.

> In a language like Scala, static typing is your friend. Use type constraints to
express a lot of business rules and use the compiler as the first-level verifier of your
DSL syntax.

> When you’re using a language like Clojure that offers compile-time metaprogramming,
use macros to define custom syntax structures. You'll get the conciseness
of Ruby with no additional runtime performance penalty.

---

### Implementation notes ###

There is no implicit context in F#, so we use records to mimic the scope of an implicit context. 
We may revisit this issue by exploiting some reflection-based techniques.

The Decorator example in Ruby is twisted by using a mutable property in F#.

For the porfolio example in Scala, we only translate the generic version.

The trade example in Scala is for demonstrating the idea of type constraints. 
Type constraints and inheritance are not as popular in F# as they are in Scala, so the approach in `Trade.Scala.fs` isn't recommended.

The Clojure example is currently ignored due to the lack of macro facility in F#.
