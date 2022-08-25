const path = require("path");


module.exports = {
    publicPath: process.env.NODE_ENV === "production" ? "./" : "/",
    pages: {
        "SettingsPanel": {
            title: "Settings Panel",
            entry: "src/modules/settings-panel/main.ts",
            filename: "settings-panel.html",
            template: "public/index.html"
        },
        "AdminPanel": {
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
        },
        "CharacterManager": {
            title: "CharacterManager",
            entry: "src/modules/character-manager/main.ts",
            filename: "character-manager.html",
            template: "public/index.html"
        }
    },
    outputDir: path.resolve(__dirname, "..", "..", "..", "client_packages", "web_packages"),
}
