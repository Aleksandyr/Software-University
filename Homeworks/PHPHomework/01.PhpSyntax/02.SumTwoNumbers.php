<?php
function sumTwoNums($fNum, $sNum){
    $sum = $fNum + $sNum;
    return '$firstNumber + $secondNumber = ' . " {$fNum} + {$sNum} = " . number_format($sum, 2, '.', '') . "\n\r";

}

echo sumTwoNums(2, 5);
echo sumTwoNums(1.567808, 0.356);
echo sumTwoNums(1234.5678, 333);
?>