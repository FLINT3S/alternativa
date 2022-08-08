module.exports = {
    apps: [{
        script: "./ragemp-server",
        name: "alternativa",
        watch: true,
        watch_delay: 5000,
        max_memory_restart: '500M',
        max_restarts: 300,
        cwd: "/home/alternativa/alternativa/",
        error_file: "/home/alternativa/alternativa/logs/error.log",
        out_file: "home/alternativa/alternativa/logs/out.log",
        cron_restart: '0 */5 * * *'
    }]
}