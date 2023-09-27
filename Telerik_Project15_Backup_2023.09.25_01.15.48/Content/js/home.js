function onDataBound(e) {
    var listViewData = e.sender.dataSource.view();
    $.each(listViewData, function (index, item) {
        $("#rating_" + item.Id).val(item.Rating);
    });
}

function onReadMoreClick(e) {
    var window = $("#window").data("kendoWindow");
    var clickedButton = $(this.element);
    var description = clickedButton.parent().prev().find(".destination-info").text();
    window.content(description);
    window.center().open();
}