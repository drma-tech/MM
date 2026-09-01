"use strict";

const ua = navigator.userAgent;
window.browser = window.bowser?.getParser ? window.bowser.getParser(ua) : null;
const botUAs = ["google", "baidu", "bingbot", "duckduckbot", "teoma", "slurp", "yandex", "toutiao", "bytespider", "applebot", "crawler"];
const isBot = botUAs.some(bot => ua.toLowerCase().includes(bot)) || navigator.webdriver;

function testBrowserVersion(rules, ignore = false, fallback = false) {
    if (ignore) return false;

    if (!window.browser) return fallback;

    try {
        return window.browser.satisfies(rules);
    } catch {
        return fallback;
    }
}

const wasmSupported = typeof WebAssembly === "object";
const isLocalhost = window.location.hostname === "localhost";
const isPrerendering = window.location.hostname === "127.0.0.1"
const isDev = location.hostname.includes("develop");
const isWebview = /webtonative/i.test(ua);
const isPrintScreen = location.href.includes("printscreen");

//SIMD can be disabled by the browser if the hardware doesn't support it, so you have to test it in practice rather than just checking the browser version.
function supportsWasmSimd() {
    if (typeof WebAssembly === "undefined") return false;
    const bytes = new Uint8Array([
        0x00, 0x61, 0x73, 0x6d, 0x01, 0x00, 0x00, 0x00,
        0x01, 0x05, 0x01, 0x60, 0x00, 0x01, 0x7b,
        0x03, 0x02, 0x01, 0x00,
        0x0a, 0x0a, 0x01, 0x08, 0x00, 0x41, 0x00, 0xfd, 0x0f, 0xfd, 0x62, 0x0b
    ]);
    return WebAssembly.validate(bytes);
}

//The browser does not support WASM or SIMD.
const blazorSupported = wasmSupported && supportsWasmSimd();

//probably a bot, so doesnt support sw
const disableServiceWorker = testBrowserVersion(
    {
        chrome: "<134", //special case (usually bots)
        edge: "<91", //may 21
        firefox: "<89", //may 21
        safari: "<16.4", //mar 23
        opera: "<77", //jun 21
    },
    isWebview,
    true // uncertain environment → disable
);

const servicesConfig = {
    AnalyticsCode: "G-P7B5BSBS9S",
    ClarityKey: "r3z34efopo",
    UserBackToken: "A-A2J4M5NKCbDp1QyQe7ogemmmq",
    SentryDsn: "https://ed1ba47e2afd2ee2d3425e67475ac829@o4510938040041472.ingest.us.sentry.io/4510942977523712",
};

const supabaseConfig = {
    projectUrl: "https://bbvdyzbbvsffyvnktlno.supabase.co",
    supabaseKey: "sb_publishable_5QUdGWH9m1rHAWYehPoivQ_TrEnJeIO",
};

const clerkConfig = {
    devPk: "pk_test_cGlja2VkLXJlZGZpc2gtMjMxOS5jbGVyay5hY2NvdW50cy5kZXYk",
    prdPk: "pk_live_Y2xlcmsubW9kZXJuLW1hdGNobWFrZXIuY29tJA",
};

const baseApiUrl = isLocalhost ? "http://localhost:7091" : "";

window.appConfig = {
    isBot,
    blazorSupported,
    disableServiceWorker,
    isLocalhost,
    isPrerendering,
    isDev,
    isWebview,
    isPrintScreen,
    servicesConfig,
    supabaseConfig,
    clerkConfig,
    baseApiUrl
};
