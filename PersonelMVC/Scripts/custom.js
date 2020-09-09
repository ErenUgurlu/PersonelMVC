$(function () {
    $("#tblDepartmanlar").DataTable();
    $("#tblPersoneller").DataTable();
    
    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
        var btn = $(this);

        bootbox.confirm("Departmanı Silmek İstediğinize emin misiniz?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "get",
                    url: "/Departman/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                })
            }
        })

    })
    

});
