using System.Drawing;
using System.Drawing.Imaging;

namespace CheckersGame.UI
{
    internal class GifImage
    {
        private readonly Image r_GifImage;
        private readonly FrameDimension r_Dimension;
        private readonly int r_MaxFrames;
        private int m_CurrentFrame = -1;

        public bool IsMaxFrameReached
        {
            get
            {
                return m_CurrentFrame == r_MaxFrames - 1;
            }
        }

        internal GifImage(Bitmap i_Bitmap)
        {
            r_GifImage = i_Bitmap;
            r_Dimension = new FrameDimension(r_GifImage.FrameDimensionsList[0]);
            r_MaxFrames = r_GifImage.GetFrameCount(r_Dimension);
        }

        internal Image GetNextFrame()
        {
            Image nextFrame;

            m_CurrentFrame = m_CurrentFrame >= 0 && m_CurrentFrame < r_MaxFrames ? m_CurrentFrame + 1 : 0;

            // Catching external exception related to accessing to GDI resources.
            // In such case return the last frame and set the current frame to the maximum
            try
            {
                nextFrame = getFrameCopyByIndex(m_CurrentFrame);
            }
            catch
            {
                nextFrame = getFrameCopyByIndex(m_CurrentFrame - 1);
                m_CurrentFrame = r_MaxFrames - 1;
            }

            return nextFrame;
        }

        private Image getFrameCopyByIndex(int i_FrameIndex)
        {
            r_GifImage.SelectActiveFrame(r_Dimension, i_FrameIndex);

            return r_GifImage.Clone() as Image;
        }
    }
}