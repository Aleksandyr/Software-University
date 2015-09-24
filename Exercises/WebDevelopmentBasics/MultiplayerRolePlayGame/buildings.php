<?php

require_once 'index.php';

if(!$app->isLogged()){
    header('Location: login.php');
}

$buildings = $app->createBuildings();
loadTemplate('buildings', $buildings);