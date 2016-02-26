'use strict';

(function(){
    function makeRow(values, columnHtmlType){
        var newRow = $('<tr>'),
            len = values.length;

        for (var i = 0; i < len; i++) {
            $(columnHtmlType).text(values[i]).appendTo(newRow);
        }

        return newRow;
    }

    $.fn.grid = function(){
        this.addHeader = function(values){
            var newRow = makeRow(values, '<th>');
            this.find('thead').empty().append(newRow);

            return this;
        };

        this.addRow = function(values){
            var newRow = makeRow(values, '<td>');
            this.find('tbody').append(newRow);

            return this;
        };

        return this.empty().append('<tbody>').append('<thead>');
    }
}());

$('#gridTable')
    .grid()
    .addHeader(['First Name', 'Last Name', 'Age'])
    .addRow(['Pesho', 'Goshov', 20])
    .addRow(['Gosho', 'Peshev', 23]);