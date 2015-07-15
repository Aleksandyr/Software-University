<?php
$now = new DateTime();
$start = new DateTime($now->format('m/01/Y'));
$end = new DateTime($now->format('m/t/Y'));
$interval = new DateInterval('P1D');
$period = new DatePeriod($start, $interval, $end);
$check = $start->format('w');

foreach($period as $date){
    if($date->format('w') == 0){
        echo $date->format('jS F, Y');
        echo "<br>";
    }
}
?>