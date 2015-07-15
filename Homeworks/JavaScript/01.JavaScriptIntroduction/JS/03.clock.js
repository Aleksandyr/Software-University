var currentTime = new Date();

if(currentTime.getHours() < 10){
    document.getElementById("currTime").innerHTML = "0" + currentTime.getHours() + ":" + currentTime.getMinutes() + ":" + currentTime.getSeconds();
} else if(currentTime.getMinutes() < 10){
    document.getElementById("currTime").innerHTML = currentTime.getHours() + ":0" + currentTime.getMinutes() + ":" + currentTime.getSeconds();
} else if(currentTime.getSeconds() < 10){
    document.getElementById("currTime").innerHTML = currentTime.getHours() + ":" + currentTime.getMinutes() + ":0" + currentTime.getSeconds();
} else{
    document.getElementById("currTime").innerHTML = currentTime.getHours() + ":" + currentTime.getMinutes() + ":" + currentTime.getSeconds();
}