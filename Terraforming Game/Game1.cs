using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Terraforming_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D empty;
        private Texture2D button;
        private Texture2D buttonHover;
        private Texture2D buttonPressed;
        private Texture2D buttonTransparent;

        private SpriteFont uiText_12;
        private SpriteFont uiText_10;
        

        Vector2 resolution = new Vector2(512, 512);
        int resScale = 1;

        string gameSeed = "0000";
        Random seed;

        Solar_System system1;

        enum gameState
        {
            MainMenu = 0,
            GalaxyView,
            SystemView,
            PlanetView,
        }
        gameState _state;

        Button[] _Systembuttons;
        Button[] _Planetbuttons;
        Button[] _Hazardbuttons;

        int currentSystem = 0;
        int currentPlanet = 0;

        private Solar_System[] galaxy;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = (int)(resolution.Y) * resScale;
            graphics.PreferredBackBufferWidth = (int)resolution.X * resScale;
            Content.RootDirectory = "Content";

            _state = gameState.SystemView;
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

            // TODO: use this.Content to load your game content here
            empty = Content.Load<Texture2D>("empty");
            button = Content.Load<Texture2D>("button");
            buttonHover = Content.Load<Texture2D>("buttonhover");
            buttonPressed = Content.Load<Texture2D>("buttonpressed");
            buttonTransparent = Content.Load<Texture2D>("buttontransparent");

            uiText_12 = Content.Load<SpriteFont>("UIText");
            uiText_10 = Content.Load<SpriteFont>("UIText2");

            seed = new Random();
            gameSeed = Convert.ToString(seed.Next(0,1000));
            while (gameSeed.Length < 4)
            {
                gameSeed = "0" + gameSeed;
            }

            //generate new solar system.
            //string[] pN = new string[]{"Mercury","Venus","Earth","Mars","Jupiter","Saturn","Uranus","Neptune"};

            galaxy = new Solar_System[1];
            system1 = new Solar_System("Sol", 8, gameSeed);
            galaxy[0] = system1;        //IMPLEMENT SYSTEM GENERATION LATER

            //SOLAR SYSTEM BUTTON LAYOUT
            _Systembuttons = new Button[13];
            _Systembuttons[0] = new Button(new Rectangle(17, 250, 52, 25), button, buttonHover, buttonPressed);
            for(int i = 1; i < 13; i++)
            {
                _Systembuttons[i] = new Button(new Rectangle(17, 39 + (i * 17), 52,16), button, buttonTransparent, buttonTransparent);
            }

            //PLANET BUTTON LAYOUT
            _Planetbuttons = new Button[1];
            _Planetbuttons[0] = new Button(new Rectangle(20,250,50,25), button, buttonHover, buttonPressed);

            //HAZARD BUTTON LAYOUT

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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

            MouseState mouseState = Mouse.GetState();
            // TODO: Add your update logic here
            switch (_state)
            {
                case gameState.MainMenu:
                    break;
                case gameState.GalaxyView:
                    break;
                case gameState.SystemView:
                    for (int i = 0; i <= galaxy[currentSystem].getSize(); i++)
                    {
                        bool clicked = _Systembuttons[i].Update(mouseState);
                        if (clicked == false) continue;
                        if (i == 0)
                            i = 0;//do the thing
                        else
                        {
                            currentPlanet = i - 1;
                            _state = gameState.PlanetView;
                        }
                    }
                    break;
                case gameState.PlanetView:
                    for (int i = 0; i < _Planetbuttons.Length; i++)
                    {
                        bool clicked = _Planetbuttons[i].Update(mouseState);
                        if (clicked == false) continue;
                        if (i == 0)
                            _state = gameState.SystemView;
                        else
                        {
                        }
                    }
                    break;
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
            
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            switch (_state)
            {
                case gameState.MainMenu:
                    DrawMenu();
                    break;
                case gameState.GalaxyView:
                    DrawGalaxy();
                    break;
                case gameState.SystemView:
                    DrawSystem();
                    break;
                case gameState.PlanetView:
                    DrawPlanet();
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawMenu()
        {
            spriteBatch.Draw(empty, new Rectangle(0, 0, 20, 20), Color.White);
            spriteBatch.DrawString(uiText_12, gameSeed, new Vector2(20, 20), Color.Black);
        }

        private void DrawGalaxy()
        {
            //do things
        }

        private void DrawSystem()
        {
            _Systembuttons[0].setPosition(new Rectangle(17, 60 + (galaxy[currentSystem].getSize()*17), 52, 25));
            for (int i = 0; i <= galaxy[currentSystem].getSize(); i++)
            {
                _Systembuttons[i].Draw(spriteBatch);
            }
            spriteBatch.DrawString(uiText_12, gameSeed, new Vector2(20, 10), Color.Black);
            //do things
            spriteBatch.DrawString(uiText_12, system1.getName(), new Vector2(20, 30), Color.Black);
            for (int i = 0; i < system1.getSize(); i++)
            {
                Planet pTemp = system1.getPlanet(i);
                float pDist = pTemp.getDistance(); pDist /= 20;
                string planetInfo = "Planet " + i + ": Name = " + pTemp.getName() + "; Distance = " + pDist + "AU; Type = " + Globals.getTemplate(pTemp.getType());

                spriteBatch.DrawString(uiText_10, planetInfo, new Vector2(20, 55 + (i*17)), Color.Black);
            }
        }

        private void DrawPlanet()
        {
            foreach (Button b in _Planetbuttons)
            {
                b.Draw(spriteBatch);
            }
            Planet tPlanet = galaxy[currentSystem].getPlanet(currentPlanet);
            spriteBatch.DrawString(uiText_12, "system " + currentSystem + ", planet " + currentPlanet, new Vector2(20, 10), Color.Black);
            spriteBatch.DrawString(uiText_12, tPlanet.getName(), new Vector2(20, 30), Color.Black);
            //do things
        }
    }
}
