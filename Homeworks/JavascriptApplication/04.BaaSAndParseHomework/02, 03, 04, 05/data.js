'use strict';

var app = app || {};

(function(scope){
    scope.data = {};
    var BASE_URL = 'baas.kinvey.com/appdata';
    var PARSE_APP_ID = 'kid_ZJNYs_CZkZ';
    var PARSE_REST_API_KEY = '4760c22bf68040c18f49e3f60380672d';

    var CRUD = function(crudMethod, crudUrl, crudData, crudSuccessCallbakc, crudErrorCallback){
        var REST_API = 'cGVzaG86MTIzNDU2';

        $.ajax({
            method: crudMethod,
            headers: {
                'Authorization' : 'Basic ' + REST_API,
                'X-Kinvey-API-Version' : '3',
                'Content-Type' : 'application/json'
            },
            url: crudUrl,
            data: JSON.stringify(crudData)
        }).success(crudSuccessCallbakc).error(crudErrorCallback);
    };

    scope.loadCountries = function(){
        CRUD('GET', 'http://baas.kinvey.com/appdata/' + PARSE_APP_ID + '/countries', null, scope.successfulCountriesLoad, scope.showAJAXError);
    }
}(app));