(function ($) {
    $.searchbox = {};

    $.extend(true, $.searchbox, {
        settings: {
            url: '/search',
            dom_id: '#results',
            delay: 100,
            loading_css: '#loading',
            on_start: function () { }
        },

        loading: function () {
            $($.searchbox.settings.loading_css).show()
        },

        resetTimer: function (timer) {
            if (timer) clearTimeout(timer)
        },

        idle: function () {
            $($.searchbox.settings.loading_css).hide()
        },

        process: function (inputs) {
            var path = $.searchbox.settings.url.split('?'),
              base = path[0],
              params = path[1],
              query_string = "";

            var len = inputs.size();
            if (len) {
                $.each(inputs, function (index, element) {
                    element = $(element);
                    console.log(element);
                    query_string += element.attr("name") + "=" + element.val();
                    if (len - 1 != index) {
                        query_string += "&";
                    }
                })

                console.log(query_string);
            }


            $.post([base, '?', query_string].join(''), function (data) {
                $($.searchbox.settings.dom_id).html(data)
            })
        },

        start: function () {
            $(document).trigger('before.searchbox')
            $.searchbox.loading()
        },

        stop: function () {
            $.searchbox.idle()
            $(document).trigger('after.searchbox')
        }
    });

    $.fn.searchbox = function (config) {
        var settings = $.extend(true, $.searchbox.settings, config || {})

        $.searchbox.settings.on_start && $.searchbox.settings.on_start()
        $.searchbox.idle()

        var inp_this = this;

        return this.each(function () {
            var $input = $(this);

            $input
            .focus()
            .ajaxStart(function () { $.searchbox.start() })
            .ajaxStop(function () { $.searchbox.stop() })
            .keyup(function () {
                if ($input.val() != this.previousValue) {
                    $.searchbox.resetTimer(this.timer)

                    this.timer = setTimeout(function () {
                        $.searchbox.process(inp_this)
                    }, $.searchbox.settings.delay)

                    this.previousValue = $input.val()
                }
            })
        })
    }
})(jQuery);