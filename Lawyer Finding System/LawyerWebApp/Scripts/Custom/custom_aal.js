$(document).ready(function () {
    //Initialize tooltips
    $('.nav-tabs > li a[title]').tooltip();

    //Wizard
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

        var $target = $(e.target);

        if ($target.parent().hasClass('disabled')) {
            return false;
        }
    });

    $(".next-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        $active.next().removeClass('disabled');
        nextTab($active);

    });

    $(".LogInBtn").click(function (e) {
        /* var $element = $('.wizard .nav-tabs li.login');
         console.log($element);
 
         var $active = $('.wizard .nav-tabs li.active');
         var $loginelement = $active.find('.login');
         console.log($loginelement);
         $loginelement.removeClass('disabled');
         console.log($loginelement);
         nextTablogin($active);*/

        $(".wizard .nav-tabs li").find('.login').removeClass('disabled').addClass('active');


    });

    $(".prev-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        prevTab($active);

    });
});

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}

function prevTab(elem) {
    $(elem).prev().find('a[data-toggle="tab"]').click();
}