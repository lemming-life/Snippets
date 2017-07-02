// Author: http://lemming.life
// Language: Javascript
// Purpose: Resize media to fit parent container while maintaining proportions.

// Steps:
// 1. Store the media and the original ratios
// 2. When browser resizes, resize media to fit parent container.

// Create a data bank
var media = new Media();
window.addEventListener('load', initResize);    // Step 1
window.addEventListener('resize', resizeMedia); // Step 2

function Media() {
    this.elements = [];
    this.containerClassNames = [ 'container' ];
    this.tags = [ 'img' ];
    this.externalTags = [ 'iframe' ];
    this.externalFilter = [ 'youtube' ]; // For vimeo and youtube [ 'vimeo', 'youtube' ]
}

function initResize() {
    storeMedia();
    resizeMedia();
}

function storeMedia() {
    for (var containerClassNameIndex = 0; containerClassNameIndex < media.containerClassNames.length; ++containerClassNameIndex) {
        var containers = document.getElementsByClassName(media.containerClassNames[containerClassNameIndex]);

        for (var containerIndex = 0; containerIndex < containers.length; ++containerIndex) {
            inspectContainer(containers[containerIndex], media.tags, []);
            inspectContainer(containers[containerIndex], media.externalTags, media.externalFilter);
        }
    }
}

function inspectContainer(container, tags, filter) {
    for (var tagIndex = 0; tagIndex < tags.length; ++tagIndex) {
        var elements = container.getElementsByTagName(tags[tagIndex]);
        
        for (var elementIndex = 0; elementIndex < elements.length; ++elementIndex) {
            var element = elements[elementIndex];

            if (inFilter(element.src, filter) == false) { continue; }

            media.elements.push( {
                'handle' : element,
                'width' : element.clientWidth,
                'height' : element.clientHeight
            } );

        } // End for var elementIndex
    } // End for var tagIndex
} // End inspectContainer()

function inFilter(url, filter) {
    if (filter.length == 0) { return true; }

    var found = false;
    for (var filterIndex = 0; filterIndex < filter.length; ++filterIndex) {
        if (url.search(filter[filterIndex]) > -1) {
            found = true;
            break;
        }
    }
    return found;
} // End inFilter()

function resizeMedia() {
    for (var elementIndex = 0; elementIndex < media.elements.length; ++elementIndex) {
        var element = media.elements[elementIndex];
        var parent = element.handle.parentElement;
        var w1 = element.width;
        var h1 = element.height;
        var w2 = w1;
        var h2 = h1;

        if (w1 > h1) {
            w2 = parent.offsetWidth;
            h2 = (w2 * h1) / w1;
        } else {
            h2 = parent.offsetWidth;
            w2 = (h2 * w1) / h1;
        }

        element.handle.width = w2;
        element.handle.height = h2;
    }
} // End resizeMedia()