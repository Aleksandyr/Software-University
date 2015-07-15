<?php
$name = "Gosho";
$phoneNum = "0882-321-423";
$age = 24;
$addres = "Hadji Dimitar";
?>

<!DOCTYPE html>
<html>
<head>
    <title>Information Table</title>
</head>
<style>
    table tr td:first-child{
        background-color: orange;
    }
</style>
<body>
<table border="1" cellpadding="0" cellspacing="0">
    <tr>
        <td>Name</td>
        <td><?= $name ?></td>
    </tr>
    <tr>
        <td>Phone number</td>
        <td><?= $phoneNum ?></td>
    </tr>
    <tr>
        <td>Age</td>
        <td><?= $age ?></td>
    </tr>
    <tr>
        <td>Address</td>
        <td><?= $addres ?></td>
    </tr>
</table>
</body>
</html>