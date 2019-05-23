function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

$.ajax({
    type: 'GET',
    headers: {
        "X-XSRF-TOKEN": getCookie("X-XSRF-TOKEN")
    },
    url: '/api/Users/',
}).done(function (res) {
    console.log(res);
    });
//debugger;
    //var _actionBegin = function (args) {
    //    console.log("_actionBegin: ");
    //    console.log(args);
    //    if (args.requestType == "save1") {
    //        if (args.action == "edit1") {
    //            data = args.rowData;
    //            $.ajax({
    //                type: 'PUT',
    //                url: '/api/Users/' + data.UserId,
    //                contentType: 'application/json',
    //                data: JSON.stringify(data),
    //            }).done(function (res) {
    //                console.log(res);
    //                //args.data = res.data;
    //            });
    //        } else if (args.action == "add") {
    //            data = args.data;
    //            $.ajax({
    //                type: 'POST',
    //                url: '/api/Users/',
    //                contentType: 'application/json',
    //                data: JSON.stringify(data),
    //            }).done(function (res) {
    //                console.log(res);
    //                //args.data = res.data;
    //            });
    //        }
    //    } else if (args.requestType == "delete1") {
    //        $.ajax({
    //            type: 'DELETE',
    //            url: '/api/Users/' + args.data.UserId,
    //        }).done(function (res) {
    //            console.log(res);
    //            //args.data = res.data;
    //        });
    //    }
    //};