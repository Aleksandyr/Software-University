var canvas = document.getElementById('canvas');
var context = canvas.getContext('2d');

canvas.width = 500;
canvas.height = 500;

Object.prototype.extends = function (properties) {
    function f() { }    ;
    var prop;
    f.prototype = Object.create(this);
    
    for (prop in properties) {
        f.prototype[prop] = properties[prop];
    }    ;
    
    f.prototype._super = this;
    return new f();
}

var Coords = (function () {
    function Coords(x, y) {
        Coords.prototype.setCoords.call(this, x, y);
    }
    
    Coords.prototype.setCoords = function (x, y) {
        if (typeof x != "number" || typeof y != "number" || x < 0 || x > 500 || y < 0 || y > 500) {
            throw "Invalid coords, enter values in rage [0 ... 500]!";
        }
        
        this.x = x;
        this.y = y;
    }
    
    Coords.prototype.toString = function () {
        return "(x: " + this.x + ", y: " + this.y + ")";
    }
    
    return Coords;
})();

var Shapes = (function () {
    var Shape = {
        init: function init(pointA, color) {
            this.setPointA(pointA);
            this.setColor(color);
            
            return this;
        },
        setPointA: function setPointA(value) {
            this.validateCoords(value);
            this.pointA = value;
        },
        setColor: function setColor(value) {
            if (!(/(^#[0-9A-F]{6}$)|(^#[0-9A-F]{3}$)/i.test(value))) {
                throw "Color not valid!";
            }
            
            this.color = value;
        },
        validateCoords: function areCoordsValid(value) {
            if (!(value instanceof Coords)) {
                throw "Coords not valid!";
            }
        },
        isNumber: function isNumber(value) {
            if (typeof value == "number" && !isNaN(value)) {
                return true;
            }
            
            return false;
        },
        draw: function draw() {
            context.beginPath();
            context.fillStyle = this.color;
            context.lineWidth = 5;
        },
        endDraw: function endDraw() {
            context.fill();
            context.stroke();
            context.closePath();
        },
        toString: function toString() {
            return "my color is " + this.color + ", my point A has coords " + this.pointA.toString();
        }
    };
    
    var Circle = Shape.extends({
        init: function init(pointO, color, radius) {
            this._super.init.call(this, pointO, color);
            this.setRadius(radius);
            
            return this;
        },
        setRadius: function setRadius(value) {
            if (!this._super.isNumber.call(this, value) || value <= 0) {
                throw "Radius value should be positive!";
            }
            
            this.radius = value;
        },
        draw: function draw() {
            this._super.draw.call(this);
            context.arc(this.pointA.x, this.pointA.y, this.radius, 0, 2 * Math.PI, false);
            this._super.endDraw.call(this);
        },
        toString: function toString() {
            var parrentToString = this._super.toString.call(this);
            return "I'm circle, " + parrentToString + " and my radius is " + this.radius + ".";
        }
    });
    
    var Rectangle = Shape.extends({
        init: function init(pointA, color, width, height) {
            this._super.init.call(this, pointA, color);
            this.setWidth(width);
            this.setHeight(height);
            
            return this;
        },
        draw: function draw() {
            this._super.draw.call(this);
            context.rect(this.pointA.x, this.pointA.y, this.width, this.height);
            this._super.endDraw.call(this);
        },
        setWidth: function setWidth(value) {
            if (!this._super.isNumber.call(this, value) || value <= 0) {
                throw "Width value should be positive!";
            }
            
            this.width = value;
        },
        setHeight: function setHeight(value) {
            if (!this._super.isNumber.call(this, value) || value <= 0) {
                throw "Height value should be positive!";
            }
            
            this.height = value;
        },
        toString: function toString() {
            var parrentToString = this._super.toString.call(this);
            return "I'm rectangle, " + parrentToString + ", my width is " + this.width + " and my height is " + this.height + ".";
        }
    });
    
    var Triangle = Shape.extends({
        init: function init(pointA, color, pointB, pointC) {
            this._super.init.call(this, pointA, color);
            this.setPointB(pointB);
            this.setPointC(pointC);
            
            return this;
        },
        setPointB: function setPointB(value) {
            this._super.validateCoords.call(this, value);
            
            this.pointB = value;
        },
        setPointC: function setPointC(value) {
            this._super.validateCoords.call(this, value);
            
            this.pointC = value;
        },
        draw: function draw() {
            this._super.draw.call(this);
            context.moveTo(this.pointA.x, this.pointA.y);
            context.lineTo(this.pointB.x, this.pointB.y);
            context.lineTo(this.pointC.x, this.pointC.y);
            context.lineTo(this.pointA.x, this.pointA.y);
            this._super.endDraw.call(this);
        },
        toString: function toString() {
            var parrentToString = this._super.toString.call(this);
            return "I'm triangle, " + parrentToString + ", my point B has coords " + this.pointB.toString() + " and my point C has coords " + this.pointC.toString() + ".";
        }
    });
    
    var Line = Shape.extends({
        init: function init(pointA, color, pointB) {
            this._super.init.call(this, pointA, color);
            this.setPointB(pointB);
            
            return this;
        },
        setPointB: function setPointB(value) {
            this._super.validateCoords.call(this, value);
            
            this.pointB = value;
        },
        draw: function draw() {
            this._super.draw.call(this);
            context.moveTo(this.pointA.x, this.pointA.y);
            context.lineTo(this.pointB.x, this.pointB.y);
            this._super.endDraw.call(this);
        },
        toString: function toString() {
            var parrentToString = this._super.toString.call(this);
            return "I'm line, " + parrentToString + ", my point B has coords " + this.pointB.toString() + ".";
        }
    });
    
    var Segment = Shape.extends({
        init: function init(pointA, color, pointB) {
            this._super.init.call(this, pointA, color);
            this.setPointB(pointB);
            
            return this;
        },
        setPointB: function setPointB(value) {
            this._super.validateCoords.call(this, value);
            
            this.pointB = value;
        },
        draw: function draw() {
            this._super.draw.call(this);
            context.moveTo(this.pointA.x, this.pointA.y);
            context.lineTo(this.pointB.x, this.pointB.y);
            this._super.endDraw.call(this);
        },
        toString: function toString() {
            var parrentToString = this._super.toString.call(this);
            return "I'm segment, " + parrentToString + ", my point B has coords " + this.pointB.toString() + ".";
        }
    });
    
    return {
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle,
        Line: Line,
        Segment: Segment
    };
})();