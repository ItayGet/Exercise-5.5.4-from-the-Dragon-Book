using System;
using System.Collections.Generic;

namespace Parsing {

	public static class LLParser {
		public static void Parse(Queue<Terminal> inp, Stack<Symbol> stack) {
			for(Terminal currChar = null; !(stack.Count == 1 && stack.Peek() is S.SynS);) {
				if(currChar == null) {
				    currChar = inp.Dequeue();
				}
				var currSym = stack.Pop();
				if(currSym is Terminal) {
					var terminal = currSym as Terminal;
					if(currChar.C != terminal.C) {
						throw new Exception($"Syntax Error: expected '{terminal.C}' but got '{currChar.C}'");
					}

					//Next char
					currChar = null;
				} else if(currSym is Nonterminal) {
					var nt = currSym as Nonterminal;
					nt.Sa.Nt = nt;
					stack.Push(nt.Sa);

					nt.PrepareRow();
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
