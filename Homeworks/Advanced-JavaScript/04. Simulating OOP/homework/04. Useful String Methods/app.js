String.prototype.startsWith = function (substring) {
    var stringCut = this.substring(0, substring.length);

    return stringCut === substring;
}

String.prototype.endsWith = function (substring) {
    var stringCut = this.substring(this.length - substring.length);

    return stringCut === substring;
}

String.prototype.left = function (count) {
    return this.substring(0, count);
}

String.prototype.right = function (count) {
    return this.substring(this.length - count);
}

String.prototype.padLeft = function (count, character) {
    if (typeof (character) === "undefined") {
        character = " ";
    }

    return this.length <= count ? Array(count + 1 - this.length).join(character) + this : this.toString();
}

String.prototype.padRight = function (count, character) {
    if (typeof (character) === "undefined") {
        character = " ";
    }

    return this.length <= count ? this + Array(count + 1 - this.length).join(character) : this.toString();
}

String.prototype.repeat = function (count) {
    return new Array(count + 1).join(this);
}

var example = "This is an example string used only for demonstration purposes.";
console.log(example.startsWith("This"));
console.log(example.startsWith("this"));
console.log(example.startsWith("other"));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.endsWith("poses."));
console.log(example.endsWith("example"));
console.log(example.startsWith("something else"));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.left(9));
console.log(example.left(90));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.right(9));
console.log(example.right(90));

// Combinations must also work
var example = "abcdefgh";
console.log(example.left(5).right(2));

var hello = "hello";
console.log(hello.padLeft(5));
console.log(hello.padLeft(10));
console.log(hello.padLeft(5, "."));
console.log(hello.padLeft(10, "."));
console.log(hello.padLeft(2, "."));

var hello = "hello";
console.log(hello.padRight(5));
console.log(hello.padRight(10));
console.log(hello.padRight(5, "."));
console.log(hello.padRight(10, "."));
console.log(hello.padRight(2, "."));

var character = "*";
console.log(character.repeat(5));

// Alternative syntax
console.log("~".repeat(3));

// Another combination
console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));
