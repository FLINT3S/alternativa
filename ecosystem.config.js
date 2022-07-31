module.exports = {
    apps: [{
        script: "./rage-server",
        name: "alternativa",
        watch: ["dotnet", "client_packages"],
        watch_delay: 10000,
        ignore_watch : ["node_modules", "client/img"],
    }]
}