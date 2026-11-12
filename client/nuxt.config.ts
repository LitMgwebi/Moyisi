import tailwindcss from '@tailwindcss/vite'
import { existsSync } from 'node:fs'

// Load secrets from a separate, git-ignored file (does not override real env vars)
if (existsSync('.env.secrets')) {
  process.loadEnvFile('.env.secrets')
}

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  modules: ['@nuxt/image', '@nuxt/ui'],
  compatibilityDate: '2025-07-15',
  devtools: { enabled: true },
  css: ['./app/assets/css/main.css'],
  vite: {
    plugins: [tailwindcss()],
    optimizeDeps: {
      include: [
        'lucide-vue-next',
        '@vue/devtools-core',
        '@vue/devtools-kit',
        '@vueuse/motion',
      ]
    }
  },
  runtimeConfig: {
    cloudinaryApiKey: process.env.CLOUDINARY_API_KEY,
    cloudinaryApiSecret: process.env.CLOUDINARY_API_SECRET,

    public: {
      cloudinaryCloudName: process.env.CLOUDINARY_CLOUD_NAME,
      contactEmail: process.env.CONTACT_EMAIL,
      instagramUrl: process.env.INSTAGRAM_URL,
      twitterUrl: process.env.TWITTER_URL,
      linkedinUrl: process.env.LINKEDIN_URL,
    },
  },
})