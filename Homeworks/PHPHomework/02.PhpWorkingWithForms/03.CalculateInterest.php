<!DOCTYPE html>
<?php


?>
<html xmlns="http://www.w3.org/1999/html">
<head>
    <meta charset="utf-8"/>
    <title>Calculate interest</title>
</head>
<body>
<form action="" method="get">
    <label>Enter Amount</label>
    <input type="number" name="amount" required="true"/><br />
    <input type="radio" name="currency" value="USD" id="USD"/>
    <label for="USD">USD</label>
    <input type="radio" name="currency" value="EUR" id="EUR"/>
    <label for="EUR">EUR</label>
    <input type="radio" name="currency" value="BGN" id="BGN"/>
    <label for="BGN">BGN</label><br />
    <label>Compound Interest Amount</label>
    <input type="number" name="interest-amount" required="true"/><br />
    <select name="period-of-time" >
        <option value="6-months">6 Months</option>
        <option value="1-year">1 Year</option>
        <option value="2-years">2 Years</option>
        <option value="5-years">5 Years</option>
    </select>
    <input type="submit" value="calculate" />
    <span>
    <?php
    if(isset($_GET['amount'], $_GET['interest-amount'])) {
        $percentPerMonth = ($_GET['interest-amount'] / 12) / 100;
        $periodOfTime = explode('-', $_GET['period-of-time']);
        $amount = $_GET['amount'];
        if (strpos($periodOfTime[1], 'month') === false) {
            $periodOfTime[0] *= 12;
        }
        $sum = 0;
        for ($i = 0; $i < $periodOfTime[0]; $i++) {
            $amount += $amount * $percentPerMonth;
        }

        if(isset($_GET['currency'])){
            $currency = $_GET['currency'];
            if($currency === 'USD'){
                echo "$" . round($amount, 2);
            } elseif($currency === 'EUR') {
                echo "€" . round($amount, 2);
            } else{
                echo round($amount, 2) . 'лв';
            }
        } else{
            echo 'Chose currency!';
        }
    }
    ?>
    </span>
</form>
</body>
</html>