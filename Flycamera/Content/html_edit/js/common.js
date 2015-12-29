jQuery(document).ready(function($) {




    /* truot thong tin chi tiet san pham*/
    jQuery("#list-products > li").bind("mouseenter", function() {
        jQuery(this).find(".detail-product").stop().velocity({
            bottom: 0
        }, 300);
    }).bind("mouseleave", function() {
        jQuery(this).find(".detail-product").stop().velocity({
            bottom: -150
        }, 300);
    });

    /* active banner Home Page */
    activeBannerHome("#frm-banner", true);

    /* active Video Home Page */
    activeBannerHome("#navigation-clip", false);


    /* slide down Navigation Product (submenu list product) */
    if (jQuery('ul.nav-main li a.nav-3').size()) {
        jQuery('ul.nav-main li a.nav-3').clickToggle(function() {
            jQuery("#nav-products").slideDown();
            jQuery(this).closest("li").addClass("active");
        }, function() {
            jQuery("#nav-products").slideUp();
            jQuery(this).closest("li").removeClass("active");
        });
    }

    /* Expand List Gallery in overview page products */
    if (jQuery('.btn-expand').size()) {
        jQuery('.btn-expand').clickToggle(function() {
            jQuery('#gallery-block .list-gallery').data("heightRoot", jQuery('#gallery-block .list-gallery').height());
            jQuery('#gallery-block .list-gallery').stop(false).velocity({
                height: "330px"
            }, 500);
            jQuery(this).text("Collapse");
        }, function() {
            jQuery('#gallery-block .list-gallery').stop(false).velocity({
                height: "672px"
            }, 500);
            jQuery(this).text("Expand");
        });
    }

    /* handle event click item Feature in subpage Feature Products */
    selectItemFeature();
});

function setCenter(objSV) {
    windowWidth = jQuery(window).width();
    windowHeight = jQuery(window).height();
    popupWidth = objSV.width();
    popupHeight = objSV.height();
    // objSV.css('top', (windowHeight - popupHeight) / 2);
    objSV.css('left', (windowWidth - popupWidth) / 2);
    objSV.show();
    jQuery('.overlay').show();
    $(window).resize(function() {
        windowWidth = jQuery(window).width();
        windowHeight = jQuery(window).height();
        // objSV.css('top', (windowHeight - popupHeight) / 2);
        objSV.css('left', (windowWidth - popupWidth) / 2);
    });

}


function activeBannerHome(elm, autoplay) {
    if (jQuery(elm).size()) {

        var bannerSwiper = "";
        // jQuery(window).resize(function() {
        //     jQuery(".swiper-container").velocity({
        //         height: jQuery(window).height() - 80
        //     }, 0);
        // });
        bannerSwiper = new Swiper(elm + ' .swiper-container', {
            mode: 'horizontal',
            paginationClickable: true,
            pagination: '.pagina',
            autoplay: 3000,
            loop: true
        });
        if (!autoplay) {
            bannerSwiper.stopAutoplay();
        }
        if (bannerSwiper != "") {
            jQuery(".btn-prev-banner").click(function(event) {
                bannerSwiper.swipePrev();
                return false;
            });
            jQuery(".btn-next-banner").click(function(event) {
                bannerSwiper.swipeNext();
                return false;
            });
        } else {
            activeBannerHome(elm, autoplay);
        }
    }
}

function scaleSize(elemImg, maxW, maxH) {
    var maxW = maxW;
    var maxH = maxH
    var currW = jQuery(elemImg).width();
    var currH = jQuery(elemImg).height();
    var ratio = currH / currW;

    if (currW >= maxW && ratio <= 1) {
        currW = maxW;
        currH = currW * ratio;
    } else if (currH >= maxH) {
        currH = maxH;
        currW = currH / ratio;
    }

    return {
        "width": currW,
        "height": currH
    };
}

/* handle event click item Feature in subpage Feature Products */
function selectItemFeature() {
    _itemF = jQuery('a.item-feature');
    if (_itemF.size()) {
        _itemF.each(function(index, el) {
            jQuery(el).on('click', function(event) {
                event.preventDefault();
                _imgRotate = jQuery(this).data("target");

                /* get list url img*/
                _listIMG = jQuery(this).data("images");

                /*get url img first */
                _firstIMG = _listIMG.split(',');

                jQuery(_imgRotate).attr({
                    "data-images": _listIMG,
                    "src": _firstIMG[0]
                });

                jQuery(_imgRotate).reel({
                    images: _firstIMG,
                    frame: 1,
                    cw: !0
                });

                jQuery(".right-image ul li a.active").removeClass('active')
                jQuery(this).addClass('active');
                return false;
            });
        });
        _itemF.eq(0).trigger('click');
    }
}