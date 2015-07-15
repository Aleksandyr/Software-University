'use strict'

   var persons = [
        {
            'name' : 'Пешо',
            'score' : 91
        },
        {
            'name' : 'Лилия',
            'score' : 290
        },
        {
            'name' : 'Алекс',
            'score' : 343
        },
        {
            'name' : 'Габриела',
            'score' : 400
        },
        {
            'name' : 'Жичка',
            'score' : 70
        }
    ]

    persons.map(function(p){
        p.score = Math.round((p.score * 1.1) * 10) / 10;
        if(p.score >= 100){
            p.hasPassed = true;
        } else{
            p.hasPassed = false;
        }
    });

    persons.sort(function(x, y){
        return x.name > y.name;
    });

    persons.forEach(function(p){
        if(p.hasPassed == true){
            console.log(p);
        }
    });





