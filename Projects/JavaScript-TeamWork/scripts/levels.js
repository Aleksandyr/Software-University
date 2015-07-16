function levelSelect(playerLevel){
    if(playerLevel === 0){
        return createEnemies(1,1,100,85);
    }
    else if(playerLevel === 1){
        return createEnemies(6,1,100,85);
    }
    else if(playerLevel === 2){
        return createEnemies(4,2,100,85);
    }
    else if(playerLevel === 3){
        return createEnemies(6,2,100,85);
    }
    else if(playerLevel === 4){
        return createEnemies(6,3,100,85);
    }
    else if(playerLevel > 4){
        return createEnemies(6,3,100,85);
    }
}