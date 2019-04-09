using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG_Thing
{
    class AnimatedSprite : AnimatedThing
    {
        public AnimatedSprite(Texture2D texture, int frameWidth, int frameHeight)
        {
            this.texture = texture;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;

            rectangleX = 0;
            rectangleY = 0;

            currentFrame = 0;

            totalFrames = texture.Width / frameWidth;
        }

        public override void Update()
        {
            if (currentFrame > totalFrames)
            {
                currentFrame = 0;
            }

            switch (currentFrame)
            {
                case 0:
                    rectangleX = FrameWidth * 0;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    break;
                case 1:
                    rectangleX = FrameWidth * 1;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    break;
                case 2:
                    rectangleX = FrameWidth * 2;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    break;
                case 3:
                    rectangleX = FrameWidth * 3;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    break;
                case 4:
                    rectangleX = FrameWidth * 4;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    break;
                case 5:
                    rectangleX = FrameWidth * 5;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    break;
                case 6:
                    rectangleX = FrameWidth * 6;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    break;
                case 7:
                    rectangleX = FrameWidth * 7;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    break;
            }
        }

        public override void SetRight()
        {
            currentFrame = 6;
        }

        public void UpdateRight(GameTime gameTime)
        {            
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 6;
                }

                timer = 0f;
            }

        }

        public override void SetLeft()
        {
            currentFrame = 5;
        }

        public void UpdateLeft(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                currentFrame--;
                if (currentFrame == 3)
                {
                    currentFrame = 5;
                }

                timer = 0f;
            }

        }

        public override void SetUp()
        {
            currentFrame = 1;
        }

        public void UpdateUp(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                currentFrame--;
                if (currentFrame < 0)
                {
                    currentFrame = 1;
                }

                timer = 0f;
            }

        }

        public override void SetDown()
        {
            currentFrame = 2;
        }

        public void UpdateDown(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                currentFrame++;
                if (currentFrame == 4)
                {
                    currentFrame = 2;
                }

                timer = 0f;
            }

        }
       
    }
}
