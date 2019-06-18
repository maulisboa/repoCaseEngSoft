const uri = "api/hashtag";
let hashtags = null;
function getCount(data) {
    const el = $("#counter");
    let name = "item";
    if (data) {
        if (data > 1) {
            name = "itens";
        }
        el.text(data + " " + name);
    } else {
        el.text("Nenhum " + name);
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#hashtags");

            $(tBody).empty();

            getCount(data.length);

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.id_hashtag))
                    .append($("<td></td>").text(item.hashtag_name))
                    .append(
                        $("<td></td>").append(
                            $("<button>Alterar</button>").on("click", function () {
                                editItem(item.id_hashtag);
                            })
                        )
                    )
                    .append(
                        $("<td></td>").append(
                            $("<button>Excluir</button>").on("click", function () {
                                deleteItem(item.id_hashtag);
                            })
                        )
                    );

                tr.appendTo(tBody);
            });

            hashtags = data;
        }
    });
}

function addItem() {
    const item = {
        hashtag_name: $("#add-name").val()
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            getData();
            $("#add-name").val("");
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + "/" + id,
        type: "DELETE",
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    $.each(hashtags, function (key, item) {
        if (item.id_hashtag === id) {
            $("#edit-name").val(item.hashtag_name);
            $("#edit-id").val(item.id_hashtag);
        }
    });
    $("#spoiler").css({ display: "block" });
}

$(".my-form").on("submit", function () {
    //alert($("#edit-id").val());
    //alert($("#edit-name").val());

    const item = {
        hashtag_name: $("#edit-name").val(),
        id_hashtag: $("#edit-id").val()
    };

    $.ajax({
        url: uri + "/" + $("#edit-id").val(),
        type: "PUT",
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $("#spoiler").css({ display: "none" });
}