'use strict';

var app = app || {};

(function(scope){
    scope.data = {};
    var BASE_URL = 'http://baas.kinvey.com';
    var PARSE_APP_ID = 'kid_ZJNYs_CZkZ';
    var PARSE_REST_API_KEY = '4760c22bf68040c18f49e3f60380672d';

    var CRUD = function(crudMethod, crudUrl, crudData, crudSuccessCallback, crudErrorCallback, contentType){
        var USER_AUTH = 'cGVzaG86MTIzNDU2';

        $.ajax({
            method: crudMethod,
            headers: {
                'Authorization' : 'Basic ' + USER_AUTH,
                'X-Kinvey-API-Version' : '3',
                'Content-Type' : contentType
            },
            url: crudUrl,
            data: JSON.stringify(crudData)
        }).success(crudSuccessCallback).error(crudErrorCallback);
    };

    scope.loadCountries = function(){
        var allPath = BASE_URL + '/appdata/' + PARSE_APP_ID + '/countries';
        CRUD('GET', allPath, null, scope.successfulCountriesLoad, scope.showAJAXError, 'application/json');
    };

    scope.loadCountryTowns = function(e){
        var countryId = $(this).parent().attr('data-id');
        var query = '?query={"country._id":"' + countryId + '"}';
        var getCountryTownsUrl = BASE_URL + '/appdata/' + PARSE_APP_ID + '/towns' + query;

        scope.data.countryId = countryId;
        CRUD('GET', getCountryTownsUrl, null, scope.successfulTownsLoad, scope.showAJAXError);

        e.preventDefault();
    };

    scope.editCountry = function(e){
        var countryId = $('#edit-country').attr('data');
        var country = $('#edit-country-value').val();
        var editData = {'name': country};

        CRUD('PUT', BASE_URL + '/appdata/' + PARSE_APP_ID + '/countries/' + countryId, editData, scope.reloadCountries, scope.showAJAXError, 'application/json');

        e.preventDefault();
    };

    scope.addNewCountry = function(e){
        var newCountryValue = $('#add-country').val();
        var newCountryData = {'name': newCountryValue};

        var allPath = BASE_URL + '/appdata/' + PARSE_APP_ID + '/countries';
        CRUD('POST', allPath, newCountryData, scope.reloadCountries, scope.showAJAXError, 'application/json');

        $('#add-country').val('');
        e.preventDefault();
    };

    scope.deleteCountry = function(e){
        var countryId = $(this).parent().attr('data-id');

        CRUD('DELETE', BASE_URL + '/appdata/' + PARSE_APP_ID + '/countries/' + countryId, null, scope.reloadCountries, scope.showAJAXError);

        e.preventDefault();
    }
}(app));