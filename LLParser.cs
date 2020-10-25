using System;
using System.Collections.Generic;

using Parsing.Symbols;

namespace Parsing {

	public static class LLParser {
		public static void Parse(Queue<Terminal> inp, Stack<Symbol> stack) {
			while(!(stack.Count == 1 && stack.Peek() is S.Syn)) {
				var currSym = stack.Pop();
				if(currSym is Terminal terminal) {
					var currChar = inp.Dequeue();
					if(currChar.C != terminal.C) {
						throw new Exception($"Syntax Error: expected '{terminal.C}' but got '{currChar.C}'");
					}
				} else if(currSym is Nonterminal nt) {
					nt.PrepareRow();
					foreach(var s in nt.Row[inp.Peek().C]) {
						if (s is Nonterminal snt) {
							snt.Sa.Nt = snt;
							stack.Push(snt.Sa);
						}
						stack.Push(s);
					}
				} else if(currSym is Action action) {
					action.Run(stack);
				} else {
					//Error
				}
			}
		}
	}
}
