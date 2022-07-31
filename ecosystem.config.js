module.exports = {
    apps: [{
        script: "./ragemp-server",
        name: "alternativa",
        watch: true,
        watch_delay: 5000,
        max_memory_restart: '500M',
        max_restarts: 300,
        cwd: "/var/www/alternativa/",
        error_file: "/var/www/alternativa/logs/error.log",
        out_file: "/var/www/alternativa/logs/out.log",
    }]
}