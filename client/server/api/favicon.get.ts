import { v2 as cloudinary } from 'cloudinary'

const LOGO_FOLDER = 'non-artwork/logo'

export default defineEventHandler(async (event) => {
  try {
    const result = await cloudinary.search
      .expression(`folder=${LOGO_FOLDER} AND resource_type:image`)
      .sort_by('created_at', 'desc')
      .max_results(1)
      .execute()

    const logo = result.resources?.[0]

    if (logo) {
      const url = cloudinary.url(logo.public_id, {
        format: 'png',
        transformation: [{ width: 64, height: 64, crop: 'fill' }],
      })

      // Cache briefly so the tab icon isn't re-queried on every request
      setHeader(event, 'Cache-Control', 'public, max-age=3600')
      return sendRedirect(event, url, 302)
    }
  } catch (error) {
    console.error('Favicon lookup failed, using fallback:', error)
  }

  // Backup: the default Nuxt favicon
  setHeader(event, 'Cache-Control', 'no-cache')
  return sendRedirect(event, '/favicon.ico', 302)
})
