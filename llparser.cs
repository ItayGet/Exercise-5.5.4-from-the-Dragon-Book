using System;
using System.Collections.Generic;

namespace Parsing {
	using ParseTable = Dictionary<Nonterminal, Dictionary<char, Stack<Symbol>>>;

	public static class LLParser {
		public static void Parse(Queue<Terminal> inp, Stack<Symbol> stack) {
			var currChar = inp.Dequeue();
			while(inp.Count != 0) {
				var currSym = stack.Pop();
				if(currSym is Terminal) {
					var terminal = currSym as Terminal;
					if(currChar.C != terminal.C) {
						throw new Exception($"Syntax Error: expected '{terminal.C}' but got '{currChar.C}'");
					}

					//Next char
					currChar = inp.Dequeue();
				} else if(currSym is Nonterminal) {
					var nt = currSym as Nonterminal;
					stack.Push(nt.SynAttrs);
					
					foreach(var s in nt.Row[currChar.C]) {
						stack.Push(s);
					}
				} else if(currSym is Action) {
					(currSym as Action).Run(stack);
				} else {
					//Error
				}
			}
		}
	}
}