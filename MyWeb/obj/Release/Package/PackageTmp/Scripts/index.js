
$(function () {
    //$("#select").attr("class", "active");
    $.ajaxSetup({ cache: false });
    var topid = 1;
    var likeid = 1;
    $.getJSON("/Home/List/", null, function (jsonData) {
        if (jsonData.Statu == "ok") {
            $.each(jsonData.Data.PagedData, function (idx, item) {
                $("#ulike").append("<li><span style=' background-color:#337AB7;' class='badge'>" + likeid + "</span>&nbsp;<span><a href='/articles/content/" + item.id + "'>" + item.Title + "</a></span></li></br>");
                likeid += 1;
                switch (idx) {
                    case 0:
                        $("#img1").attr("src", item.CoverImage);
                        $("#imgtitle1").append(item.Title);
                        break;
                    case 1:
                        $("#img2").attr("src", item.CoverImage);
                        $("#imgtitle2").append(item.Title);
                        break;
                    case 2:
                        $("#img3").attr("src", item.CoverImage);
                        $("#imgtitle3").append(item.Title);
                        break;
                }
            });
        }
    });
    //window.onload = function () {
    $.get("/Articles/Top/", null, function (back) {
        if (back.Statu == "ok") {
            $.each(back.Data.PagedData, function (idx, item) {
                //alert(idx);
                $("#topten").append("<li><span style=' background-color:#337AB7;' class='badge'>" + topid + "</span>&nbsp;<span><a href='/articles/content/" + item.id + "'>" + item.Title + "</a></span></li></br>");
                //$("#topten").append("</br>")
                topid += 1;
            });
        }
    });


});
window._bd_share_config = {
    "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "16" }, "share": {}
}; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];
window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "32" }, "share": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];

//回到顶部
$(function () {
    //当滚动条的位置处于距顶部100像素以下时，跳转链接出现，否则消失 
    $("#top").hide();
    $(window).scroll(function () {
        if ($(window).scrollTop() > 100) {
            $("#top").fadeIn(500);
        }
        else {
            $("#top").fadeOut(500);
        }
    });
    //当点击跳转链接后，回到页面顶部位置 
    $("#top").click(function () {
        $('body,html').animate({ scrollTop: 0 }, 100);
        return false;
    });
    //获取友链
    $.get("/Home/link/", null, function (back1) {
        if (back1.Statu == "ok") {
            $.each(back1.Data.PagedData, function (idx, item) {
                $("#link").append("<li><span><a href='" + item.LinkUrl + "'>" + item.LinkName + "</a>|</span></li>")
                //$("#topten").append("</br>")

            })
        }
    })

});