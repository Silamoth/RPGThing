using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RPG_Thing
{
    abstract class Enemy
    {
        public Texture2D texture;
        public Vector2 position;
        public Rectangle rectangle;

        public AnimatedSprite sprite;

        double health;

        Random random = new Random();

        bool idle = true;

        int damageTimer = 0;
        bool canDamage = true;
        bool incrementDamageTimer = false;

        public virtual void Update(GameTime gameTime)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.FrameWidth, sprite.FrameHeight);

            sprite.Update();

            if (idle)
            {
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

            if (incrementDamageTimer)
                damageTimer++;

            if (damageTimer > 100)
            {
                canDamage = true;
                incrementDamageTimer = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }

        public virtual void LoadContent(ContentManager content)
        {

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

        public void AttackPlayer(Player player, GameTime gameTime)
        {
            idle = false;

            bool haveSameX = false;
            bool haveSameY = false;

            if (player.Position.X == position.X)
                haveSameX = true;

            if (rectangle.Intersects(new Rectangle((int)position.X, (int)player.Position.Y, player.Rectangle.Width + 15, player.Rectangle.Height + 15)))
            {
                haveSameY = true;
            }

            if (rectangle.Intersects(new Rectangle((int)player.Position.X, (int)position.Y, player.Rectangle.Width + 15, player.Rectangle.Height + 15)))
            {
                haveSameX = true;
            }

            if (haveSameX && !haveSameY)
            {
                if (player.Position.Y > position.Y)
                    MoveDown(gameTime, 1);
                else
                    MoveUp(gameTime, 1);
            }

            if (haveSameY && !haveSameX)
            {
                if (player.Position.X > position.X)
                    MoveRight(gameTime, 1);
                else
                    MoveLeft(gameTime, 1);
            }

            if (!haveSameX && !haveSameY || haveSameX && haveSameY)
            {
                int number = random.Next(0, 2);

                if (number == 0)
                {
                    if (player.Position.X > position.X)
                        MoveRight(gameTime, 1);
                    else
                        MoveLeft(gameTime, 1);
                }
                else
                {
                    if (player.Position.Y > position.Y)
                        MoveDown(gameTime, 1);
                    else
                        MoveUp(gameTime, 1);
                }
            }
        }

        //Properties

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        public double Health
        {
            get { return health; }
            set { health = value; }
        }

        abstract public int Reward
        {
            get;
        }

        abstract public int Damage
        {
            get;
        }

        abstract public string Name
        {
            get;
        }

        public bool IsIdle
        {
            get { return idle; }
            set { idle = value; }
        }

        public bool CanDamage
        {
            get { return canDamage; }
            set { canDamage = value; }
        }

        public bool IncrementDamageTimer
        {
            set { incrementDamageTimer = value; }
        }

        public int DamageTimer
        {
            set { damageTimer = value; }
        }
    }
}
