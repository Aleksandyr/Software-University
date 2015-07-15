function calcCircleArea(r){
    return Math.PI * (r * r);
}

document.getElementById("first-area").innerHTML = calcCircleArea(7);
document.getElementById("second-area").innerHTML = calcCircleArea(1.5);
document.getElementById("third-area").innerHTML = calcCircleArea(20);


