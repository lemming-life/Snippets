// Author: http://lemming.life
// Language: D
// Dependencies: dlangui
// Description:
// - TListWidget(T) for EditLineForList
// - EditLineForList : text box that can be used in a list of widgets.
// - WidgetListAdapterKeysMouse : an adapter that indicates that mouse and keys can be used.
// - ListWidgetNav : A list that is meant to be used with StringListAdapter and finds item via keystrokes.

module lemmingwidgets;
import dlangui;

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
	} // End onKeyEvent(KeyEvent event)

	
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
	} // End onKeyEvent(KeyEvent event)


	dstring idAsDstring() {
		import std.conv : to;
		return to!dstring(id);
	}
} // End EditLineForList


// Widget that allows selection of item via keys
class ListWidgetNav : StringListWidget {
	import std.conv : to;
	import std.datetime : dto = to, StopWatch;

	private dstring _searchString = "";
	private StopWatch _sw;

	override bool onKeyEvent(KeyEvent event) {
        if (itemCount == 0)
            return false;

		// Lemming modification
		// - Accept user input and try to find a match in the list.
		if (event.action == KeyAction.Text) {
			if (!_sw.running) {
				// If stopWatch not running
				_sw.start;
				_searchString = ""d ~ to!dchar(event.text.toUTF8);
			} else {
				immutable auto timePassed = _sw.peek.dto!("seconds", float)(); // dto is std.datetime.to

				if (timePassed > 0.5) {
					_searchString = ""d ~ to!dchar(event.text.toUTF8);
					_sw.reset;
				} else {
					_searchString ~= to!dchar(event.text.toUTF8);
					_sw.reset;
				}
			}

			if ( selectClosestMatch(_searchString) ) {
				invalidate();
				return true;
			}
		}

        return super.onKeyEvent(event);

    } // End onKeyEvent()

	bool selectClosestMatch(dstring term) {
		import std.uni : toLower;
		if (term.length == 0) { return false;}

		int[int] scores;
		auto myItems = (cast(StringListAdapter)adapter).items;

		// Perfect match or best match
		int[] indexes;
		foreach(int itemIndex; 0 .. myItems.length) {
			dstring item = myItems.get(itemIndex);
			if (item == term) {
				// Perfect match
				selectItem(itemIndex);
				itemSelected(this, itemIndex);
				return true;
			} else {
				// Not perfect, but maybe within term
				bool addItem = true;
				foreach(int termIndex; 0 .. cast(int)term.length) {
					if (termIndex < item.length) {
						if (toLower(term[termIndex]) != toLower(item[termIndex]) ) {
							addItem = false;
							break;
						}
					}
				}
				if (addItem) { indexes ~= itemIndex; }
			}
		}

		// Select the first item
		if (indexes.length > 0) {
			selectItem(indexes[0]);
			itemSelected(this, indexes[0]);
			return true;
		}

		// Did not find an item
		return false;
		
	} // End selectClosestMatch()

} // End class ListWidgetNav