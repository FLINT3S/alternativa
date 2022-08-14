const path = require("path");


module.exports = {
    publicPath: process.env.NODE_ENV === "production" ? "./" : "/",
    pages: {
        "settings-panel": {
            title: "Settings Panel",
            entry: "src/modules/settings-panel/main.ts",
            filename: "settings-panel.html",
            template: "public/index.html"
        },
        "admin-panel": {
            title: "Admin Panel",
            entry: "src/modules/admin-panel/main.ts",
            filename: "admin-panel.html",
            template: "public/index.html"
        },
        "Authorization": {
            title: "Authorization",
            entry: "src/modules/authorization/main.ts",
            filename: "authorization.html",
            template: "public/index.html"
        }
    },
    outputDir: path.resolve(__dirname, "..", "..", "..", "client_packages", "web_packages"),
}
