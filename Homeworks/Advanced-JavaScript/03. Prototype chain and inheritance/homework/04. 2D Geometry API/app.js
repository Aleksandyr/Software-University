var shapes = [];

document.getElementById("shapeType").onchange = function () {
    var shapeType = this.value;
    changeForm(shapeType);
}

document.getElementById("remove").onclick = function (form) {
    var consoleItems = document.getElementById("console");
    var shape = consoleItems.options[consoleItems.selectedIndex];
    
    if (shape) {
        var shapeId = shape.value;
        removeShapeFromConsole(shapeId);
        redrawCanvas();
    }

    form.preventDefault();
}

document.getElementById("up").onclick = function (form) {
    var consoleItems = document.getElementById("console");

    var shape = consoleItems.options[consoleItems.selectedIndex];
    var previousShape = consoleItems.options[consoleItems.selectedIndex - 1];

    if (shape && previousShape) {
        swapHTMLElements(shape, previousShape);
        
        var temp = shapes[shape.value];
        shapes[shape.value] = shapes[previousShape.value];
        shapes[previousShape.value] = temp;

        redrawCanvas();
    }
    
    form.preventDefault();
}

document.getElementById("down").onclick = function (form) {
    var consoleItems = document.getElementById("console");
    
    var shape = consoleItems.options[consoleItems.selectedIndex];
    var nextShape = consoleItems.options[consoleItems.selectedIndex + 1];
    
    if (shape && nextShape) {
        swapHTMLElements(shape, nextShape);
        
        var temp = shapes[shape.value];
        shapes[shape.value] = shapes[nextShape.value];
        shapes[nextShape.value] = temp;
        
        redrawCanvas();
    }
    
    form.preventDefault();
}

document.getElementById("geometry-api").onsubmit = function (form) {
    var shape;
    var shapeType = this.elements['shapeType'].value;
    
    var aX = getNumberValueOfElement("pointAX");
    var aY = getNumberValueOfElement("pointAY");
    var color = document.getElementById("color").value;

    try {
        switch (shapeType) {
            case "circle":
                var radius = getNumberValueOfElement("radius");

                shape = Object.create(Shapes.Circle).init(new Coords(aX, aY), color, radius);

                break;
            case "rectangle":
                var width = getNumberValueOfElement("width");
                var height = getNumberValueOfElement("height");
                
                shape = Object.create(Shapes.Rectangle).init(new Coords(aX, aY), color, width, height);

                break;
            case "triangle":
                var bX = getNumberValueOfElement("pointBX");
                var bY = getNumberValueOfElement("pointBY");
                var cX = getNumberValueOfElement("pointCX");
                var cY = getNumberValueOfElement("pointCY");
                
                shape = Object.create(Shapes.Triangle).init(new Coords(aX, aY), color, new Coords(bX, bY), new Coords(cX, cY));
                
                break;
            case "line":
                var bX = getNumberValueOfElement("pointBX");
                var bY = getNumberValueOfElement("pointBY");
                
                shape = Object.create(Shapes.Line).init(new Coords(aX, aY), color, new Coords(bX, bY));
                
                break;
            case "segment":
                var bX = getNumberValueOfElement("pointBX");
                var bY = getNumberValueOfElement("pointBY");
                
                shape = Object.create(Shapes.Segment).init(new Coords(aX, aY), color, new Coords(bX, bY));
                
                break;
            default:
                throw "Invalid shape!";
        }

        shapes.unshift(shape);
        shape.draw();

        addShapeToConsole(shape);

        document.getElementById("geometry-api").reset();
        changeForm("circle");
    }
    catch (exc) {
        console.log(exc);
        alert(exc);
    }

    form.preventDefault();
}

var changeForm = function (shapeType) {
    document.getElementById("radius-").style.display = "none";
    document.getElementById("width-height").style.display = "none";
    document.getElementById("x2-y2").style.display = "none";
    document.getElementById("x3-y3").style.display = "none";
    
    switch (shapeType) {
        case "circle":
            document.getElementById("radius-").style.display = "block";
            
            break;
        case "rectangle":
            document.getElementById("width-height").style.display = "block";
            
            break;
        case "triangle":
            document.getElementById("x2-y2").style.display = "block";
            document.getElementById("x3-y3").style.display = "block";
            
            break;
        case "line":
            document.getElementById("x2-y2").style.display = "block";
            
            break;
        case "segment":
            document.getElementById("x2-y2").style.display = "block";
            
            break;
        default:
            break;
    }
}

var getNumberValueOfElement = function (element) {
    return parseFloat(document.getElementById(element).value);
}

var addShapeToConsole = function (shape) {
    var newShape = document.createElement("option");
    newShape.setAttribute("value", shapes.length - 1);
    newShape.setAttribute("id", shapes.length - 1);
    var shapeMessage = document.createTextNode(shape.toString());
    newShape.appendChild(shapeMessage);
    
    document.getElementById("console").insertBefore(newShape, document.getElementById("console").firstChild);
}

var removeShapeFromConsole = function (shapeId) {
    shapes[shapeId] = null;

    var shapeElement = document.getElementById(shapeId);
    document.getElementById("console").removeChild(shapeElement);
}

var redrawCanvas = function() {
    context.clearRect(0, 0, canvas.width, canvas.height);

    shapes.reverse();

    for (var i = 0; i < shapes.length; i++) {
        if (shapes[i] != null) {
            shapes[i].draw();
        }
    }
    shapes.reverse();
}

function swapHTMLElements(obj1, obj2) {
    var tempId = obj1.id;
    obj1.id = obj2.id;
    obj1.value = obj2.value;
    obj2.id = tempId;
    obj2.value = tempId;

    var temp = document.createElement("div");
    obj1.parentNode.insertBefore(temp, obj1);
    
    obj2.parentNode.insertBefore(obj1, obj2);
    
    temp.parentNode.insertBefore(obj2, temp);
    
    temp.parentNode.removeChild(temp);
}