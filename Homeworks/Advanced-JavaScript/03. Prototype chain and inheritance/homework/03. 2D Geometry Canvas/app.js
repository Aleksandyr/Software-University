/* // Invalid statements
 * new Coords(-200, 170);
 * new Coords(200, -170);
 * new Coords()
 * new Coords(-200, 170);
 * new Coords(200, -170);
 * new Coords();
 * new Coords(200);
 * new Coords(-200);
 * new Coords(200, null);
 * new Coords(200, "");
 */

var circle = Object.create(Shapes.Circle).init(new Coords(200, 170), "#f00", 50);
/* Invalid statements
 * 
 * // Invalid coords
 * var circle = Object.create(Shapes.Circle).init(5, "#f00", 50);
 * var circle = Object.create(Shapes.Circle).init(null, "#f00", 50);
 * var circle = Object.create(Shapes.Circle).init("", "#f00", 50);
 * 
 * // Invalid color
 * var circle = Object.create(Shapes.Circle).init(new Coords(200, 170), "#ff00", 50);
 * var circle = Object.create(Shapes.Circle).init(new Coords(200, 170), "#ff00ss", 50);
 * var circle = Object.create(Shapes.Circle).init(new Coords(200, 170), "", 50);
 * var circle = Object.create(Shapes.Circle).init(new Coords(200, 170), "green", 50);
 * 
 * // Invalid radius
 * var circle = Object.create(Shapes.Circle).init(new Coords(200, 170), "#ff0", 0);
 * var circle = Object.create(Shapes.Circle).init(new Coords(200, 170), "#ff0", -5);
 * var circle = Object.create(Shapes.Circle).init(new Coords(200, 170), "#ff0");
 * var circle = Object.create(Shapes.Circle).init(new Coords(200, 170), "#ff0", null);
 * var circle = Object.create(Shapes.Circle).init(new Coords(200, 170), "#ff0", "");
 */

var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", 133, 66);
/* Invalid statements
 * 
 * // Invalid width
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff");
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", 200);
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", -200);
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", null);
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", "");
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", 0);
 * 
 * // Invalid height
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", 200);
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", 200, 0);
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", 200, -200);
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", 200, null);
 * var rectangle = Object.create(Shapes.Rectangle).init(new Coords(80, 30), "#0ff", 200, "");
 */

var triangle = Object.create(Shapes.Triangle).init(new Coords(275, 350), "#05f", new Coords(400, 275), new Coords(400, 425));
/* Invalid statements
 * 
 * // Invalid coords
 * var triangle = Object.create(Shapes.Triangle).init(new Coords(275, 350), "#05f");
 * var triangle = Object.create(Shapes.Triangle).init(new Coords(275, 350), "#05f", new Coords(400, 275));
 * var triangle = Object.create(Shapes.Triangle).init(new Coords(275, 350), "#05f", new Coords(null, 275), new Coords(400, 425));
 * var triangle = Object.create(Shapes.Triangle).init(new Coords(275, 350), "#05f", new Coords(400, 275), new Coords(null, 425));
 */

var line = Object.create(Shapes.Line).init(new Coords(120, 350), "#f0f", new Coords(460, 123));
/* Invalid statements
 * 
 * // Invalid coords
 * var line = Object.create(Shapes.Line).init(new Coords(120, 350), "#f0f");
 * var line = Object.create(Shapes.Line).init(new Coords(120, 350), "#f0f", new Coords(460, null));
 */

var segment = Object.create(Shapes.Segment).init(new Coords(100, 200), "#00f", new Coords(250, 400));
/* Invalid statements
 * 
 * // Invalid coords
 * var segment = Object.create(Shapes.Segment).init(new Coords(100, 200), "#00f");
 * var segment = Object.create(Shapes.Segment).init(new Coords(100, 200), "#00f", new Coords(250, null));
 */

console.log(circle.toString() + "\n");
console.log(rectangle.toString() + "\n");
console.log(triangle.toString() + "\n");
console.log(line.toString() + "\n");
console.log(segment.toString() + "\n");

circle.draw();
rectangle.draw();
triangle.draw();
line.draw();
segment.draw();