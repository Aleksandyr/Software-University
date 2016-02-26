'use strict';

(function(){
    var index = 1;
    var intervalInMilliseconds = 5000;

    $(function(){
        $('#button-left').on('click', previousSlide);
        $('#button-right').on('click', nextSlide);
        nextSlide();

        setInterval(function(){
            $('#button-right').trigger('click');
        }, intervalInMilliseconds)
    });

    function previousSlide(){
        slide('previous');
    }

    function nextSlide(){
        slide('next');
    }

    function slide(position){
        $('#images-container').children().hide();
        $('#image' + index).fadeIn(1000);

        if(position == "next"){
            index++;

            if(index == 4){
                index = 1;
            }
        } else if(position == "previous"){
            index--;

            if(index == 0){
                index = 3;
            }
        }
    }
}());