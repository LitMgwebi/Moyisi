<template>
  <Hero />
  <AnimationShowcase :items="animations" :isLoading="animationsPending" :error="animationsError" />
  <GalleryShowcase id="digital-artworks" title="Digital Artworks"
    description="A curated selection of stunning digital artworks showcasing creativity and innovation."
    :items="digitalArtworks" :isLoading="digitalArtworksPending" :error="digitalArtworksError" bgColor="bg-gray-100" />
  <GalleryShowcase id="paintings" title="Traditional Paintings"
    description="Original paintings created with traditional media on canvas" :items="paintings" :isLoading="paintingsPending" :error="paintingsErrors" bgColor="bg-white" />
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
  error: animationsError,
} = await useFetch('/api/artwork', {
  query: { category: 'animations' },
})

</script>
