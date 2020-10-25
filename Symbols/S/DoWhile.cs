using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	using ParseEntry = KeyValuePair<char, Stack<Symbol>>;

    public partial class S : Nonterminal {
        class DoWhile : Derivation {
            public DoWhile() {
                Entries = new ParseEntry[] { new ParseEntry('d', new Stack<Symbol>(new Symbol[] {
                    new Terminal('d'),
                    new Action_1(),
                    new S(new SynS_1()),
                    new Terminal('w'),
                    new Terminal('('),
                    new C(new SynC_1()),
                    new Terminal(')'),
                    new Action_2(),
                }))};
            }

            // Synthesized attributes actions
            public class SynS_1 : Syn {
                public override void Run(Stack<Symbol> s) {
                    var action_2 = s.ElementAt(5) as Action_2;

                    action_2.S_1Code = Code;
                }
            }

            public class SynC_1 : C.Syn {
                public override void Run(Stack<Symbol> s) {
                    var action_2 = s.ElementAt(1) as Action_2;

                    action_2.CCode = Code;
                }
            }
        
            // Actions
            public class Action_1 : Action {
                public override void Run(Stack<Symbol> s) {
                    var s_1 = s.ElementAt(0) as S;
                    var c = s.ElementAt(4) as C;
                    var action_2 = s.ElementAt(7) as Action_2;
                    var syn = s.ElementAt(8) as Syn;
                    var s_0 = syn.Nt as S;

                    action_2.L1 = new Label();
                    action_2.L2 = new Label();

                    c.True = action_2.L1;
                    c.False = s_0.Next;

                    s_1.Next = action_2.L2; 
                }
            }
            public class Action_2 : Action {
                public Label L1 { get; set; }
                public Label L2 { get; set; }
                public string CCode { get; set; }
                public string S_1Code { get; set; }
                public override void Run(Stack<Symbol> s) {
                    var syn = s.ElementAt(0) as Syn;
                    syn.Code = $"{L1.L}:\n{S_1Code}{L2.L}:\n{CCode}\n";
                }
            }
        } 
    }
}
