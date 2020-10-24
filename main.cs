using System;
using System.Collections.Generic;

namespace Parsing {
	class Program {
		public static void Main (string[] args) {
			var s = new S(new S.SynS());
			s.Next = new Label();
			var stack = new Stack<Symbol>(new[] {s});
			LLParser.Parse(
				Symbol.StringToTerminalQueue("s"),
			 	stack
			);
		}
	}
}