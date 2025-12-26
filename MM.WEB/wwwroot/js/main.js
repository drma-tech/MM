window.browser = window.bowser.getParser(window.navigator.userAgent);

export const isBot =
    navigator.webdriver === true ||
    /google|baidu|bingbot|duckduckbot|teoma|slurp|yandex|toutiao|bytespider|applebot/i.test(
        navigator.userAgent
    );

/// avoid bots with fake browsers
export const isOldBrowser = window.browser.satisfies({
    chrome: "<132", //jan 2025
    edge: "<132", //jan 2025
    safari: "<18.3", //jan 2025
});
export const isLocalhost = location.host.includes("localhost");
export const isDev = location.hostname.includes("dev.");
export const isWebview = /webtonative/i.test(navigator.userAgent);
export const isPrintScreen = location.href.includes("printscreen");
export const appVersion = (
    await fetch("/build-date.txt")
        .then((r) => r.text())
        .catch(() => "version-error")
).trim();

export const servicesConfig = {
    AnalyticsCode: "G-P7B5BSBS9S",
    ClarityKey: "r3z34efopo",
    UserBackToken: "A-A2J4M5NKCbDp1QyQe7ogemmmq",
    UserBackSurveyKey: "kcyhCB",
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

export const baseApiUrl = isLocalhost ? "http://localhost:7091" : "";
