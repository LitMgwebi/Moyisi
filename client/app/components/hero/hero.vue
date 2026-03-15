<template>
  <section
    id="home"
    class="min-h-screen flex items-center justify-center bg-gradient-to-br from-purple-50 via-white to-blue-50 pt-16"
  >
    <div class="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
      <!-- Heading -->
       <ClientOnly>
      <h1
        v-motion
        :initial="{ opacity: 0, y: 30 }"
        :enter="{ opacity: 1, y: 0 }"
        :transition="{ duration: 0.8 }"
        class="text-5xl sm:text-6xl lg:text-7xl mb-6"
      >
        Creative Artist & Animator
      </h1>
       </ClientOnly>

      <!-- Subheading -->
       <ClientOnly>
      <p
        v-motion
        :initial="{ opacity: 0, y: 30 }"
        :enter="{ opacity: 1, y: 0 }"
        :transition="{ duration: 0.8, delay: 0.2 }"
        class="text-xl sm:text-2xl text-gray-600 mb-8 max-w-2xl mx-auto"
      >
        Bringing imagination to life through digital art, traditional paintings,
        and captivating animations
      </p>
       </ClientOnly>
      <!-- CTA buttons -->
       <ClientOnly>
      <div
        v-motion
        :initial="{ opacity: 0, y: 30 }"
        :enter="{ opacity: 1, y: 0 }"
        :transition="{ duration: 0.8, delay: 0.4 }"
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
    </ClientOnly>
      <!-- Scroll indicator -->
       <ClientOnly>
      <div
        v-motion
        :initial="{ opacity: 0 }"
        :enter="{ opacity: 1 }"
        :transition="{ duration: 1, delay: 1 }"
        class="mt-20"
      >
        <NuxtLink to="#animations" class="inline-block">
          <ClientOnly>
          <div
            v-motion
            :animate="{ y: [0, 10, 0] }"
            :transition="{ duration: 1.5, repeat: Infinity }"
          >
            <ChevronDown size="32" class="text-gray-400" />
          </div>
        </ClientOnly>
        </NuxtLink>
      </div>
    </ClientOnly>
    </div>
  </section>
</template>

<script setup></script>
