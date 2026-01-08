<template>
  <header
    class="fixed top-0 left-0 right-0 z-50 bg-white/80 backdrop-blur-md border-b border-gray-200"
  >
    <nav class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <div class="flex justify-between items-center h-16">
        <div
          v-motion
          :initial="{ opacity: 0, x: -20 }"
          :enter="{ opacity: 1, x: 0 }"
          class="text-xl font-semibold"
        >
          Moyisi
        </div>

        <div class="hidden md:flex space-x-8">
          <NuxtLink
            v-for="(item, index) in navItems"
            :key="item.name"
            :to="item.href"
            v-motion
            :initial="{ opacity: 0, y: -10 }"
            :enter="{ opacity: 1, y: 0 }"
            :transition="{ delay: index * 0.1 }"
            class="text-gray-700 hover:text-black transition-colors"
          >
            {{ item.name }}
          </NuxtLink>
        </div>

        <v-btn
          variant="text"
          class="md:hidden p-2"
          @click="mobileMenuOpen = !mobileMenuOpen"
          icon
        >
          <component :is="mobileMenuOpen ? X : Menu" :size="24" />
        </v-btn>
      </div>

      <div
        v-if="mobileMenuOpen"
        v-motion
        :initial="{ opacity: 0, height: 0 }"
        :enter="{ opacity: 1, height: 'auto' }"
        :leave="{ opacity: 0, height: 0 }"
        :transition="{ duration: 0.25, ease: 'easeOut' }"
        class="md:hidden overflow-hidden"
      >
        <div class="py-4 space-y-3">
          <NuxtLink
            v-for="item in navItems"
            :key="item.name"
            :to="item.href"
            @click="mobileMenuOpen = false"
            class="block text-gray-700 hover:text-black transition-colors"
          >
            {{ item.name }}
          </NuxtLink>
        </div>
      </div>
    </nav>
  </header>
</template>

<script setup lang="ts">
import { Menu, X } from 'lucide-vue-next'

const mobileMenuOpen = ref(false)
const navItems = ref([
  { name: 'Home', href: '#home' },
  { name: 'Animations', href: '#animations' },
  { name: 'Digital Art', href: '#digital' },
  { name: 'Paintings', href: '#paintings' },
  { name: 'Contact', href: '#contact' },
])
</script>
