// Write your Javascript code.


$("img#phoneBook").click(function(){
    $.ajax({
        type: 'GET',
        url: '/Contacts/GetOurContacts',
        contentType: 'application/html; charset=utf-8',
        dataType: 'html'
    })
    .success(function(result){
        alert("I am here");
        $('#contactListDiv').html(result);
    })

});