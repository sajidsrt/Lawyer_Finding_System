$(document).ready(function () {


    $('#carouselHover1').hover(function () {
        $('.hideClass1').removeClass('hiddenDiv');
        $('.hoverClass1').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass1').removeClass('hiddenDiv');
        $('.hideClass1').addClass('hiddenDiv');
    });

    $('#carouselHover2').hover(function () {
        $('.hideClass2').removeClass('hiddenDiv');
        $('.hoverClass2').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass2').removeClass('hiddenDiv');
        $('.hideClass2').addClass('hiddenDiv');
    });

    $('#carouselHover3').hover(function () {
        $('.hideClass3').removeClass('hiddenDiv');
        $('.hoverClass3').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass3').removeClass('hiddenDiv');
        $('.hideClass3').addClass('hiddenDiv');
    });

    $('#carouselHover4').hover(function () {
        $('.hideClass4').removeClass('hiddenDiv');
        $('.hoverClass4').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass4').removeClass('hiddenDiv');
        $('.hideClass4').addClass('hiddenDiv');
    });

    $('#carouselHover5').hover(function () {
        $('.hideClass5').removeClass('hiddenDiv');
        $('.hoverClass5').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass5').removeClass('hiddenDiv');
        $('.hideClass5').addClass('hiddenDiv');
    });

    $('#carouselHover6').hover(function () {
        $('.hideClass6').removeClass('hiddenDiv');
        $('.hoverClass6').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass6').removeClass('hiddenDiv');
        $('.hideClass6').addClass('hiddenDiv');
    });

    $('#carouselHover7').hover(function () {
        $('.hideClass7').removeClass('hiddenDiv');
        $('.hoverClass7').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass7').removeClass('hiddenDiv');
        $('.hideClass7').addClass('hiddenDiv');
    });

    $('#carouselHover8').hover(function () {
        $('.hideClass8').removeClass('hiddenDiv');
        $('.hoverClass8').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass8').removeClass('hiddenDiv');
        $('.hideClass8').addClass('hiddenDiv');
    });

    $('#carouselHover9').hover(function () {
        $('.hideClass9').removeClass('hiddenDiv');
        $('.hoverClass9').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass9').removeClass('hiddenDiv');
        $('.hideClass9').addClass('hiddenDiv');
    });

    $('#carouselHover10').hover(function () {
        $('.hideClass10').removeClass('hiddenDiv');
        $('.hoverClass10').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass10').removeClass('hiddenDiv');
        $('.hideClass10').addClass('hiddenDiv');
    });

    $('#carouselHover11').hover(function () {
        $('.hideClass11').removeClass('hiddenDiv');
        $('.hoverClass11').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass11').removeClass('hiddenDiv');
        $('.hideClass11').addClass('hiddenDiv');
    });

    $('#carouselHover12').hover(function () {
        $('.hideClass12').removeClass('hiddenDiv');
        $('.hoverClass12').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass12').removeClass('hiddenDiv');
        $('.hideClass12').addClass('hiddenDiv');
    });

    $('#carouselHover13').hover(function () {
        $('.hideClass13').removeClass('hiddenDiv');
        $('.hoverClass13').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass13').removeClass('hiddenDiv');
        $('.hideClass13').addClass('hiddenDiv');
    });

    $('#carouselHover14').hover(function () {
        $('.hideClass14').removeClass('hiddenDiv');
        $('.hoverClass14').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass14').removeClass('hiddenDiv');
        $('.hideClass14').addClass('hiddenDiv');
    });

    $('#carouselHover15').hover(function () {
        $('.hideClass15').removeClass('hiddenDiv');
        $('.hoverClass15').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass15').removeClass('hiddenDiv');
        $('.hideClass15').addClass('hiddenDiv');
    });

    $('#carouselHover16').hover(function () {
        $('.hideClass16').removeClass('hiddenDiv');
        $('.hoverClass16').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass16').removeClass('hiddenDiv');
        $('.hideClass16').addClass('hiddenDiv');
    });

    $('#carouselHover17').hover(function () {
        $('.hideClass17').removeClass('hiddenDiv');
        $('.hoverClass17').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass17').removeClass('hiddenDiv');
        $('.hideClass17').addClass('hiddenDiv');
    });

    $('#carouselHover18').hover(function () {
        $('.hideClass18').removeClass('hiddenDiv');
        $('.hoverClass18').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass18').removeClass('hiddenDiv');
        $('.hideClass18').addClass('hiddenDiv');
    });

    $('#carouselHover19').hover(function () {
        $('.hideClass19').removeClass('hiddenDiv');
        $('.hoverClass19').addClass('hiddenDiv');
    }, function () {
        $('.hoverClass19').removeClass('hiddenDiv');
        $('.hideClass19').addClass('hiddenDiv');
    });

    //$('#carousel-example-generic').carousel();  

    // Instantiate the Bootstrap carousel
    $('.multi-item-carousel').carousel({
        interval: 10000
    });
    
    
    
    
    //   ask a layer Modal
    $("#next").click(function () {
    $('#myModal').modal('hide');
    $('#modalLogin').modal('show');
    });
    
    $(".LogInBtn").click(function () {
    $('#modalLogin').modal('hide');
    $('#modalDisclaimerPolicy').modal('show');
    });
    
    $("#next2").click(function () {
    $('#modalDisclaimerPolicy').modal('hide');
    $('#modalConfirmation').modal('show');
    });
    
    $(".clkButtn").click(function () {
    $('.srchArea').removeClass('hide');
    $('.clkButtn').addClass('show');
    });
    



});



