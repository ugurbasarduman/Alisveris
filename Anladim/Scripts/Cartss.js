$(function () {
    $(".adtocart").on("click", function () {
        var pid = $(this).attr("data-pId");
        $.post("/Cart/AddProduct?id=" + pid + "&quantity=1", function () {
            alert("sepete eklendi");
        });
    });
    $(".ddd").on("click", function () {

        var $button = $(this);
        var oldValue = $button.closest('.sp-quantity').find("input.quntity-input").val();

        if ($button.text() == "+") {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            // Don't allow decrementing below zero
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }
        }
        var dal = $button.closest('.sp-quantity').find("input.quntity-input").val(newVal);
    });

});
