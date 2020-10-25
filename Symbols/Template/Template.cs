// This is a template for a symbol. It is should not be compiled
// It should be used to copy when one wants to create a new symbol
#if false
using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	public partial class Template : Nonterminal {
		public Template(Syn syn) {
			Sa = syn;
		}

        public override void PrepareRow() {
			PrepareRowParams(new Deriviation[] { /* All Nonterminal Deriviations, eg. Template.Deriviation */ });
		}

		// Inherited Attributes
        public object Attr { get; set; }

		public class Syn : SynAttrs {	
			// Synthesized Attributes
			public object Attr { get; set; }
		}
	}
}
#endif
