using System.Collections.Generic;

namespace Parsing {
	using ParseRow = Dictionary<char, Stack<Symbol>>;
	
	public class C : Nonterminal {
		public C(SynC synC) {
			SynAttrs = synC;
		}

        public override void PrepareRow()
        {
            Row = new ParseRow() {
                {'c', new Stack<Symbol>(new[] {
                    new Terminal('c'),
                })},
            };
        }

        public Label True { get; set; }

		public class SynC : Action {
			public string Code { get; set; }
		}

	}
}
