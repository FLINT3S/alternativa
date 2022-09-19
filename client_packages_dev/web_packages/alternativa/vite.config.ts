import {fileURLToPath, URL} from 'node:url'
import {defineConfig} from 'vite'
import vue from '@vitejs/plugin-vue'

const path = require("path");

// https://vitejs.dev/config/
export default defineConfig(({mode}) => {
  const base = {
    plugins: [vue()],
    resolve: {
      alias: {
        '@': fileURLToPath(new URL('./src', import.meta.url))
      }
    },
    build: {
      outDir: path.resolve(__dirname, "..", "..", "..", "client_packages", "web_packages"),
      emptyOutDir: true,
      chunkSizeWarningLimit: 2000,
    }
  }

  if (mode === "development") {
    console.log("Development mode")

    return {
      ...base,
      base: "/"
    }
  } else {
    console.log("Production mode")

    return {
      ...base,
      base: "./",
    }
  }
})
