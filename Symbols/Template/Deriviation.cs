// This is a template for a symbol deriviation. It is should not be compiled
// It should be used to copy when one wants to create a new symbol deriviation
#if false
using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	using ParseEntry = KeyValuePair<char, Stack<Symbol>>;

    public partial class Template : Nonterminal {
        class TemplateDerivation : Deriviation {
            public TemplateDerivation() {
                Entries = new ParseEntry[] { new ParseEntry(/* Character to match */, new Stack<Symbol>(new Symbol[] {
                    // Place your derivation here. This supports Terminals, Nonterminals, and Actions
					new Terminal('w'),
                    new Template(new SynT_1()),
					new Action_1(),
				}))};
            }
            
            // Synthesized attributes actions
           public class SynT_1 : Syn {
                public override void Run(Stack<Symbol> s) {
                    // Code to use synthesized attributes from the Nonterminal
                }
            }

            // Actions
            public class Action_1 : Action {
                public override void Run(Stack<Symbol> s) {
                    // Actions that can use the parsing stack
                }
            }
        } 
    }
}
#endif
