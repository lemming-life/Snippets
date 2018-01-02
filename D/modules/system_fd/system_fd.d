// Author: http://lemming.life
// Language: D
// Description: Request the directories or files given a path, span mode, and ignore array.

// Test: rdmd -unittest -main system_fd.d


module system_fd;
import std.file;

class System {
  import std.path;

	static string[] getDirectories(string path, SpanMode spanMode = SpanMode.shallow, string[] ignore = null) {
		return get!(isDir)(path, spanMode, ignore);
	}

	static string[] getFiles(string path, SpanMode spanMode = SpanMode.shallow, string[] ignore = null) {
		return get!(isFile)(path, spanMode, ignore);
	}

	private:

	static string[] get(alias F)(string path, SpanMode spanMode = SpanMode.shallow, string[] ignore = null) {
		import std.algorithm, std.conv, std.file;
		string[] to_return = [];

		foreach(DirEntry entry; dirEntries(path, spanMode)) {
			if ( !F(entry.name) || (ignore !is null && ignore.canFind(entry.name.baseName)) ) continue;
			to_return ~= entry.name.to!string;
		}	

		return to_return; 
	}
}

/*
  SpanModes:
	SpanMode.shallow
	SpanMode.depth
	SpanMode.breadth
*/