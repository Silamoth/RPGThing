using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RPG_Thing
{
    class Knife
    {
        private Texture2D texture;
        private Vector2 target;
        public Vector2 position;
        private Vector2 velocity;
        public bool isActive;
        private float moveSpeed;
        Rectangle rectangle;

        int damage = 1;

        public Knife()
        {
            isActive = false;
        }

        public void ActivateBullet(Vector2 target, Vector2 position, ContentManager content, int direction)
        {
            this.target = target;
            this.position = position;
            moveSpeed = 650;

            switch (direction)
            {
                case 0:
                    LoadContentUp(content);
                    break;
                case 1:
                    LoadContentDown(content);
                    break;
                case 2:
                    LoadContentLeft(content);
                    break;
                case 3:
                    LoadContentRight(content);
                    break;
            }

            isActive = true;
            SetVelocity();
        }

        public void SetVelocity()
        {
            velocity = -(position - target);
            velocity.Normalize();
        }

        public void Update(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Update position and the collision rectangle
            position += (velocity * moveSpeed * elapsedTime);
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)(texture.Width * .15), (int)(texture.Height * .15));

            //Out of bounds checks
            //if (position.X > 3200)
            //    Kill();

            //if (position.X < 0)
            //    Kill();

            //if (position.Y < 0)
            //    Kill();

            //if (position.Y > 3200)
            //    Kill();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(texture, position, null, Color.White, 0f, new Vector2(0, 0), 0.15f, SpriteEffects.None, 1f);
        }

        public void Kill()
        {
            isActive = false;
            moveSpeed = 0;
            position = new Vector2(1000, 1000);
        }

        void LoadContentUp(ContentManager content)
        {
            texture = content.Load<Texture2D>("swordUp");
        }

        void LoadContentDown(ContentManager content)
        {
            texture = content.Load<Texture2D>("swordDown");
        }

        void LoadContentLeft(ContentManager content)
        {
            texture = content.Load<Texture2D>("swordLeft");
        }

        void LoadContentRight(ContentManager content)
        {
            texture = content.Load<Texture2D>("swordRight");
        }

        //Propeties

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
    }
}