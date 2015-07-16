/**
 * Created by samis_000 on 31.3.2015 г..
 */

var Bullet = (function(){
    function Bullet(x, y, velo) {
        this.position = new Vector2(x, y);
        this.velocity = velo;

        this.width = 80;
        this.height = 50;

        this.animation = new Animation(this.width, this.height, 2, 1, 1, 'ressources/images/shoot.png', 1, 0, 0);
        this.boundingBox = new Rectangle(x, y, this.width-50, this.height);

    };

    Bullet.prototype.update = function () {
        this.animation.position.set(this.position.x, this.position.y);
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
        this.animation.update();
    };

    Bullet.prototype.render = function (ctx) {
        this.animation.draw(ctx);
    };

    Bullet.prototype.shoot = function () {
        this.position.y -= this.velocity;
    };
    return Bullet;
}());








