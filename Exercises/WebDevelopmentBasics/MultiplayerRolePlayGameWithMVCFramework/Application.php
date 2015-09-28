<?php
namespace SoftUni;

class Application{
    private $controllerName;
    private $actionName;
    private $requestParams = [];

    private $controller;

    const CONTROLLWES_NAMESPACE = 'SoftUni\\Controllers\\';
    const CONTROLLERS_SUFFIX = 'Controller';

    public function __construct($controllerName, $actionName, $requestParams = []){
        $this->controllerName = $controllerName;
        $this->actionName = $actionName;
        $this->requestParams = $requestParams;
    }

    public function start(){
        $this->initController();

        View::$controllerName = $this->controllerName;
        View::$actionName = $this->actionName;

        call_user_func_array(
            [
                $this->controller,
                $this->actionName
            ],
            $this->requestParams
        );
    }

    private function initController(){
        $controllerName =
            self::CONTROLLWES_NAMESPACE
            . $this->controllerName
            . self::CONTROLLERS_SUFFIX;

        $this->controller = new $controllerName();
    }
}