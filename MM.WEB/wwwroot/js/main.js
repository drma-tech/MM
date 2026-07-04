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

//browser versions not compatible with SIMD
const hideBlazorIndex = testBrowserVersion(
    {
        chrome: "<91", //may 21
        edge: "<91", //may 21
        firefox: "<89", //may 21
        safari: "<16.4", //mar 23
        opera: "<77", //jun 21
    },
    /Mediapartners-Google/i.test(ua),
    false // uncertain environment → allow
);

//probably a bot, so doesnt support sw
const disableServiceWorker = testBrowserVersion(
    {
        chrome: "<134", //special case (usually bots)
        edge: "<91", //may 21
        firefox: "<89", //may 21
        safari: "<16.4", //mar 23
        opera: "<77", //jun 21
    },
    false,
    true // uncertain environment → disable
);

const isLocalhost = window.location.hostname === "localhost";
const isPrerendering = window.location.hostname === "127.0.0.1"
const isDev = location.hostname.includes("develop");
const isWebview = /webtonative/i.test(ua);
const isPrintScreen = location.href.includes("printscreen");

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

const baseApiUrl = isLocalhost ? "http://localhost:7091" : "";

window.appConfig = {
    isBot,
    hideBlazorIndex,
    disableServiceWorker,
    isLocalhost,
    isPrerendering,
    isDev,
    isWebview,
    isPrintScreen,
    servicesConfig,
    supabaseConfig,
    baseApiUrl
};
