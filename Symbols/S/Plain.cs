using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	using ParseEntry = KeyValuePair<char, Stack<Symbol>>;

    public partial class S : Nonterminal {
        class Plain : Derivation {
            public Plain() {
                Entries = new ParseEntry[] { new ParseEntry('s', new Stack<Symbol>(new Symbol[] {
                    new Terminal('s'),
                    new Action_1()
                }))};
            }
            public class Action_1 : Action {
                public override void Run(Stack<Symbol> s) {
                    var syn = s.ElementAt(0) as Syn;
                    var s_0 = syn.Nt as S;

                    syn.Code = $"//statement\ngoto {s_0.Next.L}\n";
                }
            }

        }
    }
}
