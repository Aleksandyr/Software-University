'use strict';

$(function(){
    var json = [{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},
        {"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},
        {"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}];

    json.forEach(function(obj){
        $('table').append($('<tr>')
            .append($('<td>').text(obj.manufacturer))
            .append($('<td>').text(obj.model))
            .append($('<td>').text(obj.year))
            .append($('<td>').text(obj.price))
            .append($('<td>').text(obj.class))
        );
    })
}());