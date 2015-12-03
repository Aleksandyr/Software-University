function StopWatch() {

    var isPaused = false;
    var minutes = addLeadingZeros(2, 0);
    var seconds = addLeadingZeros(2, 0);
    var miliSeconds = addLeadingZeros(4, 0);
    var date = null;
    var inputMin;
    var inputSec;
    var inputMSec;
    var interval = null;

    function init(){
        return{
            initHtml: initHtml,
            start: start,
            stop: stop,
            reset: reset,
            remove: remove
        }
    }

    function initHtml(){
        this._div = document.createElement('div');
        this._div.addEventListener('click', handler.bind(this));

        inputMin = document.createElement('input');
        inputMin.setAttribute('type', 'number');
        inputMin.setAttribute('value', minutes);

        this._div.appendChild(inputMin);

        inputSec = document.createElement('input');
        inputSec.setAttribute('type', 'number');
        inputSec.setAttribute('value', seconds);

        this._div.appendChild(inputSec);

        inputMSec = document.createElement('input');
        inputMSec.setAttribute('type', 'number');
        inputMSec.setAttribute('value', miliSeconds);

        this._div.appendChild(inputMSec);

        this._startButton = document.createElement('button');
        this._startButton.innerHTML = 'Start';

        this. _div.appendChild(this._startButton);

        this._stopButton = document.createElement('button');
        this._stopButton.innerHTML = 'Stop';

        this._div.appendChild(this._stopButton);

        this._removeButton = document.createElement('button');
        this._removeButton.innerHTML = 'Remove';

        this._div.appendChild(this._removeButton);

        this._resetButton = document.createElement('button');
        this._resetButton.innerHTML = 'Reset';

        this._div.appendChild(this._resetButton);

        this._pauseButton = document.createElement('button');
        this._pauseButton.innerHTML = 'Pause';

        this._div.appendChild(this._pauseButton);


        getElement('wrapper').appendChild(this._div);

        return this;
    }

    function getElement(id) {
        return document.getElementById(id);
    }

    function getValue(element) {
        return element.value;
    }

    function setValue(elem, value) {
        return elem.value = value;
    }

    function pause(){
        isPaused = !isPaused;

        return this;
    }

    function reset(){
        date = new Date();

        return this;
    }

    function start(){
        if(interval == null){

            date = new Date();
            interval = setInterval(showWatch, 1);

            return this;
        }

        return this;
    }

    function stop(){
        if(interval != null) {
            clearInterval(interval);
            interval = null;
            return this;
        }

        return this;
    }

    function remove(){
        clearInterval(interval);
        minutes = 0;
        seconds = 0;
        miliSeconds = 0;

        getElement('wrapper').removeChild(this._div);

        return this;
    }

    function reverseTimer(){

    }

    function showWatch(){
        var currentDate = new Date();

        minutes = Math.floor( currentDate / 1000 / 60 - date / 1000 / 60) % 60;
        seconds = Math.floor( currentDate / 1000 - date / 1000) % 60;
        miliSeconds = currentDate % 1000;

        if(!isPaused){
            setValue(inputMin, addLeadingZeros(2, minutes));
            setValue(inputSec, addLeadingZeros(2, seconds));
            setValue(inputMSec, addLeadingZeros(4, miliSeconds));
        }
    }

    function addLeadingZeros(length, val){
        var str = val + '';
        while(str.length < length){
            str = '0' + str;
        }

        return str;
    }

    function handler(e){
        if(e.target.innerText.toLocaleLowerCase() === 'start'){
            start();

            return true;
        }

        if(e.target.innerText.toLocaleLowerCase() === 'stop'){
            stop();

            return true;
        }

        if(e.target.innerText.toLocaleLowerCase() === 'remove'){
            this.remove();

            return true;
        }

        if(e.target.innerText.toLocaleLowerCase() === 'reset'){
            reset();

            return true;
        }

        if(e.target.innerText.toLocaleLowerCase() === 'pause'){
            pause();

            return true;
        }

        return false;
    }

    return init();
}

var stopWatch = new StopWatch();
stopWatch.initHtml();


