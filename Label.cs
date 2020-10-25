public class Label {
	static int Counter { get; set; }
	public int L { get; set; }
	
	public Label() {
		L = Counter++;
	}
}