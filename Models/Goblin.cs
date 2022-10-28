using Microsoft.Xna.Framework.Graphics;

namespace Rydge
{
    class Goblin
    {
        private float xpos;
        private float xsize;
        private float ypos;
        private float ysize;
        private float xVelocity;
        private float yVelocity;
        private Texture2D playerTexture;
        public Goblin()
        {
            this.xsize= 20;
            this.ysize= 35;
            this.xpos= 0;
            this.ypos=0;
            this.xVelocity=0;
            this.yVelocity= 0;
        }
        public void setTexture(Texture2D ptexture)
        {
            this.playerTexture = ptexture;
        }
        public Texture2D getTexture()
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
    }
}