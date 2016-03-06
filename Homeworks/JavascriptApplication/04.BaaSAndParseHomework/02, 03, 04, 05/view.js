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

    scope.successfulTownsLoad = function(data) {
        $('#selectedCountryTowns').text('');
        $('#edit-town-form').fadeOut();
        $('#edit-country-form').fadeOut();

        var townCreate = $('<form method="POST">');
        townCreate.append('<input type="text" id="new-town-value" data="' + scope.data.countryId + '" placeholder="New town name..." />');
        townCreate.append($('<input type="submit" id="new-town-submit" value="Submit" />').bind('click', scope.addNewTown));
        $('#selectedCountryTowns').append(townCreate);

        for (var t in data) {
            var town = data[t];
            var townItemHolder = $('<li>').attr('class', 'town').attr('data-id', town._id);

            var editButton = $('<input type="button" data="' + town.name + '" value="Edit" />').bind('click', scope.showEditTownForm);
            var deleteButton = $('<input type="button" value="Delete" />').bind('click', scope.deleteTown);

            townItemHolder.append(editButton);
            townItemHolder.append(deleteButton);
            townItemHolder.append($('<a>').text(town.name));
            townItemHolder.appendTo($('#selectedCountryTowns'));
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

    scope.showEditTownForm = function(e) {
        var townId = $(this).parent().attr('data-id');
        var town = $(this).attr('data');

        $('#edit-town-form').fadeIn();
        $('#edit-town-value').val(town);
        $('#edit-town-value').attr('data', townId);

        e.preventDefault();
    };


    scope.showAJAXError = function() {
        alert('Error with the AJAX request!');
    }

}(app));