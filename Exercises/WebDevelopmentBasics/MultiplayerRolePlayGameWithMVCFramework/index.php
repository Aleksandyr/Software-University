<?php

$uri = $_SERVER['REQUEST_URI'];
$self = $_SERVER['PHP_SELF'];
$index = basename($self);
$directories = str_replace($index, '', $self);
$requestStrung = str_replace($directories, '', $uri);
$requestParams = explode("/", $requestStrung);

$controller = array_shift($requestParams);
$action = array_shift($requestParams);

/*
require 'Controllers\UsersController.php';
$fullQualifiedController = '\\SoftUni\\Controllers\\' . ucfirst($controller) . 'Controller';
$controllerInstance = new $fullQualifiedController();
var_dump($controllerInstance);


 spl_autoload_register(function($class){
     $classPath = str_replace("\\", "/", $class);
     require_once $classPath . '.php';
 });
*/
session_start();

require_once 'Application.php';
require_once 'Autoloader.php';

$autoloader = new \SoftUni\Autoloader();
$autoloader->init();

\SoftUni\Core\Database::SetInstance(
    \SoftUni\Config\DatabaseConfig::DB_INSTANCE,
    \SoftUni\Config\DatabaseConfig::DB_DRIVER,
    \SoftUni\Config\DatabaseConfig::DB_USER,
    \SoftUni\Config\DatabaseConfig::DB_PASS,
    \SoftUni\Config\DatabaseConfig::DB_NAME,
    \SoftUni\Config\DatabaseConfig::DB_HOST
);

$app = new \SoftUni\Application($controller, $action, $requestParams);
$app->start();
