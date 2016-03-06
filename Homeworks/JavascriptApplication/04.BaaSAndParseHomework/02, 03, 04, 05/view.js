'user strict';

var app = app || {};

(function(scope){
    scope.successfulCountriesLoad = function(data){
        $('<h1>').text('Countries').appendTo($('#countries'));

        for (var c in data) {
            var country = data[c];
            var countryItemHolder = $('<li>').attr('class', 'country').attr('data-id', country.objectId);
            var editButton = $('<input type="button" data="' + country.name + '" value="Edit" />').bind('click', scope.showEditCountryForm);
            var deleteButton = $('<input type="button" value="Delete" />').bind('click', scope.deleteCountry);

            countryItemHolder.append(editButton);
            countryItemHolder.append(deleteButton);
            countryItemHolder.append($('<a href="#">').text(country.name).bind('click', scope.loadCountryTowns));

            countryItemHolder.appendTo($('#countries'));
        }
    };

    scope.showAJAXError = function() {
        alert('Error with the AJAX request!');
    }

}(app));