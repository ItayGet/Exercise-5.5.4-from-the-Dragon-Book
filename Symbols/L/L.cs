using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	public partial class L : Nonterminal {
		public L(Syn syn) {
			Sa = syn;
		}

        public override void PrepareRow() {
			PrepareRowParams(new Derivation[] { new Statements(), new Epsilon() });
		}

        public Label Next { get; set; }

		public class Syn : SynAttrs {	
			public string Code { get; set; }
		}
	}
}
