window.browser = window.bowser.getParser(window.navigator.userAgent);

export const isBot =
    /google|baidu|bingbot|duckduckbot|teoma|slurp|yandex|toutiao|bytespider|applebot/i.test(
        navigator.userAgent
    );

// supports WebAssembly SIMD
export const isOldBrowser = window.browser.satisfies({
    chrome: "<91",
    edge: "<91",
    safari: "<16.4",
});
// validate only if it's a webapp
export const isBotBrowser = window.browser.satisfies({
    chrome: "<134", //feb 2025
});
export const isLocalhost = location.host.includes("localhost");
export const isDev = location.hostname.includes("dev.");
export const isWebview = /webtonative/i.test(navigator.userAgent);
export const isPrintScreen = location.href.includes("printscreen");
export let appVersion = "loading";

fetch("/build-date.txt")
    .then((r) => r.text())
    .then((text) => {
        appVersion = text.trim();
    }).catch(() => {
        appVersion = "version-error";
    });

export const servicesConfig = {
    AnalyticsCode: "G-P7B5BSBS9S",
    ClarityKey: "r3z34efopo",
    UserBackToken: "A-A2J4M5NKCbDp1QyQe7ogemmmq",
    UserBackSurveyKey: "kcyhCB",
    SentryDsn: "https://ed1ba47e2afd2ee2d3425e67475ac829@o4510938040041472.ingest.us.sentry.io/4510942977523712",
};

export const firebaseConfig = {
    apiKey: "AIzaSyB2EgEuxbPvK5KMS0v7xWI-HepzaIe0h1c",
    authDomain: "auth.modern-matchmaker.com",
    projectId: "modern-matchmaker-a5b31",
    storageBucket: "modern-matchmaker-a5b31.firebasestorage.app",
    messagingSenderId: "224690707146",
    messagingKey: "BE_cSKMuRPksKGllUQI1ekC_H-Brf6txxHUuLZnG3mYKSvlevJaoWO6S7gWYlXy3vLeIeF3eEzPIP5E1EzHACUo",
    appId: "1:224690707146:web:1a1b235112b69cbaabf233",
    measurementId: "G-ZKC5YQW77C",
};

export const supabaseConfig = {
    projectUrl: "https://rwabygidcrhbnvigfwff.supabase.co",
    supabaseKey: "sb_publishable_pCufBP2wD58v_mRqfzbV7w_V4scD058",
};

export const baseApiUrl = isLocalhost ? "http://localhost:7091" : "";

// Disable robots for dev environment
if (isDev) {
    const meta = document.createElement("meta");
    meta.name = "robots";
    meta.content = "noindex, nofollow";
    document.head.appendChild(meta);
}

// temporary: remove in the end of 2026
if (typeof Promise.withResolvers !== "function") {
    Promise.withResolvers = function () {
        let resolve, reject;
        const promise = new Promise((res, rej) => {
            resolve = res;
            reject = rej;
        });
        return { promise, resolve, reject };
    };
}
