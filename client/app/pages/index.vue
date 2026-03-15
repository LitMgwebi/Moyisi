<template>
  <Hero />
  <AnimationShowcase />
  <GalleryShowcase id="digital-artworks" title="Digital Artworks"
    description="A curated selection of stunning digital artworks showcasing creativity and innovation."
    :items="digitalArtworks" bgColor="bg-gray-100" />
  <GalleryShowcase id="paintings" title="Traditional Paintings"
    description="Original paintings created with traditional media on canvas" :items="paintings" bgColor="bg-white" />
  <Contact />
</template>

<script setup>

//TODO: I need to add loading skeletons and error handling for these fetches
//TODO: Ask Xola for more details of his profile.
//TODO: Fix motion and intersection errors
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
</script>
