<?php
namespace Core;


class Statement
{
    private $stmt;

    public function __construct($pdo_instance) {
        $this->stmt = $pdo_instance;
    }

    public function fetch($fetchStyle = \PDO::FETCH_ASSOC){
        return $this->stmt->fetch($fetchStyle);
    }

    public function fetchAll($fetchStyle = \PDO::FETCH_ASSOC){
        return $this->stmt->fetchAll($fetchStyle);
    }

    public function bindParam($parameter, $variable, $dataType = \PDO::PARAM_STR, $length){
        return $this->stmt->bindParam($parameter, $variable, $dataType, $length);
    }

    public function execute($input_params){
        return $this->stmt->execute($input_params);
    }

    public function rowCount(){
        return $this->stmt->rowCount();
    }
}