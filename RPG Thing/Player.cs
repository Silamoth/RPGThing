using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Windows.Forms;

namespace RPG_Thing
{
    class Player
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        PlayerSprite player;

        KeyboardState oldState;

        int maxHealth;
        int maxMana;
        int strength;
        int defense;
        int speed;
        int fame;

        double currentHealth;
        int currentMana;

        int money;

        SpriteFont font;

        Quest currentQuest;

        Knife knife;

        AnimatedSword sword;
        Texture2D swordTexture;

        int statIncreaser;

        public Player(ContentManager content)
        {
            LoadContent(content);
            LoadStats();

            player = new PlayerSprite(texture, 64, 64);
            position = new Vector2(400, 300);

            knife = new Knife();
            sword = new AnimatedSword(swordTexture, 112, 112);
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, player.FrameWidth, player.FrameHeight);

            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && oldState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
            {
                if (position.Y > 0)
                    position.Y -= 5;

                player.UpdateUp(gameTime);
            }

            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && !oldState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
            {
                if (position.Y > 0)
                    position.Y -= 5;

                player.SetUp();
            }

            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && oldState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
            {
                if (position.Y < 3150)
                    position.Y += 5;

                player.UpdateDown(gameTime);
            }

            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && !oldState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
            {
                if (position.Y < 3150)
                    position.Y += 5;

                player.SetDown();
            }

            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D) && oldState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
            {
                if (position.X < 3150)
                    position.X += 5;

                player.UpdateRight(gameTime);
            }

            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D) && !oldState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
            {
                if (position.X < 3150)
                    position.X += 5;

                player.SetRight();
            }

            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && oldState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
            {
                if (position.X > 0)
                    position.X -= 5;

                player.UpdateLeft(gameTime);
            }

            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !oldState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && !newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
            {
                if (position.X > 0)
                    position.X -= 5;

                player.SetLeft();
            }

            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space) && !oldState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                sword.IsActive = true;

                if (player.isUp)
                {
                    player.SetUpSwing(gameTime);
                    sword.SetUp();
                }

                if (player.isDown)
                {
                    player.SetDownSwing(gameTime);
                    sword.SetDown();
                }

                if (player.isRight)
                {
                    player.SetRightSwing(gameTime);
                    sword.SetRight();
                }

                if (player.isLeft)
                {
                    player.SetLeftSwing(gameTime);
                    sword.SetLeft();
                }
            }

            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F))
            {
                if (player.isRight)
                {
                    if (!knife.isActive)
                        knife.ActivateBullet(new Vector2(5000, position.Y), new Vector2(position.X, position.Y + 20), content, 3);
                }

                if (player.isLeft)
                {
                    if (!knife.isActive)
                        knife.ActivateBullet(new Vector2(-5000, position.Y), new Vector2(position.X, position.Y + 20), content, 2);
                }

                if (player.isUp)
                {
                    if (!knife.isActive)
                        knife.ActivateBullet(new Vector2(position.X, -5000), new Vector2(position.X, position.Y + 20), content, 0);
                }

                if (player.isDown)
                {
                    if (!knife.isActive)
                        knife.ActivateBullet(new Vector2(position.X, 5000), new Vector2(position.X, position.Y + 20), content, 1);
                }
            }

            oldState = newState;

            if (knife.isActive)
                knife.Update(gameTime);

            if (knife.isActive)
            {
                if (Vector2.Distance(knife.position, position) > 400)
                    knife.Kill();
            }

            player.Update(gameTime);

            if (currentQuest != null)
            {
                currentQuest.Update();

                if (currentQuest.Completed)
                {
                    fame += currentQuest.Reward;
                    currentQuest = null;
                }
            }

            sword.Update();

            if (statIncreaser == 10)
            {
                statIncreaser = 0;
                strength++;
                defense++;
                maxHealth++;
                currentHealth = maxHealth;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch, position);

            if (knife.isActive)
                knife.Draw(spriteBatch);

            if (sword.IsActive)
            {
                switch (player.CurrentFrame)
                {
                        //Up

                    case 39:
                        sword.Draw(spriteBatch, new Vector2(position.X + 30, position.Y + 15));
                        break;
                    case 40:
                        sword.Draw(spriteBatch, new Vector2(position.X + 43, position.Y + 5));
                        break;
                    case 41:
                        sword.Draw(spriteBatch, new Vector2(position.X + 43, position.Y + 5));
                        break;

                        //Left
                        
                    case 42:
                        sword.Draw(spriteBatch, new Vector2(position.X - 3, position.Y - 5));
                        break;
                    case 43:
                        sword.Draw(spriteBatch, new Vector2(position.X - 3, position.Y));
                        break;
                    case 44:
                        sword.Draw(spriteBatch, new Vector2(position.X - 3, position.Y + 5));
                        break;
                    case 45:
                        sword.Draw(spriteBatch, new Vector2(position.X, position.Y + 10));
                        break;
                    case 46:
                        sword.Draw(spriteBatch, new Vector2(position.X + 3, position.Y + 13));
                        break;

                        //Down

                    case 49:
                        sword.Draw(spriteBatch, new Vector2(position.X + 15, position.Y + 40));
                        break;
                    case 50:
                        sword.Draw(spriteBatch, new Vector2(position.X + 15, position.Y + 40));
                        break;
                    case 51:
                        sword.Draw(spriteBatch, new Vector2(position.X + 20, position.Y + 40));
                        break;
                    case 52:
                        sword.Draw(spriteBatch, new Vector2(position.X + 25, position.Y + 30));
                        break;
                    case 53:
                        sword.Draw(spriteBatch, new Vector2(position.X + 35, position.Y + 30));
                        break;

                        //Right

                    case 54:
                        sword.Draw(spriteBatch, new Vector2(position.X + 40, position.Y - 5));
                        break;
                    case 55:
                        sword.Draw(spriteBatch, new Vector2(position.X + 40, position.Y));
                        break;
                    case 56:
                        sword.Draw(spriteBatch, new Vector2(position.X + 40, position.Y + 5));
                        break;
                    case 57:
                        sword.Draw(spriteBatch, new Vector2(position.X + 34, position.Y + 10));
                        break;
                    case 58:
                        sword.Draw(spriteBatch, new Vector2(position.X + 34, position.Y + 15));
                        break;
                }
            }
        }

        public void DrawStats(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Health: " + currentHealth + "/" + maxHealth, new Vector2(10, 10), Color.Black);
            spriteBatch.DrawString(font, "Mana: " + currentMana + "/" + maxMana, new Vector2(10, 30), Color.Black);
            spriteBatch.DrawString(font, "Fame: " + fame.ToString(), new Vector2(10, 50), Color.Black);

            if (Quest != null)
                spriteBatch.DrawString(font, "Quest: Kill " + Quest.NumberLeftToKill.ToString() + " more " + Quest.Target.Name + "s out of " + Quest.NumberToKill.ToString(), new Vector2(10, 70), Color.Black);
        }

        void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("playerSpritesheet");
            font = content.Load<SpriteFont>("font");
            swordTexture = content.Load<Texture2D>("swordSpritesheet");
        }

        void LoadStats()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "stats.txt";
            string fullPath = System.IO.Path.Combine(path, fileName);

            try
            {
                if (File.Exists(fullPath))
                {
                    StreamReader reader = new StreamReader(fullPath);

                    maxHealth = Convert.ToInt32(reader.ReadLine());
                    maxMana = Convert.ToInt32(reader.ReadLine());
                    strength = Convert.ToInt32(reader.ReadLine());
                    defense = Convert.ToInt32(reader.ReadLine());
                    speed = Convert.ToInt32(reader.ReadLine());
                    currentHealth = Convert.ToInt32(reader.ReadLine());
                    currentMana = Convert.ToInt32(reader.ReadLine());
                    money = Convert.ToInt32(reader.ReadLine());
                    fame = Convert.ToInt32(reader.ReadLine());

                    reader.Close();
                }
                else
                {
                    StreamWriter writer = new StreamWriter(fullPath);

                    //Write the base max health and max mana
                    writer.WriteLine("10");
                    writer.WriteLine("10");

                    //Write the base attribute stats
                    writer.WriteLine("1");
                    writer.WriteLine("1");
                    writer.WriteLine("1");

                    //Write the current health and current mana, which are at the current max
                    writer.WriteLine("10");
                    writer.WriteLine("10");

                    //Write the default money amount
                    writer.WriteLine("0");

                    //Write the default fame amount
                    writer.Write("0");

                    writer.Close();

                    //Read the stats that were just written

                    StreamReader reader = new StreamReader(fullPath);

                    maxHealth = Convert.ToInt32(reader.ReadLine());
                    maxMana = Convert.ToInt32(reader.ReadLine());
                    strength = Convert.ToInt32(reader.ReadLine());
                    defense = Convert.ToInt32(reader.ReadLine());
                    speed = Convert.ToInt32(reader.ReadLine());
                    currentHealth = Convert.ToInt32(reader.ReadLine());
                    currentMana = Convert.ToInt32(reader.ReadLine());
                    money = Convert.ToInt32(reader.ReadLine());

                    reader.Close();
                }
            }catch(Exception e)
            {
                MessageBox.Show("Error", e.Message);
            }
        }

        public void WriteStats()
        {
            StreamWriter writer = new StreamWriter("stats.txt");

            //Write the max health and max mana
            writer.WriteLine(maxHealth.ToString());
            writer.WriteLine(maxMana.ToString());

            //Write the attribute stats
            writer.WriteLine(strength.ToString());
            writer.WriteLine(defense.ToString());
            writer.WriteLine(speed.ToString());

            //Write the current health and current mana
            writer.WriteLine(currentHealth.ToString());
            writer.WriteLine(currentMana.ToString());

            //Write the money
            writer.WriteLine(money.ToString());

            //Write the fame
            writer.Write(fame.ToString());

            writer.Close();
        }

        public void DeleteStats()
        {
            File.Delete("stats.txt");
        }

        //Properties

        public Vector2 Position
        {
            get { return position; }
        }

        public Quest Quest
        {
            get { return currentQuest; }
            set { currentQuest = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        public Knife Knife
        {
            get { return knife; }
        }

        public AnimatedSword Sword
        {
            get { return sword; }
        }

        public double Health
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public double DefenseModifier
        {
            get { return defense * 0.05; }
        }

        public double AttackModifier
        {
            get { return strength * 0.05; }
        }

        public int StatIncreaser
        {
            get { return statIncreaser; }
            set { statIncreaser = value; }
        }
    }
}
