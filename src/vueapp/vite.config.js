// import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-vue';

// https://vitejs.dev/config/
export default defineConfig({
    build: {
        rollupOptions: {
        //   input: {
        //     main: resolve(__dirname, 'index.html'),
        //     nested: resolve(__dirname, 'nested/index.html'),
        //   },
        },
    },
    plugins: [plugin()],
    resolve: {
        alias: {
            // '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        // proxy: {
        //     '^/weatherforecast': {
        //         target: 'https://localhost:7057/',
        //         secure: false
        //     }
        // },
        plugins:[],
        port: 5173,
        // https: {
        //     key: fs.readFileSync(keyFilePath),
        //     cert: fs.readFileSync(certFilePath),
        // }
    }
})
