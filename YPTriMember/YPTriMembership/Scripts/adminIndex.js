$(document).ready(function () {

    var createAutocomplete = function () {
        var $input = $(this);
        var options = {
            source: $input.attr("data-members-autocomplete")
        };
        $input.autocomplete(options);
    };

    $("input[data-members-autocomplete]").each(createAutocomplete);

    var ajaxFormSubmit = function () {

        var createAutocomplete = function () {
            var $input = $(this);

            var options = {
                source: $input.attr("data-members-autocomplete")
            }

            $input.autocomplete(options);
        };

        $("input[data-members-autocomplete]").each(createAutocomplete);

        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var target = $($form.attr("data-members-target"));
            var $data = $(data);
            target.html($data);
            $data.effect("fade", "slow");
        });

        return false;
    };

    $("#searchTerm").submit(ajaxFormSubmit);
});

