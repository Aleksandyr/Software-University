'use strict';

var app = app || {};

(function(scope){
	app.router = Sammy(function(){
		var selector = '#text';

		this.get('#/', function(){
			$(selector).html('home');
		});

		this.get('#/sam', function(){
			$(selector).html('Sam');
		});
		this.get('#/bob', function(){
			$(selector).html('Bob');
		});
		this.get('#/tom', function(){
			$(selector).html('Tom');
		});
	});

	app.router.run('#/');
}(app));

