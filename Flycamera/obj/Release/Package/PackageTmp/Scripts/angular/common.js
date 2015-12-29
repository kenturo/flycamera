'use strict';

var UtilFunction = {};

$(window).load(function() {

    // UtilFunction.initBanner({
    //     elem: '.wrapper__banner--list',
    //     isPagination: true,
    //     item: 1,
    //     wrap: "circular",
    //     isAutoplay: true,
    //     controlNext: 'wrapper__banner .jcarousel-control-next',
    //     controlPrev: 'wrapper__banner .jcarousel-control-prev'
    // });

    // UtilFunction.initBanner({
    //     elem: '.wrapper__Introduce--listFace',
    //     isPagination: true,
    //     item: 1,
    //     wrap: "both",
    //     isAutoplay: false,
    //     controlNext: '.wrapper__Introduce--jcarousel .jcarousel-control-next',
    //     controlPrev: '.wrapper__Introduce--jcarousel .jcarousel-control-prev'
    // });

    // init google map
    if ($(".wrapper__GoogleMap").size()) {
        google.maps.event.addDomListener(window, 'load', UtilFunction.initGoogleMap());
    }

});



$(function() {
    UtilFunction.initBanner = function(option) {

        var _variable = {
            elem: undefined,
            isPagination: false,
            item: 1,
            wrap: "both",
            isAutoplay: false,
            controlNext: '.jcarousel-control-next',
            controlPrev: '.jcarousel-control-prev'
        };

        _variable.elem = option.elem;
        _variable.isPagination = option.isPagination;
        _variable.item = option.item;
        _variable.wrap = option.wrap;
        _variable.isAutoplay = option.isAutoplay;
        _variable.controlNext = option.controlNext;
        _variable.controlPrev = option.controlPrev;


        if ($(_variable.elem).size()) {
            var objCarousel = $(_variable.elem).jcarousel({
                wrap: _variable.wrap,
                interval: 1000
            })

            if (_variable.isAutoplay) {
                objCarousel.jcarouselAutoscroll({
                    autostart: true
                });
            }

            $(_variable.controlPrev)
                .on('jcarouselcontrol:active', function() {
                    $(this).removeClass('inactive');
                })
                .on('jcarouselcontrol:inactive', function() {
                    $(this).addClass('inactive');
                })
                .jcarouselControl({
                    target: '-=' + _variable.item
                });

            $(_variable.controlNext)
                .on('jcarouselcontrol:active', function() {
                    $(this).removeClass('inactive');
                })
                .on('jcarouselcontrol:inactive', function() {
                    $(this).addClass('inactive');
                })
                .jcarouselControl({
                    target: '+=' + _variable.item
                });

            if (_variable.isPagination) {
                $('.jcarousel-pagination')
                    .on('jcarouselpagination:active', 'a', function() {
                        $(this).addClass('active');
                    })
                    .on('jcarouselpagination:inactive', 'a', function() {
                        $(this).removeClass('active');
                    })
                    .jcarouselPagination();
            }
        }
    };

    UtilFunction.handleClickItemFace = function(opt){
        var className = {
            active : "active"
        };

        var itemFaceFirst = $(opt.elem).find('a').eq(0);
        var detailFirst = $(itemFaceFirst).attr('href');

        // setup active First Item 
        $(itemFaceFirst).addClass(className.active)
        $(detailFirst).addClass(className.active);

        //handle Event Click Face Item
        $(opt.elem).find('a').on('click', function(event) {
            event.preventDefault();
            var detailItem = $(this).attr('href');

            //remove active
            $(opt.elem).find('a').removeClass(className.active);
            $('.wrapper__Introduce--detail > div').removeClass(className.active);

            // active
            $(this).addClass(className.active);
            $(detailItem).addClass(className.active);
        });
    }

    UtilFunction.initGoogleMap = function() {
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
    }
});