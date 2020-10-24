using System.Collections.Generic;

namespace Parsing {
	using ParseRow = Dictionary<char, Stack<Symbol>>;
	
	public class S : Nonterminal {
		public S(SynS synS) {
			SynAttrs = synS;
		}

        public override void PrepareRow()
        {
            Row = new ParseRow() {
                {'i', new Stack<Symbol>(new Symbol[] {
                    new Terminal('i'),
                    new Terminal('('),
                    new C(new SSynnC()),
                    new Terminal(')'),
                    new S(new SSynS_1()), // S_1
		    new Terminal('e'),
                    new S(new SSynS_2()), // S_2
			    })},
                {'s', new Stack<Symbol>(new[] {
                    new Terminal('s'),
                })},
            };
        }

        public Label Next { get; set; }

		// Synthesized attributes for S
		public class SynS : Action {	
			public string Code { get; set; }
		}

		public class SSynnC : C.SynC {
			public override void Run(Stack<Symbol> s) {

			}
		}

		// Actions for S_1
		public class SSynS_1 : SynS {
			public override void Run(Stack<Symbol> s) {

			}
		}

		// Actions for S_2
		public class SSynS_2 : SynS {
			public override void Run(Stack<Symbol> s) {
				
			}
		}
	}
}
