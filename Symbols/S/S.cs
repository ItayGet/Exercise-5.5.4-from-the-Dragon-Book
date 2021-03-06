using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	public partial class S : Nonterminal {
		public S(Syn syn) {
			Sa = syn;
		}

        public override void PrepareRow() {
			PrepareRowParams(new Derivation[] { new Plain(), new IfElse(), new While(), new DoWhile(), new Block() });
		}

        public Label Next { get; set; }

		public class Syn : SynAttrs {	
			public string Code { get; set; }
		}
	}
}
