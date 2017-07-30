// Needs cleanup.

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



// Need a list widget that responds to keystrokes so
// that we can quickly get to the item.

class ListWidgetNav : StringListWidget {
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
        if (navigationDelta != 0) {
            moveSelection(navigationDelta);
            return true;
        }
        if (event.action == KeyAction.KeyDown) {
            if (event.keyCode == KeyCode.HOME) {
                // select first enabled item on HOME key
                selectItem(0, 1);
                return true;
            } else if (event.keyCode == KeyCode.END) {
                // select last enabled item on END key
                selectItem(itemCount - 1, -1);
                return true;
            } else if (event.keyCode == KeyCode.PAGEDOWN) {
                // TODO
            } else if (event.keyCode == KeyCode.PAGEUP) {
                // TODO
            }
        }
        if ((event.keyCode == KeyCode.SPACE || event.keyCode == KeyCode.RETURN)) {
            if (event.action == KeyAction.KeyDown && enabled) {
                if (itemEnabled(_selectedItemIndex)) {
                    itemClicked(_selectedItemIndex);
                }
            }
            return true;
        }



		
		// Lemming modification
		/*
		import std.conv;
		if (event.action == KeyAction.Text) {
			auto c = to!dchar(event.text.toUTF8);
			
			// TODO:
			// Consider a timer for input
			// If the timer is active then add to a search string
			// If the timer is inactive activate timer and initiate search string

			// For now
			if (findItemAndSelect(c)) {
				return true;				
			}
		}
		*/

        return super.onKeyEvent(event);
    }

	// To be replaced
	bool findItemAndSelect(dchar c) {
		auto myItems = (cast(StringListAdapter)adapter).items;
		
		foreach(i; 0 .. myItems.length) {
			if (myItems.get(i)[0] == c) {
				selectItem(i);
				invalidate();
				return true;
			}
		}
		return false;
	}


	/*
	// Discard function and make a new one
	bool findItemAndSelect(dstring lookFor) {
		if (lookFor.length == 0) { return false; }

		auto myItems = (cast(StringListAdapter)adapter).items;
		StringScore[int] map;
		foreach (i; 0..myItems.length) {
			StringScore stringScore;
			stringScore.value = myItems.get(i);
			stringScore.score = 0;
			map[i] = stringScore;
		}

		// Must begin with the right character
		foreach(k, ref v; map) {
			if (v.value[0] != lookFor[0]) {
				map.remove(k);
			} else {
				++v.score;
			}
		}

		if (map.length == 0) { return false; }

		foreach(k, ref v; map) {
			foreach(i, c; lookFor) {
				if (i < v.value.length) {
					if (v.value[i] == lookFor[i]) {
						v.score += (int.max / (i+1));
					}
				}
			}
		}

		int highestScore = 0;
		StringScore highestStringScore;
		int highestIndex;
		foreach(k, ref v; map) {
			if (v.score > highestScore) {
				highestScore = v.score;
				highestIndex = k;
			}
		}

		selectItem(highestIndex);
		invalidate();

		return true;
	}*/

	/*
	struct StringScore {
		dstring value;
		int score;
	}


	dstring _track;
	*/


}