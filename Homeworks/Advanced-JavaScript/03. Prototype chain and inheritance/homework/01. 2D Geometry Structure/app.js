Object.prototype.extends = function (parent) {
    if (!Object.create) {
        Object.prototype.create = function (proto) {
            function F() {};
            F.prototype = proto;
            return new F();
        };
    }
    
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

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
    var Shape = (function () {
        function Shape(pointA, color) {
            this._pointA = pointA;
            this._color = color;
        }
        
        Shape.prototype.toString = function () {
            return "my color is " + this._color + ", my point A has coords " + this._pointA.toString();
        };
        
        return Shape;
    }());
    
    var Circle = (function () {
        function Circle(pointO, color, radius) {
            Shape.call(this, pointO, color);
            this._radius = radius;
        }
        
        Circle.extends(Shape);
        
        Circle.prototype.toString = function () {
            var parrentToString = Shape.prototype.toString.call(this);
            return "I'm circle, " + parrentToString + " and my radius is " + this._radius + ".";
        };
        
        return Circle;
    }());
    
    var Rectangle = (function () {
        function Rectangle(pointA, color, width, height) {
            Shape.call(this, pointA, color);
            this._width = width;
            this._height = height;
        }
        
        Rectangle.extends(Shape);
        
        Rectangle.prototype.toString = function () {
            var parrentToString = Shape.prototype.toString.call(this);
            return "I'm rectangle, " + parrentToString + ", my width is " + this._width + " and my height is " + this._height + ".";
        };
        
        return Rectangle;
    }());
    
    var Triangle = (function () {
        function Triangle(pointA, color, pointB, pointC) {
            Shape.call(this, pointA, color);
            this._pointB = pointB;
            this._pointC = pointC;
        }
        
        Triangle.extends(Shape);
        
        Triangle.prototype.toString = function () {
            var parrentToString = Shape.prototype.toString.call(this);
            return "I'm triangle, " + parrentToString + ", my point B has coords " + this._pointB.toString() + " and my point C has coords " + this._pointC.toString() + ".";
        };
        
        return Triangle;
    }());
    
    var Line = (function () {
        function Line(pointA, color, pointB) {
            Shape.call(this, pointA, color);
            this._pointB = pointB;
        }
        
        Line.extends(Shape);
        
        Line.prototype.toString = function () {
            var parrentToString = Shape.prototype.toString.call(this);
            return "I'm line, " + parrentToString + ", my point B has coords " + this._pointB.toString() + ".";
        };
        
        return Line;
    }());
    
    var Segment = (function () {
        function Segment(pointA, color, pointB) {
            Shape.call(this, pointA, color);
            this._pointB = pointB;
        }
        
        Segment.extends(Shape);
        
        Segment.prototype.toString = function () {
            var parrentToString = Shape.prototype.toString.call(this);
            return "I'm segment, " + parrentToString + ", my point B has coords " + this._pointB.toString() + ".";
        };
        
        return Segment;
    }());

    return {
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle,
        Line: Line,
        Segment: Segment
    };
})();

var circle = new Shapes.Circle(new Coords(5, 10), "#f00", 5);
var rectangle = new Shapes.Rectangle(new Coords(6, 3), "#0ff", 20, 40);
var triangle = new Shapes.Triangle(new Coords(2, 4.5), "#05f", new Coords(-6, 7.3), new Coords(9.23, 5.449));
var line = new Shapes.Line(new Coords(5.7, 3.14), "#f0f", new Coords(2.23, -3.14));
var segment = new Shapes.Segment(new Coords(3.56, 1.23), "#00f", new Coords(9.87, -4.56));

console.log(circle.toString() + "\n");
console.log(rectangle.toString() + "\n");
console.log(triangle.toString() + "\n");
console.log(line.toString() + "\n");
console.log(segment.toString() + "\n");