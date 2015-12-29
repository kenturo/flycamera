var _Variable = {
    active: "active"
};

var Services = {
    getListProduct: "../../Services/getListProduct",
    GetListProductForChoose: "/Services/GetListProductForChoose",
    GetListVideoForChoose: "../../Services/GetListVideoForChoose",
    GetFeatureTab: "../../Services/GetFeatureTab",
    GetListAccessoriesForChoose: "../../Services/GetListAccessoriesForChoose",
    GetListRelateProduct: "../../Services/GetListRelateProduct",
    RemoveRelateProduct: "../../Services/RemoveRelateProduct",
    isExistAccount: "../../Services/isExistAccount",
    isExistEmail: "../../Services/isExistEmail",
    login: "../../Services/login",
    RemoveMappingRole: "../../Services/RemoveMappingRole",
    UpdateInformationOrder: "../../Services/UpdateInformationOrder",
    SearchOrderStatus: "../../Services/SearchOrderStatus",
    OrderItem: "../../Services/OrderItem"
}


var PositionGallery = {
    Feature: "Feature",
    Overview: "Overview",
    Video: "Video",
    Gallery: "Gallery",
    Specs: "Specs",
    Technical: "Technical",
    Gallery: "Gallery"
}

var activeCarousel = function(element, prev, next, autoplay) {
    if (jQuery.fn.jcarousel !== undefined) {

        if (jQuery(element).size()) {

            $(element).jcarousel({
                wrap: 'both'
            });

            $('.jcarousel-pagination')
                .on('jcarouselpagination:active', 'a', function() {
                    $(this).addClass('active');
                })
                .on('jcarouselpagination:inactive', 'a', function() {
                    $(this).removeClass('active');
                }).jcarouselPagination();

            if (autoplay) {
                $(element).jcarouselAutoscroll({
                    interval: 4000
                });
            }

            $('.jcarousel-control-prev')
                .on('jcarouselcontrol:active', function() {
                    $(this).removeClass('inactive');
                })
                .on('jcarouselcontrol:inactive', function() {
                    $(this).addClass('inactive');
                })
                .jcarouselControl({
                    target: '-=1'
                });

            $('.jcarousel-control-next')
                .on('jcarouselcontrol:active', function() {
                    $(this).removeClass('inactive');
                })
                .on('jcarouselcontrol:inactive', function() {
                    $(this).addClass('inactive');
                })
                .jcarouselControl({
                    target: '+=1'
                });

            $(element).on('jcarousel:targetin', 'li', function(event, carousel) {
                jQuery(this).addClass('active');
            });
            $(element).on('jcarousel:targetout', 'li', function(event, carousel) {
                jQuery(this).removeClass('active');
            });
        }
    }
};

var paginationList = function(element, currentClick, callbacks) {
    var _this = jQuery(element);
    var _currentPage = jQuery(".currentList").attr('value');
    var _pageSize = jQuery(".pagesizeList").attr('value');
    var _skipPage = 0;
    if (_this.length > 0) {
        _skipPage = (currentClick - 1) * _pageSize;
        $.ajax({
            url: Services.getListProduct,
            dataType: 'json',
            data: {
                take: _pageSize,
                skip: _skipPage
            }
        }).done(function(data) {
            _html = "";
            for (var i = 0; i < data.length; i++) {
                stick = (data[i].isNew) ? "stick-news" : "stick-gift";
                _html += '<li><span class="' + stick + '"></span><a class="image-link" title="" href="/product/detai/' + data[i].ProductID + '"><img src="' + data[i].ImageLink + '" class="img-product"></a><div class="detail-product"><div class="subject"><a class="image-link" title="" href="/product/detai/' + data[i].ProductID + '">' + data[i].ProductName + '</a><div class="frm-share"><a title="Google Plus" class="gplus" href="#">Google Plus</a><a title="Facebook" class="fb" href="#">Facebook</a></div></div><ul class="infomation-product"><li class="title-tbl">ID:</li><li>' + data[i].ProductID + '</li><li class="title-tbl">Price:</li><li class="title-phone">' + data[i].Price + '</li></ul><div class="frm-btn-cotnrol"><a title="See Now" class="btn-more" href="/product/detai/' + data[i].ProductID + '">See Now</a><p class="serect-price">' + data[i].PriceAdmin + '</p></div></div></li>';
            };
            _this.html(_html);
            jQuery(".currentList").attr('value', currentClick);


            if (callbacks && typeof(callbacks) === "function") {
                callbacks();
            }

        });
    }
};

(function($) {
    $.fn.clickToggle = function(func1, func2) {
        var funcs = [func1, func2];
        this.data('toggleclicked', 0);
        this.click(function(e) {
            e.preventDefault();
            var data = $(this).data();
            var tc = data.toggleclicked;
            $.proxy(funcs[tc], this)();
            data.toggleclicked = (tc + 1) % 2;
        });
        return this;
    };
}(jQuery));


function PopupChooseProduct(btnEl, btnClose) {
    url = Services.GetListProductForChoose;
    boxContent = $(".box-content");
    if (btnEl != undefined) {

        // button close
        $(btnClose).click(function(event) {
            _itemClose = $(this).attr('data-popup');
            boxContent.animate({
                top: "-100%"
            }, 500, function() {
                $(_itemClose).hide();
            });
        });

        // button open popup
        $(btnEl).on('click', function(event) {
            event.preventDefault();
            popup = $(this).attr('data-popup');
            $(popup).show();
            boxContent.animate({
                top: "10%"
            }, 500);

            state = boxContent.attr('data-state');
            if (state != "active") {
                $.ajax({
                    type: "POST",
                    url: url,
                    success: function(data) {
                        boxContent.attr('data-state', 'active');
                        td = "";
                        for (var i = 0; i < data.result.length; i++) {
                            td += '<tr class="row-' + data.result[i].Id + '" data-accessory="' + data.result[i].Accessory + '"><td width="10%">' + data.result[i].Id + '</td><td class="filter-name">' + data.result[i].ProductName + '</td><td width="20%"><img src="' + data.result[i].ImageLink + '" alt="img" width="135" height="90" /></td><td width="15%" class="control">    <a title="Choose" href="javascript:;" class="button chose-product">Choose</a></td></tr>';
                        };

                        // add result 
                        $(".responstable tbody").html(td);

                        // typing keyword search product name, search static
                        // jQuery('.input-filter').on('input propertychange paste', function(e) {
                        //     var val = $(this).val();
                        //     $(".filter-name").each(function(i) {
                        //         var content = $(this).html();
                        //         if (content.toLowerCase().indexOf(val) == -1) {
                        //             $(this).closest('tr').hide();
                        //         } else {
                        //             $(this).closest('tr').show();
                        //         }
                        //     });
                        // });

                        //chose product
                        jQuery(".chose-product").on('click', function(event) {
                            event.preventDefault();
                            var tr = $(this).closest('tr');
                            var td = tr.find("td");
                            jQuery(".reviewProduct").val(td[0].innerHTML + "-" + td[1].innerHTML);
                            jQuery(".valueID").val(td[0].innerHTML);
                            if ($(".imgLink_nav").size()) {
                                var isAccess = $(td[0]).closest('tr').data("accessory");
                                var urlGen = "/product/overview/" + td[0].innerHTML;
                                if (isAccess == "true" || isAccess) {
                                    urlGen = "/accessories/" + td[0].innerHTML;
                                }
                                $(".url-gen").val(urlGen)
                                jQuery(".imgLink_nav").val($(td[2]).children('img').attr('src'));
                                jQuery(".RviewLink_nav").attr("src", $(td[2]).children('img').attr('src'));
                            }
                            return false;
                        });

                    }
                });
            }
            return false;
        });


    }
};

function PopupChooseVideo(btnEl, btnClose) {
    urlvideo = Services.GetListVideoForChoose;
    boxContent = $(".box-content");

    if (btnEl != undefined) {

        // button close
        $(btnClose).click(function(event) {
            _itemClose = $(this).attr('data-popup');
            boxContent.animate({
                top: "-100%"
            }, 500, function() {
                $(_itemClose).hide();
            });
        });

        // button open popup
        $(btnEl).on('click', function(event) {
            event.preventDefault();
            popup = $(this).attr('data-popup');
            $(popup).show();
            boxContent.animate({
                top: "10%"
            }, 500);

            state = boxContent.attr('data-state');
            if (state != "active") {
                $.ajax({
                    type: "POST",
                    url: urlvideo,
                    success: function(data) {
                        boxContent.attr('data-state', 'active');
                        td = "";
                        for (var i = 0; i < data.result.length; i++) {
                            if (data.result[i].VideoLink != null && data.result[i].ImageLink) {
                                td += '<tr class="filter-name"><td >' + data.result[i].Title + '</td><td class="" width="10%">' + ((data.result[i].VideoLink != null && data.result[i].VideoLink.length > 10) ? '<a class="iconVideoClip fancybox" title="View Clip" href="' + data.result[i].VideoLink + '">View Clip</a>' : "Unknow") + '</td><td width="180"><img src="' + data.result[i].ImageLink + '" alt="img" width="180" height="80" /></td><td width="15%" class="control">    <a title="Choose" href="javascript:;" class="button choseVideo">Choose</a></td></tr>';
                            }
                        };

                        // add result 
                        $(".responstable tbody").html(td);



                        //chose product
                        jQuery(".choseVideo").on('click', function(event) {
                            event.preventDefault();
                            var tr = $(this).closest('tr');
                            var td = tr.find("td");
                            jQuery(".reviewVideos").val($(td[1].childNodes[0]).attr('href'));
                            jQuery(".getImageUrl").val(td[2].childNodes[0].src);
                            jQuery(".preview").attr("src", $(td[2].childNodes[0]).attr('src'));
                            return false;
                        });

                    }
                });
            }
            return false;
        });


    }
};

function activeTabheader() {
    tabheader = $('.frame-tabheader li a');

    if ($(tabheader).size()) {
        $(tabheader).on('click', function(event) {
            if (!$(this).hasClass('no-href')) {
                // get id of tabcontent need active
                href = $(this).attr('href');
            } else {
                href = "." + $(this).attr('rel');
            }
            // remove active all tag a
            $(this).parents("ul").find('a').removeClass(_Variable.active);

            // add active for elment handle event
            $(this).addClass(_Variable.active);

            // hide all tabcontent
            $(href).siblings().fadeOut('slow');

            // show tabcontent handle event
            $(href).fadeIn('slow');

            return false;
        });
    }
}

function onChangeTextboxImage(e, stt) {
    switch (stt) {
        case 1:
            jQuery(".preview").attr('src', $(e).val());
            break;

        case 2:
            jQuery(".preview-rotate").attr('src', $(e).val());
            break;

        case 3:
            jQuery(".preview-gallery").attr('src', $(e).val());
            break;
    }
}

function handleClickAddLine() {
    _frm = $('.frame-tab--listURL');
    _input = $('.frame-tab--listURL input');
    $('.btn-addLineText').on('click', function(event) {
        event.preventDefault();
        _html = '<input type="text" class="" placeholder="Enter URL Image Here" oninput="onChangeTextboxImage(this,2)" value=""/>';
        _scrollValue = _input.length * (_input.height() + 10);
        _frm.append(_html).delay(1000).scrollTop(_scrollValue);

        return false;
    });

    $('.btn-addLineText--gallery').on('click', function(event) {
        event.preventDefault();
        _html = '<input type="text" class="" placeholder="Enter URL Image Here" oninput="onChangeTextboxImage(this,3)" value=""/>';
        _scrollValue = $(".frame-tab--listURLGallery input").length * ($(".frame-tab--listURLGallery input").height() + 10);
        $('.frame-tab--listURLGallery').append(_html).delay(1000).scrollTop(_scrollValue);

        return false;
    });
}

function ajaxMinitab() {
    if ($("#listViewTab").size()) {
        var tab = $('.mini-tab-pr a');

        tab.on('click', function(event) {
            event.preventDefault();

            param = $(this).data("param");

            tab.removeClass(_Variable.active);
            $(this).addClass(_Variable.active);

            $.get(Services.GetFeatureTab, {
                    type: param
                },
                function(data) {
                    html_e = '';

                    for (var i = 0; i < data.length; i++) {
                        html_e += '<tr class="row-1"><td>' + data[i].Name + '</td><td width="8%">' + data[i].PositionName + '</td><td>' + data[i].FullDescription + '</td><td>' + data[i].FullDescription_EN + '</p></td><td width="5%">    <a title="Edit" href="/Administrator/ProductGallery/Edit/' + data[i].ProductID + '" class="editIcon">Edit</a></td><td width="5%">    <a title="delete" rel="' + data[i].ProductID + '" href="/Administrator/ProductGallery" data="Video" class="removeItem">Delete</a></td></tr>';
                    };
                    $('.responstable tbody').html(html_e);
                }
            );
        });
    }
}

function handleClickVideoHome() {

    if ($("#navigation-clip").size()) {
        var itemClick = $("ul.list-clip a");
        var iframeClip = $(".ifrm-clip-home");
        var spanTitle = $("#navigation-clip span.title");

        itemClick.on('click', function(event) {
            event.preventDefault();
            src = $(this).attr('href');
            title = $(this).attr('title');


            iframeClip.attr('src', src + "?autoplay=1&rel=0&showinfo=0");
            spanTitle.text(title);


            $("ul.list-clip li").removeClass('active');
            $(this).closest('li').addClass('active');
        });
    }
}

function PopupChooseRelateProduct(btnEl, btnClose) {
    urlsv = Services.GetListAccessoriesForChoose;
    boxContent = $(".box-content");
    if (btnEl != undefined) {

        // button close
        $(btnClose).click(function(event) {
            _itemClose = $(this).attr('data-popup');
            boxContent.animate({
                top: "-100%"
            }, 500, function() {
                $(_itemClose).hide();
            });
            handleClick.removeRowRelateProduct(".btn-remove-relateProduct");
        });

        // button open popup
        $(btnEl).on('click', function(event) {
            event.preventDefault();
            popup = $(this).attr('data-popup');
            $(popup).show();
            boxContent.animate({
                top: "10%"
            }, 500);

            state = boxContent.attr('data-state');
            if (state != "active") {
                $.ajax({
                    type: "POST",
                    url: urlsv,
                    success: function(data) {
                        boxContent.attr('data-state', 'active');
                        td = "";
                        for (var i = 0; i < data.result.length; i++) {
                            td += '<tr class="row-' + data.result[i].Id + '"><td width="10%">' + data.result[i].Id + '</td><td class="filter-name">' + data.result[i].ProductName + '</td><td width="20%"><img src="' + data.result[i].ImageLink + '" alt="img" width="135" height="90" /></td><td width="15%" class="control">    <a title="Choose" href="javascript:;" class="button chose-product">Choose</a></td></tr>';
                        };

                        // add result 
                        $("#responstable tbody").html(td);

                        // typing keyword search product name, search static
                        // jQuery('.input-filter').on('input propertychange paste', function(e) {
                        //     var val = $(this).val();
                        //     $(".filter-name").each(function(i) {
                        //         var content = $(this).html();
                        //         if (content.toLowerCase().indexOf(val) == -1) {
                        //             $(this).closest('tr').hide();
                        //         } else {
                        //             $(this).closest('tr').show();
                        //         }
                        //     });
                        // });

                        //chose product
                        jQuery(".chose-product").on('click', function(event) {
                            event.preventDefault();
                            tr = $(this).closest('tr');
                            td = tr.find("td");
                            valArr = $(".arrRelationProduct").val();
                            _valArrRelateId = $(".arrRelationId").val();

                            valArr += (valArr.length > 0) ? "," + td[0].innerHTML : td[0].innerHTML;
                            _valArrRelateId += (_valArrRelateId.length > 0) ? "," + 0 : 0;

                            _addHtml = '<tr class="r-' + td[0].innerHTML + '"><td width="10%">' + td[0].innerHTML + '</td><td class="filter-name">' + td[1].innerHTML + '</td><td width="20%"><img width="135" height="90" alt="img" src="' + $(td[2].childNodes[0]).attr('src') + '"></td><td width="15%" class="control">    <a title="Remove" href="javascript:;" class="button btn-remove-relateProduct">Remove</a></td></tr>';
                            $(".relate-product--table tbody").append(_addHtml);

                            $(".arrRelationId").val(_valArrRelateId);
                            $(".arrRelationProduct").val(valArr)
                            return false;
                        });

                    }
                });
            }
            return false;
        });


    }
};

function loadRelateProductList(id, container) {
    _containerBlock = $(container);
    _valueRelateId = "";
    _valueRelateProduct = "";
    _stateAjax = _containerBlock.attr('data-state');
    if (_containerBlock.hasClass('edit-page')) {
        if (_containerBlock.size() && _stateAjax != "active") {
            $.ajax({
                type: "GET",
                url: Services.GetListRelateProduct,
                data: {
                    id: id
                },
                success: function(data) {
                    if (data.length > 0) {
                        _containerBlock.attr('data-state', 'active');
                        td = "";
                        for (var i = 0; i < data.length; i++) {
                            _valueRelateId += (_valueRelateId.length > 0) ? "," + data[i].RelatedProductID : data[i].RelatedProductID;
                            _valueRelateProduct += (_valueRelateProduct.length > 0) ? "," + data[i].ProductID2 : data[i].ProductID2;
                            td += '<tr class="r-' + data[i].RelatedProductID + '"><td width="10%">' + data[i].ProductID2 + '</td><td class="filter-name">' + data[i].Name + '</td><td width="20%"><img src="' + data[i].OriginalURL + '" alt="img" width="135" height="90" /></td><td width="15%" class="control">    <a title="Remove" href="javascript:;" class="button btn-remove-relateProduct" data-item="' + data[i].RelatedProductID + '">Remove</a></td></tr>';
                        };


                        // add result 
                        _containerBlock.children("tbody").html(td);
                        $(".arrRelationId").val(_valueRelateId);
                        $(".arrRelationProduct").val(_valueRelateProduct);

                        handleClick.removeRowRelateProduct(".btn-remove-relateProduct");
                    }
                }
            });
        }
    }
}


var Utilities = {

}


var handleClick = {
    init: function() {
        handleClick.RelateProductClick();
        handleClick.formatCurrency();


        handleClick.checkExitUser();
        handleClick.checkExitEmail();
        handleClick.checkCaptchaMatch();

        handleClick.activeLogin();

        handleClick.filterTypingName();

        handleClick.MultipSelectBox(".table__customer-role", ".arrRole__chose", true);

        setTimeout(function() {
            $(".loading__page").fadeOut();
        }, 1000);

        handleClick.eventClickReviewImage();

        handleClick.initGoogleMap();

        handleClick.SubmitFormPay();

        handleClick.initFancybox(".fancybox");



        if ($(".administrator").size()) {
            handleClick.initEditor();
            handleClick.initDatePicker();

        }

    },
    RelateProductClick: function() {
        _itemClick = $(".button-relate-product");

        if (_itemClick.size()) {
            _itemClick.on('click', function(event) {
                event.preventDefault();
                loadRelateProductList($("#Product_ProductId").val(), ".relate-product--table");

                if ($(".add-relate--button").size()) {
                    PopupChooseRelateProduct($(".add-relate--button"), $(".close-popup"));
                }

            });
        }
    },
    removeRowRelateProduct: function(elmentclick) {
        $(elmentclick).on("click", function(event) {
            event.preventDefault();
            _dataItem = $(this).attr('data-item');
            tr = $(this).closest('tr');
            td = tr.find("td");

            if (_dataItem != undefined) {
                //get item arr relateProductID
                _arrItem = $(".arrRelationId").val();
                _splitItem = _arrItem.split(",");
                // remove index and assign value
                _splitItem.remove(_dataItem);
                $(".arrRelationId").val(_splitItem.toString());

                $.ajax({
                    url: Services.RemoveRelateProduct,
                    type: 'POST',
                    dataType: 'json',
                    data: {
                        id: _dataItem
                    },
                    success: function(data) {
                        console.log(data);
                    }
                });
            } else {
                _dataItem = td[0].innerHTML;
            }

            //get item arr Product2
            _arrRelateItem = $(".arrRelationProduct").val();
            _splitRelateItem = _arrRelateItem.split(",");

            _splitRelateItem.remove(td[0].innerHTML);
            $(".arrRelationProduct").val(_splitRelateItem.toString());


            // remove row table
            $(".r-" + _dataItem).remove();
        });
    },
    formatCurrency: function() {
        $.each($(".currency-data"), function(index, val) {
            defaultVal = parseInt($(val).text());
            $(val).text(defaultVal.formatMoney(0, "VND ", ".", "."));
        });
    },
    checkExitUser: function() {
        $(".f-txb-pwd-login").on('focus', function(event) {
            event.preventDefault();
            $.ajax({
                url: Services.isExistAccount,
                dataType: 'json',
                data: {
                    userName: $(this).val()
                },
            })
                .done(function(data) {
                    if (data) {
                        $(".msg-validation--user").removeClass('checkSuccess').text("(*) Tài khoản này đã tồn tại").slideDown();
                    } else {
                        $(".msg-validation--user").text("(*) Tài khoản chưa tồn tại").addClass('checkSuccess').slideDown();;
                    }
                });
        });

    },
    checkExitEmail: function() {
        $(".f-tbx-email").on('blur', function(event) {
            event.preventDefault();
            $.ajax({
                url: Services.isExistEmail,
                dataType: 'json',
                data: {
                    email: $(this).val()
                },
            })
                .done(function(data) {
                    if (data) {
                        $(".msg-validation--email").removeClass('checkSuccess').text("(*) Email này đã tồn tại").slideDown();
                    } else {
                        $(".msg-validation--email").text("(*) Email chưa tồn tại").addClass('checkSuccess').slideDown();;
                    }
                });
        });

    },
    checkCaptchaMatch: function() {
        $(".f-txtb-captcha").on('input propertychange paste', function(event) {
            event.preventDefault();
            cookObj = getCookie("codectp");
            if (cookObj == undefined || ($(this).val() != cookObj.split("=")[1])) {
                $(".msg-validation--captcha").text("(*) Mã captcha không chính xác").slideDown();
                $(".form-submit").attr('disabled', 'true');
            } else {
                $(".msg-validation--captcha").slideUp();
                $(".form-submit").removeAttr('disabled');
            }
        });
    },
    activeLogin: function() {
        // tab header active
        $(".popup-signIn--user .tab-content li a").on('click', function(event) {
            event.preventDefault();
            itemLi = $(this).closest('li');
            itemLi.addClass(_Variable.active);
            itemLi.siblings('li').removeClass(_Variable.active);
            itemIndex = itemLi.index();
            cssTag = {};
            if (itemIndex == 0) {
                cssTag = {
                    height: "400px"
                }
            } else {
                cssTag = {
                    height: "550px"
                }
            }
            $(".popup-signIn--user").animate(cssTag, 400);
            $(".popup-content--user > div").hide().eq(itemIndex).fadeIn();
        });

        // close popup
        $(".close-popup--user").click(function(event) {
            event.preventDefault();
            cssTaganimate = {
                top: "-15%"
            }
            $(".popup-signIn--user").animate(cssTaganimate, 400).hide();
            $(".overlay").fadeOut();
        });

        // show popup
        $(".fm-login").click(function(event) {
            event.preventDefault();
            cssTaganimate = {
                top: "8%"
            }
            $(".overlay").fadeIn();
            $(".popup-signIn--user").show().animate(cssTaganimate, 400);

            // handle login
            handleClick.Login(false);

        });
    },
    Login: function(isAdmin) {

        $(".submit-button--login").click(function(event) {
            event.preventDefault();
            usname = $(".f-txb-user-login").val()
            mkuname = $(".f-txb-pwd-login").val();
            objAjax = $.ajax({
                url: Services.login,
                type: 'POST',
                dataType: 'json',
                data: {
                    uname: usname,
                    pwd: mkuname
                },
            });
            objAjax.done(function(data) {
                if (data) {
                    if (isAdmin) {
                        location.href = "../../Administrator";
                    } else {
                        setTimeout(location.reload(), 3000);
                    }
                } else {
                    $(".msg-login").slideDown();
                }
            });

        });
    },
    filterTypingName: function() {
        // typing keyword search product name, search static
        jQuery('.input-filter').on('input propertychange paste', function(e) {
            var val = $(this).val();
            $(".filter-name").each(function(i) {
                var content = $(this).html();
                if (content.toLowerCase().indexOf(val) == -1) {
                    $(this).closest('tr').hide();
                } else {
                    $(this).closest('tr').show();
                }
            });
        });
    },
    MultipSelectBox: function(table, arrContainter, isRemoveDataAjax) {
        var _arrSelect = "";
        var isFlagAjax = false;
        $(table + " input[type='checkbox']").unbind("change").on("change", function(e) {
            _arrSelect = $(arrContainter).val();
            if (this.checked) {
                _arrSelect += (_arrSelect.length > 0) ? "," + e.target.value : e.target.value;
                // console.log("Checked :", e.target.value);
            } else {
                if (isRemoveDataAjax) {

                    isFlagAjax = handleClick.ajaxRemoveItemRole(e.target.value, $("#idcustomer__page").val());
                } else {
                    isFlagAjax = true;
                }
                _arrSelect = (isFlagAjax) ? _arrSelect.split(",").remove(e.target.value + "") : _arrSelect;
            }
            $(arrContainter).val(_arrSelect.toString());
        })
    },
    ajaxRemoveItemRole: function(mappingRoleId, custId) {
        $.ajax({
            url: Services.RemoveMappingRole,
            type: 'POST',
            dataType: 'json',
            data: {
                mappingRoleId: mappingRoleId,
                customerId: custId
            },
            success: function(data) {
                return data;
            },
            error: function() {
                return false;
            }
        });

    },
    UpdateInformationOrder: function(orderId, userId, typeOpt) {
        var param = {
            orderId: "",
            userId: "",
            type: ""
        };

        param.orderId = orderId;
        param.userId = userId;
        param.type = typeOpt;

        $.ajax({
            url: Services.UpdateInformationOrder,
            type: 'POST',
            dataType: 'json',
            data: param,
            success: function(data) {
                if (data) {
                    $('.status-approve').text("Order status has been changed to Processing");
                }
            },
            error: function(err) {
                console.log(err);
            }
        })
    },
    SearchResultOrderStatus: function(thisElem, select) {
        var param = {
            status: ""
        };

        container = $(thisElem).data("bind");
        param.status = $(select).val();

        $.ajax({
            url: Services.SearchOrderStatus,
            dataType: 'json',
            data: param,
            beforeSend: function() {
                $(container).empty().html('<tr><td colspan="9"><img src="/Content/images/loading.gif" alt="loading data" width="24" height="24" /></td></tr>');
            },
            success: function(data) {
                _html = "";

                if (data.result.length > 0) {
                    for (var i = 0; i < data.result.length; i++) {
                        _html += '<tr class=\'row-' + data.result[i].orderid + '\'>' + '<td width="5%">' + data.result[i].orderid + '</td>' + '<td class="currency-data">' + parseInt(data.result[i].ordertotal).formatMoney(0, "VND ", ".", ".") + '</td>' + '<td>' + data.result[i].orderstatus + '</td>' + '<td>' + data.result[i].paymentmethod + '</td>' + '<td>' + data.result[i].shippingmethod + '</td>' + '<td>' + data.result[i].shippingstatus + '</td>' + '<td>' + data.result[i].customer + '</td>' + '<td width="3%">' + data.result[i].createdon + '</td>' + '<td width="3%"><a title="Edit" href="/Administrator/order/Detail/' + data.result[i].orderid + '" class="button">View</a></td>';
                    };
                } else {
                    _html = "<tr><td colspan='9'>Không Tìm Thấy Dữ Liệu</td></tr>";
                }
                setTimeout(function() {
                    $(container).empty().html(_html);
                }, 1000);
            },
            error: function(err) {
                console.log(err);
            }
        })
    },
    initGoogleMap: function() {

        try {
            if ($("#wrapper__GoogleMap--canvas").size()) {
                $.getScript('https://maps.googleapis.com/maps/api/js', function(data, textStatus) {
                    var myLatlng = new google.maps.LatLng(10.76665, 106.677246);
                    var mapOptions = {
                        zoom: 18,
                        center: myLatlng
                    }
                    var map = new google.maps.Map(document.getElementById('wrapper__GoogleMap--canvas'), mapOptions);

                    var marker = new google.maps.Marker({
                        position: myLatlng,
                        map: map,
                        title: 'Hello Flycamera!'
                    });
                });
            }
        } catch (err) {
            console.log(err);
        }
    },
    eventClickReviewImage: function() {
        var objbox = $(".box__reviewAccessories--listImg");
        var reviewBigImg = $(".box__reviewAccessories--bigReview img");
        if (objbox.size()) {
            objbox.find('a').on('click', function(event) {
                event.preventDefault();
                reviewBigImg.attr('src', $(this).children('img').attr('src'));
                $(".box__reviewAccessories--listImg li").removeClass('active')
                $(this).closest('li').addClass('active');
            });
        }
    },
    SubmitFormPay: function() {
        if ($(".wrapper__ShoppingCart--form").size()) {
            $(".wrapper__ShoppingCart--form form").submit(function(event) {
                $.ajax({
                    url: Services.OrderItem,
                    type: 'POST',
                    data: $(".wrapper__ShoppingCart--form form").serialize(),
                    success: function(data) {
                        if (data.rs) {
                            $(".message-show").addClass('success').text("Checkout successful !!!").slideDown(300);
                        } else {
                            $(".message-show").addClass('fail').text("Checkout occur error, please check information !!!").slideDown(300);
                        }
                    },
                })
                return false;
            });
        }
    },
    initFancybox: function(selector) {
        if ($(selector).length > 0) {
            $(selector).fancybox({
                openEffect: 'elastic',
                autoCenter: true,
                padding: [7, 7, 7, 7],
                helpers: {
                    title: {
                        type: 'inside'
                    },
                    media: {}
                },
                nextEffect: 'elastic',
                prevEffect: 'elastic'
            });
        }
    },
    initEditor: function() {
        tinymce.init({
            selector: "#editor,#editor1",
            height: 250,
            mode: "textareas",
            plugins: [
                "advlist autolink autosave link image lists charmap print preview hr anchor pagebreak ",
                "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
                "table contextmenu directionality emoticons template textcolor paste fullpage textcolor colorpicker textpattern"
            ],
            toolbar: "cut copy paste | insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image media"
        });
    },
    initDatePicker: function() {
        if ($(".datetimepicker").size()) {
            $(".datetimepicker").kendoDateTimePicker({
                format: "dd/MM/yyyy",
                value: new Date(),
                start: "2014"
            });
        }
    }
}

var attrSocail = {

};

var SocialShare = {
    init: function() {

        //add box social
        SocialShare.initBoxSocial();

        // init button Like FB
        SocialShare.FBLike();

        // init event click button share
        SocialShare.handleClickShare();
    },
    handleClickShare: function() {
        var btnSFB = $(".btn__FB--share");
        var btnSFB_eveItem = $(".share__fb--evenItem");
        var urlShare = window.location.href;

        if (btnSFB.size()) {
            btnSFB.on('click', function(event) {
                event.preventDefault();
                SocialShare.FBShare(urlShare);
            });
        }

        if (btnSFB_eveItem.size()) {
            btnSFB_eveItem.on('click', function(event) {
                event.preventDefault();
                SocialShare.FBShare(window.location.host + $(this).attr('rel'));
            });
        }
    },
    initBoxSocial: function() {
        var html = '<div id="popup-social-home"><div class="block-social"><div class="like-block-social"><div class="button-control"><div class="group-facebook"><div id="fb-root"></div><div class="btn-fb-share-social btn__FB--share" title="Share">Share</div></div><div class="btn-custom-like"></div></div></div></div></div>';
        jQuery('body').append(html);
    },
    FBLike: function() {
        _jsFB = '<script>(function(d, s, id) {' + 'var js, fjs = d.getElementsByTagName(s)[0];' + 'if (d.getElementById(id)) return;' + 'js = d.createElement(s); js.id = id;' + 'js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.5";' + 'fjs.parentNode.insertBefore(js, fjs);' + '}(document, "script", "facebook-jssdk"));</script>';
        _htmlLike = '<div id="fb-root"></div><div class="fb-like" data-href="https://www.facebook.com/FLYCAMPRO.vn" data-layout="box_count" data-action="like" data-show-faces="false" data-share="false"></div>';
        if ($(".group-facebook").size()) {
            $(".group-facebook").before(_htmlLike);
            $("head").append(_jsFB)
        }
    },
    FBShare: function(hrefShare) {
        if (navigator.userAgent.indexOf('MSIE') != -1) {
            winDef = 'scrollbars=no,status=no,toolbar=no,location=nnoo,menubar=no,resizable=yes,height=430,width=550,top='.concat((screen.height - 500) / 2).concat(',left=').concat((screen.width - 500) / 2);
        } else {
            winDef = 'scrollbars=no,status=no,toolbar=no,location=no,menubar=no,resizable=no,height=400,width=550,top='.concat((screen.height - 500) / 2).concat(',left=').concat((screen.width - 500) / 2);
        }
        var urlShare = '//www.facebook.com/sharer/sharer.php?u=' + hrefShare + '&t=' + document.title;

        var win = window.open(urlShare, '_blank', winDef);
    },
}

Array.prototype.remove = function() {
    var what, a = arguments,
        L = a.length,
        ax;
    while (L && this.length) {
        what = a[--L];
        while ((ax = this.indexOf(what)) !== -1) {
            this.splice(ax, 1);
        }
    }
    return this;
};

Number.prototype.formatMoney = function(places, symbol, thousand, decimal) {
    places = !isNaN(places = Math.abs(places)) ? places : 2;
    symbol = symbol !== undefined ? symbol : "$";
    thousand = thousand || ",";
    decimal = decimal || ".";
    var number = this,
        negative = number < 0 ? "-" : "",
        i = parseInt(number = Math.abs(+number || 0).toFixed(places), 10) + "",
        j = (j = i.length) > 3 ? j % 3 : 0;
    return negative + (j ? i.substr(0, j) + thousand : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousand) + (places ? decimal + Math.abs(number - i).toFixed(places).slice(2) : "") + " " + symbol;
};

window.getCookie = function(name) {
    match = document.cookie.match(new RegExp(name + '=([^;]+)'));
    if (match) return match[1];
}

window.onload = function() {

    if (!$(".administrator").size()) {
        setTimeout(function() {
            SocialShare.init();

        }, 2000);
    }
}