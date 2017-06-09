
// Sets the inner HTML to be the current year.
function setCurrentYear() {
    var elementId = "currentYear";
    var d = new Date();
    document.getElementById(elementId).innerHTML = d.getFullYear();
}

/* To use:
- In the html file add an element with a specific id.
    <div id="currentYear"></div>
- In the javascript file call the function.
    window.addEventListener("load", setCurrentYear);
*/