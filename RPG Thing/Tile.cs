using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RPG_Thing
{
    class Tile
    {
        string name;

        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        public Tile(ContentManager content, string name, Vector2 position)
        {
            this.name = name;
            this.position = position;

            LoadContent(content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(name);
        }

        //Properties

        public String Name
        {
            get { return name; }
        }

        public Vector2 Position
        {
            get { return position; }
        }
    }
}
