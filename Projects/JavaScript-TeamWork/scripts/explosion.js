var Explosion = (function () {
    function Explosion(x, y) {
        this.position = new Vector2(x, y);
        this.movement = { left: false, right: false, up: false, down: false };

        this.width = 113.4;
        this.height = 126.5;
        
        this.animation = new Animation(this.width, this.height, 0, 5, 23, 'ressources/images/exp.png', 20, 8, 4);
        this.boundingBox = new Rectangle(x, y, this.width, this.height);

    }
    
    Explosion.prototype.update = function () {
        //to do some more 
        
        this.animation.position.set(this.position.x, this.position.y);
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
        this.animation.update();
    };
    
    Explosion.prototype.render = function (ctx) {
        this.animation.draw(ctx);
    };
    
    return Explosion;
}());