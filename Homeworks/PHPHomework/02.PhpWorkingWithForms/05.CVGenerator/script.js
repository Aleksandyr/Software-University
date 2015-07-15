document.addEventListener('DOMContentLoaded', function(){
    var progLangId = 2;
    document.getElementById('add-prog-lang').onclick = function(e){
        e.preventDefault();
        var wrapper = document.createElement('div');
        wrapper.setAttribute('id', 'prog-lang-' + progLangId);
        wrapper.innerHTML = ' <input type="text" name=\"programmingLanguages[]\" /> <select name=\"programmingLanguageLevels[]\">' +
        '<option>Beginner</option> <option>Programmer</option> <option>Advanced</option> <option>expert</option>' +
        ' <option>Ninja</option> </select>';
        document.getElementById('programming-languages').appendChild(wrapper);
        progLangId++;
        console.log(wrapper);
    };

    document.getElementById('remove-prog-lang').onclick = function(e){
        e.preventDefault();
        var currDiv = document.getElementById('prog-lang-' + (progLangId - 1));
        if(currDiv.id !== 'prog-lang-1'){
            document.getElementById('programming-languages').removeChild(currDiv);
            progLangId--;
        }
    };

    var langId = 2;
    document.getElementById('add-lang').onclick = function (e) {
        e.preventDefault();var wrapper = document.createElement('div');
        wrapper.setAttribute('id', 'lang-'+ langId);
        wrapper.innerHTML = '<input type=\"text\" name=\"languages[]\" /> ' +
        '<select name=\"comprehension[]\"><option selected disabled>-Comprehension-</option> ' +
        '<option>beginner</option><option>intermediate</option><option>advanced</option> ' +
        '</select><select name=\"reading[]\"><option selected disabled>-Reading-</option>' +
        '<option>beginner</option><option>intermediate</option><option>advanced</option> ' +
        '</select><select name=\"writing[]\"><option selected disabled>-Writing-</option> ' +
        '<option>beginner</option><option>intermediate</option><option>advanced</option> </select>';
        document.getElementById('languages').appendChild(wrapper);
        langId++;
    };

    document.getElementById('remove-lang').onclick = function (e) {
        e.preventDefault();
        var lastElemId = document.getElementById('languages').lastChild.id;
        if(lastElemId != 'lang-1'){
            document.getElementById('languages').lastChild.remove();
        }
    }
});
