const path = require("path");
const webpack = require("webpack");
const CircularDependencyPlugin = require('circular-dependency-plugin')

module.exports = {
    mode: "production",
    plugins: [
        new webpack.optimize.ModuleConcatenationPlugin(),
        new CircularDependencyPlugin({
            exclude: /a\.js|node_modules/,
            include: /src/,
            failOnError: true,
            allowAsyncCycles: false,
            cwd: process.cwd(),
        })
        // new UglifyJsPlugin({ sourceMap: true })
    ],
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: "ts-loader",
                exclude: /node_modules/
            }
        ]
    },
    entry: "./src/adminPanel.ts",
    optimization: {
        minimize: false,
        splitChunks: {
            chunks: "all"
        }
    },
    resolve: {
        extensions: [".ts"]
    },
    watchOptions: {
        ignored: "**/node_modules"
    },
    output: {
        filename: "client.build.js",
        path: path.resolve(__dirname, "..", "..", "client_packages", "js_packages"),
    }
};
