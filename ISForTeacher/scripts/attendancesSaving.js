$(document).ready(function () {
    $('#save').on('click', function () {
        var cellRedactors = $('.cellRedactor');
        var dataToSend = [];
        $.each(cellRedactors, function (i, e) {
            var studentId = $(e).attr("studentId");
            var workId = $(e).attr("workId");
            var value = $(e).val();

            var cellData = {
                StudentId: studentId,
                WorkId: workId,
                Value: value
            }

            dataToSend.push(cellData);
        });

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: "POST",
            url: "Attendances/SaveAttendances",
            data: JSON.stringify({ 'info': dataToSend }),
            success: function (data) {
                alert("Изменения сохранены");
            }
        });
    })

});