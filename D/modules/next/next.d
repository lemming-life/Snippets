// Author: http://lemming.life
// Language: D
// Description: Given a range of numbers, and increments by one, get the next number in the sequence.
// Supports inclusive and exclusive.

// Test: rdmd -unittest -main next.d

module next;

class Next (T) {
	private T min, max, current;

  	this(T min, T max, bool inclusive = true) {
		this.min = min;
		this.max = max;
		this.current = this.min + 1;
		if (inclusive) {
			--this.min;
			++this.max;
			--this.current;
		}
	}

	T get() {
		auto to_return  = current;
		++current;
		if (current == max) current = min+1;
		return to_return;
	}
}

unittest {
	auto nextInclusive = new Next!int(1,3);
	assert( nextInclusive.get == 1 );
	assert( nextInclusive.get == 2 );
	assert( nextInclusive.get == 3 );
	assert( nextInclusive.get == 1 );

	auto nextExclusive = new Next!int(1,3, false);
	assert( nextExclusive.get == 2 );
	assert( nextExclusive.get == 2 );
}