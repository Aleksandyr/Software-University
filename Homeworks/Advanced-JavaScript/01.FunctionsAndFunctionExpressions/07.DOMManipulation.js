'use strict';

var domModule = (function domModle(){
   function appendChild(domElement, selector) {
       var target = document.querySelector(selector);

       target.appendChild(domElement);
   }

    function removeChild(parentSelector, childSelector){
        var target = document.querySelector(parentSelector);
        var child = target.querySelector(childSelector);

        target.removeChild(child);
    }

    function addHandler(selector, eventHandler, event){
        var target = document.querySelector(selector);

        for (var i = 0; i < target.length; i += 1) {
            target[i].addEventListener(eventHandler, event);
        }
    }

    function retrieveElements(selector){
        var elements = document.querySelector(selector);

        return elements;
    }

    return{
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };
})();

var liElement = document.createElement("li");

domModule.appendChild(liElement, ".birds-list");
domModule.removeChild("ul.birds-list", "li:first-child");
domModule.addHandler("li.bird", "click",function(){
    alert("Hello there!");
});

var elements = domModule.retrieveElements(".bird");
console.log(elements);