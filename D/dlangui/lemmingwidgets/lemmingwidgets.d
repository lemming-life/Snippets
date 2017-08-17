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

interface OnItemTriggered {
	bool itemTriggerd(Widget source, int itemIndex);
}

// Widget that allows selection of item via keys
class ListWidgetNav : StringListWidget {
	import std.conv : to;
	import std.datetime : dto = to, StopWatch;

	Signal!OnItemTriggered itemTriggered;

	private dstring _searchString = "";
	private StopWatch _stopWatch;

	KeyFlag keyFlag = KeyFlag.Command;

	//version ( OSX ) {
	//	keyFlag = KeyFlag.Command;
	//} else {
	//	keyFlag = KeyFlag.Control;
	//}

	override bool onKeyEvent(KeyEvent event) {
        if (itemCount == 0)
            return false;

		if (event.action == KeyAction.KeyDown) {
			if (event.keyCode == KeyCode.RETURN || event.keyCode == KeyCode.RIGHT || event.keyCode == KeyCode.LEFT) {
				itemTriggered(this, selectedItemIndex);
				return true;
			}
		}

		if (event.action == KeyAction.KeyDown) {
			import std.stdio : writeln;

			if ( (event.flags & keyFlag) == keyFlag) {
				if (event.keyCode == KeyCode.KEY_J) {
					// Navigate left
					
					return true;
				} else if (event.keyCode == KeyCode.KEY_L) {
					// Navigate right
					
					return true;
				} else if (event.keyCode == KeyCode.KEY_I) {
					"I".writeln;
					// Up
					return true;
				} else if (event.keyCode == KeyCode.KEY_K) {
					// Down
					"K".writeln;
					return true;
				} else if (event.keyCode == KeyCode.KEY_E) {
					// Open it
					"item trigger".writeln;
					itemTriggered(this, selectedItemIndex);
					return true;
				}

			}
		}

		// Accept user input and try to find a match in the list.
		if (itemCount == 0) return false;

        // Accept user input and try to find a match in the list.
        if (event.action == KeyAction.Text) {
            if ( !_stopWatch.running) { _stopWatch.start; }

            auto timePassed = _stopWatch.peek.dto!("seconds", float)(); // dtop is std.datetime.to

            if (timePassed > 0.5) _searchString = ""d;
            _searchString ~= to!dchar(event.text.toUTF8);
            _stopWatch.reset;

            if ( selectClosestMatch(_searchString) ) {
                invalidate();
                return true;
            }
        }

        return super.onKeyEvent(event);
    } // End onKeyEvent()


	private bool selectClosestMatch(dstring term) {
        import std.uni : toLower;
        if (term.length == 0) return false;
        auto myItems = (cast(StringListAdapter)adapter).items;

        // Perfect match or best match
        int[] indexes;
        foreach(int itemIndex; 0 .. myItems.length) {
            dstring item = myItems.get(itemIndex);

            if (item == term) {
                // Perfect match
                indexes ~= itemIndex;
                break;
            } else {
                // Term approximate 
                bool addItem = true;
                foreach(int termIndex; 0 .. cast(int)term.length) {
                    if (termIndex < item.length) {
                        if ( toLower(term[termIndex]) != toLower(item[termIndex]) ) {
                            addItem = false;
                            break;
                        }
                    }
                }

                if (addItem) { indexes ~= itemIndex; }

            }
        }

        // Return best match
        if (indexes.length > 0) {
            selectItem(indexes[0]);
            itemSelected(this, indexes[0]);
            return true;
        }

        return false; // Did not find term
    } // End selectClosestMatch()

} // End class ListWidgetNav