
//
/********************* Client-Slider js ************************/
//
function initSwiper2() {
    var swiper = new Swiper(".homeslider", {
        spaceBetween: 30,
        loop: true,
        effect: "fade",
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
    });
}
