'user strict';

var app = app || {};

(function(scope){
    scope.reloadCountries = function(){
        $('#edit-country-form').fadeOut();
        $('#edit-town-form').fadeOut();
        $('#selectedCountryTowns').text('');
        $('#countries').text('');

        scope.loadCountries();
    };

    scope.successfulCountriesLoad = function(data){
        $('<h1>').text('Countries').appendTo($('#countries'));

        for (var c in data) {
            var country = data[c];
            var countryItemHolder = $('<li>').attr('class', 'country').attr('data-id', country._id);
            var editButton = $('<input type="button" data="' + country.name + '" value="Edit" />').bind('click', scope.showEditCountryForm);
            var deleteButton = $('<input type="button" value="Delete" />').bind('click', scope.deleteCountry);

            countryItemHolder.append(editButton);
            countryItemHolder.append(deleteButton);
            countryItemHolder.append($('<a href="#">').text(country.name).bind('click', scope.loadCountryTowns));

            countryItemHolder.appendTo($('#countries'));
        }
    };

    scope.showEditCountryForm = function(e){
        var countryId = $(this).parent().attr('data-id');
        var country = $(this).attr('data');

        $('#selectedCountryTowns').text('');
        $('#edit-country-form').fadeIn();
        $('#edit-country-value').val(country);
        $('#edit-country').attr('data', countryId);

        e.preventDefault();
    };

    scope.showAJAXError = function() {
        alert('Error with the AJAX request!');
    }

}(app));