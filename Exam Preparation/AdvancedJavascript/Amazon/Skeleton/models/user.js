var models = models || {};

(function(scope){
    function User (username, fullName, balance){
        this.username = username;
        this.fullName = fullName;
        this._balance = balance;
        this._shoppingCart = scope.getShoppingCart();
    }

    User.prototype.addItemToCart = function(item){
        return this._shoppingCart.addItem(item);
    };

    scope.getUser = function(username, fullName, balance){
        return new User (username, fullName, balance);
    };

}(models));