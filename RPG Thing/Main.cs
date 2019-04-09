using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace RPG_Thing
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;

        Camera camera = new Camera();

        List<Enemy> enemies;

        string[] mapString = new string[100];
        char[,] mapChar = new char[100, 100];
        List<Tile> tiles;

        SpriteFont font;

        Random random = new Random();

        NPC npc;

        //State variables

        bool isPlaying = true;
        bool isPaused = false;

        //Timer stuff for pausing the game

        int pauseTimer = 0;
        bool canPause = true;
        bool incrementPauseTimer = false;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);

            Window.AllowUserResizing = true;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            enemies = new List<Enemy>();
            tiles = new List<Tile>();

            LoadMap();

            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Player(Content);

            font = Content.Load<SpriteFont>("font");

            npc = new NPC(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (canPause)
                {
                    if (isPaused)
                        isPaused = false;
                    else
                        isPaused = true;

                    if (isPlaying)
                        isPlaying = false;
                    else
                        isPlaying = true;

                    canPause = false;
                    pauseTimer = 0;
                    incrementPauseTimer = true;
                }
            }

            if (isPlaying)
            {
                player.Update(gameTime, Content);

                npc.Update(gameTime);

                camera.Update(player.Position);

                Vector2 mouseCoordinates = new Vector2(Mouse.GetState().X + camera.Position.X, Mouse.GetState().Y + camera.Position.Y);

                Rectangle mouseRectangle = new Rectangle((int)mouseCoordinates.X, (int)mouseCoordinates.Y, 12, 12);

                if (npc.Rectangle.Intersects(mouseRectangle))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        player.Quest = new Quest();
                    }
                }

                foreach (Enemy enemy in enemies)
                {
                    enemy.Update(gameTime);

                    if (Vector2.Distance(player.Position, enemy.position) < 400 && Vector2.Distance(player.Position, enemy.position) > 15)
                    {
                        enemy.AttackPlayer(player, gameTime);
                    }

                    if (enemy.Rectangle.Intersects(player.Knife.Rectangle))
                    {
                        if (player.Knife.isActive)
                        {
                            enemy.Health -= (player.Knife.Damage + player.AttackModifier);
                            player.Knife.Kill();
                        }
                    }

                    if (enemy.Rectangle.Intersects(player.Sword.Rectangle))
                    {
                        if (player.Sword.IsActive)
                        {
                            enemy.Health -= (player.Sword.Damage + player.AttackModifier);
                            player.Sword.Kill();
                        }
                    }

                    if (enemy.Rectangle.Intersects(player.Rectangle))
                    {
                        if (enemy.CanDamage)
                        {
                            player.Health -= (enemy.Damage - player.DefenseModifier);
                            enemy.CanDamage = false;
                            enemy.IncrementDamageTimer = true;
                            enemy.DamageTimer = 0;
                        }
                    }
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].Health < 1)
                    {
                        if (player.Quest != null)
                        {
                            if (enemies[i].GetType() == player.Quest.Target.GetType())
                                player.Quest.NumberLeftToKill--;
                        }

                        enemies.RemoveAt(i);
                        player.StatIncreaser++;
                    }
                }

                foreach (Tile tile in tiles)
                {
                    int number;
                    switch (tile.Name)
                    {
                        case "grass":
                            number = random.Next(0, 1050210);
                            if (number == 97)
                                enemies.Add(new Skeleton(Content, tile.Position));
                            else if (number == 98)
                                enemies.Add(new Spider(Content, tile.Position));
                            break;
                        case "sand":
                            number = random.Next(0, 1000000);
                            if (number == 97)
                                enemies.Add(new Demon(Content, tile.Position));
                            break;
                    }
                }      
            }

            if (incrementPauseTimer)
                pauseTimer++;

            if (pauseTimer == 45)
            {
                incrementPauseTimer = false;
                canPause = true;
            }

            if (player.Health <= 0)
            {
                isPlaying = false;
                player.DeleteStats();
                Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.ViewMatrix);

            foreach (Tile tile in tiles)
                tile.Draw(spriteBatch);

            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
                spriteBatch.DrawString(font, enemy.Health.ToString(), new Vector2(enemy.position.X + 10, enemy.position.Y - 20), Color.White);
            }

            player.Draw(spriteBatch);

            npc.Draw(spriteBatch);

            //spriteBatch.Draw(Content.Load<Texture2D>("Bullet"), new Rectangle(Mouse.GetState().Position.X, Mouse.GetState().Position.Y, 12, 12), Color.Black);

            spriteBatch.End();

            spriteBatch.Begin();

            player.DrawStats(spriteBatch);

            if (isPaused)
                spriteBatch.DrawString(font, "The game is paused.  Hit Esc again to unpause it.", new Vector2(275, 200), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);

            if (isPlaying)
                player.WriteStats();
        }

        void LoadMap()
        {
            
            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "map.txt");
            StreamReader reader = new StreamReader(@"Content\map.txt");

            int index = 0;

            //Gather the map into a string array

            while (reader.Peek() != -1)
            {
                mapString[index] = reader.ReadLine();
                index++;
            }

            //Convert the string array into a two-dimensional char array

            for (int i = 0; i < mapString.Length; i++)
            {
                char[] temp = new char[mapString[i].Length];
                temp = mapString[i].ToCharArray();

                for (int x = 0; x < temp.Length; x++)
                {
                    mapChar[i, x] = temp[x];
                }
            }

            //Loop through the now-gathered map to make the actual tiles

            for (int i = 0; i < mapChar.GetLength(0); i++)
            {
                for (int x = 0; x < mapChar.GetLength(1); x++)
                {
                    switch (mapChar[x, i])
                    {
                        case 'x':
                            tiles.Add(new Tile(Content, "grass", new Vector2(i * 32, x * 32)));
                            break;
                        //case 'y':
                        //    tiles.Add(new Tile(Content, "grassLight", new Vector2(i * 32, x * 32)));
                        //    break;
                        //case 'z':
                        //    tiles.Add(new Tile(Content, "grassLime", new Vector2(i * 32, x * 32)));
                        //    break;
                        case 'l':
                            tiles.Add(new Tile(Content, "topLeftGrass", new Vector2(i * 32, x * 32)));
                            break;
                        case 'f':
                            tiles.Add(new Tile(Content, "midLeftGrass", new Vector2(i * 32, x * 32)));
                            break;
                        case 'c':
                            tiles.Add(new Tile(Content, "bottomLeftGrass", new Vector2(i * 32, x * 32)));
                            break;
                        case 'r':
                            tiles.Add(new Tile(Content, "topRightGrass", new Vector2(i * 32, x * 32)));
                            break;
                        case 'j':
                            tiles.Add(new Tile(Content, "midRightGrass", new Vector2(i * 32, x * 32)));
                            break;
                        case 'p':
                            tiles.Add(new Tile(Content, "bottomRightGrass", new Vector2(i * 32, x * 32)));
                            break;
                        case 'u':
                            tiles.Add(new Tile(Content, "bottomMidGrass", new Vector2(i * 32, x * 32)));
                            break;
                        case 's':
                            tiles.Add(new Tile(Content, "sand", new Vector2(i * 32, x * 32)));
                            break;
                        case 'w':
                            tiles.Add(new Tile(Content, "bottomLeftSand", new Vector2(i * 32, x * 32)));
                            break;
                        case 'o':
                            tiles.Add(new Tile(Content, "bottomMidSand", new Vector2(i * 32, x * 32)));
                            break;
                        case 'i':
                            tiles.Add(new Tile(Content, "bottomRightSand", new Vector2(i * 32, x * 32)));
                            break;
                        case 't':
                            tiles.Add(new Tile(Content, "midRightSand", new Vector2(i * 32, x * 32)));
                            break;
                        case 'g':
                            tiles.Add(new Tile(Content, "midLeftSand", new Vector2(i * 32, x * 32)));
                            break;
                        case 'h':
                            tiles.Add(new Tile(Content, "topRightSand", new Vector2(i * 32, x * 32)));
                            break;
                        case 'd':
                            tiles.Add(new Tile(Content, "topMidSand", new Vector2(i * 32, x * 32)));
                            break;
                        case 'e':
                            tiles.Add(new Tile(Content, "topLeftSand", new Vector2(i * 32, x * 32)));
                            break;
                        case 'k':
                            tiles.Add(new Tile(Content, "topMidGrass", new Vector2(i * 32, x * 32)));
                            break;
                    }
                }
            }
        }
    }
}