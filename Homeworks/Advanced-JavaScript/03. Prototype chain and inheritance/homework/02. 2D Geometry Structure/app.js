Object.prototype.extends = function (properties) {
    function f() {};
    var prop;
    f.prototype = Object.create(this);

    for (prop in properties) {
        f.prototype[prop] = properties[prop];
    };
    
    f.prototype._super = this;
    return new f();
}

var Coords = (function () {
    function Coords(x, y) {
        this._x = x;
        this._y = y;
    }
    
    Coords.prototype.toString = function () {
        return "(x: " + this._x + ", y: " + this._y + ")";
    }
    
    return Coords;
})();

var Shapes = (function () {
    var Shape = {
        init: function init(pointA, color) {
            this.pointA = pointA;
            this.color = color;

            return this;
        },
        
        toString: function toString() {
            return "my color is " + this.color + ", my point A has coords " + this.pointA.toString();
        }
    };

    var Circle = Shape.extends({
        init: function init(pointO, color, radius) {
            this._super.init.call(this, pointO, color);
            this.radius = radius;
            
            return this;
        },
        
        toString: function toString() {
            var parrentToString = this._super.toString.call(this);
            return "I'm circle, " + parrentToString + " and my radius is " + this.radius + ".";
        }
    });
    
    var Rectangle = Shape.extends({
        init: function init(pointA, color, width, height) {
            this._super.init.call(this, pointA, color);
            this.width = width;
            this.height = height;
            
            return this;
        },
        
        toString: function toString() {
            var parrentToString = this._super.toString.call(this);
            return "I'm rectangle, " + parrentToString + ", my width is " + this.width + " and my height is " + this.height + ".";
        }
    });
    
    var Triangle = Shape.extends({
        init: function init(pointA, color, pointB, pointC) {
            this._super.init.call(this, pointA, color);
            this.pointB = pointB;
            this.pointC = pointC;
            
            return this;
        },
        
        toString: function toString() {
            var parrentToString = this._super.toString.call(this);
            return "I'm triangle, " + parrentToString + ", my point B has coords " + this.pointB.toString() + " and my point C has coords " + this.pointC.toString() + ".";
        }
    });
    
    var Line = Shape.extends({
        init: function init(pointA, color, pointB) {
            this._super.init.call(this, pointA, color);
            this.pointB = pointB;
            
            return this;
        },
        
        toString: function toString() {
            var parrentToString = this._super.toString.call(this);
            return "I'm line, " + parrentToString + ", my point B has coords " + this.pointB.toString() + ".";
        }
    });
    
    var Segment = Shape.extends({
        init: function init(pointA, color, pointB) {
            this._super.init.call(this, pointA, color);
            this.pointB = pointB;
            
            return this;
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

var circle = Object.create(Shapes.Circle).init(new Coords(5, 10), "#f00", 5);
var rectangle = Object.create(Shapes.Rectangle).init(new Coords(6, 3), "#0ff", 20, 40);
var triangle = Object.create(Shapes.Triangle).init(new Coords(2, 4.5), "#05f", new Coords(-6, 7.3), new Coords(9.23, 5.449));
var line = Object.create(Shapes.Line).init(new Coords(5.7, 3.14), "#f0f", new Coords(2.23, -3.14));
var segment = Object.create(Shapes.Segment).init(new Coords(3.56, 1.23), "#00f", new Coords(9.87, -4.56));

console.log(circle.toString() + "\n");
console.log(rectangle.toString() + "\n");
console.log(triangle.toString() + "\n");
console.log(line.toString() + "\n");
console.log(segment.toString() + "\n");