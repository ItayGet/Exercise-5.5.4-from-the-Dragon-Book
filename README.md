# Exercise-5.5.4-from-the-Dragon-Book
A POC of exercise 5.5.4 from the Dragon Book, done in C# so development would be quick.

This program consists of an LL parser that converts C-style blocks to pseudo assembly with labels.

The parsing is done thorugh a stack that contains all symbols that still need to be expanded.
Nonterminals are expanded using a parse table that is fully customizable, and can be changed through the files in the symbols directory.
There are 4 types of symbols available for the design of the table:
1. Nonterminals - Can be expanded to nonterminals, terminals(characters) and actions.
1. Terminals - Plain characters that need to be matched with the input string.
1. Actions - Act on the stack held by the parser to manipulate fields of other symbols
1. Synthesized Attributes - Each nonterminal has one. They are expanded during the expansion of nonterminals and placed before the derivation of them.
	they hold the synthesized attributes of them after they get expanded

## Features
* If-else statement
* While loop
* Do-while loop
* Block statements

## Notes
* Lexing is not done at all. Instead, each terminal contains a single character.
