using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	using ParseEntry = KeyValuePair<char, Stack<Symbol>>;

    public partial class C {
        class Plain : Deriviation {
            public Plain() {
                Entries = new ParseEntry[] { new ParseEntry('c', new Stack<Symbol>(new Symbol[] {
                    new Terminal('c'),
                    new Action_1()
                }))};
            }
        }

        public class Action_1 : Action {
			public override void Run(Stack<Symbol> s) {
				var syn = s.ElementAt(0) as Syn;
				var c = syn.Nt as C;

				syn.Code = $"cmp 1, 0\njne {c.False.L}\njmp {c.True.L}\n";
			}
		}
    }
}
