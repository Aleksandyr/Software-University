<?php
namespace Core;

class BuildingsRepository
{
    /**
     * @var Database
     */
    private $db;

    /**
     * @var User
     */
    private $user;

    public function getUser() {
        return $this->user;
    }

    public function getBuildings() {
        $result = $this->db->prepare("
            SELECT b.id, b.name, bl.level, bl.gold, bl.food
            FROM players_buildings ub
            LEFT JOIN buildings b ON b.id = ub.building_id
            LEFT JOIN levels bl ON bl.building_id = b.id AND bl.level = ub.level_id + 1
            WHERE user_id = ?");

        $user_id = $this->getUser()->getId();
        $result->execute([ $user_id ]);

        return $result->fetchAll();
    }

    public function evolve($buildingId){

    }

}
