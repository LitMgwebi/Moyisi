<template>
  <section id="animations" class="py-20 bg-black text-white">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">

      <!-- Section header -->
      <div
        v-motion="fadeInMotion"
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

      <!-- Error Message -->
      <div
        v-if="error"
        class="mb-8 p-4 bg-red-500/10 border border-red-500/50 rounded-lg text-red-400 text-center"
      >
        <UBanner color="error" icon="i-lucide-info" :title="error.data.message" />
      </div>

      <!-- Grid -->
      <div class="grid grid-cols-1 lg:grid-cols-2 gap-8">


        <!-- Actual Animation Cards -->
        <div
          v-if="!isLoading && items && items.length && !error"
          v-for="(animation, index) in items"
          :key="animation.id"
          v-motion="getItemMotion(index as number)"
          class="relative group cursor-pointer"
          @click="openVideo(animation)"
        >
          <div class="relative overflow-hidden rounded-2xl aspect-video bg-gray-900">

            <!-- Thumbnail -->
            <img
              :src="animation.thumbnail"
              :alt="animation.title"
              class="w-full h-full object-cover transition-transform duration-500 group-hover:scale-110"
            />

            <!-- Overlay -->
            <div
              class="absolute inset-0 bg-linear-to-t from-black/80 via-black/40 to-transparent opacity-80 group-hover:opacity-90 transition-opacity"
            />

            <!-- Play button -->
            <div
              v-motion
              :while-hover="{ scale: 1.1 }"
              class="absolute inset-0 flex items-center justify-center"
            >
              <div
                class="w-20 h-20 bg-white/20 backdrop-blur-sm rounded-full flex items-center justify-center border-2 border-white/50 transition-all group-hover:bg-white/30 group-hover:border-white/80"
              >
                <Play :size="32" class="text-white ml-1" fill="white" />
              </div>
            </div>

            <!-- Info -->
            <div class="absolute bottom-0 left-0 right-0 p-6">
              <div class="flex items-center gap-2 mb-2">
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

        <!-- Skeleton Loaders -->
        <div
          v-else
          v-for="index in 2"
          :key="`skeleton-${index}`"
          class="relative overflow-hidden rounded-2xl aspect-video bg-gray-800 animate-pulse"
        >
          <USkeleton class="w-full h-full rounded-2xl" />

          <div class="absolute bottom-0 left-0 right-0 p-6 space-y-2">
            <USkeleton class="h-4 w-20" />
            <USkeleton class="h-6 w-3/4" />
            <USkeleton class="h-4 w-full" />
          </div>
        </div>
      </div>
    </div>

    <!-- Video Modal -->
    <Teleport to="body">
      <Transition name="fade">
        <div
          v-if="selectedAnimation"
          class="fixed inset-0 bg-black/95 backdrop-blur-sm z-50 flex items-center justify-center p-4"
          @click.self="closeVideo"
        >
          <div class="w-full max-w-5xl relative">

            <!-- Close button -->
            <button
              @click="closeVideo"
              class="absolute -top-12 right-0 text-white hover:text-gray-300 transition-colors z-10"
              aria-label="Close video"
            >
              <svg
                class="w-8 h-8"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M6 18L18 6M6 6l12 12"
                />
              </svg>
            </button>

            <!-- Video -->
            <div class="rounded-2xl overflow-hidden aspect-video bg-black">
              <video
                ref="videoPlayer"
                :src="selectedAnimation.url"
                class="w-full h-full"
                controls
                autoplay
              />
            </div>

            <!-- Info -->
            <div class="mt-6">
              <h3 class="text-2xl text-white mb-2">
                {{ selectedAnimation.title }}
              </h3>
              <p class="text-gray-300">
                {{ selectedAnimation.description }}
              </p>
            </div>

          </div>
        </div>
      </Transition>
    </Teleport>
  </section>
</template>

<script setup lang="ts">
import { Award, Play } from 'lucide-vue-next'
import { ref, nextTick, onMounted, onUnmounted } from 'vue'
import type { GalleryItem } from '@/assets/types'
import type { FetchError } from 'ofetch'

const selectedAnimation = ref<any>(null)
const videoPlayer = ref<HTMLVideoElement | null>(null)

  const props = defineProps<{
  items?: GalleryItem[]
  isLoading?: ComputedRef<boolean>
  error?: FetchError<any> | null
}>()

// ✅ Motion configs
const fadeInMotion = {
  initial: { opacity: 0, y: 30 },
  enter: { opacity: 1, y: 0 },
  transition: { duration: 0.6 }
}

const getItemMotion = (index: number) => ({
  initial: { opacity: 0, y: 30 },
  enter: { opacity: 1, y: 0 },
  transition: { duration: 0.6, delay: index * 0.1 }
})

// Video logic
const openVideo = (animation: any) => {
  selectedAnimation.value = animation
  nextTick(() => {
    videoPlayer.value?.focus()
  })
}

const closeVideo = () => {
  if (videoPlayer.value) {
    videoPlayer.value.pause()
  }
  selectedAnimation.value = null
}

// Escape key
onMounted(() => {
  const handleKeydown = (e: KeyboardEvent) => {
    if (e.key === 'Escape' && selectedAnimation.value) {
      closeVideo()
    }
  }
  window.addEventListener('keydown', handleKeydown)

  onUnmounted(() => {
    window.removeEventListener('keydown', handleKeydown)
  })
})
</script>

<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.3s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>