<template>
  <section id="animations" class="py-20 bg-black text-white">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <!-- Section header -->
      <ClientOnly>
      <div
        v-motion
        :initial="{ opacity: 0, y: 30 }"
        :enter="{ opacity: 1, y: 0 }"
        :transition="{ duration: 0.6 }"
        v-intersect.once
        class="text-center mb-16"
      >
        <div class="flex items-center justify-center gap-2 mb-4">
          <Award class="text-yellow-400" :size="32" />
          <span class="text-yellow-400 text-sm uppercase tracking-wider">
            Featured Work
          </span>
        </div>

        <h2 class="text-4xl sm:text-5xl mb-4">Animation Portfolio</h2>
        <p class="text-xl text-gray-400 max-w-2xl mx-auto">
          Explore my latest animation projects, from character work to motion
          graphics
        </p>
      </div>
      </ClientOnly>

      <!-- Grid -->
      <div class="grid grid-cols-1 lg:grid-cols-2 gap-8">
        <ClientOnly>
        <div
          v-for="(animation, index) in items"
          :key="animation.id"
          v-motion
          v-intersect.once
          :initial="{ opacity: 0, y: 30 }"
          :enter="{ opacity: 1, y: 0 }"
          :transition="{ duration: 0.6, delay: index * 0.1 }"
          :class="[
            'relative group cursor-pointer',
          ]"
        >
          <div
            class="relative overflow-hidden rounded-2xl aspect-video bg-gray-900"
          >
            <!-- Thumbnail -->
            <img
              :src="animation.thumbnail"
              :alt="animation.title"
              class="w-full h-full object-cover transition-transform duration-500 group-hover:scale-110"
            />

            <!-- Overlay -->
            <div
              class="absolute inset-0 bg-gradient-to-t from-black/80 via-black/40 to-transparent opacity-80 group-hover:opacity-90 transition-opacity"
            />

            <!-- Play button -->
            <ClientOnly>
            <div
              v-motion
              :hovered="{ scale: 1.1 }"
              class="absolute inset-0 flex items-center justify-center"
            >
              <div
                class="w-20 h-20 bg-white/20 backdrop-blur-sm rounded-full flex items-center justify-center border-2 border-white/50"
              >
                <Play :size="32" class="text-white ml-1" fill="white" />
              </div>
            </div>
          </ClientOnly>
            <!-- Info -->
            <div class="absolute bottom-0 left-0 right-0 p-6">
              <div class="flex items-center gap-2 mb-2">
                <!-- <span
                  v-if="animation.featured"
                  class="px-3 py-1 bg-yellow-400 text-black text-xs rounded-full"
                >
                  Featured
                </span> -->

                <span
                  class="px-3 py-1 bg-white/20 backdrop-blur-sm text-white text-xs rounded-full"
                >
                  {{ animation.duration }}
                </span>
              </div>

              <h3 class="text-2xl mb-2">{{ animation.title }}</h3>
              <p class="text-gray-300">{{ animation.description }}</p>
            </div>
          </div>
        </div>
        </ClientOnly>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import { Award, Play } from 'lucide-vue-next'

type GalleryItem = {
  id: number
  url: string
  title: string
  type: string
  description: string
  duration: string,
  thumbnail: string
}

const props = defineProps<{
  items: GalleryItem[]
}>()
</script>
