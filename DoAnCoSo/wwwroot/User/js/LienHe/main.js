$(document).ready(function($) {
    awe_backtotop();
    awe_category();
    $('#trigger-mobile, #evo-trigger-mobile, #evo-trigger-mobile2, #evo-trigger-mobile3').click(function() {
        $(".mobile-main-menu").toggleClass('active');
        $(".backdrop__body-backdrop___1rvky").addClass('active');
    });
    $('.evo-header-cart').click(function() {
        $(".cart_sidebar").toggleClass('active');
        $(".backdrop__body-backdrop___1rvky").addClass('active');
    });
    $('.backdrop__body-backdrop___1rvky, .evo-close-menu, .cart_btn-close, .search_close').click(function() {
        $("body").removeClass('show-search');
        $(".mobile-main-menu, .cart_sidebar, .evo_sidebar_search").removeClass('active');
        $(".backdrop__body-backdrop___1rvky").removeClass('active');
    });
    $(".backdrop__body-backdrop___1rvky").removeClass('active');
    $('.ng-has-child1 a .svg1').on('click', function(e) {
        e.preventDefault();
        var $this = $(this);
        $this.parents('.ng-has-child1').find('.ul-has-child1').stop().slideToggle();
        $(this).toggleClass('active');
        return false;
    });
    $('.ng-has-child1 .ul-has-child1 .ng-has-child2 a .svg2').on('click', function(e) {
        e.preventDefault();
        var $this = $(this);
        $this.parents('.ng-has-child1 .ul-has-child1 .ng-has-child2').find('.ul-has-child2').stop().slideToggle();
        $(this).toggleClass('active');
        return false;
    });
    if ($('.cart_body>div').length == '0') {
        $('.cart-footer').hide();
        jQuery('<div class="cart-empty">' + '<span class="empty-icon"><i class="ico ico-cart"></i></span>' + '<div class="btn-cart-empty">' + '<a class="btn btn-default" href="/" title="Tiáº¿p tá»¥c mua hÃ ng">Tiáº¿p tá»¥c mua hÃ ng</a>' + '</div>' + '</div>').appendTo('.cart_body');
    };
    $(".rte table").wrap("<div class='table-responsive'></div>");
    $('.full-footer .footer-coll-title').on('click', function(e) {
        e.preventDefault();
        var $this = $(this);
        $this.parents('.full-footer').find('.col-footer-show').stop().slideToggle();
        $(this).toggleClass('active');
        return false;
    });
});
$(document).on('click', '.overlay, .close-popup, .btn-continue, .fancybox-close', function() {
    hidePopup('.awe-popup');
    setTimeout(function() {
        $('.loading').removeClass('loaded-content');
    }, 500);
    return false;
})

function awe_showNoitice(selector) {
    $(selector).animate({
        right: '0'
    }, 500);
    setTimeout(function() {
        $(selector).animate({
            right: '-300px'
        }, 500);
    }, 3500);
}
window.awe_showNoitice = awe_showNoitice;

function awe_showLoading(selector) {
    var loading = $('.loader').html();
    $(selector).addClass("loading").append(loading);
}
window.awe_showLoading = awe_showLoading;

function awe_hideLoading(selector) {
    $(selector).removeClass("loading");
    $(selector + ' .loading-icon').remove();
}
window.awe_hideLoading = awe_hideLoading;

function awe_showPopup(selector) {
    $(selector).addClass('active');
}
window.awe_showPopup = awe_showPopup;

function awe_hidePopup(selector) {
    $(selector).removeClass('active');
}
window.awe_hidePopup = awe_hidePopup;

function awe_convertVietnamese(str) {
    str = str.toLowerCase();
    str = str.replace(/Ã |Ã¡|áº¡|áº£|Ã£|Ã¢|áº§|áº¥|áº­|áº©|áº«|Äƒ|áº±|áº¯|áº·|áº³|áºµ/g, "a");
    str = str.replace(/Ã¨|Ã©|áº¹|áº»|áº½|Ãª|á»|áº¿|á»‡|á»ƒ|á»…/g, "e");
    str = str.replace(/Ã¬|Ã­|á»‹|á»‰|Ä©/g, "i");
    str = str.replace(/Ã²|Ã³|á»|á»|Ãµ|Ã´|á»“|á»‘|á»™|á»•|á»—|Æ¡|á»|á»›|á»£|á»Ÿ|á»¡/g, "o");
    str = str.replace(/Ã¹|Ãº|á»¥|á»§|Å©|Æ°|á»«|á»©|á»±|á»­|á»¯/g, "u");
    str = str.replace(/á»³|Ã½|á»µ|á»·|á»¹/g, "y");
    str = str.replace(/Ä‘/g, "d");
    str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, "-");
    str = str.replace(/-+-/g, "-");
    str = str.replace(/^\-+|\-+$/g, "");
    return str;
}
window.awe_convertVietnamese = awe_convertVietnamese;

function awe_category() {
    $('.nav-category .Collapsible__Plus').click(function(e) {
        $(this).parent().toggleClass('active');
    });
}
window.awe_category = awe_category;

function awe_backtotop() {
    if ($('.back-to-top').length) {
        var scrollTrigger = 100,
            backToTop = function() {
                var scrollTop = $(window).scrollTop();
                if (scrollTop > scrollTrigger) {
                    $('.back-to-top').addClass('show');
                } else {
                    $('.back-to-top').removeClass('show');
                }
            };
        backToTop();
        $(window).on('scroll', function() {
            backToTop();
        });
        $('.back-to-top').on('click', function(e) {
            e.preventDefault();
            $('html,body').animate({
                scrollTop: 0
            }, 700);
        });
    }
}
window.awe_backtotop = awe_backtotop;
$('.btn-close').click(function() {
    $(this).parents('.dropdown').toggleClass('open');
});
$(document).on('keydown', '#qty, #quantity-detail, .number-sidebar, .number-phone', function(e) {
    -1 !== $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) || /65|67|86|88/.test(e.keyCode) && (!0 === e.ctrlKey || !0 === e.metaKey) || 35 <= e.keyCode && 40 >= e.keyCode || (e.shiftKey || 48 > e.keyCode || 57 < e.keyCode) && (96 > e.keyCode || 105 < e.keyCode) && e.preventDefault()
});
var buy_now = function(id) {
    var quantity = 1;
    var params = {
        type: 'POST',
        url: '/cart/add.js',
        data: 'quantity=' + quantity + '&variantId=' + id,
        dataType: 'json',
        success: function(line_item) {
            window.location = '/checkout';
        },
        error: function(XMLHttpRequest, textStatus) {
            Bizweb.onError(XMLHttpRequest, textStatus);
        }
    };
    jQuery.ajax(params);
}
window.theme = window.theme || {};
theme.wishlist = (function() {
    var wishlistButtonClass = '.js-btn-wishlist',
        wishlistRemoveButtonClass = '.js-remove-wishlist',
        $wishlistCount = $('.js-wishlist-count'),
        $wishlistContainer = $('.js-wishlist-content'),
        $wishlistSmall = $('.wish-list-small'),
        wishlistViewAll = $('.wish-list-button-all'),
        wishlistObject = JSON.parse(localStorage.getItem('localWishlist')) || [],
        wishlistPageUrl = $('.js-wishlist-link').attr('href'),
        loadNoResult = function() {
            $wishlistContainer.html('<div class="col text-center"><div class="alert alert-warning d-inline-block"><h3>Sáº£n pháº©m nÃ o cá»§a chÃºng tÃ´i báº¡n mong muá»‘n sá»Ÿ há»¯u nháº¥t?</h3><p>HÃ£y thÃªm vÃ o danh sÃ¡ch sáº£n pháº©m yÃªu thÃ­ch ngay nhÃ©!</p></div></div>');
            $wishlistSmall.html('<div class="empty-description"><span class="empty-icon"><i class="ico ico-favorite-heart"></i></span><div class="empty-text"><h3>Sáº£n pháº©m nÃ o cá»§a chÃºng tÃ´i báº¡n mong muá»‘n sá»Ÿ há»¯u nháº¥t?</h3><p>HÃ£y thÃªm vÃ o danh sÃ¡ch sáº£n pháº©m yÃªu thÃ­ch ngay nhÃ©!</p></div></div><style>.container--wishlist .js-wishlist-content{border:none;}</style>');
            wishlistViewAll.addClass('d-none');
        };

    function loadWishlist() {
        $wishlistContainer.html('');
        if (wishlistObject.length > 0) {
            var recentview_wishlist = [];
            for (var i = 0; i < wishlistObject.length; i++) {
                var productHandle = wishlistObject[i];
                for (var i = 0; i < wishlistObject.length; i++) {
                    var productHandle = wishlistObject[i];
                    var wishlist = new Promise(function(resolve, reject) {
                        $.ajax({
                            url: '/' + productHandle + '?view=wishlist',
                            success: function(product) {
                                resolve(product);
                            },
                            error: function(err) {
                                resolve('');
                            }
                        })
                    });
                    recentview_wishlist.push(wishlist);
                }
                Promise.all(recentview_wishlist).then(function(values) {
                    $.each(values, function(i, v) {
                        $('.js-wishlist-content').append(v);
                    });
                    awe_lazyloadImage();
                    $(".evo-product-block-item .thumbs-list .thumbs-list-item img").click(function() {
                        var t = $(this).attr("data-img");
                        $(this).parent().siblings().removeClass("active"), $(this).parent().addClass("active");
                        var e = $(this).parents(".evo-product-block-item ").find(".evo-image-pro img");
                        e && $(e).attr("src", t);
                    });
                });
            }
        } else {
            loadNoResult();
        }
        $wishlistCount.text(wishlistObject.length);
        $(wishlistButtonClass).each(function() {
            var productHandle = $(this).data('handle');
            var iconWishlist = $.inArray(productHandle, wishlistObject) !== -1 ? "ÄÃ£ yÃªu thÃ­ch" : "YÃªu thÃ­ch";
            var textWishlist = $.inArray(productHandle, wishlistObject) !== -1 ? "Äáº¿n trang sáº£n pháº©m yÃªu thÃ­ch" : "ThÃªm vÃ o yÃªu thÃ­ch";
            $(this).html(iconWishlist).attr('title', textWishlist);
        });
    }

    function updateWishlist(self) {
        var productHandle = $(self).data('handle'),
            allSimilarProduct = $(wishlistButtonClass + '[data-handle="' + productHandle + '"]');
        var isAdded = $.inArray(productHandle, wishlistObject) !== -1 ? true : false;
        if (isAdded) {
            // go to wishlist page
            window.location.href = wishlistPageUrl;
        } else {
            wishlistObject.push(productHandle);
            allSimilarProduct.fadeOut('slow').fadeIn('fast').html(theme.strings.wishlistIconAdded)
            $('.tooltip-inner').text(theme.strings.wishlistTextAdded);
        }
        localStorage.setItem('localWishlist', JSON.stringify(wishlistObject));
        $wishlistCount.text(wishlistObject.length);
    };
    $(document).on('click', wishlistButtonClass, function(event) {
        event.preventDefault();
        updateWishlist(this);
    });
    $(document).on('click', wishlistRemoveButtonClass, function() {
        var productHandle = $(this).data('handle'),
            allSimilarProduct = $(wishlistButtonClass + '[data-handle="' + productHandle + '"]');

        //update button
        allSimilarProduct.html(theme.strings.wishlistIcon)
            //update tooltip
        allSimilarProduct.attr('data-original-title', theme.strings.wishlistText);
        $('.tooltip-inner').text(theme.strings.wishlistText);
        //update Object
        wishlistObject.splice(wishlistObject.indexOf(productHandle), 1);
        localStorage.setItem('localWishlist', JSON.stringify(wishlistObject));
        // Remove element
        $(this).closest('.js-wishlist-item').fadeOut(); // or .remove()
        //count
        $wishlistCount.text(wishlistObject.length);
        if (wishlistObject.length === 0) {
            loadNoResult();
        }
    });

    loadWishlist();
    $(document).on('shopify:section:load', loadWishlist);
    return {
        load: loadWishlist
    }
})()
theme.compare = (function() {
    var compareButtonClass = '.js-btn-compare',
        compareRemoveButtonClass = '.js-remove-compare',
        $compareShowButton = $('.site-header__compare'),
        $compareCount = $('.js-compare-count'),
        $compareContainer = $('.js-compare-content'),
        $compareProduct = $('.compare-product'),
        $compareSpecification = $('.compare-specification'),
        compareObject = JSON.parse(localStorage.getItem('localCompare')) || [],
        alertClass = 'alert-success',
        evoCheckProductType = '',
        evoDefaultProductType = '';

    function updateCompare(self) {
        var productHandle = $(self).data('handle'),
            productType = $(self).data('type'),
            alertText = '';
        var isAdded = $.inArray(productHandle, compareObject) !== -1 ? true : false;
        evoCheckProductType = $(self).data('type');
        if (isAdded) {
            compareObject.splice(compareObject.indexOf(productHandle), 1);
            alertText = 'ÄÃ£ xÃ³a khá»i dÃ¡nh sÃ¡ch so sÃ¡nh';
            alertClass = 'alert-success';
        } else {
            if (compareObject.length === 3) {
                alertText = 'So sÃ¡nh tá»‘i Ä‘a 3 sáº£n pháº©m';
                alertClass = 'alert-danger';
            } else {
                if (evoDefaultProductType == '') {
                    alertClass = 'alert-success';
                    compareObject.push(productHandle);
                    alertText = 'ÄÃ£ thÃªm vÃ o danh sÃ¡ch so sÃ¡nh';
                } else {
                    if (evoDefaultProductType != evoCheckProductType) {
                        alertText = 'Sáº£n pháº©m so sÃ¡nh pháº£i cÃ¹ng loáº¡i';
                        alertClass = 'alert-danger';
                    } else {
                        alertClass = 'alert-success';
                        compareObject.push(productHandle);
                        alertText = 'ÄÃ£ thÃªm vÃ o danh sÃ¡ch so sÃ¡nh';
                    }
                }
            }
        }
        localStorage.setItem('localCompare', JSON.stringify(compareObject));
        theme.alert.new('So sÃ¡nh sáº£n pháº©m', alertText, 3000, alertClass);
        $compareCount.text(compareObject.length);
        var evoFirstCompareProductHandle = compareObject[0];
        Bizweb.getProduct(evoFirstCompareProductHandle, function(product) {
            evoDefaultProductType = product.product_type;
        });
    };

    function loadCompare() {
        var compareGrid;
        //$compareContainer.html('');
        $compareProduct.html('');
        $compareSpecification.html('');
        if (compareObject.length > 0) {
            $compareShowButton.removeClass('d-none');
            compareGrid = compareObject.length === 1 ? 'col' : 'col';
            for (var i = 0; i < compareObject.length; i++) {
                var productHandle = compareObject[i];
                Bizweb.getProduct(productHandle, function(product) {
                    var htmlProduct = '',
                        htmlSpecification = '',
                        productComparePrice = Intl.NumberFormat('vi-VN', {
                            style: 'currency',
                            currency: 'VND'
                        }).format(product.variants[0].compare_at_price),
                        productAvailable = product.available ? "CÃ²n hÃ ng" : "Háº¿t hÃ ng",
                        productAvailableClass = product.available ? 'alert-success' : 'alert-danger',
                        productVendorHTML = product.vendor !== null ? '<a href="/collections/vendors?q=' + product.vendor + '">' + product.vendor + '</a>' : '<span>Äang cáº­p nháº­t</span>';
                    if (product.featured_image != null) {
                        var src = Bizweb.resizeImage(product.featured_image, 'large');
                    } else {
                        var src = "//bizweb.dktcdn.net/thumb/large/assets/themes_support/noimage.gif";
                    }
                    if (product.variants[0].price > 0) {
                        var productPrice = Intl.NumberFormat('vi-VN', {
                            style: 'currency',
                            currency: 'VND'
                        }).format(product.variants[0].price);
                    } else {
                        var productPrice = "LiÃªn há»‡";
                    }
                    if (product.content != null) {
                        var productContent = product.content;
                        if (productContent.includes('---')) {
                            var productMainContent = productContent.split('---')[1];
                            if (productMainContent.includes('h5')) {
                                var productMainContent = productMainContent.split('<h5>')[0];
                                if (productMainContent.includes('h6')) {
                                    var productMainContent = productMainContent.split('<h6>')[1];
                                } else {
                                    var productMainContent = productMainContent.split('<h5>')[0];
                                }
                            } else {
                                var productMainContent = productContent.split('---')[1];
                            }
                        } else {
                            var productMainContent = "<div class='no-content'>Ná»™i dung Ä‘ang cáº­p nháº­t</div>";
                        }
                    } else {
                        var productMainContent = "<div class='no-content'>Ná»™i dung Ä‘ang cáº­p nháº­t</div>";
                    }
                    htmlProduct += '<div class="compare-item ' + compareGrid + ' col-6 col-lg-3 col-md-4 padding-2"></div>';
                    htmlProduct += '<div class="compare-item ' + compareGrid + ' col-6 col-lg-3 col-md-4 padding-2">';
                    htmlProduct += ' <div class="compage-image"><button class="js-remove-compare" data-handle="' + product.alias + '" title="XÃ³a"><span>x</span></button>';
                    htmlProduct += ' <a href="' + product.url + '" title="' + product.name + '">';
                    htmlProduct += ' <img src="' + src + '" alt="' + product.name + '" />';
                    htmlProduct += ' </a></div>';
                    htmlProduct += ' <h5><a href="' + product.url + '" title="' + product.name + '">' + product.name + '</a></h5>';
                    htmlProduct += ' <div class="group-price"><span class="price"> ' + productPrice + '</span>';
                    if (product.variants[0].compare_at_price > product.variants[0].price) {
                        htmlProduct += ' <s class="old-price">' + productComparePrice + '</s></div>';
                    }
                    htmlProduct += '<div class="clearfix"></div><span class=' + productAvailableClass + '> ' + productAvailable + '</span>';
                    htmlProduct += '</div>';
                    $compareProduct.append(htmlProduct);
                    htmlSpecification += '<div class="compare-item ' + compareGrid + ' col-6 col-lg-3 col-md-4 padding-2">';
                    htmlSpecification += productMainContent.replace("ThÃ´ng sá»‘ ká»¹ thuáº­t", "");
                    htmlSpecification += '</div>';
                    $compareSpecification.append(htmlSpecification);
                    $('.compare-specification h6, .compare-specification p').remove();
                });
            }
            var evoFirstCompareProductHandle = compareObject[0];
            Bizweb.getProduct(evoFirstCompareProductHandle, function(product) {
                evoDefaultProductType = product.product_type;
                var countcomparecell = $('.compare-specification .compare-item:nth-child(1) table tr').length;
                for (var i = 1; i <= countcomparecell; i++) {
                    var height1 = $(".compare-specification .compare-item:nth-child(1) table tr:nth-child(" + i + ")").height();
                    var height2 = $(".compare-specification .compare-item:nth-child(2) table tr:nth-child(" + i + ")").height();
                    var height3 = $(".compare-specification .compare-item:nth-child(3) table tr:nth-child(" + i + ")").height();
                    var setHeight = Math.max(height1, height2, height3);
                    $(".compare-specification .compare-item:nth-child(1) table tr:nth-child(" + i + ")").height(setHeight);
                    $(".compare-specification .compare-item:nth-child(2) table tr:nth-child(" + i + ")").height(setHeight);
                    $(".compare-specification .compare-item:nth-child(3) table tr:nth-child(" + i + ")").height(setHeight);
                }
            });
        } else {
            $compareContainer.html('<div class="alert alert-warning margin-10">Vui lÃ²ng chá»n sáº£n pháº©m Ä‘á»ƒ so sÃ¡nh</div>');
            $compareShowButton.addClass('d-none');
            evoDefaultProductType = '';
        }
        $(compareButtonClass).each(function() {
            var productHandle = $(this).data('handle');
            var status = $.inArray(productHandle, compareObject) !== -1 ? 'added' : '';
            $(this).removeClass('added').addClass(status);
        });
        $compareCount.text(compareObject.length);
    }
    $(document).on('click', compareButtonClass, function(event) {
        event.preventDefault();
        updateCompare(this);
        loadCompare();
    });
    $(document).on('click', compareRemoveButtonClass, function() {
        var productHandle = $(this).data('handle');
        compareObject.splice(compareObject.indexOf(productHandle), 1);
        localStorage.setItem('localCompare', JSON.stringify(compareObject));
        loadCompare();
    });
    loadCompare();
    $(document).on('Bizweb:section:load', loadCompare);
    return {
        load: loadCompare
    }
})()
theme.alert = (function() {
    var $alert = $('#js-global-alert'),
        $title = $('#js-global-alert .alert-heading'),
        $content = $('#js-global-alert .alert-content'),
        close = '#js-global-alert .close';
    $(document).on('click', close, function() {
        $alert.removeClass('active');
    });

    function createAlert(title, mess, time, type) {
        var alertTitle = title || '',
            showTime = time || 3000,
            alertClass = type || 'alert-success';
        $alert.removeClass('alert-success').removeClass('alert-danger').removeClass('alert-warning')
        $alert.addClass(alertClass);
        $title.html(title);
        $content.html(mess);
        $alert.addClass('active');
        setTimeout(function() {
            $alert.removeClass('active');
        }, showTime);
    }
    return {
        new: createAlert
    }
})()
theme.strings = {
    wishlistNoResult: "<h3>Sáº£n pháº©m nÃ o cá»§a chÃºng tÃ´i báº¡n mong muá»‘n sá»Ÿ há»¯u nháº¥t?</h3><p>HÃ£y thÃªm vÃ o danh sÃ¡ch sáº£n pháº©m yÃªu thÃ­ch ngay nhÃ©!</p>",
    wishlistIcon: "YÃªu thÃ­ch",
    wishlistIconAdded: "ÄÃ£ yÃªu thÃ­ch",
    wishlistText: "ThÃªm vÃ o yÃªu thÃ­ch",
    wishlistTextAdded: "Äáº¿n trang sáº£n pháº©m yÃªu thÃ­ch",
    wishlistRemove: "XÃ³a",
    compareNoResult: "Vui lÃ²ng chá»n sáº£n pháº©m Ä‘á»ƒ so sÃ¡nh",
    compareIcon: "<svg version='1.1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' x='0px' y='0px' viewBox='0 0 477.867 477.867' style='enable-background:new 0 0 477.867 477.867;' xml:space='preserve'><path d='M409.6,0c-9.426,0-17.067,7.641-17.067,17.067v62.344C304.667-5.656,164.478-3.386,79.411,84.479c-40.09,41.409-62.455,96.818-62.344,154.454c0,9.426,7.641,17.067,17.067,17.067S51.2,248.359,51.2,238.933c0.021-103.682,84.088-187.717,187.771-187.696c52.657,0.01,102.888,22.135,138.442,60.976l-75.605,25.207c-8.954,2.979-13.799,12.652-10.82,21.606s12.652,13.799,21.606,10.82l102.4-34.133c6.99-2.328,11.697-8.88,11.674-16.247v-102.4C426.667,7.641,419.026,0,409.6,0z'/><path d='M443.733,221.867c-9.426,0-17.067,7.641-17.067,17.067c-0.021,103.682-84.088,187.717-187.771,187.696c-52.657-0.01-102.888-22.135-138.442-60.976l75.605-25.207c8.954-2.979,13.799-12.652,10.82-21.606c-2.979-8.954-12.652-13.799-21.606-10.82l-102.4,34.133c-6.99,2.328-11.697,8.88-11.674,16.247v102.4c0,9.426,7.641,17.067,17.067,17.067s17.067-7.641,17.067-17.067v-62.345c87.866,85.067,228.056,82.798,313.122-5.068c40.09-41.409,62.455-96.818,62.344-154.454C460.8,229.508,453.159,221.867,443.733,221.867z'/></svg>",
    compareText: "So sÃ¡nh",
    compareRemove: "XÃ³a khá»i danh sÃ¡ch",
    compareNotifyAdded: 'ÄÃ£ thÃªm vÃ o danh sÃ¡ch so sÃ¡nh',
    compareNotifyRemoved: "ÄÃ£ xÃ³a khá»i dÃ¡nh sÃ¡ch so sÃ¡nh",
    compareNotifyMaximum: "So sÃ¡nh tá»‘i Ä‘a 4 sáº£n pháº©m",
};