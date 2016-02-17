var models = models || {};

(function(scope){
    function UsedItem (title, description, price, condition){
        scope._Item.apply(this, arguments);
        this.condition = condition;
    }

    UsedItem.extends(scope._Item);

    scope.getUsedItem = function(title, description, price, condition){
        return new UsedItem(title, description, price, condition);
    };

}(models));