using System.Linq;
using System.Collections.Generic;

namespace Parsing {
	using ParseRow = Dictionary<char, Stack<Symbol>>;
	
	public class S : Nonterminal {
		public S(SynS synS) {
			Sa = synS;
		}

        public override void PrepareRow() {
            Row = new ParseRow() {
                {'i', new Stack<Symbol>(new Symbol[] {
                    new Terminal('i'),
                    new Terminal('('),
					new Action_1(),
                    new C(new SynC()),
                    new Terminal(')'),
                    new S(new SynS_1()), // S_1
		    		new Terminal('e'),
                    new S(new SynS_2()), // S_2
					new Action_2(),

			    })},
                {'s', new Stack<Symbol>(new Symbol[] {
                    new Terminal('s'),
					new Action_3()
                })},
            };
        }

        public Label Next { get; set; }

		public class SynS : SynAttrs {	
			public string Code { get; set; }
		}

		public class SynC : C.SynC {
			public override void Run(Stack<Symbol> s) {
				var action_2 = s.ElementAt(6) as Action_2;

				action_2.CCode = Code;
			}
		}

		public class SynS_1 : SynS {
			public override void Run(Stack<Symbol> s) {
				var action_2 = s.ElementAt(3) as Action_2;

				action_2.S_1Code = Code;
			}
		}

		public class SynS_2 : SynS {
			public override void Run(Stack<Symbol> s) {
				var action_2 = s.ElementAt(0) as Action_2;

				action_2.S_2Code = Code;
			}
		}

		public class Action_1 : Action {
			public override void Run(Stack<Symbol> s) {
				var c = s.ElementAt(0) as C;
				var s_1 = s.ElementAt(3) as S;
				var s_2 = s.ElementAt(6) as S;
				var action_2 = s.ElementAt(8) as Action_2;
				var synS = s.ElementAt(9) as SynS;
				var s_0 = synS.Nt as S;

				c.True = new Label();
				c.False = new Label();

				action_2.l1 = c.True;
				action_2.l2 = c.False;

				s_1.Next = s_0.Next;
				s_2.Next = s_0.Next;
			}
		}

		public class Action_2 : Action {
			public Label l1 { get; set; }
			public Label l2 { get; set; }
			public string S_1Code { get; set; }
			public string S_2Code { get; set; }
			public string CCode { get; set; } 

			public override void Run(Stack<Symbol> s) {
				var synS = s.ElementAt(0) as SynS;

				synS.Code = $"{CCode}{l1.L}:\n{S_1Code}{l2.L}:\n{S_2Code}\n";
			}
		}

		public class Action_3 : Action {
			public override void Run(Stack<Symbol> s) {
				var synS = s.ElementAt(0) as SynS;
				var s_0 = synS.Nt as S;

				synS.Code = $"//statement\ngoto {s_0.Next.L}\n";
			}
		}
	}
}
