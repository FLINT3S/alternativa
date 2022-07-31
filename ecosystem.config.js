module.exports = {
    apps: [{
        script: "./ragemp-server",
        name: "alternativa",
        watch: ["dotnet", "client_packages"],
        watch_delay: 10000,
        ignore_watch : ["node_modules", "client/img"],
        max_memory_restart: '500M'
    }]
}