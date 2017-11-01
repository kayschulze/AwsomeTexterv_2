
$("img#phoneBook").click(function(){
    $.ajax({
        type: 'GET',
        url: '/Contacts/GetOurContacts',
        contentType: 'application/html; charset=utf-8',
        dataType: 'html'
    })
    .success(function(result){
        $('#contactListDiv').html(result);
    })

});

$("body").on("click", "li", function () {
    var phoneNumber = $("#phoneNumber").text().trim();
    if ($("input#To").val() === "") {
        $("input#To").val(phoneNumber);
    } else {
        $("input#To").val($("input#To").val() + ", " + phoneNumber);
    }
});

//$("#btnSend").click(function (event) {
//    event.preventDefault();
//    var phoneNumbers = $('input#To').val();
//    $.ajax({
//        type: 'POST',
//        url: '@Url.Action("SendMessage")',
//        dataType: 'json',
//        data: $(this).serialize()

//    })
//        .success(function (resulst) {

//        })
//});