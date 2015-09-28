<?php
namespace SoftUni\Core\Drivers;

class MySQLDriver extends DriverAbstract
{
    /**
     * @return string
     */
    public function getDsn()
    {
        $dsn = "mysql:host=" . $this->host . ";dbname=" . $this->dbName;

        return $dsn;
    }
}