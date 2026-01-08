<template>
  <section :id="id" :class="['py-20', bgColor]">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <!-- Section header -->
      <div
        v-motion
        v-intersect.once
        :initial="{ opacity: 0, y: 30 }"
        :enter="{ opacity: 1, y: 0 }"
        :transition="{ duration: 0.6 }"
        class="text-center mb-16"
      >
        <h2 class="text-4xl sm:text-5xl mb-4">{{ title }}</h2>
        <p class="text-xl text-gray-600 max-w-2xl mx-auto">
          {{ description }}
        </p>
      </div>

      <!-- Masonry -->
      <div class="masonry">
        <div
          v-for="(item, index) in items"
          :key="item.id"
          v-motion
          v-intersect.once
          :initial="{ opacity: 0, y: 30 }"
          :enter="{ opacity: 1, y: 0 }"
          :transition="{ duration: 0.6, delay: index * 0.05 }"
          :hovered="{ y: -8 }"
          class="masonry-item group relative overflow-hidden rounded-lg cursor-pointer"
        >
          <NuxtImg
            :src="item.image"
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
              <p class="text-sm text-gray-300">{{ item.category }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
interface GalleryItem {
  id: number
  image: string
  title: string
  category: string
}

const props = defineProps<{
  id: string
  title: string
  description: string
  items: GalleryItem[]
  bgColor?: string
}>()

const bgColor = props.bgColor ?? 'bg-white'
</script>

<style scoped>
/* Simple CSS Masonry (SSR-safe) */
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
