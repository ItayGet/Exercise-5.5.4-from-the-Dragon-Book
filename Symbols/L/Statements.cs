using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	using ParseEntry = KeyValuePair<char, Stack<Symbol>>;

    public partial class L : Nonterminal {
        class Statements : Derivation {
            public Statements() {
                var Entry = new Stack<Symbol>(new Symbol[] {
                    new Action_1(),
                    new S(new SynS_1()),
                    new L(new SynL_1()),
                    new Action_2(),
                });

                Entries = new ParseEntry[] {
                    new ParseEntry('i', Entry),
                    new ParseEntry('w', Entry),
                    new ParseEntry('d', Entry),
                    new ParseEntry('{', Entry),
                    new ParseEntry('s', Entry),
                };
            }
            
            // Synthesized attributes actions
           public class SynS_1 : S.Syn {
                public override void Run(Stack<Symbol> s) {
                    var action_2 = s.ElementAt(2) as Action_2;

                    action_2.SCode = Code;
                }
           }
           public class SynL_1 : Syn {
                public override void Run(Stack<Symbol> s) {
                    var action_2 = s.ElementAt(0) as Action_2;

                    action_2.LCode = Code;
                }
           }

            // Actions
            public class Action_1 : Action {
                public override void Run(Stack<Symbol> s) {
                    var s_1 = s.ElementAt(0) as S;
                    var l_1 = s.ElementAt(2) as L;
                    var action_2 = s.ElementAt(4) as Action_2;
                    var syn = s.ElementAt(5) as Syn;
                    var l_0 = syn.Nt as L;

                    action_2.L1 = new Label();

                    s_1.Next = action_2.L1;
                    l_1.Next = l_0.Next;
                }
            }

            public class Action_2 : Action {
                public Label L1 { get; set; }
                public string SCode { get; set; }
                public string LCode { get; set; }

                public override void Run(Stack<Symbol> s) {
                    var syn = s.ElementAt(0) as Syn;

                    syn.Code = $"{SCode}{L1.L}:\n{LCode}";
                }
            }
        } 
    }
}
