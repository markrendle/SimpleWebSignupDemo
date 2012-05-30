function getLink(obj,rel) {
    for (var i in obj.links) {
        var link = obj.links[i];
        if (link.Rel === rel) {
            return link;
        }
    }
    return '#';
}

function getSelfHref(obj) {
    return getLink(obj, 'self');
}

$(function () {
    $.getJSON("/admin/signups")
        .success(function (data) {
            for (var i in data) {
                var sendInvitationLink = getLink(data[i], 'send.invitation');
                $('#list').append('<li><a href="' + getSelfHref(data[i]) + '">' + data[i].Email + '</a> - <a href="' + sendInvitationLink.Href + '">' + sendInvitationLink.Title + '</a></li>');
            }
        })
        .error(function (error) {
            alert(error);
        });
});