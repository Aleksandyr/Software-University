var models = models || {};

(function(scope){
    function Category (name){
        this.name = name;
        this._categories = [];
        this._items = [];
    }

    Category.prototype.addCategory = function(category){
        return this._categories.push(category);
    };

    Category.prototype.getCategories = function(){
        return this._categories;
    };

    Category.prototype.addItem = function(item){
        return this._items.push(item);
    };

    Category.prototype.getItems = function(){
        return this._items;
    };

    scope.getCategory = function(name){
        return new Category(name);
    };

}(models));