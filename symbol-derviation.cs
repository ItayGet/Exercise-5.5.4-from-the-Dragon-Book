namespace Parsing {
	public class S : Nonterminal {
		// Synthesized attributes
		public string Code {get; set; }

		// Inherited attributes
		public Label Next { get; set; }
	}

	public class C : Nonterminal {
		// Synthesized attributes
		public string Code {get; set; }

		// Inherited attributes
		public Label True { get; set; }
		public Label False { get; set; }
	}
}