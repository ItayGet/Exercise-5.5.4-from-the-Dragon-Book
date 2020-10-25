using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	using ParseEntry = KeyValuePair<char, Stack<Symbol>>;

    public partial class S : Nonterminal {
        class Block : Derivation {
            public Block() {
                Entries = new ParseEntry[] { new ParseEntry('{', new Stack<Symbol>(new Symbol[] {
                    new Terminal('{'),
                    new Action_1(),
                    new L(new SynL_1()),
                    new Terminal('}'),
                }))};
            }

            // Synthesized attributes actions
            public class SynL_1 : L.Syn {
                public override void Run(Stack<Symbol> s) {
                    var syn = s.ElementAt(1) as Syn;

                    syn.Code = Code;
                }
            }
        
            // Actions
            public class Action_1 : Action {
                public override void Run(Stack<Symbol> s) {
                    var l = s.ElementAt(0) as L;
                    var syn = s.ElementAt(3) as Syn;
                    var s_0 = syn.Nt as S;

                    l.Next = s_0.Next;
                }
            }
        } 
    }
}
