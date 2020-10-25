using System;
using System.Collections.Generic;

using Parsing.Symbols;

namespace Parsing {
	class Program {
		public static void Main (string[] args) {
			// Simulating a real stack
			var s = new S(new S.Syn());
			s.Next = new Label();
			s.Sa.Nt = s;
			var stack = new Stack<Symbol>(new Symbol[] {s.Sa, s});

			LLParser.Parse(
				Symbol.StringToTerminalQueue("{i(c)ses}"),
			 	stack
			);
			Console.WriteLine((stack.Peek() as S.Syn).Code);
		}
	}
}