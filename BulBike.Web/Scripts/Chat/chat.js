$(function () {
    // declare a proxy to reference the hub.

    var chathub = $.connection.chatHub;
    registerClientMethods(chathub);

    // start hub
    $.connection.hub.start().done(function () {
        registerEvents(chathub)
    });

    function registerEvents(chathub) {

        //$('#btnSendMsg').click(function () {

        //    var msg = $("#txtMessage").val();
        //    if (msg.length > 0) {

        //        var username = $('#hdUsername').val();
        //        chathub.server.sendMessageToAll(username, msg);
        //        $("#txtMessage").val('');
        //    }
        //});

        $("#txtNickname").keypress(function (e) {
            if (e.which == 13) {
                $("#btnStartChat").click();
            }
        });

        $("#txtMessage").keypress(function (e) {
            if (e.which == 13) {
                $('#btnSendMsg').click();
            }
        });
    }

    function registerClientMethods(chathub) {
        chathub.client.onConnected = function (allusers, messages) {

            var users = JSON.parse(allusers);
            for (i = 0; i < users.length; i++) {
                console.log(users[i])
                addRoom(chathub, users[i].ConnectionId, users[i].Name);
            }
        }

        chathub.client.onUserDisconnected = function (id, username) {

            $('#' + id).remove();

            var ctrid = 'private_' + id;
            $('#' + ctrid).remove();


            var disc = $('<div class="disconnect">"' + username + '" logged off.</div>');

            $(disc).hide();
            $('#divusers2').prepend(disc);
            $(disc).fadein(200).delay(2000).fadeout(200);

        }

        chathub.client.sendPrivateMessage = function (windowid, fromusername, message) {

            var ctrid = 'private_' + windowid;

            if ($('#' + ctrid).length == 0) {
                createPrivateChatWindow(chathub, windowid, ctrid, fromusername);
            }

            $('#' + ctrid).find('#divMessage').append('<div class="message"><span class="username">' + fromusername + '</span>: ' + message + '</div>');

            // set scrollbar
            var height = $('#' + ctrid).find('#divMessage')[0].scrollHeight;
            $('#' + ctrid).find('#divMessage').scrollTop(height);
        }
    }

    function addRoom(chathub, id, name) {

        var userid = $('#hdid').val();
        var test = '<a id="' + id + '" class="user" >' + name + '<a><br/>';
        var code = $(test)
        $(code).dblclick(function () {

            var id = $(this).attr('id');

            if (userid != id)
                openPrivateChatWindow(chathub, id, name);
        });

        $("#divUsers2").append(code);

    }

    function openPrivateChatWindow(chathub, id, username) {

        var ctrid = 'private_' + id;

        if ($('#' + ctrid).length > 0) return;

        createPrivateChatWindow(chathub, id, ctrid, username);

    }

    function createPrivateChatWindow(chathub, userid, ctrid, room) {

        var div = '<div id="' + ctrid + '" class="ui-widget-content draggable" rel="0">' +
                   '<div class="header"  id="room">' +
                      '<div  style="float:right;">' +
                          '<img id="imgDelete"  style="cursor:pointer;" src="/images/delete.png"/>' +
                       '</div>' +

                       '<span class="selText" rel="0">' + room + '</span>' +
                   '</div>' +
                   '<div id="divMessage" class="messageArea">' +

                   '</div>' +
                   '<div class="buttonBar">' +
                      '<input id="txtPrivateMessage" class="msgText" type="text"   />' +
                      '<input id="btnSendMessage" class="submitButton button" type="button" value="send"   />' +
                   '</div>' +
                '</div>';

        var $div = $(div);

        // delete button image
        $div.find('#imgDelete').click(function () {
            $('#' + ctrid).remove();
        });

        // send button event
        $div.find("#btnSendMessage").click(function () {

            $textbox = $div.find("#txtPrivateMessage");
            var msg = $textbox.val();
            var currentRoom = $('#room').text();
            if (msg.length > 0) {

                chathub.server.sendMessage(msg, currentRoom);
                $textbox.val('');
            }
        });

        // text box event
        $div.find("#txtPrivateMessage").keypress(function (e) {
            if (e.which == 13) {
                $div.find("#btnSendMessage").click();
            }
        });

        addDivtoContainer($div);

    }

    function addDivtoContainer($div) {
        $('#divContainer').prepend($div);

        $div.draggable({

            handle: ".header",
            stop: function () {

            }
        });
    }
});