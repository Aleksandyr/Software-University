<?php
function printType($variable){
    if(is_numeric($variable)){
        var_dump($variable);
    } else{
        echo gettype($variable) . "\n\r";
    }
}

printType("hello");
printType(15);
printType(1.234);
printType(array(1,2,3));
printType((object)[2,34]);
?>