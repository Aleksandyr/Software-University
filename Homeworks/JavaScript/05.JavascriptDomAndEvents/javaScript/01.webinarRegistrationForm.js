'use strict';

function showInvoiceForm(){
    var check = document.getElementById('checkbox');
    var visibOrInvisibForm = document.getElementById('form-invoice');
    if(check.checked){
        visibOrInvisibForm.style.visibility = 'visible';
    } else{
        visibOrInvisibForm.style.visibility = 'hidden';
    }
}