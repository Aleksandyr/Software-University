<?php

require_once('includes/config.php');

$requestParts = explode('/', parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH));

//Get default controller
$controllerName = DEFAULT_CONTROLLER;
//Get current controller name
if(count($requestParts) >= 2 && $requestParts[1] != ''){
    $controllerName = $requestParts[1];
}

//Get default action
$action = DEFAULT_ACTION;
//Get current action
if(count($requestParts) >= 3 && $requestParts[2] != ''){
    $action = $requestParts[2];
}

//Get params from URL
$params = array_splice($requestParts, 3);


//First letter of controller is uppercase
$controllerClassName = ucfirst(strtolower($controllerName)) . 'Controller';
$controllerFileName = "controllers/" . $controllerClassName . '.php';

//if controller exist create instance of controller
if(class_exists($controllerClassName)){
    $controller = new $controllerClassName($controllerName, $action);
} else{
    die("Cannot find controller '$controllerName' in class '$controllerFileName'");
}

//if action exist in current controller perform it
if(method_exists($controller, $action)){
    //$controller->{$action}($params);
    call_user_func_array(array($controller, $action), $params);
    $controller->renderView();
} else{
    die("Cannot find action '$action' in controller '$controllerClassName'");
}

//Render view
$controller->renderView();

//Autoload method for controllers and methods
function __autoload($class_name){
    if(file_exists("controllers/$class_name.php")){
        include "controllers/$class_name.php";
    }
    if(file_exists("models/$class_name.php")){
        include "models/$class_name.php";
    }
}