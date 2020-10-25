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
					new Action_I1(),
					new C(new SynIC_1()),
					new Terminal(')'),
					new S(new SynIS_1()),
					new Terminal('e'),
					new S(new SynIS_2()),
					new Action_I2(),

				})},
				{'s', new Stack<Symbol>(new Symbol[] {
					new Terminal('s'),
					new Action_S1()
				})},
				{'d', new Stack<Symbol>(new Symbol[] {
					new Terminal('d'),
					new Action_D1(),
					new S(new SynDS_1()),
					new Terminal('w'),
					new Terminal('('),
					new C(new SynDC_1()),
					new Terminal(')'),
					new Action_D2(),
				})},
				{'w', new Stack<Symbol>(new Symbol[] {
					new Terminal('w'),
					new Terminal('('),
					new Action_W1(),
					new C(new SynWC_1()),
					new Terminal(')'),
					new S(new SynWS_1()),
					new Action_W2(),
				})}
			};
        }

        public Label Next { get; set; }

		public class SynS : SynAttrs {	
			public string Code { get; set; }
		}

		public class SynIC_1 : C.SynC {
			public override void Run(Stack<Symbol> s) {
				var action_2 = s.ElementAt(6) as Action_I2;

				action_2.CCode = Code;
			}
		}

		public class SynIS_1 : SynS {
			public override void Run(Stack<Symbol> s) {
				var action_2 = s.ElementAt(3) as Action_I2;

				action_2.S_1Code = Code;
			}
		}

		public class SynIS_2 : SynS {
			public override void Run(Stack<Symbol> s) {
				var action_2 = s.ElementAt(0) as Action_I2;

				action_2.S_2Code = Code;
			}
		}

		public class SynDS_1 : SynS {
			public override void Run(Stack<Symbol> s) {
				var action_2 = s.ElementAt(5) as Action_D2;

				action_2.S_1Code = Code;
			}
		}

		public class SynDC_1 : C.SynC {
			public override void Run(Stack<Symbol> s) {
				var action_2 = s.ElementAt(1) as Action_D2;

				action_2.CCode = Code;
			}
		}

		public class SynWC_1 : C.SynC {
			public override void Run(Stack<Symbol> s) {
				var action_2 = s.ElementAt(3) as Action_W2;

				action_2.CCode = Code;
			}
		}

		public class SynWS_1 : SynS {
			public override void Run(Stack<Symbol> s) {
				var action_2 = s.ElementAt(0) as Action_W2;

				action_2.S_1Code = Code;
			}
		}

		public class Action_I1 : Action {
			public override void Run(Stack<Symbol> s) {
				var c = s.ElementAt(0) as C;
				var s_1 = s.ElementAt(3) as S;
				var s_2 = s.ElementAt(6) as S;
				var action_2 = s.ElementAt(8) as Action_I2;
				var synS = s.ElementAt(9) as SynS;
				var s_0 = synS.Nt as S;
				
				action_2.L1 = new Label();
				action_2.L2 = new Label();

				c.True = action_2.L1;
				c.False = action_2.L2;

				s_1.Next = s_0.Next;
				s_2.Next = s_0.Next;
			}
		}

		public class Action_I2 : Action {
			public Label L1 { get; set; }
			public Label L2 { get; set; }
			public string S_1Code { get; set; }
			public string S_2Code { get; set; }
			public string CCode { get; set; } 

			public override void Run(Stack<Symbol> s) {
				var synS = s.ElementAt(0) as SynS;

				synS.Code = $"{CCode}{L1.L}:\n{S_1Code}{L2.L}:\n{S_2Code}\n";
			}
		}

		public class Action_S1 : Action {
			public override void Run(Stack<Symbol> s) {
				var synS = s.ElementAt(0) as SynS;
				var s_0 = synS.Nt as S;

				synS.Code = $"//statement\ngoto {s_0.Next.L}\n";
			}
		}

		public class Action_D1 : Action {
            public override void Run(Stack<Symbol> s) {
				var s_1 = s.ElementAt(0) as S;
				var c = s.ElementAt(4) as C;
				var action_2 = s.ElementAt(7) as Action_D2;
				var synS = s.ElementAt(8) as SynS;
				var s_0 = synS.Nt as S;

				action_2.L1 = new Label();
				action_2.L2 = new Label();

				c.True = action_2.L1;
				c.False = s_0.Next;

				s_1.Next = action_2.L2; 
			}
		}
		public class Action_D2 : Action {
			public Label L1 { get; set; }
			public Label L2 { get; set; }
			public string CCode { get; set; }
			public string S_1Code { get; set; }
            public override void Run(Stack<Symbol> s) {
				var synS = s.ElementAt(0) as SynS;
				synS.Code = $"{L1.L}:\n{S_1Code}{L2.L}:\n{CCode}\n";
			}
		}
        public class Action_W1 : Action {
            public override void Run(Stack<Symbol> s) {
				var c = s.ElementAt(0) as C;
				var s_1 = s.ElementAt(3) as S;
				var action_2 = s.ElementAt(5) as Action_W2;
				var synS = s.ElementAt(6) as SynS;
				var s_0 = synS.Nt as S;

				action_2.L1 = new Label();
				action_2.L2 = new Label();

				c.True = action_2.L2;
				c.False = s_0.Next;

				s_1.Next = action_2.L1; 
			}
		}
		public class Action_W2 : Action {
			public Label L1 { get; set; }
			public Label L2 { get; set; }
			public string S_1Code { get; set; }
			public string CCode { get; set; }
			public override void Run(Stack<Symbol> s) {
				var synS = s.ElementAt(0) as SynS;
				synS.Code = $"{L1.L}:\n{CCode}{L2.L}:\n{S_1Code}\n";
			}
		}
	}
}
