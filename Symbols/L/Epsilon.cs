using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	using ParseEntry = KeyValuePair<char, Stack<Symbol>>;

    public partial class L : Nonterminal {
        class Epsilon : Derivation {
            public Epsilon() {
                Entries = new ParseEntry[] { new ParseEntry('}' , new Stack<Symbol>(new Symbol[] {
					new Action_1(),
				}))};
            }
            
            // Actions
            public class Action_1 : Action {
                public override void Run(Stack<Symbol> s) {
                    var syn = s.ElementAt(0) as Syn;

                    syn.Code = "";
                }
            }
        } 
    }
}
