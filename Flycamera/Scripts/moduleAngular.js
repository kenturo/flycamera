var services = {
    partnership: "http://flycamepro.somee.com/services/GetListPartnership",
    eventVideo: "http://flycamepro.somee.com/services/GetListEventVideo",
    listBlogpost: "http://flycamepro.somee.com/services/GetListBlogPost",
    DetailBlogpost: "http://flycamepro.somee.com/services/GetDetailBlogPost",
    listTeam: "http://flycamepro.somee.com/services/GetListTeam",
    bannerSevices: "http://flycamepro.somee.com/services/GetListBannerServices"

};


var appDirective = angular.module("ngRepeatUtils", [])
appDirective.directive('ngRepeatEndWatch', function($timeout) {
    return {
        restrict: 'A',
        scope: {},
        link: function(scope, element, attrs) {
            if (attrs.ngRepeat) {
                if (scope.$parent.$last) {
                    if (attrs.ngRepeatEndWatch !== '') {
                        if (typeof scope.$parent.$parent[attrs.ngRepeatEndWatch] === 'function') {
                            // Executes defined function
                            scope.$parent.$parent[attrs.ngRepeatEndWatch]();
                        } else {
                            // For watcher, if you prefer
                            scope.$parent.$parent[attrs.ngRepeatEndWatch] = true;
                        }
                    } else {
                        // If no value was provided than we will provide one on you controller scope, that you can watch
                        // WARNING: Multiple instances of this directive could yeild unwanted results.
                        scope.$parent.$parent.ngRepeatEnd = true;
                    }
                }
            } else {
                throw 'ngRepeatEndWatch: `ngRepeat` Directive required to use this Directive';
            }
        }
    };
})

var app = angular.module("myApp", ['ngRepeatUtils']);

app.filter('rawHtml', ['$sce', function($sce) {
    return function(val) {
        return $sce.trustAsHtml(val);
    };
}]);

app.controller("partner-controller", function($scope, $http) {
    $http.get(services.partnership).success(function(resp) {
        $scope.resultPartnerShip = resp.result;
    })
});

app.controller('bannerServices-ctrl', function($scope, $http) {
    $http.get(services.bannerSevices).success(function(resp) {
        $scope.resultBanner = resp.result;
    })

    $scope.initBannerList = function() {
        UtilFunction.initBanner({
            elem: '.wrapper__banner--list',
            isPagination: true,
            item: 1,
            wrap: "circular",
            isAutoplay: true,
            controlNext: 'wrapper__banner .jcarousel-control-next',
            controlPrev: 'wrapper__banner .jcarousel-control-prev'
        });
    }
});

app.controller("eventClip-controller", function($scope, $http) {
    $http.get(services.eventVideo).success(function(resp) {
        $scope.resultEventClip = resp.result;
    })

    $scope.initFancybox = function() {
        if ($('.fancybox').length > 0) {
            $('.fancybox').fancybox({
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
    }
});


app.controller('BlogPostController', function ($scope, $http) {
    $http.get(services.listBlogpost).success(function(resp) {
        $scope.resultBlogpost = resp.result;
    });

    $scope.seoUrl = function(str) {
        str = str.replace(/^\s+|\s+$/g, ''); // trim
        str = str.toLowerCase();

        str = str.toLowerCase();
        str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
        str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
        str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
        str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
        str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
        str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
        str = str.replace(/đ/g, "d");
        str = str.replace(/!|@|\$|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\'| |\"|\&|\#|\[|\]|~/g, "-");
        str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-
        str = str.replace(/^\-+|\-+$/g, ""); //cắt bỏ ký tự - ở đầu và cuối chuỗi


        // remove accents, swap ñ for n, etc
        var from = "ãàáäâẽèéëêìíïîõòóöôùúüûñç·/_,:;";
        var to = "aaaaaeeeeeiiiiooooouuuunc------";
        for (var i = 0, l = from.length; i < l; i++) {
            str = str.replace(new RegExp(from.charAt(i), 'g'), to.charAt(i));
        }

        str = str.replace(/[^a-z0-9 -]/g, '') // remove invalid chars
            .replace(/\s+/g, '-') // collapse whitespace and replace by -
            .replace(/-+/g, '-'); // collapse dashes

        return str;
    };

});

app.controller('DetailBlogPostController', function ($scope, $http) {
    setTimeout(function () {
        var idb = window.location.pathname.split('-')[window.location.pathname.split('-').length - 1];
        $http.get(services.DetailBlogpost, { params: { id: idb } }).success(function (resp) {
            $scope.resultDetailBlogPost = resp.result;
        });
    }, 500);
});

app.controller('teamController', function($scope, $http) {
    $http.get(services.listTeam).success(function(resp) {
        $scope.resultTeam = resp.result;
    });

    $scope.initListFace = function() {
        UtilFunction.initBanner({
            elem: '.wrapper__Introduce--listFace',
            isPagination: true,
            item: 1,
            wrap: "both",
            isAutoplay: false,
            controlNext: '.wrapper__Introduce--jcarousel .jcarousel-control-next',
            controlPrev: '.wrapper__Introduce--jcarousel .jcarousel-control-prev'
        });

        setTimeout(function() {
            UtilFunction.handleClickItemFace({
                elem: '.wrapper__Introduce--listFace'
            });
        }, 50);
    }
});
