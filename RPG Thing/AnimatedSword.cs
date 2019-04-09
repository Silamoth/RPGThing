using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RPG_Thing
{
    class AnimatedSword : AnimatedThing
    {
        bool isActive = false;
        Rectangle rectangle;

        public AnimatedSword(Texture2D texture, int frameWidth, int frameHeight)
        {
            this.texture = texture;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;

            rectangleX = 0;
            rectangleY = 0;

            currentFrame = 0;
        }

        public override void Update()
        {
            switch (currentFrame)
            {
                case 0:
                    rectangleX = FrameWidth * 0;
                    break;
                case 1:
                    rectangleX = FrameWidth * 0;
                    break;
                case 2:
                    rectangleX = FrameWidth * 2;
                    break;
                case 3:
                    rectangleX = FrameWidth * 0;
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle sourceRectangle = new Rectangle(rectangleX, rectangleY, frameWidth, frameHeight);

            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, 0f, new Vector2(0, 0), 0.35f, SpriteEffects.None, 1f);

            rectangle = new Rectangle((int)position.X, (int)position.Y, FrameWidth, FrameHeight);
        }

        public override void SetUp()
        {
            currentFrame = 0;
            //UpdateUp(gameTime);
        }

        //public void UpdateUp()
        //{
        //    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        //    if (timer > interval)
        //    {
        //        currentFrame++;

        //        if (currentFrame > 41)
        //        {
        //            SetUp();
        //        }

        //        timer = 0f;
        //    }
        //}

        public override void SetLeft()
        {
            currentFrame = 3;
            //UpdateLeft(gameTime);
        }

        //public void UpdateLeft()
        //{
        //    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        //    if (timer > interval)
        //    {
        //        currentFrame++;

        //        if (currentFrame == 48)
        //        {
        //            SetLeft();
        //        }

        //        timer = 0f;
        //    }
        //}

        public override void SetDown()
        {
            currentFrame = 2;
            //UpdateDown(gameTime);
        }

        //public void UpdateDown()
        //{
        //    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        //    if (timer > interval)
        //    {
        //        currentFrame++;

        //        if (currentFrame == 54)
        //        {
        //            SetDown();
        //        }

        //        timer = 0f;
        //    }
        //}

        public override void SetRight()
        {
            currentFrame = 1;
            //UpdateRight(gameTime);
        }

        //public void UpdateRight()
        //{
        //    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        //    if (timer > interval)
        //    {
        //        currentFrame++;

        //        if (currentFrame == 60)
        //        {
        //            SetRight();
        //        }

        //        timer = 0f;
        //    }
        //}

        //Properties

        public void Kill()
        {
            isActive = false;
        }
        
        //Properties

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        public int Damage
        {
            get { return 3; }
        }
    }
}
