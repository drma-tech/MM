window.initSwiper = (id) => {
    let el = document.getElementById(id);
    if (!el) return;
    let posterSize = 150;
    let margin = 4;

    var swiper = new Swiper(el, {
        slidesPerView: 'auto',
        spaceBetween: 4,
        breakpointsBase: 'container',
        navigation:
        {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        pagination:
        {
            el: ".swiper-pagination",
            clickable: true,
        },
        breakpoints: {
            [250 - margin]: { slidesPerView: Math.floor(250 / posterSize) },
            [300 - margin]: { slidesPerView: Math.floor(300 / posterSize) },
            [350 - margin]: { slidesPerView: Math.floor(350 / posterSize) },
            [400 - margin]: { slidesPerView: Math.floor(400 / posterSize) },
            [500 - margin]: { slidesPerView: Math.floor(500 / posterSize) },
            [600 - margin]: { slidesPerView: Math.floor(600 / posterSize) },
            [700 - margin]: { slidesPerView: Math.floor(700 / posterSize) },
            [800 - margin]: { slidesPerView: Math.floor(800 / posterSize) },
            [1000 - margin]: { slidesPerView: Math.floor(1000 / posterSize) },
            [1200 - margin]: { slidesPerView: Math.floor(1200 / posterSize) },
            [1400 - margin]: { slidesPerView: Math.floor(1400 / posterSize) },
            [1600 - margin]: { slidesPerView: Math.floor(1600 / posterSize) },
            [2000 - margin]: { slidesPerView: Math.floor(2000 / posterSize) },
        },
    });
};

window.initCalendar = (id) => {
    let el = document.getElementById(id);
    if (!el) return;

    var swiper = new Swiper(el, {
        centeredSlides: true,
        lazy: true,
        navigation:
        {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        pagination:
        {
            el: ".swiper-pagination",
            clickable: true,
        }
    });
};

window.initGrid = (id) => {
    let el = document.getElementById(id);
    if (!el) return;
    let posterSize = 130;
    let margin = 4;

    var swiper = new Swiper(el, {
        slidesPerView: 'auto',
        spaceBetween: 4,
        breakpointsBase: 'container',
        grid: {
            rows: 2,
        },
        navigation:
        {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        pagination:
        {
            el: ".swiper-pagination",
            clickable: true,
        },
        breakpoints: {
            [250 - margin]: { slidesPerView: Math.floor(250 / posterSize) },
            [300 - margin]: { slidesPerView: Math.floor(300 / posterSize) },
            [350 - margin]: { slidesPerView: Math.floor(350 / posterSize) },
            [400 - margin]: { slidesPerView: Math.floor(400 / posterSize) },
            [500 - margin]: { slidesPerView: Math.floor(500 / posterSize) },
            [600 - margin]: { slidesPerView: Math.floor(600 / posterSize) },
            [700 - margin]: { slidesPerView: Math.floor(700 / posterSize) },
            [800 - margin]: { slidesPerView: Math.floor(800 / posterSize) },
            [1000 - margin]: { slidesPerView: Math.floor(1000 / posterSize) },
            [1200 - margin]: { slidesPerView: Math.floor(1200 / posterSize) },
            [1400 - margin]: { slidesPerView: Math.floor(1400 / posterSize) },
            [1600 - margin]: { slidesPerView: Math.floor(1600 / posterSize) },
            [2000 - margin]: { slidesPerView: Math.floor(2000 / posterSize) },
        },
    });
};