module.exports = {
    apps: [{
        script: "./ragemp-server.exe",
        name: "alternativa",
        watch: ["dotnet", "client_packages"],
        ignore_watch: ["\.git", ".*\.git*", "logs", ".*\.listcache", ".*\/obj", ".*\/node_modules", ".listcache", "\.listcache", ".git", "client_packages/.listcache"]
    }]
}