<template>
  <footer className="py-8 bg-black text-white">
    <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
      <p className="text-gray-400">
        © {{ date }} Powered By Lithi. All rights reserved.
      </p>
    </div>
  </footer>
</template>

<script setup>
const date = new Date().getFullYear()
</script>
