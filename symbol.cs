using System.Collections.Generic;

namespace Parsing {
	using ParseRow = Dictionary<char, Stack<Symbol>>;

	public abstract class Symbol {
		public static Queue<Terminal> StringToTerminalQueue(string str) {
			var q = new Queue<Terminal>();
			foreach(var c in str) {
				q.Enqueue(new Terminal(c));
			}
			return q;
		}
	}

	public abstract class Action : Symbol {
		public virtual void Run(Stack<Symbol> s) {}
	}

	public abstract class Nonterminal : Symbol {
		public ParseRow Row { get; set; }
		
		// Synthesized attributes of nonterminal
		public Action SynAttrs { get; set; }
	}

	public class Terminal : Symbol {
		public char C { get; set; }
		public Terminal(char c) {
			C = c;
		}
	}
}