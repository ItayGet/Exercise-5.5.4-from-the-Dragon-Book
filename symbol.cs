namespace Parsing {
	public abstract class Symbol {}

	public abstract class Action : Symbol {
		public virtual void Run(Stack<Symbol> s) {}
	}

	public abstract class Nonterminal : Symbol {}

	public class Terminal : Symbol {
		public char C { get; set; }
		public Terminal(char c) {
			C = c;
		}
	}
}