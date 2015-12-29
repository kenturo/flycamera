jQuery(document).ready(function($) {
    

    // toogle menu
    ToggleMenu();




});


function ToggleMenu(){
    $(".ico-menu").clickToggle(function(event) {
        $(".left-header").slideDown();
    },function(){
        $(".left-header").slideUp();
    });
}