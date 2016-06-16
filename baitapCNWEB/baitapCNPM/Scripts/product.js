$(function () {
    $("#kind").change(function () {
        getProducts(1);
    })
    $("#order").change(function () {
        getProducts(1);
    })
    $("#range").change(function () {
        getProducts(1);
    })
    function pages(total, active) {
        var text = '<ul class="pagination" style="display:block" >';
        for (i = 1; i <= total; i++) {
            if (i == active) {
                text += '<li class="active"><a>' + i + '</a></li>';
            }
            else text += '<li><a>' + i + '</a></li>';
        }
        text += '</ul>';
        return text;
    }
    function getProducts(pagenumber) {
        var cat = $("#kind").children("option:selected").attr("data-id");
        var order = $("#order").children("option:selected").index();
        var price = $("#range").children("option:selected").attr("data-id");
        $.ajax({
            url: "/Product/ViewProduct",
            type: "get",
            data: { cat: cat, page: pagenumber, order: order, price: price },
            beforeSend: function () {
                $("#replace").text("Products are loading...");
            },
            success: function (data) {
                $("#replace").html(data);
                $("#pagination").html(pages($("#pages").attr("data-id"), pagenumber));
                $(".pagination>li>a").on("click", function () {
                    var index = parseInt($(this).text());
                    getProducts(index);
                })
            }
        })
    }
    function fadeimage(arr, speed) {
        arr[0].style.opacity = "1";
        var x = 1;
        var temp = 0;
        setInterval(function () {
            arr[x].style.opacity = "1";
            arr[temp].style.opacity = "0";
            temp = x;
            x++;
            if (x == arr.length) x = 0;
        }, speed);
    }
    $(window).load(function () {
        getProducts(1);
        var a1 = $('.moduleslide1 .slide_main_item');
        var a2 = $('.moduleslide2 .slide_main_item');
        var a3 = $('.moduleslide3 .slide_main_item');
        fadeimage(a1, 3000);
        fadeimage(a2, 4000);
        fadeimage(a3, 3500);
    })
})