'use strict';

function isMailValid(){
    var texField = document.getElementById('text-field').value;
    //var button = document.getElementById('check-button');
    var isValid = document.getElementById('is-email-correct');

    var re = new RegExp(/\@([a-zA-Z]+)\.([a-zA-Z]{2,4})/g);
    console.log(texField);

    if(texField.search(re) > -1){
        isValid.style.backgroundColor = 'lightgreen';
        var str = texField;
        isValid.innerText = str;
    } else{
        isValid.style.backgroundColor = 'red';
        isValid.innerText = texField;
    }
}