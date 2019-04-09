using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RPG_Thing
{
    class Spider : Enemy
    {
        public Spider(ContentManager content, Vector2 position)
        {
            LoadContent(content);

            sprite = new AnimatedSprite(texture, 32, 32);

            Health = 3;

            this.position = position;
        }

        public Spider()
        {
            //Empty constructor for quest purposes
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("spiderSpritesheet");
        }

        public override int Damage
        {
            get { return 2; }
        }

        public override int Reward
        {
            get { return 10; }
        }

        public override string Name
        {
            get { return "Spider"; }
        }
    }
}
