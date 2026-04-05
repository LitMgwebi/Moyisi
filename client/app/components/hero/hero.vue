<template>
  <section
    id="home"
    class="min-h-screen flex items-center justify-center bg-linear-to-br from-purple-50 via-white to-blue-50 pt-16"
  >
    <div class="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8 text-center">

      <!-- Heading -->
      <h1
        v-motion="headingMotion"
        class="text-5xl sm:text-6xl lg:text-7xl mb-6"
      >
        Creative Artist & Animator
      </h1>

      <!-- Subheading -->
      <p
        v-motion="subheadingMotion"
        class="text-xl sm:text-2xl text-gray-600 mb-8 max-w-2xl mx-auto"
      >
        Bringing imagination to life through digital art, traditional paintings,
        and captivating animations
      </p>

      <!-- CTA buttons -->
      <div
        v-motion="ctaMotion"
        class="flex flex-wrap gap-4 justify-center"
      >
        <NuxtLink
          to="#animations"
          class="px-8 py-3 bg-black text-white rounded-full hover:bg-gray-800 transition-colors"
        >
          View Animations
        </NuxtLink>

        <NuxtLink
          to="#digital"
          class="px-8 py-3 border-2 border-black text-black rounded-full hover:bg-black hover:text-white transition-colors"
        >
          Explore Gallery
        </NuxtLink>
      </div>

      <!-- Scroll indicator -->
      <div
        v-motion="fadeInDelayed"
        class="mt-20"
      >
        <NuxtLink to="#animations" class="inline-block">
          <div
            v-motion="bounceMotion"
          >
            <!-- <ChevronDown :size="32" class="text-gray-400" /> -->
             HI
          </div>
        </NuxtLink>
      </div>

    </div>
  </section>
</template>

<script setup lang="ts">
import { ChevronDown } from 'lucide-vue-next'

// ✅ Motion configs
const headingMotion = {
  initial: { opacity: 0, y: 30 },
  enter: { opacity: 1, y: 0 },
  transition: { duration: 0.8 }
}

const subheadingMotion = {
  initial: { opacity: 0, y: 30 },
  enter: { opacity: 1, y: 0 },
  transition: { duration: 0.8, delay: 0.2 }
}

const ctaMotion = {
  initial: { opacity: 0, y: 30 },
  enter: { opacity: 1, y: 0 },
  transition: { duration: 0.8, delay: 0.4 }
}

const fadeInDelayed = {
  initial: { opacity: 0 },
  enter: { opacity: 1 },
  transition: { duration: 1, delay: 1 }
}

// ⚠️ infinite animation (safe because plugin is client-only)
const bounceMotion = {
  initial: { y: 0 },
  animate: { y: [0, 10, 0] },
  transition: { duration: 1.5, repeat: Infinity }
}
</script>