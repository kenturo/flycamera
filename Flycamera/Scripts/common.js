(function($) {
    jQuery(document).ready(function($) {




        /* truot thong tin chi tiet san pham*/
        activeSlideProducts();


        /* active banner Home Page */
        activeBannerHome();

        /* active Video Home Page */
        activeCarousel(".jcarousel", "", "", false);


        /* slide down Navigation Product (submenu list product) */
        if (jQuery('ul.nav-main li a.nav-3').size()) {
            if (!jQuery('ul.nav-main li a.nav-3').hasClass('devices')) {
                jQuery('ul.nav-main li a.nav-3').clickToggle(function() {
                    jQuery("#nav-products").slideDown();
                    jQuery(this).closest("li").addClass("active");
                }, function() {
                    jQuery("#nav-products").slideUp();
                    jQuery(this).closest("li").removeClass("active");
                });
            }
        }

        /* Expand List Gallery in overview page products */
        if (jQuery('.btn-expand').size()) {
            jQuery('.btn-expand').clickToggle(function() {
                jQuery('#gallery-block .list-gallery').data("heightRoot", jQuery('#gallery-block .list-gallery').height());
                jQuery('#gallery-block .list-gallery').stop(false).animate({
                    height: "330px"
                }, 500);
                jQuery(this).text("Collapse");
            }, function() {
                jQuery('#gallery-block .list-gallery').stop(false).animate({
                    height: "672px"
                }, 500);
                jQuery(this).text("Expand");
            });
        }

        /* handle event click item Feature in subpage Feature Products */
        selectItemFeature();


        /* call pagination List Products */
        jQuery(".frm-pagination a").click(function(event) {
            event.preventDefault();
            var _elementUL = jQuery('.list-pag li')
            if (!jQuery(this).closest('li').hasClass('active')) {

                /* pagination control if true */
                if (jQuery(this).hasClass('btn-pag')) {
                    var className = jQuery(this).attr('rel');
                    var indexCurrent = jQuery(".currentList").attr('value');
                    var indexPageNumber = jQuery(".pageNumber").attr('value');
                    var indexLi = _elementUL.eq(0);
                    switch (className) {
                        case "next":
                            indexLi = _elementUL.eq(indexCurrent);
                            break;

                        case "prev":
                            indexLi = _elementUL.eq((indexCurrent - 2) < 0 ? 0 : indexCurrent - 2);
                            break;

                        case "last":
                            indexLi = _elementUL.eq(indexPageNumber - 1);
                            break;

                        case "first":
                            indexLi = _elementUL.eq(0);
                            break;
                    }
                    indexLi.children('a').trigger('click');
                    return false;
                }


                /* call data*/
                paginationList("#list-products", jQuery(this).attr("rel"), function() {
                    /* truot thong tin chi tiet san pham*/
                    activeSlideProducts();
                });

                /* remove and add class active for element */
                siblngsElement = jQuery(this).closest('li').siblings('li').removeClass(_Variable.active);
                jQuery(this).closest('li').addClass(_Variable.active);

            }
        });

        // show popup choose product on Administrator
        if ($(".choseProduct").size()) {
            PopupChooseProduct($(".choseProduct"), $(".close-popup"));
        }
        if ($(".choosePopupVideo").size()) {
            PopupChooseVideo($(".choosePopupVideo"), $(".close-popup"));
        }



        // toggle Element
        toggleBox('.element-Tick', '.toggle-Element', function() {
            if ($('.element-Tick:checked').hasClass('showin')) {
                $('.element-Tick:checked').trigger('click');
            }
        });

        // delete record in Administrator
        DeleteItem();
        activeRole();

        /* tab header*/
        activeTabheader();

        // handle checkbox group in list item Products
        handleCheckboxGroup();

        //handle click button add textbox , upload image by url
        if ($('.btn-addLineText').size()) {
            handleClickAddLine();
        }

        //handle click submit for page CreateFeature
        handleClickButtonSubmit(".frame-tab--listURL", "#image_url");
        handleClickButtonSubmit(".frame-tab--listURLGallery", "#image_url--Gallery");

        if ($('#position').size()) {
            $('#position').change(function() {
                _value = $(this).find('option:selected').text();
                if (_value == PositionGallery.Overview) {
                    $('.frm-upload--backgroundIMG').slideDown();
                } else {
                    $('.frm-upload--backgroundIMG').slideUp();
                }
            });
        }



        // miniTab in ProductGallery Controller
        ajaxMinitab();

        // handle click navigation Clip Homepage;
        handleClickVideoHome();

        // handleClick Item
        handleClick.init();


        // calculator Shopping Cart
        if ($('.wrapper__ShoppingCart').size()) {
            calculatorShoppingCart();
        }
    });
})(jQuery);

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


function activeBannerHome() {
    if (jQuery("#frm-banner").size()) {

        var bannerSwiper = "";
        // jQuery(window).resize(function() {
        //     jQuery(".swiper-container").velocity({
        //         height: jQuery(window).height() - 80
        //     }, 0);
        // });
        bannerSwiper = new Swiper('.swiper-container', {
            mode: 'horizontal',
            paginationClickable: true,
            pagination: '.pagina',
            autoplay: 3000,
            loop: true
        });
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
            activeBannerHome();
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

function BrowseServer() {
    if ($('.SyncURLImageLink').val().length > 0) {
        if ($(".btn-upload-img").size()) {
            UploadImage($('.SyncURLImageLink').val());
        } else {
            var finder = new CKFinder();
            finder.selectActionFunction = UploadImage;
            finder.popup();
        }
    } else {
        alert("Vui lòng nhập đường dẫn hình ảnh")
    }
}

function UploadImage(fileUrl) {
    if (fileUrl != null && fileUrl.length > 0) {
        $.post("/Services/UploadImage", {
                imgLink: fileUrl
            },
            function(data) {
                if (jQuery(".imgLink").hasClass('getImageUrl')) {
                    jQuery(".getImageUrl").val(fileUrl);
                } else {
                    jQuery(".imgLink").val(data.id);
                }
                jQuery(".preview").attr("src", fileUrl);
            }
        );
    } else {
        alert("Please, Enter image url.");
        jQuery(".imgLink").focus();
    }
}

/* truot thong tin chi tiet san pham*/
function activeSlideProducts() {
    jQuery("#list-products > li").on("mouseenter", function() {
        jQuery(this).find(".detail-product").stop().animate({
            bottom: 0
        }, 300);
    }).on("mouseleave", function() {
        jQuery(this).find(".detail-product").stop().animate({
            bottom: -150
        }, 300);
    });
}
// delete Item
function DeleteItem() {
    if ($('.removeItem').size()) {
        $('.removeItem').on('click', function(event) {
            var row = $(this).attr("rel");
            var controller = $('#controllerServices').val();
            console.log("controller : ", controller);
            if (confirm("Đối tượng sẽ bị xóa.Bạn có muốn không ?")) {
                $.ajax({
                    type: "POST",
                    url: '/Administrator/' + controller + '/Delete',
                    data: {
                        id: row
                    },
                    success: function() {
                        $(".row-" + row).remove();
                    }
                });
            }
        });
    }
}

// active administrator
function activeRole() {
    var objac = $('.adminItem');
    var isAdmincheck = true;
    if (objac.size()) {
        objac.on('click', function(event) {
            _seft = $(this);
            if ($(this).hasClass('unAdmin')) {
                isAdmincheck = false;
            }

            var row = $(this).attr("rel");
            var td = $(this).closest('td');
            var controller = $('#controllerServices').val();
            if (confirm("Tài khoản sẽ được phân quyền Administrator.Bạn có muốn không ?")) {
                $.ajax({
                    type: "POST",
                    url: '/Administrator/' + controller + '/activeAdministrator',
                    data: {
                        id: row,
                        isAdmin: isAdmincheck
                    },
                    success: function(data) {
                        if (data) {
                            itmTD = td.siblings('td')[5];
                            $(itmTD).children('input').prop('checked', isAdmincheck);
                            if (isAdmincheck) {
                                _seft.addClass('unAdmin')
                            } else {
                                _seft.removeClass('unAdmin')
                            }
                        } else {
                            alert("Phân quyền Administrator thất bại !")
                        }
                    }
                });
            }
            return false;
        });

    }
}

function toggleBox(eleTick, eleAppear, callbacks) {
    var $itemTick = $(eleTick);
    var $itemAppear = $(eleAppear);

    if ($itemTick.size()) {
        $itemTick.click(function(event) {
            console.log($(this).hasClass('showin'));
            if ($itemAppear.size() && $itemTick.hasClass('showin')) {
                ($(this).hasClass('showin')) ? $itemAppear.slideDown() : $itemAppear.slideUp();
            }
        });
    }
    typeof callbacks === 'function' && callbacks();
}

function handleCheckboxGroup() {
    var objChecked = undefined;
    var _valueCheckbox = "";

    $('input[type="checkbox"]').on('change', function() {
        objChecked = $('input.checkAction[type=checkbox]:checked');
        $('input[name="' + this.name + '"]').not(this).prop('checked', false);
        if (objChecked.length > 0) {
            _valueCheckbox = objChecked.val();
        }
        $('.responstable tr.active').removeClass('active');
        $('input.checkAction[type=checkbox]:checked').parents('tr').addClass(_Variable.active);
    });

    $('.child-action').children('a').on("click", function(event) {
        objChecked = $('input.checkAction[type=checkbox]:checked');
        if (objChecked.length > 0) {
            _href = $(this).attr('rel');
            if (!$(this).hasClass('no-action')) {
                _href += "/" + _valueCheckbox;
            }
            $(this).attr('href', _href);
        } else {
            alert("Vui lòng chọn sản phẩm muốn thao tác");
            return false;
        }
    });
}



function handleClickButtonSubmit(listimgr, containerData) {
    _btnSubmit = $('.btn-submit');
    _imgurlList = "";

    if (_btnSubmit.size()) {
        _btnSubmit.on('click', function(event) {
            _imgurlList = "";
            if ($(listimgr).size()) {
                $(listimgr + ' input[type="text"]').each(function(index, el) {
                    if ($(el).val().length > 3)
                        _imgurlList += $.trim($(el).val()) + ",";
                });
                $(containerData).val(_imgurlList);
            }
        });
    }
}

function calculatorShoppingCart() {

    // calculator total price of one item
    $(".checkout-quantity").unbind("input propertychange paste").on('input propertychange paste', function(event) {
        event.preventDefault();
        calculatorPrice($(this), '.checkout-totalOrder');
    });

    // $('.checkout-totalOrder').text($(".checkout-totalItem").text());


    $.each($(".checkout-quantity"), function(index, val) {
        calculatorPrice(val, '.checkout-totalOrder');
    });



}

var calculatorPrice = function(thisQuantity, elmTotalOrder) {
    var qttItem = $(thisQuantity).val();
    var parentTD = $(thisQuantity).closest('td');
    var priceItemTD = $(parentTD).prev();
    var totalItemTD = $(parentTD).next();
    var priceItemTD = $(priceItemTD).children().attr("rel");
    $(totalItemTD).children('p').text((parseInt(qttItem) * parseInt(priceItemTD.split('VND')[0])).formatMoney(0, "VND ", ".", "."));
    $(totalItemTD).children('input').val((parseInt(qttItem) * parseInt(priceItemTD.split('VND')[0])))
    $(elmTotalOrder).text((parseInt(qttItem) * parseInt(priceItemTD.split('VND')[0])).formatMoney(0, "VND ", ".", "."));
    $(elmTotalOrder).next('input').val((parseInt(qttItem) * parseInt(priceItemTD.split('VND')[0])))
}