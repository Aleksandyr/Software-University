'use strict';

function createParagraph(id, text){
    var mainElem = document.getElementById(id);
    var createParagraph = document.createElement('p');
    var txt = document.createTextNode(text);
    createParagraph.appendChild(txt);
    mainElem.appendChild(createParagraph);
}

createParagraph('wrapper', 'some text');