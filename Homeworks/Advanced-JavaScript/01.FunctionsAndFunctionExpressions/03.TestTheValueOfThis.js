'use strict';

function testContext(){
    console.log(this);
}

testContext();

(function(){
    testContext();
})();

new testContext();