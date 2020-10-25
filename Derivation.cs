using System;
using System.Collections.Generic;
using System.Text;

namespace Parsing {
	using ParseEntry = KeyValuePair<char, Stack<Symbol>>;

    public abstract class Derivation {
        public ParseEntry[] Entries { get; set; }
    }
}
