import { v2 as cloudinary } from 'cloudinary'

const ALLOWED_CATEGORIES = ['paintings', 'animations', 'digital-artworks']

export default defineEventHandler(async (event) => {
  const {category} = getQuery(event)

    if (!category || !ALLOWED_CATEGORIES.includes(String(category))) {
      throw createError({
        statusCode: 400,
        statusMessage: 'Invalid artwork category',
      })
    }
  
    const folder = `artwork/${category}`
  
    const result = await cloudinary.search
      .expression(`folder=${folder}`)
      .with_field('context')
      .with_field('metadata')
      .sort_by('created_at', 'desc')
      .max_results(50)
      .execute()

    return result.resources.map((asset: any) =>
      {
        const isVideo = asset.resource_type === 'video'

        const formattedDuration = isVideo && asset.duration
          ? `${Math.floor(asset.duration / 60)}:${Math.floor(asset.duration % 60)
              .toString()
              .padStart(2, '0')}`
          : null
        
        return {
          id: asset.asset_id,
        url: asset.secure_url,
        type: asset.resource_type,
        title: asset.context?.caption ?? '',
        description: asset.context?.alt ?? '',
        duration: formattedDuration,
        thumbnail: cloudinary.url(asset.public_id, {
          resource_type: asset.resource_type,
          format: asset.resource_type === 'video' ? 'jpg' : undefined,
          transformation: [
            { width: 400, height: 400, crop: 'fill' },
            ...(asset.resource_type === 'video'
              ? [{ start_offset: '2' }]
              : [])
          ]
        })}

    })
})