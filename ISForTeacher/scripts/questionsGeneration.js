var selectedClassName = 'selectedElem';

function elemIsSelected(elem) {
    var result = false;
    $(elem.attr('class').split(' ')).each(function () {
        if (this == selectedClassName)
            result = true;
    });
    return result;
}

$(document).ready(function () {
    $(".element").on("click", function () {
        if (elemIsSelected($(this))) {
            $(this).removeClass(selectedClassName);
            return;
        }
        $(this).addClass(selectedClassName);
    });

    $('#selectAll').on("click", function () {
        $(".element").each(function () {
            $(this).addClass(selectedClassName);
        });
    });

    $('#unselectAll').on("click", function () {
        $(".element").each(function () {
            $(this).removeClass(selectedClassName);
        });
    });

    $('#generateQuestions').on("click", function () {
        var subjectId = $(this).attr('subjectId');
        var stuentIds = '';
        //var stuentIdsForQuery = '';
        var started = false;
        $(".element").each(function () {
            if (elemIsSelected($(this))) {
                if (started)
                    stuentIds += '&';
                stuentIds += 'studentIds=' + $(this).attr('studentid');
                started = true;
            }
        });
        if (stuentIds.length == 0) {
            alert('Не выбрано ни одного студента');
            return;
        }

        var link = "QuestionsList?" + stuentIds + "&subjectId=" + subjectId;
        window.location.href = link;
    });
});