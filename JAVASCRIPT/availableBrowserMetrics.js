// Author: http://lemming.life
// Language: Javascript
// Description: Facilitates operations involved with a browser's available space

// Get the browser's available width (removing the scroll bar width)
function getClientWidth() {
      if (window.innerWidth) {
            return window.innerWidth - getScrollBarWidth();
      } else {
            return screen.width = getScrollBarWidth();
      }
}

// Get the browser's available height
function getClientHeight() {
      if (window.innerHeight) {
            return window.innerHeight;
      } else {
            return screen.height;
      }
}

// Get the browser's scroll bar width
function getScrollBarWidth() {
      var containerDiv = document.createElement('div');
      containerDiv.style.width = '75px';
      document.body.appendChild(containerDiv);

      var containerDivWidth = containerDiv.offsetWidth;
      containerDiv.style.overflow = 'scroll';

      var innerDiv = document.createElement('div');
      innerDiv.style.width = 100 + '%';
      containerDiv.appendChild(innerDiv);

      var innerDivWidth = innerDiv.offsetWidth;
      containerDiv.parentNode.removeChild(containerDiv);

      return (containerDivWidth - innerDivWidth);
}