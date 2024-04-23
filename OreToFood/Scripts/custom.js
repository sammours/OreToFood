$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var target = $($form.attr("data-otf-target"));
            var $newHTML = $(data);
            target.replaceWith($newHTML);
            $newHTML.effect("highlight");
        });

        return false;
    };

    var submitAutocomplete = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutocomplete
        };

        $input.autocomplete(options);
    };


    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };
        
        $.ajax(options).done(function (data) {
            
            var target = $a.parents("div.page-list").attr("data-otf-target");
            $(target).replaceWith(data);
        });

        return false;
    };

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);

    $(".body-content").on("click", ".page-list a", getPage)
});