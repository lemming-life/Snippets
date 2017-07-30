// Author: http://lemming.life
// Language: D
// Purpose: Example of EditLine/text boxes in a List widget

// What Works:
// - Navigation via up and down keys.
// - Modification of EditLine text via keys.
// - Scrolling of the list.
// - Single click (positions caret at picked EditLine position)
// - Double click (picks a word in the EditLine)
// - Triple click (picks the line in the EditLine)

// Does not work:
// - caret blinking.

module app;
import dlangui;

// Get at https://github.com/lemming-life/Snippets/tree/master/D/lemmingwidgets
// Also modify the dub.json to match whererever you placed the file at.
import lemmingwidgets; 

mixin APP_ENTRY_POINT;

/// Entry point for dlangui based application
extern (C) int UIAppMain(string[] args) {
	auto view = new View("EditLine List Example");
    return Platform.instance.enterMessageLoop();
}

// Our View example
class View {
	this(dstring aTitle) {
		// Prep the window
		auto window = Platform.instance.createWindow(aTitle, null, WindowFlag.Resizable, 640, 480);
		window.mainWidget = parseML(q{
			VerticalLayout {
				margins: 5pt;
				layoutWidth: fill
				layoutHeight: fill
			}
		});

		// Prep the adapter and list
		auto listAdapter = new WidgetListAdapterKeysMouse();
		auto listWidget = new TListWidget!EditLineForList();
			listWidget.layoutWidth(FILL_PARENT);
			listWidget.layoutHeight(FILL_PARENT);
			listWidget.ownAdapter = listAdapter;
		window.mainWidget.addChild(listWidget);
		
		// Add some EditLineForList objects
		import std.conv : to;
		for (int i=0; i<64; ++i) {
			auto editLine = new EditLineForList();
			editLine.id = "editLine" ~ to!string(i);
			editLine.layoutWidth(FILL_PARENT);
			editLine.text = to!dstring(editLine.id) ~ (i%2 == 0 ? " even"d : ""d);
			listAdapter.add(editLine);
		}

		// Event Handlers
		// Note: More efficient if delegate is assigned to the listWidget instead of the individual editLine
		listWidget.itemSelected = delegate(Widget source, int itemIndex) {
			auto item = cast(EditLineForList) listAdapter.itemWidget(itemIndex);
			window.windowCaption = aTitle ~ " | Selected: "d ~ item.idAsDstring;
			return true;
		};

		window.show;
	} // End this(dstring aTitle)

} // End class View