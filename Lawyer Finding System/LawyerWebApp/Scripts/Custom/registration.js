//var acc = document.getElementsByClassName("accordion");



$(document).ready(function () {
    //Acordian
    var acc = $('.accordion')
    var i;

    for (i = 0; i < acc.length; i++) {
        acc[i].onclick = function () {
            this.classList.toggle("active");
            this.nextElementSibling.classList.toggle("show");
        }
    }
    
    
    
    
    //Add remove
    var next = 1;
    $(".add-more").click(function(e){
        e.preventDefault();
        var addto = "#field" + next;
        var addRemove = "#field" + (next);
        next = next + 1;
        //var newIn = '<input autocomplete="off" class="input form-control" id="field' + next + '" name="field' + next + '" type="text">';
        var newIn = '<div class="input-group"><select class="form-control" id="division" style="width:200px; color: #f05a3d; border-radius:2px;"><option disabled selected>Level of Education</option><option>Level of Education</option><option>Level of Education</option></select> id="field' + next + '" name="field' + next + '  </div>';
        var newInput = $(newIn);
        var removeBtn = '<button id="remove' + (next - 1) + '" class="btn btn-danger remove-me" >Remove</button></div><div id="field">';
        var removeButton = $(removeBtn);
        $(addto).after(newInput);
        $(addRemove).after(removeButton);
        $("#field" + next).attr('data-source',$(addto).attr('data-source'));
        $("#count").val(next);  
        
            $('.remove-me').click(function(e){
                e.preventDefault();
                var fieldNum = this.id.charAt(this.id.length-1);
                var fieldID = "#field" + fieldNum;
                $(this).remove();
                $(fieldID).remove();
            });

    });


    // Toggle Caret
    $('.caRet').click(function () {
        $(this).find("i").toggleClass('fa-caret-left fa-caret-down');
    });


    // Collapse on click next button in lawFirm Registration Page
    $('.next_button_basic').click(function () {
        $('.about_firm').addClass('show');
        $('.about_firm_parent').addClass('active');
        $('.about_firm_parent').find("i").toggleClass('fa-caret-left fa-caret-down');

        $('.basic_details').removeClass('show');
        $('.basic_details_parent').removeClass('active');
        $('.basic_details_parent').find("i").toggleClass('fa-caret-left fa-caret-down');
    });

    $('.next_button_about').click(function () {
        $('.payment_firm').addClass('show');
        $('.payment_firm_parent').addClass('active');
        $('.about_firm_parent').find("i").toggleClass('fa-caret-left fa-caret-down');

        $('.about_firm').removeClass('show');
        $('.about_firm_parent').removeClass('active');
        $('.payment_firm_parent').find("i").toggleClass('fa-caret-left fa-caret-down');
    });


    //Payment extension
    $('.bKash_payment').hide();
    $('.electronicCard_payment').hide();
    $('.cash_payment').hide();
    $('.EFT_payment').hide();
    
    $('.payViabKash').click(function () {
        $('.bKash_payment').show();
        $('.payViabKash').hide();
    });

    $('.payviaCredit').click(function () {
        $('.electronicCard_payment').show();
        $('.payviaCredit').hide();
    });

    $('.payViaCash').click(function () {
        $('.cash_payment').show();
        $('.payViaCash').hide();
    });

    $('.payViaEFT').click(function () {
        $('.EFT_payment').show();
        $('.payViaEFT').hide();
    });



    //Back
    $('.back').click(function () {
        $('.bKash_payment').hide();
        $('.payViabKash').show();
    });

    $('.back').click(function () {
        $('.electronicCard_payment').hide();
        $('.payviaCredit').show();
    });

    $('.back').click(function () {
        $('.cash_payment').hide();
        $('.payViaCash').show();
    });

    $('.back').click(function () {
        $('.EFT_payment').hide();
        $('.payViaEFT').show();
    });

    
    
});