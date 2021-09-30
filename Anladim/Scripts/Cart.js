$(document).ready(function () {
    //called when key is pressed in textbox
    $("#quantity").keypress(function (e) {
        //if the letter is not a digit, we will display the error message and dont allow them to type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            //we will display error message
            $("#errmsg").html("Sadece Sayý Gir!").show().fadeOut("slow");
            return false;
        }
    });
});
