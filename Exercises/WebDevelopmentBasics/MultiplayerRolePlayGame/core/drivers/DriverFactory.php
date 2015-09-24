<?php
namespace Core\Drivers;

class DriverFactory
{
    public function create($driver, $user, $pass, $dbName, $host){
        if($driver == 'mysql'){
            $mysql_driver = new MySQLDriver($user, $pass, $dbName, $host);
            return $mysql_driver;
        }

        throw new \Exception('Driver not found!');
    }
}