module.exports = {
    apps: [{
        script: "./ragemp-server",
        name: "alternativa",
        watch: true,
        watch_delay: 5000,
        max_memory_restart: '500M',
        max_restarts: 100,
        cwd: "/var/www/alternativa/"
    }]
}