module.exports = {
    apps: [{
        script: "./ragemp-server.exe",
        name: "alternativa",
        watch: ["dotnet", "client_packages"],
        restart_delay: 2000,
        ignore_watch: ["\.git", ".*\.git*", "logs", ".*\.listcache", ".*\/node_modules", ".listcache", "\.listcache", ".git", "client_packages/.listcache", "*\.cs"]
    }]
}
