var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');

var Player = (function(){
    function Player(x, y) {
        this.position = new Vector2(x, y);
        this.movement = {left: false, right: false, up: false, down: false, fire: false};
        this.velocity = 8;
        this.fireCooldown = false;
        this.bulletArray = [];
        this.level = 0;
		this.hitCounter = 0;
		this.isAlive = true;

        this.width = 60;
        this.height = 100;

        this.animation = new Animation(this.width, this.height, 0, 0, 1, 'ressources/images/F5S4.png', 1, 0, 0);
        this.boundingBox = new Rectangle(x, y, this.width, this.height);
		this.explosionAnimation = new Animation(113.4, 126.5, 0, 5, 23, 'ressources/images/exp.png', 20, 8, 4);
		this.flashAnimation = new Animation(this.width, this.height, 0, 0, 1,'ressources/images/F5S4-flash.png',1,0,0);
        this.defaultAnimation = new Animation(this.width, this.height, 0, 0, 1,'ressources/images/F5S4.png',1,0,0);
        //Background.prototype.canvasWidth = this.canvas.width;

    }

    Player.prototype.update = function () {
        if (this.movement.right) {
            this.animation = new Animation(this.width, this.height, 0, 0, 1,
                'ressources/images/F5S4-right.png', 1, 0, 0);
            this.position.x += this.velocity;

            if(this.position.x >= canvas.width - this.width){
                this.position.x = canvas.width - this.width;
            }
        } else if (this.movement.left) {
            this.animation = new Animation(this.width, this.height, 0, 0, 1,
                'ressources/images/F5S4-left.png', 1, 0, 0);
            this.position.x -= this.velocity;

            if(this.position.x <= 0){
                this.position.x = 0;
            }
        } else{
            this.animation = new Animation(this.width, this.height, 0, 0, 1,'ressources/images/F5S4.png', 1, 0, 0);
        }
        if (this.movement.up) {
            this.position.y -= this.velocity;

            if(this.position.y <= canvas.height/4.5*3){
                this.position.y = canvas.height/4.5*3;
            }
        } else if (this.movement.down) {
            this.position.y += this.velocity;

            if(this.position.y >= canvas.height - this.height){
                this.position.y = canvas.height - this.height;
            }
        }
		
		var currentPlayer = this;
        enemies.forEach(function(enemy) {
            enemy.bulletArray.forEach(function(bullet){                                                
                if(currentPlayer.boundingBox.intersects(bullet.boundingBox)){                           
                    currentPlayer.hitCounter++;                                                          
                    currentPlayer.animation = currentPlayer.flashAnimation;                              
                    setTimeout(function(){currentPlayer.animation = currentPlayer.defaultAnimation;},500); 
                    enemy.bulletArray.remove(bullet);                                                  
                }                                                                                       
            })
        });                                                                                           
        
        if(this.hitCounter >= 5){
            currentPlayer.velocity = 0;
            currentPlayer.width = 113.4;
            currentPlayer.height = 126.5;
			currentPlayer.isAlive = false;
            currentPlayer.animation = currentPlayer.explosionAnimation;
            currentPlayer.level = -1;
            enemies = [];
            setTimeout(function(){
                currentPlayer.hitCounter = 0;
                currentPlayer.isAlive = true;
                currentPlayer.velocity = 8;
                },1000);
        }                                                                                           
 
		
        if(this.movement.fire && this.isAlive == true){

            this.fireBullet();
        }

        this.animation.position.set(this.position.x, this.position.y);
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
        this.animation.update();
    };

    Player.prototype.render = function (ctx) {
        this.animation.draw(ctx);
    };

    Player.prototype.fireBullet = function(){
        if(this.fireCooldown === false){
            var bull = new Bullet(this.position.x,this.position.y, 12);
            this.bulletArray.push(bull);
            this.fireCooldown = true;
            window.setTimeout(function(){
                player.fireCooldown = false;
            },100);
        }else{

        }
    }




    return Player;
}());