<?php
namespace SoftUni\Controllers;

use SoftUni\Models\Users;
use SoftUni\View;
use SoftUni\ViewModels\LoginInformation;
use SoftUni\ViewModels\RegisterInformation;

class UsersController extends BaseController{
    public function register(){

        if($this->isUserLoged()){
            header("Location: profile");
            exit;
        }

        $viewModel = new RegisterInformation();

        if(isset($_POST['username'], $_POST['password'])){
            try{
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $userModel = new Users();
                $userModel->register($user, $pass);

                $this->initLogin($user, $pass);
            } catch(\Exception $e){
                $viewModel->error = $e->getMessage();
                return new View($viewModel);
            }
        }

        return new View();
    }

    public function login(){

        if($this->isUserLoged()){
            header("Location: profile");
            exit;
        }

        $viewModel = new LoginInformation();

        if(isset($_POST['username'], $_POST['password'])){
            try{
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $this->initLogin($user, $pass);
            } catch(\Exception $e){
                $viewModel->error = $e->getMessage();
                return new View($viewModel);
            }
        }

        return new View($viewModel);
    }

    private function initLogin($user, $pass){
        $userModel = new Users();

        $userId = $userModel->login($user, $pass);
        $_SESSION['user_id'] = $userId;
        header("Location: profile");
    }
}