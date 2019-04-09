using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG_Thing
{
    class PlayerSprite : AnimatedThing
    {
        bool isSwingingUp, isSwingingLeft, isSwingingDown, isSwingingRight = false;

        int swingTimer = 0;

        public PlayerSprite(Texture2D texture, int frameWidth, int frameHeight)
        {
            this.texture = texture;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;

            rectangleX = 0;
            rectangleY = FrameHeight * 0;

            currentFrame = 0;

            //totalFrames = texture.Width / frameWidth;
        }

        public override void Update(GameTime gameTime)
        {
            //if (currentFrame > totalFrames)
            //{
            //    currentFrame = 0;
            //}

            switch (currentFrame)
            {
                    //Up

                case 0:
                    rectangleX = FrameWidth * 0;
                    rectangleY = FrameHeight * 0;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 1:
                    rectangleX = FrameWidth * 1;
                    rectangleY = FrameHeight * 0;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 2:
                    rectangleX = FrameWidth * 2;
                    rectangleY = FrameHeight * 0;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 3:
                    rectangleX = FrameWidth * 3;
                    rectangleY = FrameHeight * 0;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 4:
                    rectangleX = FrameWidth * 4;
                    rectangleY = FrameHeight * 0;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 5:
                    rectangleX = FrameWidth * 5;
                    rectangleY = FrameHeight * 0;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 6:
                    rectangleX = FrameWidth * 6;
                    rectangleY = FrameHeight * 0;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 7:
                    rectangleX = FrameWidth * 7;
                    rectangleY = FrameHeight * 0;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 8:
                    rectangleX = FrameWidth * 8;
                    rectangleY = FrameHeight * 0;
                    isUp = true;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;

                    //Left

                    case 9:
                    rectangleX = FrameWidth * 0;
                    rectangleY = FrameHeight * 1;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 10:
                    rectangleX = FrameWidth * 1;
                    rectangleY = FrameHeight * 1;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    break;
                case 11:
                    rectangleX = FrameWidth * 2;
                    rectangleY = FrameHeight * 1;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 12:
                    rectangleX = FrameWidth * 3;
                    rectangleY = FrameHeight * 1;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 13:
                    rectangleX = FrameWidth * 4;
                    rectangleY = FrameHeight * 1;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 14:
                    rectangleX = FrameWidth * 5;
                    rectangleY = FrameHeight * 1;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 15:
                    rectangleX = FrameWidth * 6;
                    rectangleY = FrameHeight * 1;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 16:
                    rectangleX = FrameWidth * 7;
                    rectangleY = FrameHeight * 1;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 17:
                    rectangleX = FrameWidth * 8;
                    rectangleY = FrameHeight * 1;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = true;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;

                    //Down

                    case 18:
                    rectangleX = FrameWidth * 0;
                    rectangleY = FrameHeight * 2;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 19:
                    rectangleX = FrameWidth * 1;
                    rectangleY = FrameHeight * 2;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 20:
                    rectangleX = FrameWidth * 2;
                    rectangleY = FrameHeight * 2;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 21:
                    rectangleX = FrameWidth * 3;
                    rectangleY = FrameHeight * 2;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 22:
                    rectangleX = FrameWidth * 4;
                    rectangleY = FrameHeight * 2;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 23:
                    rectangleX = FrameWidth * 5;
                    rectangleY = FrameHeight * 2;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 24:
                    rectangleX = FrameWidth * 6;
                    rectangleY = FrameHeight * 2;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 25:
                    rectangleX = FrameWidth * 7;
                    rectangleY = FrameHeight * 2;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 26:
                    rectangleX = FrameWidth * 8;
                    rectangleY = FrameHeight * 2;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;

                    //Right

                    case 27:
                    rectangleX = FrameWidth * 0;
                    rectangleY = FrameHeight * 3;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 28:
                    rectangleX = FrameWidth * 1;
                    rectangleY = FrameHeight * 3;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 29:
                    rectangleX = FrameWidth * 2;
                    rectangleY = FrameHeight * 3;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 30:
                    rectangleX = FrameWidth * 3;
                    rectangleY = FrameHeight * 3;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 31:
                    rectangleX = FrameWidth * 4;
                    rectangleY = FrameHeight * 3;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 32:
                    rectangleX = FrameWidth * 5;
                    rectangleY = FrameHeight * 3;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 33:
                    rectangleX = FrameWidth * 6;
                    rectangleY = FrameHeight * 3;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 34:
                    rectangleX = FrameWidth * 7;
                    rectangleY = FrameHeight * 3;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 35:
                    rectangleX = FrameWidth * 8;
                    rectangleY = FrameHeight * 3;
                    isUp = false;
                    isDown = false;
                    isRight = true;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;

                    //Up swing

                case 36:
                    rectangleX = FrameWidth * 0;
                    rectangleY = FrameHeight * 4;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = true;
                    break;
                case 37:
                    rectangleX = FrameWidth * 1;
                    rectangleY = FrameHeight * 4;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = true;
                    break;
                case 38:
                    rectangleX = FrameWidth * 2;
                    rectangleY = FrameHeight * 4;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = true;
                    break;
                case 39:
                    rectangleX = FrameWidth * 3;
                    rectangleY = FrameHeight * 4;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = true;
                    break;
                case 40:
                    rectangleX = FrameWidth * 4;
                    rectangleY = FrameHeight * 4;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = true;
                    break;
                case 41:
                    rectangleX = FrameWidth * 5;
                    rectangleY = FrameHeight * 4;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = true;
                    break;

                    //Left swing

                    case 42:
                    rectangleX = FrameWidth * 0;
                    rectangleY = FrameHeight * 5;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = true;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 43:
                    rectangleX = FrameWidth * 1;
                    rectangleY = FrameHeight * 5;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = true;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 44:
                    rectangleX = FrameWidth * 2;
                    rectangleY = FrameHeight * 5;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = true;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 45:
                    rectangleX = FrameWidth * 3;
                    rectangleY = FrameHeight * 5;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = true;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 46:
                    rectangleX = FrameWidth * 4;
                    rectangleY = FrameHeight * 5;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = true;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 47:
                    rectangleX = FrameWidth * 5;
                    rectangleY = FrameHeight * 5;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = true;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;

                    //Down swing

                    case 48:
                    rectangleX = FrameWidth * 0;
                    rectangleY = FrameHeight * 6;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = true;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 49:
                    rectangleX = FrameWidth * 1;
                    rectangleY = FrameHeight * 6;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = true;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 50:
                    rectangleX = FrameWidth * 2;
                    rectangleY = FrameHeight * 6;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = true;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 51:
                    rectangleX = FrameWidth * 3;
                    rectangleY = FrameHeight * 6;
                    isUp = false;
                    isDown = true;
                    isRight = false;
                    isLeft = false;
                    break;
                case 52:
                    rectangleX = FrameWidth * 4;
                    rectangleY = FrameHeight * 6;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = true;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;
                case 53:
                    rectangleX = FrameWidth * 5;
                    rectangleY = FrameHeight * 6;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = true;
                    isSwingingLeft = false;
                    isSwingingRight = false;
                    isSwingingUp = false;
                    break;

                    //Right swing

                case 54:
                    rectangleX = FrameWidth * 0;
                    rectangleY = 448;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = true;
                    isSwingingUp = false;
                    break;
                case 55:
                    rectangleX = FrameWidth * 1;
                    rectangleY = 448;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = true;
                    isSwingingUp = false;
                    break;
                case 56:
                    rectangleX = FrameWidth * 2;
                    rectangleY = 448;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = true;
                    isSwingingUp = false;
                    break;
                case 57:
                    rectangleX = FrameWidth * 3;
                    rectangleY = 448;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = true;
                    isSwingingUp = false;
                    break;
                case 58:
                    rectangleX = FrameWidth * 4;
                    rectangleY = 448;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = true;
                    isSwingingUp = false;
                    break;
                case 59:
                    rectangleX = FrameWidth * 5;
                    rectangleY = 448;
                    isUp = false;
                    isDown = false;
                    isRight = false;
                    isLeft = false;
                    isSwingingDown = false;
                    isSwingingLeft = false;
                    isSwingingRight = true;
                    isSwingingUp = false;
                    break;
            }

            if (isSwingingDown || isSwingingLeft || isSwingingRight || isSwingingUp)
            {
                swingTimer++;
            }

            if (swingTimer == 1)
            {
                if (isSwingingUp)
                    UpdateUpSwing(gameTime);
                if (isSwingingRight)
                    UpdateRightSwing(gameTime);
                if (isSwingingLeft)
                    UpdateLeftSwing(gameTime);
                if (isSwingingDown)
                    UpdateDownSwing(gameTime);

                swingTimer = 0;
            }
        }

        public override void SetRight()
        {
            currentFrame = 27;
        }

        public void UpdateRight(GameTime gameTime)
        {            
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                currentFrame++;
                if (currentFrame == 35)
                {
                    currentFrame = 27;
                }

                timer = 0f;
            }

        }

        public override void SetLeft()
        {
            currentFrame = 9;
        }

        public void UpdateLeft(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                currentFrame++;
                if (currentFrame == 17)
                {
                    currentFrame = 9;
                }

                timer = 0f;
            }

        }

        public override void SetUp()
        {
            currentFrame = 0;
        }

        public void UpdateUp(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                currentFrame++;
                if (currentFrame == 8)
                {
                    currentFrame = 0;
                }

                timer = 0f;
            }

        }

        public override void SetDown()
        {
            currentFrame = 18;
        }

        public void UpdateDown(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                currentFrame++;
                if (currentFrame == 26)
                {
                    currentFrame = 18;
                }

                timer = 0f;
            }
        }

        public void SetUpSwing(GameTime gameTime)
        {
            currentFrame = 36;
            UpdateUpSwing(gameTime);
        }

        public void UpdateUpSwing(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > 41)
                {
                    SetUp();
                }

                timer = 0f;
            }
        }

        public void SetLeftSwing(GameTime gameTime)
        {
            currentFrame = 42;
            UpdateLeftSwing(gameTime);
        }

        public void UpdateLeftSwing(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame == 48)
                {
                    SetLeft();
                }

                timer = 0f;
            }
        }

        public void SetDownSwing(GameTime gameTime)
        {
            currentFrame = 48;
            UpdateDownSwing(gameTime);
        }

        public void UpdateDownSwing(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame == 54)
                {
                    SetDown();
                }

                timer = 0f;
            }
        }

        public void SetRightSwing(GameTime gameTime)
        {
            currentFrame = 54;
            UpdateRightSwing(gameTime);
        }

        public void UpdateRightSwing(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame == 60)
                {
                    SetRight();
                }

                timer = 0f;
            }
        }
    }
}
