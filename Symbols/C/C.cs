using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	public partial class C : Nonterminal {
		public C(Syn syn) {
			Sa = syn;
		}

		public override void PrepareRow() {
			PrepareRowParams(new Deriviation[] { new Plain() });
		}

        public Label True { get; set; }
		public Label False { get; set; }

		public class Syn : SynAttrs {
			public string Code { get; set; }
		}
	}
}
