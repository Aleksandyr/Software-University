'use strict';

var HTMLGen = {
    createParagraph: function(id, text){
        var parent = document.getElementById(id);
        var paragraph = document.createElement('p');
        var txt = document.createTextNode(text);
        paragraph.appendChild(txt);

        parent.appendChild(paragraph);
    },

    createDiv: function(id, _class){
        var parent = document.getElementById(id);
        var div = document.createElement('div');
        div.className += _class;

        parent.appendChild(div);
    },

    createLink: function(id, text, url){
        var parent = document.getElementById(id);
        var a = document.createElement('a');
        a.innerHTML = text;
        a.href += url;

        parent.appendChild(a);
    }
};

HTMLGen.createParagraph('wrapper', 'some text');
HTMLGen.createDiv('wrapper', 'some-div');
HTMLGen.createLink('wrapper', 'softUni', 'https://softuni.bg/');

