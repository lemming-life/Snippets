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


// SLIGHTLY MODIFIED WIDGETS
class TListWidget(T) : ListWidget {
	override bool onKeyEvent(KeyEvent event) {
        if (itemCount == 0)
            return false;
        int navigationDelta = 0;
		
        if (event.action == KeyAction.KeyDown) {
            if (orientation == Orientation.Vertical) {
                if (event.keyCode == KeyCode.DOWN)
                    navigationDelta = 1;
                else if (event.keyCode == KeyCode.UP)
                    navigationDelta = -1;
            } else {
                if (event.keyCode == KeyCode.RIGHT)
					navigationDelta = 1;  
                else if (event.keyCode == KeyCode.LEFT)
            	    navigationDelta = -1;
            }
        }

		// Get the item and cast it to the T type.
		auto item = cast(T) _adapter.itemWidget(_selectedItemIndex);

        if (navigationDelta != 0) {
            moveSelection(navigationDelta);
			item = cast(T) _adapter.itemWidget(_selectedItemIndex); // because the item changed
			item.allAndFocus(); // Do a select all on the EditLine
            return true;
        }

		// Send the key events, and render the list
		if (item.onKeyEvent(event)) {
			invalidate();
			return true;
		}
		
		return super.onKeyEvent(event);
	}

	
	// Modify the behavior of the mouse on the list slightly.
	override bool onMouseEvent(MouseEvent event) {
		super.onMouseEvent(event);
		if (_selectedItemIndex == -1) { return false; }
		_adapter.itemWidget(_selectedItemIndex).onMouseEvent(event);
		return true;
	}

} // End TListWidget

// Adapter that can use keys and mouse events.
class WidgetListAdapterKeysMouse : WidgetListAdapter {
	override @property bool wantKeyEvents() {
		return true;
	}

	override @property bool wantMouseEvents() {
		return true;
	}
}

// EditLine with slight modifications for list environment.
class EditLineForList : EditLine {
	void allAndFocus() {
		bool focused = true;
		bool receivedFocusFromKeyboard = true;
		handleFocusChange(focused, receivedFocusFromKeyboard);
	}

	override bool onKeyEvent(KeyEvent event) {
		import std.stdio : writeln;
		bool focused = true;
		bool receivedFocusFromKeyboard = false;
		handleFocusChange(focused, receivedFocusFromKeyboard);

		// Move the cursor to the left or right of selection.
		if (_selectionRange.end.pos - _selectionRange.start.pos > 0) {
			if (event.keyCode == KeyCode.LEFT) {
				_caretPos.pos = _selectionRange.start.pos;
				_selectionRange.start.pos = _caretPos.pos;
				_selectionRange.end.pos = _caretPos.pos;
				ensureCaretVisible();
				return true;
			} else if (event.keyCode == KeyCode.RIGHT) {
				_caretPos.pos = _selectionRange.end.pos;
				_selectionRange.start.pos = _caretPos.pos;
				_selectionRange.end.pos = _caretPos.pos;
				ensureCaretVisible();
				return true;
			}
		}

		super.onKeyEvent(event);
		return true;
	}


	dstring idAsDstring() {
		import std.conv : to;
		return to!dstring(id);
	}
} // End EditLineForList