<?php

abstract class BaseController
{
    protected $actionName;
    protected $controllerName;
    protected $layoutName = DEFAULT_LAYOUT;
    protected $isViewRendered = false;
    protected $isPost = false;

    function __construct($controllerName, $actionName)
    {
        $this->actionName = $actionName;
        $this->controllerName = $controllerName;
        if ($_SERVER['REQUEST_METHOD'] === 'POST') {
            $this->isPost = true;
        }
        $this->onInit();
    }

    public function onInit()
    {
        //Implement initializing logic in the subclasses
    }

    public function index()
    {
        //Implement the dafault action in the subclasses
    }

    //to show views for current controller
    public function renderView($viewName = null, $includeLayout = true)
    {
        if (!$this->isViewRendered) {
            if ($viewName == null) {
                $viewName = $this->actionName;
            }
            $viewFileName = 'views/' . $this->controllerName . '/' . $viewName . '.php';
            if ($includeLayout) {
                $headerFile = 'views/layouts/' . $this->layoutName . '/header.php';
                include_once($headerFile);
            }

            include_once($viewFileName);

            if ($includeLayout) {
                $footerFile = 'views/layouts/' . $this->layoutName . '/footer.php';
                include_once($footerFile);
            }
            $this->isViewRendered = true;
        }
    }

    public function redirectToUrl($url){
        header("Location: ". $url);
        die;
    }

    public function redirect($controllerName, $actionName = null, $params = null){
        $url = '/' . urlencode($controllerName);
        if($actionName != null){
            $url .= '/' . $actionName;
        }
        if($params != null){
            $encodedParams = array_map($params, 'urlencode');
            $url .= implode('/', $encodedParams);
        }

        $this->redirectToUrl($url);
    }
}