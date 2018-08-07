// JavaScript Document
/*--------------Multiple Expand/Collapse-------------------*/
$(document).ready(function () {

    $(function () {
        $('a[data-toggle="collapse"]').on('click', function () {

            var objectID = $(this).attr('href');

            if ($(objectID).hasClass('in')) {
                $(objectID).collapse('hide');
            }

            else {
                $(objectID).collapse('show');
            }
        });


        $('#expandAll').on('click', function () {

            $('a[data-toggle="collapse"]').each(function () {
                var objectID = $(this).attr('href');
                if ($(objectID).hasClass('in') === false) {
                    $(objectID).collapse('show');
                }
            });
        });

        $('#collapseAll').on('click', function () {

            $('a[data-toggle="collapse"]').each(function () {
                var objectID = $(this).attr('href');
                $(objectID).collapse('hide');
            });
        });

    });

});
/*--------------Ends Multiple Expand/Collapse-------------------*/


/*----- Menu Toggle Script --------*/
$("#menu-toggle").click(function (e) {
    var status = $('#hidenbody').css('display');
    if (status == "none") {
        e.preventDefault();
        $(".auto-expand-panel").toggleClass("toggled");
    }
});

function sliderPanelExtn(a) {
    $(a).next('.left-sidebar-panel').css({ 'right': '0', 'display': 'block', 'z-index': 101 });
    $(a).next('.left-sidebar-panel').children('.sidebar-icons').css('display', 'block');
    $(a).css('display', 'none');

    $('.left-sidebar-panel').hover(function () {
    },
function () {
    $(this).css({ 'right': '-226px', 'display': 'none' });
    $(this).prev().css('display', 'block');
});
}

/* Left Side Navigation */
$(function () {
    //$(document).on('click','.slider-favorite.show-arrow',function(){
    //    $( ".left-sidebar-panel" ).animate({
    //      right: "+=216"
    //	  }, 400, function() {
    //        // Animation complete.
    //      });
    //	  $( ".slider-form").css("display","none");
    //	  $( ".slider-report").css("display","none");
    //	  $(this).removeClass('show-arrow').addClass('hide-arrow active');
    //});

    //$(document).on('click','.slider-favorite.hide-arrow',function(){
    //    $( ".left-sidebar-panel" ).animate({
    //      right: "-=216"
    //	  }, 400, function() {
    //        // Animation complete.
    //      });
    //	  $( ".slider-form").css("display","block");
    //	  $( ".slider-report").css("display","block");
    //	  $(this).removeClass('hide-arrow active').addClass('show-arrow');
    //});

    //function sliderPanelExtn(a) {
    //    $(a).next('.left-sidebar-panel').css({ 'right': '0', 'display': 'block', 'z-index': 101 });
    //    $(a).next('.left-sidebar-panel').children('.sidebar-icons').css('display', 'block');
    //    $(a).css('display', 'none');
    //}
    //$('.left-sidebar-panel').hover(function () {
    //},
    //function () {
    //    $(this).css({ 'right': '-226px', 'display' : 'none' });
    //    $(this).prev().css('display', 'block');
    //});


    $(document).on('click', '.slider-form.show-arrow', function () {
        $(".form-sidebar-panel").animate({
            right: "+=216"
        }, 400, function () {
            // Animation complete.
        });
        $(".slider-favorite").css("display", "none");
        $(".slider-report").css("display", "none");
        $(this).removeClass('show-arrow').addClass('hide-arrow active');
    });

    $(document).on('click', '.slider-form.hide-arrow', function () {
        $(".form-sidebar-panel").animate({
            right: "-=216"
        }, 400, function () {
            // Animation complete.
        });
        $(".slider-favorite").css("display", "block");
        $(".slider-report").css("display", "block");
        $(this).removeClass('hide-arrow active').addClass('show-arrow');
    });
    $(document).on('click', '.slider-report.show-arrow', function () {
        $(".report-sidebar-panel").animate({
            right: "+=216"
        }, 400, function () {
            // Animation complete.
        });
        $(".slider-favorite").css("display", "none");
        $(".slider-form").css("display", "none");
        $(this).removeClass('show-arrow').addClass('hide-arrow active');
    });

    $(document).on('click', '.slider-report.hide-arrow', function () {
        $(".report-sidebar-panel").animate({
            right: "-=216"
        }, 400, function () {
            // Animation complete.
        });
        $(".slider-favorite").css("display", "block");
        $(".slider-form").css("display", "block");
        $(this).removeClass('hide-arrow active').addClass('show-arrow');
    });
});
