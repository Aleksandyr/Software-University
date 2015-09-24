<?php

namespace Core;

class Database
{
    private $db;
    private static $inst = [];

    private function __construct($pdo_instance) {
        $this->db = $pdo_instance;
    }

    public static function getInstance($instanceName = 'default') {
        if(!isset(self::$inst[$instanceName])) {
            throw new \Exception('Instance with that name is not set.');
        }

        return self::$inst[$instanceName];
    }

    public function getConnection() {
        return $this->db;
    }

    public static function setInstance(
        $instanceName,
        $driver,
        $user,
        $pass,
        $dbName,
        $host = null
    ){
        $driver = Drivers\DriverFactory::create($driver, $user, $pass, $dbName, $host);

        $pdo = new \PDO(
            $driver->getDsn(),
            $user,
            $pass
        );

        self::$inst[$instanceName] = new self($pdo);
    }

    public function prepare($statement, array $driverOptions = []){
        $statement = $this->db->prepare($statement, $driverOptions);

        return new Statement($statement);
    }

    public function query($query){
        $this->db->query($query);
    }

    public function lastId($name = null){
        return $this->db->lastInsertId($name);
    }
}