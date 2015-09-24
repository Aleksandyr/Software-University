<?php
/**
 * Created by PhpStorm.
 * User: Alexander
 * Date: 9/23/2015
 * Time: 19:33
 */

namespace Core;


class User
{
    private $id;
    private $user;
    private $pass;
    private $gold;
    private $food;

    const GOLD_DEFAULT = 1500;
    const FOOD_DEFAULT = 1500;

    public function __construct($user, $pass, $id = null, $gold = null, $food = null){
        $this->setId($id);
        $this->setUsername($user);
        $this->setPass($pass);
        $this->setGold($gold);
        $this->setFood($food);
    }

    public function getId(){
        return $this->id;
    }

    public function setId($id){
        return $this->id = $id;
        return $this;
    }

    public function getUsername(){
        return $this->user;
    }

    public function setUsername($user){
        return $this->user = $user;
        return $this;
    }

    public function getPass(){
    return $this->pass;
}

    public function setPass($pass){
        $this->pass = $pass;
        return $this;
    }

    public function getGold(){
        return $this->gold;
    }

    public function setGold($gold){
        $this->gold = $gold;
        return $this;
    }

    public function getFood(){
        return $this->food;
    }

    public function setFood($food){
        $this->food = $food;
        return $this;
    }
}