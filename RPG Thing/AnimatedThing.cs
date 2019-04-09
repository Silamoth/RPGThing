using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG_Thing
{
    class AnimatedThing
    {
        public int currentFrame;
        public int totalFrames;

        public Texture2D texture;

        public int rectangleX;
        public int rectangleY;

        public int frameWidth;
        public int frameHeight;

        public float timer = 0f;
        public float interval = 125;

        public bool isUp, isDown, isLeft, isRight;

        public virtual void Update()
        {

        }

        public virtual void Update(GameTime gameTime, Vector2 position)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void SetUp()
        {

        }

        public virtual void SetDown()
        {

        }

        public virtual void SetRight()
        {

        }

        public virtual void SetLeft()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle rectangle = new Rectangle(rectangleX, rectangleY, frameWidth, frameHeight);

            spriteBatch.Draw(texture, position, rectangle, Color.White);
        }

        //Properties

        public int CurrentFrame
        {
            get { return currentFrame; }
        }

        public bool IsRight
        {
            get { return isRight; }
        }

        public bool IsLeft
        {
            get { return isLeft; }
        }

        public bool IsUp
        {
            get { return isUp; }
        }

        public bool IsDown
        {
            get { return isDown; }
        }

        public int FrameWidth
        {
            get { return frameWidth; }
        }

        public int FrameHeight
        {
            get { return frameHeight; }
        }
    }
}
