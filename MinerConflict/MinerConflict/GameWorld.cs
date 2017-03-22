using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MinerConflict.Builders;
using System.Collections.Generic;

namespace MinerConflict
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        private static GameWorld instance;
        public static GameWorld Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new GameWorld();
                }

                return instance;
            }
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public double cycles { get; private set; }

        public float deltaTime { get; private set; }

        private List<GameObject> gameObjects;
        public static readonly object accessGameObjects = new object();
        internal List<GameObject> GameObjects
        {
            get
            {
                lock (accessGameObjects)
                {
                    return gameObjects;
                }
            }
        }


        public static readonly object addUnit = new object();
        private List<GameObject> addGameObjects;
        public static readonly object removeUnit = new object();
        private List<GameObject> removeGameObjects;

        private GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 512;
            graphics.PreferredBackBufferWidth = 1536;
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
            // TODO: Add your initialization logic here
            gameObjects = new List<GameObject>();
            addGameObjects = new List<GameObject>();
            removeGameObjects = new List<GameObject>();

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

            // TODO: use this.Content to load your game content here
            Globals.Graphics.LoadAllGraphics(this.Content);

            Director dir = new Director(new BaseBuilder());
            gameObjects.Add(dir.Construct(new Vector2(20)));

            dir = new Director(new GoldMineBuilder());
            gameObjects.Add(dir.Construct(new Vector2(20, 370)));

            dir = new Director(new MinerBuilder());
            gameObjects.Add(dir.Construct(new Vector2(20, 150)));
            

            foreach (GameObject obj in gameObjects)
            {
                obj.LoadContent(this.Content);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            // TODO: Add your update logic here

            lock (accessGameObjects)
            {
                foreach (GameObject obj in gameObjects)
                {
                    obj.Update();
                }



                SortGameObjects();
            }

            cycles++;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LawnGreen);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            foreach (GameObject go in gameObjects)
            {
                if (go.GetComponent("SpriteRenderer") is SpriteRenderer)
                {
                    (go.GetComponent("SpriteRenderer") as SpriteRenderer).Draw(spriteBatch);
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        internal void AddUnit(GameObject obj)
        {
            lock (addUnit)
            {
                addGameObjects.Add(obj);
            }
        }

        internal void RemoveUnit(GameObject obj)
        {
            lock (removeUnit)
            {
                removeGameObjects.Add(obj);
            }
        }

        private void SortGameObjects()
        {
            lock (removeUnit)
            {
                if (removeGameObjects.Count > 0)
                {
                    foreach (GameObject obj in removeGameObjects)
                    {
                        gameObjects.Remove(obj);
                    }
                    removeGameObjects.Clear();
                }
            }
            lock (addUnit)
            {
                if (addGameObjects.Count > 0)
                {
                    foreach (GameObject obj in addGameObjects)
                    {
                        gameObjects.Add(obj);
                    }
                    addGameObjects.Clear();
                }
            }
        }
    }
}
