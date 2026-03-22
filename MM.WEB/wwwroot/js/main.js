const ua = navigator.userAgent;

window.browser = window?.bowser?.getParser
    ? window.bowser.getParser(ua)
    : null;

export const isBot =
    /google|baidu|bingbot|duckduckbot|teoma|slurp|yandex|toutiao|bytespider|applebot/i.test(
        ua
    );

function safeSatisfies(rules) {
    if (/Mediapartners-Google/i.test(ua)) return false; //It doesn't load packages, but it uses an updated version of Chrome.
    return window.browser.satisfies(rules);
}

export const noSimdSupport = safeSatisfies({
    chrome: "<91",
    edge: "<91",
    firefox: "<89",
    safari: "<16.4",
    opera: "<77",
});
export const isBotBrowser = window.browser.satisfies({
    chrome: "<134", //feb 2025
});
export const isLocalhost = location.host.includes("localhost");
export const isDev = location.hostname.includes("dev.");
export const isWebview = /webtonative/i.test(ua);
export const isPrintScreen = location.href.includes("printscreen");

export const servicesConfig = {
    AnalyticsCode: "G-P7B5BSBS9S",
    ClarityKey: "r3z34efopo",
    UserBackToken: "A-A2J4M5NKCbDp1QyQe7ogemmmq",
    SentryDsn: "https://ed1ba47e2afd2ee2d3425e67475ac829@o4510938040041472.ingest.us.sentry.io/4510942977523712",
};

export const supabaseConfig = {
    projectUrl: "https://bbvdyzbbvsffyvnktlno.supabase.co",
    supabaseKey: "sb_publishable_5QUdGWH9m1rHAWYehPoivQ_TrEnJeIO",
};

export const baseApiUrl = isLocalhost ? "http://localhost:7091" : "";

// Disable robots for dev environment
if (isDev) {
    const meta = document.createElement("meta");
    meta.name = "robots";
    meta.content = "noindex, nofollow";
    document.head.appendChild(meta);
}