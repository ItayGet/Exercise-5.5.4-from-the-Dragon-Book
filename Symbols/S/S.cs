using System.Linq;
using System.Collections.Generic;

namespace Parsing.Symbols {
	using ParseRow = Dictionary<char, Stack<Symbol>>;
	
	public partial class S : Nonterminal {
		public S(Syn syn) {
			Sa = syn;
		}

        public override void PrepareRow() {
			PrepareRowParams(new Deriviation[] { new Plain(), new IfElse(), new While(), new DoWhile() });
		}

        public Label Next { get; set; }

		public class Syn : SynAttrs {	
			public string Code { get; set; }
		}

		
	}
}
