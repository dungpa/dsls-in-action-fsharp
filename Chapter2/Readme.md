### Reading notes ###

##### Financial brokerage system: processing client orders #####

The trading process involves buying and selling securities
in the market place, guided by the rules of the stock exchange. These transactions
take place in response to orders placed by investors through registered
agents. These agents can be brokers, clearing banks, or financial advisers. A typical
order from a client consists of information like the security to be transacted
(buy or sell), quantity, and the unit price details. All these elements specify any
constraint that the counterparty wants to impose on the price of execution. The
following steps are performed from when the order is placed until the execution
notice of trades is generated:

1. The investor places the order with the agent.
2. The agent records the order and forwards it to the stock exchange.
3. The order is executed and the notice of execution comes back to the agent.
4. The agent records the execution details and passes the notice to the investor.

---

### Implementation notes ###

This chapter consists of two DSLs for order processing: the first one in Java and the second one in Groovy. 
While the Java version uses the fluent style which is quite common in OO world, the Groovy variant employs metaprogramming to achieve a more concise DSL.

To express these DSLs in F#, the fluent style in Java is replaced by named arguments in F# constructors and the Groovy variant is mimicked by F#'s record syntax.
There is a limitation where `300.` is parsed as a float literal, so one has to use `(300).Shares.Of` or `300 .Shares.Of`, which slightly deviate from the original version.

Some enhancements are left for the use of F#'s reflection-based techniques later.
