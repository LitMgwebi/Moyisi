<template>
  <section
    id="contact"
    class="py-20 bg-gradient-to-br from-purple-50 via-white to-blue-50"
  >
    <div class="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
      <!-- Wrapper -->
      <div
        v-motion
        v-intersect.once
        :initial="{ opacity: 0, y: 30 }"
        :enter="{ opacity: 1, y: 0 }"
        :transition="{ duration: 0.6 }"
      >
        <h2 class="text-4xl sm:text-5xl mb-6">Let's Work Together</h2>

        <p class="text-xl text-gray-600 mb-12 max-w-2xl mx-auto">
          I'm always open to new projects and collaborations. Feel free to reach
          out!
        </p>

        <!-- CTA -->
        <a
          href="mailto:artist@example.com"
          v-motion
          :hovered="{ scale: 1.05 }"
          :pressed="{ scale: 0.95 }"
          class="inline-flex items-center gap-3 px-8 py-4 bg-black text-white rounded-full text-lg hover:bg-gray-800 transition-colors mb-12"
        >
          <Mail :size="24" />
          Get in Touch
        </a>

        <!-- Socials -->
        <div class="flex justify-center gap-6 mt-8">
          <a
            v-for="(social, index) in socials"
            :key="social.label"
            :href="social.href"
            v-motion
            v-intersect.once
            :initial="{ opacity: 0, y: 20 }"
            :enter="{ opacity: 1, y: 0 }"
            :transition="{ delay: index * 0.1 }"
            :hovered="{ scale: 1.1 }"
            class="w-12 h-12 rounded-full bg-white border-2 border-gray-200 flex items-center justify-center hover:border-black transition-colors"
            :aria-label="social.label"
          >
            <component :is="social.icon" :size="20" />
          </a>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
import { Mail, Instagram, Twitter, Linkedin } from 'lucide-vue-next'

const socials = [
  { icon: Instagram, href: '#', label: 'Instagram' },
  { icon: Twitter, href: '#', label: 'Twitter' },
  { icon: Linkedin, href: '#', label: 'LinkedIn' },
]
</script>
