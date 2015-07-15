<?php
function nonRepeatingDigit($n){
    $isHaveNums = false;
    for($i = 0; $i <= $n; $i++){
        if($i >= 100 && $i < 1000){
            $thirdDigit = $i % 10;
            $secondDigit = ($i / 10) % 10;
            $firstDigit = ($i / 100) % 10;
            if($firstDigit != $secondDigit && $firstDigit != $thirdDigit && $secondDigit != $thirdDigit){
                $isHaveNums = true;
                echo $i . ", ";
            }
        }
    }
    if(!$isHaveNums){
        echo "no";
    }
    echo "<br/>";

}
nonRepeatingDigit(1234);
nonRepeatingDigit(145);
nonRepeatingDigit(15);
nonRepeatingDigit(247);
?>