<?php

require_once 'index.php';

if(isset($_POST['username'], $_POST['password'])){
    try{
        $user = $_POST['username'];
        $password = $_POST['password'];
        $app->login($user, $password);
    } catch(Exception $e){
        echo $e->getMessage();
    }
}

loadTemplate('login');