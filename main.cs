using System;
using System.Collections.Generic;

namespace Parsing {
	class Program {
		public static void Main (string[] args) {
			// Simulating a real stack
			var s = new S(new S.SynS());
			s.Next = new Label();
			s.Sa.Nt = s;
			var stack = new Stack<Symbol>(new Symbol[] {s.Sa, s});

			LLParser.Parse(
				Symbol.StringToTerminalQueue("dsw(c)"),
			 	stack
			);
			Console.WriteLine((stack.Peek() as S.SynS).Code);
		}
	}
}