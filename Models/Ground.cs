
using Microsoft.Xna.Framework.Graphics;
namespace Rydge
{
    class Ground
    {
        private float xpos;
        private int xsize;
        private float ypos;
        private int ysize;

        private Texture2D Texture;
        public Ground()
        {
            this.xsize = 32;
            this.ysize = 32;
            this.xpos = 250f;
            this.ypos = 250f;

        }
        public void setTexture(Texture2D ptexture)
        {
            this.Texture = ptexture;
        }
        public Texture2D getTexture()
        {
            return this.Texture;
        }
        public float getxsize()
        {
            return this.xsize;
        }
        public float getysize()
        {
            return this.ysize;
        }
        public float getxpos()
        {
            return this.xpos;
        }
        public float getypos()
        {
            return this.ypos;
        }
        public void setxpos(float x){
            this.xpos=x;
        }
        public void setypos(float y){
            this.ypos=y;
        }
    }
}