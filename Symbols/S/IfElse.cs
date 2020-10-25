using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	using ParseEntry = KeyValuePair<char, Stack<Symbol>>;

    public partial class S : Nonterminal {
        class IfElse : Deriviation {
            public IfElse() {
                Entries = new ParseEntry[] { new ParseEntry('i', new Stack<Symbol>(new Symbol[] {
                    new Terminal('i'),
                    new Terminal('('),
                    new Action_1(),
                    new C(new SynC_1()),
                    new Terminal(')'),
                    new S(new SynS_1()),
                    new Terminal('e'),
                    new S(new SynS_2()),
                    new Action_2(),
                }))};
            }

            // Synthesized attributes actions
            public class SynC_1 : C.Syn {
                public override void Run(Stack<Symbol> s) {
                    var action_2 = s.ElementAt(6) as Action_2;

                    action_2.CCode = Code;
                }
            }

            public class SynS_1 : Syn {
                public override void Run(Stack<Symbol> s) {
                    var action_2 = s.ElementAt(3) as Action_2;

                    action_2.S_1Code = Code;
                }
            }

            public class SynS_2 : Syn {
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
                    var syn = s.ElementAt(9) as Syn;
                    var s_0 = syn.Nt as S;
                    
                    action_2.L1 = new Label();
                    action_2.L2 = new Label();

                    c.True = action_2.L1;
                    c.False = action_2.L2;

                    s_1.Next = s_0.Next;
                    s_2.Next = s_0.Next;
                }
            }

            // Actions
            public class Action_2 : Action {
                public Label L1 { get; set; }
                public Label L2 { get; set; }
                public string S_1Code { get; set; }
                public string S_2Code { get; set; }
                public string CCode { get; set; } 

                public override void Run(Stack<Symbol> s) {
                    var synS = s.ElementAt(0) as Syn;

                    synS.Code = $"{CCode}{L1.L}:\n{S_1Code}{L2.L}:\n{S_2Code}\n";
                }
            }
        }
    }
}
