<template>
  <Hero />
  <AnimationShowcase  :items="animations"/>
  <GalleryShowcase id="digital-artworks" title="Digital Artworks"
    description="A curated selection of stunning digital artworks showcasing creativity and innovation."
    :items="digitalArtworks" bgColor="bg-gray-100" />
  <GalleryShowcase id="paintings" title="Traditional Paintings"
    description="Original paintings created with traditional media on canvas" :items="paintings" bgColor="bg-white" />
  <Contact />
</template>

<script setup>
const {
  data: digitalArtworks,
  pending: digitalArtworksPending,
  error: digitalArtworksError,
} = await useFetch('/api/artwork', {
  query: { category: 'digital-artworks' },
})

const {
  data: paintings,
  pending: paintingsPending,
  error: paintingsErrors,
} = await useFetch('/api/artwork', {
  query: { category: 'paintings' },
})

const {
  data: animations,
  pending: animationsPending,
  error: animationsErrors,
} = await useFetch('/api/artwork', {
  query: { category: 'animations' },
})
</script>
