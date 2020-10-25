using System.Linq;
using System.Collections.Generic;

namespace Parsing {
	using ParseRow = Dictionary<char, Stack<Symbol>>;
	
	public class C : Nonterminal {
		public C(SynC synC) {
			Sa = synC;
		}

		public override void PrepareRow() {
			Row = new ParseRow() {
				{'c', new Stack<Symbol>(new Symbol[] {
					new Terminal('c'),
					new ActionC_1()
				})},
			};
		}

        public Label True { get; set; }
		public Label False { get; set; }

		public class SynC : SynAttrs {
			public string Code { get; set; }
		}

		public class ActionC_1 : Action {
			public override void Run(Stack<Symbol> s) {
				var synC = s.ElementAt(0) as SynC;
				var c = synC.Nt as C;

				synC.Code = $"cmp 1, 0\njne {c.False.L}\njmp {c.True.L}\n";
			}
		}

	}
}
