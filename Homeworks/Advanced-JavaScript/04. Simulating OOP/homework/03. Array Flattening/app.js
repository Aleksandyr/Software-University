Array.prototype.flatten = function() {
    var flattenedArray = [];

    flat(this);

    function flat(array) {
        for (var i = 0; i < array.length; i++) {
            if (Array.isArray(array[i])) {
                flat(array[i]);
            } else {
                flattenedArray.push(array[i]);
            }
        }
    }

    return flattenedArray;
}

var array = [1, 2, 3, 4];
console.log(array.flatten());

var array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed

var array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());