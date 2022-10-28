using Microsoft.Xna.Framework.Graphics;

namespace Rydge
{
    class Player
    {
        private float xpos;
        private float xsize;
        private float ypos;
        private float ysize;
        private float xVelocity;
        private float yVelocity;
        private Texture2D playerTexture;
        public Player()
        {

            this.xsize = 41;
            this.ysize = 61;
            this.xpos = 0f;
            this.ypos = 0f;
            this.xVelocity = 100f;
            this.yVelocity = 100f;
        }

        public void setPLayerTexture(Texture2D ptexture)
        {
            this.playerTexture = ptexture;
        }
        public Texture2D getPlayerTexture()
        {
            return this.playerTexture;
        }
        public void setxpos(float x)
        {
            this.xpos = x;
        }
        public float getxpos()
        {
            return xpos;
        }
        public float getxsize()
        {
            return this.xsize;
        }
        public void changexpos(float x)
        {
            this.xpos += x;
        }
        public float getxvel()
        {
            return xVelocity;
        }
        public void setypos(float x)
        {
            this.ypos = x;
        }
        public float getypos()
        {
            return ypos;
        }
        public float getysize()
        {
            return this.ysize;
        }
        public void changeypos(float x)
        {
            this.ypos += x;
        }
        public float getyvel()
        {
            return yVelocity;
        }
        public void changeyvel(float dy)
        {
             yVelocity+=dy;
        }
        public void setyvel(float dy)
        {
             yVelocity=100f;
        }
    }
}