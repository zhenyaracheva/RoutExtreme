//$(function () {
//    // declare a proxy to reference the hub.
    
//    var chathub = $.connection.chathub;
//    debugger
//    registerclientmethods(chathub);

//    // start hub
//    $.connection.hub.start().done(function () {

//        registerevents(chathub)

//    });

//});

//function registerevents(chathub) {

//    var name = $("#hdusername").val();
//    if (name.length > 0) {
//        chathub.server.connect(name);
//    }

//    $('#btnsendmsg').click(function () {

//        var msg = $("#txtmessage").val();
//        if (msg.length > 0) {

//            var username = $('#hdusername').val();
//            chathub.server.sendmessagetoall(username, msg);
//            $("#txtmessage").val('');
//        }
//    });

//    $("#txtnickname").keypress(function (e) {
//        if (e.which == 13) {
//            $("#btnstartchat").click();
//        }
//    });

//    $("#txtmessage").keypress(function (e) {
//        if (e.which == 13) {
//            $('#btnsendmsg').click();
//        }
//    });
//}

//function registerclientmethods(chathub) {

//    // calls when user successfully logged in
//    chathub.client.onconnected = function (id, username, allusers, messages) {

//        $('#hdid').val(id);
//        $('#hdusername').val(username);
//        $('#spanuser').html(username);

//        // add all users
//        for (i = 0; i < allusers.length; i++) {

//            adduser(chathub, allusers[i].connectionid, allusers[i].username);
//        }

//        // add existing messages
//        for (i = 0; i < messages.length; i++) {

//            addmessage(messages[i].username, messages[i].message);
//        }
//    }

//    // on new user connected
//    chathub.client.onnewuserconnected = function (id, name) {
//        adduser(chathub, id, name);
//    }

//    // on user disconnected
//    chathub.client.onuserdisconnected = function (id, username) {

//        $('#' + id).remove();

//        var ctrid = 'private_' + id;
//        $('#' + ctrid).remove();


//        var disc = $('<div class="disconnect">"' + username + '" logged off.</div>');

//        $(disc).hide();
//        $('#divusers2').prepend(disc);
//        $(disc).fadein(200).delay(2000).fadeout(200);

//    }

//    chathub.client.messagereceived = function (username, message) {

//        addmessage(username, message);
//    }


//    chathub.client.sendprivatemessage = function (windowid, fromusername, message) {

//        var ctrid = 'private_' + windowid;


//        if ($('#' + ctrid).length == 0) {

//            createprivatechatwindow(chathub, windowid, ctrid, fromusername);

//        }

//        $('#' + ctrid).find('#divmessage').append('<div class="message"><span class="username">' + fromusername + '</span>: ' + message + '</div>');

//        // set scrollbar
//        var height = $('#' + ctrid).find('#divmessage')[0].scrollheight;
//        $('#' + ctrid).find('#divmessage').scrolltop(height);

//    }

//}

//function adduser(chathub, id, name) {

//    var userid = $('#hdid').val();

//    var code = "";

//    if (userid == id) {
//        //code = $('<div class="loginuser">' + name + "</div>");
//    }
//    else {

//        debugger
//        code = $('<a id="' + id + '" class="user" >' + name + '<a><br/>');

//        $(code).dblclick(function () {

//            var id = $(this).attr('id');

//            if (userid != id)
//                openprivatechatwindow(chathub, id, name);

//        });
//    }

//    $("#divusers2").append(code);

//}

//function addmessage(username, message) {
//    $('#divchatwindow').append('<div class="message"><span class="username">' + username + '</span>: ' + message + '</div>');

//    var height = $('#divchatwindow')[0].scrollheight;
//    $('#divchatwindow').scrolltop(height);
//}

//function openprivatechatwindow(chathub, id, username) {

//    var ctrid = 'private_' + id;

//    if ($('#' + ctrid).length > 0) return;

//    createprivatechatwindow(chathub, id, ctrid, username);

//}

//function createprivatechatwindow(chathub, userid, ctrid, username) {

//    var div = '<div id="' + ctrid + '" class="ui-widget-content draggable" rel="0">' +
//               '<div class="header">' +
//                  '<div  style="float:right;">' +
//                      '<img id="imgdelete"  style="cursor:pointer;" src="/images/delete.png"/>' +
//                   '</div>' +

//                   '<span class="seltext" rel="0">' + username + '</span>' +
//               '</div>' +
//               '<div id="divmessage" class="messagearea">' +

//               '</div>' +
//               '<div class="buttonbar">' +
//                  '<input id="txtprivatemessage" class="msgtext" type="text"   />' +
//                  '<input id="btnsendmessage" class="submitbutton button" type="button" value="send"   />' +
//               '</div>' +
//            '</div>';

//    var $div = $(div);

//    // delete button image
//    $div.find('#imgdelete').click(function () {
//        $('#' + ctrid).remove();
//    });

//    // send button event
//    $div.find("#btnsendmessage").click(function () {

//        $textbox = $div.find("#txtprivatemessage");
//        var msg = $textbox.val();
//        if (msg.length > 0) {

//            chathub.server.sendprivatemessage(userid, msg);
//            $textbox.val('');
//        }
//    });

//    // text box event
//    $div.find("#txtprivatemessage").keypress(function (e) {
//        if (e.which == 13) {
//            $div.find("#btnsendmessage").click();
//        }
//    });

//    adddivtocontainer($div);

//}

//function adddivtocontainer($div) {
//    $('#divcontainer').prepend($div);

//    $div.draggable({

//        handle: ".header",
//        stop: function () {

//        }
//    });

//    ////$div.resizable({
//    ////    stop: function () {

//    ////    }
//    ////});

//}