<template>
  <Hero />
  <AnimationShowcase />
  <GalleryShowcase
    id="digital-artworks"
    title="Digital Artworks"
    description="A curated selection of stunning digital artworks showcasing creativity and innovation."
    :items="digitalArtworks"
    bgColor="bg-gray-100"
  />
  <GalleryShowcase
    id="paintings"
    title="Traditional Paintings"
    description="Original paintings created with traditional media on canvas"
    :items="paintings"
    bgColor="bg-white"
  />
</template>

<script setup>
// Mock data for digital artwork
const digitalArtworks = ref([
  {
    id: 1,
    image:
      'https://images.unsplash.com/photo-1736175549681-c24c552da1e2?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxkaWdpdGFsJTIwYXJ0JTIwY29sb3JmdWx8ZW58MXx8fHwxNzY3NzMyNDgwfDA&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Cyberpunk Dreams',
    category: 'Digital Illustration',
  },
  {
    id: 2,
    image:
      'https://images.unsplash.com/photo-1649783467344-4dfdb3b55036?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxtb2Rlcm4lMjBpbGx1c3RyYXRpb24lMjBkZXNpZ258ZW58MXx8fHwxNzY3Nzc2MDEzfDA&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Abstract Composition',
    category: 'Concept Art',
  },
  {
    id: 3,
    image:
      'https://images.unsplash.com/photo-1590968802291-f1e1f86cde34?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHx2aWJyYW50JTIwc3RyZWV0JTIwYXJ0fGVufDF8fHx8MTc2Nzc4MDEzMXww&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Urban Energy',
    category: 'Street Art',
  },
  {
    id: 4,
    image:
      'https://images.unsplash.com/photo-1647792845543-a8032c59cbdf?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxjb250ZW1wb3JhcnklMjBhcnQlMjBnYWxsZXJ5fGVufDF8fHx8MTc2NzY5NTY3NHww&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Gallery Space',
    category: 'Installation Art',
  },
  {
    id: 5,
    image:
      'https://images.unsplash.com/photo-1600447766334-36a93f35a21d?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxhbmltYXRpb24lMjBzdHVkaW8lMjB3b3Jrc3BhY2V8ZW58MXx8fHwxNzY3NzgwMTMwfDA&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Creative Process',
    category: 'Behind the Scenes',
  },
  {
    id: 6,
    image:
      'https://images.unsplash.com/photo-1635141849017-c531949fb5b3?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxhYnN0cmFjdCUyMHBhaW50aW5nJTIwY2FudmFzfGVufDF8fHx8MTc2Nzc2NjI3OHww&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Color Study',
    category: 'Digital Painting',
  },
])

// Mock data for paintings
const paintings = ref([
  {
    id: 1,
    image:
      'https://images.unsplash.com/photo-1635141849017-c531949fb5b3?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxhYnN0cmFjdCUyMHBhaW50aW5nJTIwY2FudmFzfGVufDF8fHx8MTc2Nzc2NjI3OHww&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Abstract Expression',
    category: 'Acrylic on Canvas',
  },
  {
    id: 2,
    image:
      'https://images.unsplash.com/photo-1647792845543-a8032c59cbdf?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxjb250ZW1wb3JhcnklMjBhcnQlMjBnYWxsZXJ5fGVufDF8fHx8MTc2NzY5NTY3NHww&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Modern Landscape',
    category: 'Oil on Canvas',
  },
  {
    id: 3,
    image:
      'https://images.unsplash.com/photo-1590968802291-f1e1f86cde34?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHx2aWJyYW50JTIwc3RyZWV0JTIwYXJ0fGVufDF8fHx8MTc2Nzc4MDEzMXww&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Street Mural',
    category: 'Mixed Media',
  },
  {
    id: 4,
    image:
      'https://images.unsplash.com/photo-1736175549681-c24c552da1e2?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxkaWdpdGFsJTIwYXJ0JTIwY29sb3JmdWx8ZW58MXx8fHwxNzY3NzMyNDgwfDA&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Vibrant Forms',
    category: 'Watercolor',
  },
  {
    id: 5,
    image:
      'https://images.unsplash.com/photo-1649783467344-4dfdb3b55036?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxtb2Rlcm4lMjBpbGx1c3RyYXRpb24lMjBkZXNpZ258ZW58MXx8fHwxNzY3Nzc2MDEzfDA&ixlib=rb-4.1.0&q=80&w=1080',
    title: 'Geometric Harmony',
    category: 'Acrylic on Canvas',
  },
])
</script>
