'use strict'

function replaceATag(str){
    var re = /<a([a-zA-Z]*)>([\w\W]*)<\/a>/g;

    return str.replace(re, '[URL $1]$2[/URL]');
}

console.log(replaceATag('<ul> <li>  <a href=http://softuni.bg>SoftUni</a> </li></ul>'));