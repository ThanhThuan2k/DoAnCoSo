$(document).ready(function($) {
    var galleryThumbs = new Swiper('.gallery-thumbs', {
        spaceBetween: 0,
        slidesPerView: 5,
        freeMode: true,
        watchSlidesVisibility: true,
        watchSlidesProgress: true,
        breakpoints: {
            319: {
                slidesPerView: 3
            },
            640: {
                slidesPerView: 3
            },
            768: {
                slidesPerView: 5
            },
            1024: {
                slidesPerView: 5
            },
        }
    });
    var galleryTop = new Swiper('.gallery-top', {
        spaceBetween: 0,
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        thumbs: {
            swiper: galleryThumbs
        },
        autoplay: {
            delay: 4000,
            disableOnInteraction: false,
        },
    });
    var swiper = new Swiper('.evo-owl-product', {
        slidesPerView: 4,
        spaceBetween: 0,
        slidesPerGroup: 2,
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        breakpoints: {
            300: {
                slidesPerView: 2
            },
            500: {
                slidesPerView: 2
            },
            640: {
                slidesPerView: 2
            },
            768: {
                slidesPerView: 3
            },
            1024: {
                slidesPerView: 5
            },
        }
    });
    if (document.querySelector('.news-carousel')) {
        let SwiperTop = new Swiper('.news-carousel', {
            spaceBetween: 0,
            centeredSlides: false,
            speed: 8000,
            autoplay: {
                delay: 1,
            },
            loop: true,
            slidesPerView: '1',
            allowTouchMove: true,
            disableOnInteraction: true
        });
    }
});