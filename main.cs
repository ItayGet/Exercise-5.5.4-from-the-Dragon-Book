using System;
using System.Collections.Generic;

namespace Parsing {
	class Program {
		public static void Main (string[] args) {
			LLParser.Parse(
				Symbol.StringToTerminalQueue("s"),
			 	new Stack<Symbol>(new[] {new S(new S.SynS())})
			);
		}
	}
}