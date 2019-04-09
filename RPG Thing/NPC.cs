using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RPG_Thing
{
    class NPC
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        AnimatedSprite sprite;

        Random random = new Random();

        public NPC(ContentManager content)
        {
            LoadContent(content);

            sprite = new AnimatedSprite(texture, 32, 32);

            position = new Vector2(random.Next(100, 3100), random.Next(100, 3100));

            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.FrameWidth, sprite.FrameHeight);
        }

        public void Update(GameTime gameTime)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.FrameWidth, sprite.FrameHeight);

            sprite.Update();

            //Random movement

            int number = random.Next(0, 361);

            switch (number)
            {
                case 0:
                    MoveRight(gameTime, 10);
                    break;
                case 1:
                    MoveLeft(gameTime, 10);
                    break;
                case 2:
                    MoveDown(gameTime, 10);
                    break;
                case 3:
                    MoveUp(gameTime, 10);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void MoveUp(GameTime gameTime, int amount)
        {
            position.Y -= amount;

            if (sprite.IsUp)
                sprite.UpdateUp(gameTime);
            else
                sprite.SetUp();
        }

        public void MoveDown(GameTime gameTime, int amount)
        {
            position.Y += amount;

            if (sprite.IsDown)
                sprite.UpdateDown(gameTime);
            else
                sprite.SetDown();
        }

        public void MoveLeft(GameTime gameTime, int amount)
        {
            position.X -= amount;

            if (sprite.IsLeft)
                sprite.UpdateLeft(gameTime);
            else
                sprite.SetLeft();
        }

        public void MoveRight(GameTime gameTime, int amount)
        {
            position.X += amount;

            if (sprite.IsRight)
                sprite.UpdateRight(gameTime);
            else
                sprite.SetRight();
        }

        void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("knight1Spritesheet");
        }

        //Properties

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }
    }
}
