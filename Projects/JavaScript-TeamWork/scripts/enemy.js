var Enemy = (function() {
    function Enemy (x, y){
        this.width = 100;
        this.height = 85;
        this.velocity = 1;
		this.fireCooldown = false;
		this.bulletArray = [];
        this.moveCounter = 1;
        this.hitCounter = 0;

        this.position = new Vector2(x, y);
        this.animation = new Animation(this.width, this.height, 0, 0, 1,'ressources/images/enemy2.png',1,0,0);
        this.boundingBox = new Rectangle(x, y, this.width, this.height);
        this.flashAnimation = new Animation(this.width, this.height, 0, 0, 1,'ressources/images/enemy2-flash.png',1,0,0);
        this.defaultAnimation = new Animation(this.width, this.height, 0, 0, 1,'ressources/images/enemy2.png',1,0,0);
        this.explosionAnimation = new Animation(113.4, 126.5, 0, 5, 23, 'ressources/images/exp.png', 20, 8, 4);
    }

    Enemy.prototype.update = function () {
        if(this.moveCounter <=30){
            this.moveCounter++;
            this.position.x += this.velocity;
        }
        else if(this.moveCounter <=61){
            this.moveCounter++;
            this.position.x -= this.velocity;
        }
        else{
            this.moveCounter=0;
        }
        var currentEnemy = this;
        player.bulletArray.forEach(function(bullet){
            if(currentEnemy.boundingBox.intersects(bullet.boundingBox)){
                currentEnemy.hitCounter++;
                currentEnemy.animation = currentEnemy.flashAnimation;
                setTimeout(function(){currentEnemy.animation = currentEnemy.defaultAnimation;},50);
                player.bulletArray.remove(bullet);
            }
        })
        if(this.hitCounter >= 3){
            currentEnemy.velocity = 0;
            currentEnemy.width = 113.4;
            currentEnemy.height = 126.5;
            currentEnemy.animation = currentEnemy.explosionAnimation;
            setTimeout(function(){enemies.remove(currentEnemy);},400);

        }


        this.animation.position.set(this.position.x, this.position.y);
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
        this.animation.update();
		
        if(Math.floor((Math.random() * 9) + 1) === 3 && player.isAlive == true) {
            this.fireBullet();
        }
    };
    Enemy.prototype.render = function (ctx) {
        this.animation.draw(ctx);
    };
	   Enemy.prototype.fireBullet = function(){
        if(this.fireCooldown === false){
            var bull = new Bullet(this.position.x,this.position.y, -12),
                enemy = this;
            this.bulletArray.push(bull);
            this.fireCooldown = true;
            window.setTimeout(function(){
                enemy.fireCooldown = false;
            },2000);
        }
    };
    return Enemy
}());

function createEnemies(perLine, lines, enemyWidth, enemyHeight){
    var lineLength = canvas.width,
        maxEnemiesPerLine = parseInt(lineLength / enemyWidth),
        enemies = [];
    if(perLine > maxEnemiesPerLine){return undefined;}
    var spacing = (lineLength - enemyWidth * perLine)/(perLine + 1),
        x = spacing-8,
        y = 10;

    for(var i = 0; i < lines; i++){
        for(var j = 0; j< perLine; j++){
            enemies.push(new Enemy(x , y))
            x+=spacing+enemyWidth;
        }
        x = spacing-8;
        y+=enemyHeight + 10;
    }
    return enemies;
}

























