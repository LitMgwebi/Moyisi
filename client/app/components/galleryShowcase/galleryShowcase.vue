<template>
  <section :id="id" :class="['py-20', bgColor]">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">

      <!-- Section header -->
      <div
        v-motion="fadeInMotion"
        class="text-center mb-16"
      >
        <h2 class="text-4xl text-black sm:text-5xl mb-4">{{ title }}</h2>
        <p class="text-xl text-gray-600 max-w-2xl mx-auto">
          {{ description }}
        </p>
      </div>

      <div
        v-if="error"
        class="mb-8 p-4 bg-red-500/10 border border-red-500/50 rounded-lg text-red-400 text-center"
      >
        <UBanner color="error" icon="i-lucide-info" :title="error.data.message" />
      </div>
      <!-- Masonry -->
      <div class="masonry">
        <div
          v-if="!isLoading && !error && items && items.length"
          v-for="(item, index) in items"
          :key="item.id"
          v-motion="getItemMotion(index)"
          class="masonry-item group relative overflow-hidden rounded-lg cursor-pointer"
        >
          <NuxtImg
            :src="item.url"
            :alt="item.title"
            loading="lazy"
            class="w-full h-auto object-cover transition-transform duration-500 group-hover:scale-110"
          />

          <!-- Hover overlay -->
          <div
            class="absolute inset-0 bg-black/70 opacity-0 group-hover:opacity-100 transition-opacity duration-300 flex items-center justify-center"
          >
            <div class="text-white text-center p-4">
              <h3 class="text-xl mb-2">{{ item.title }}</h3>
              <p class="text-sm text-gray-300">{{ item.description }}</p>
            </div>
          </div>
        </div>
        <template v-else>
          <div
            v-for="i in 3"
            :key="i"
            class="masonry-item"
          >
            <USkeleton class="w-full h-62.5 rounded-lg" />
          </div>
        </template>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import type { FetchError } from 'ofetch'
import type { GalleryItem } from '@/assets/types'

const props = defineProps<{
  id: string
  title: string
  description: string
  items?: GalleryItem[]
  bgColor?: string
  isLoading?: ComputedRef<boolean>
  error?: FetchError<any> | null
}>()

const bgColor = props.bgColor ?? 'bg-white'

// ✅ Static motion config (no conditionals)
const fadeInMotion = {
  initial: { opacity: 0, y: 30 },
  enter: { opacity: 1, y: 0 },
  transition: { duration: 0.6 }
}

// ✅ Dynamic per-item motion (for stagger)
const getItemMotion = (index: number) => ({
  initial: { opacity: 0, y: 30 },
  enter: { opacity: 1, y: 0 },
  transition: { duration: 0.6, delay: index * 0.05 },
  hovered: { y: -8 }
})
</script>

<style scoped>
.masonry {
  column-count: 1;
  column-gap: 1.5rem;
}

@media (min-width: 768px) {
  .masonry {
    column-count: 2;
  }
}

@media (min-width: 1024px) {
  .masonry {
    column-count: 3;
  }
}

.masonry-item {
  break-inside: avoid;
  margin-bottom: 1.5rem;
}
</style>