using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace Kruh
{
    public class Demo : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int _sirkaOkna = 800;
        private int _vyskaOkna = 600;

        

        private Texture2D _textura;

        private int x, y, w, h, v;
        private Color c;


        public Demo()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = _sirkaOkna;
            _graphics.PreferredBackBufferHeight = _vyskaOkna;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            

            w = h = 100;

            x = (_sirkaOkna - w) / 2;
            y = (_vyskaOkna - h) / 2;

            v = 3;
            c = Color.Black;

            int d = 1000;
            int r = d / 2;

            

            Color[] pixely = new Color[d * d];

            for (int i = 0; i < d; i++)
                for (int j = 0; j < d; j++)
                    if (Math.Sqrt(Math.Pow(j - r, 2) + Math.Pow(i - r, 2)) < r)
                        pixely[d * i + j] = Color.White;
                    else
                        pixely[d * i + j] = Color.Transparent;



            _textura = new Texture2D(GraphicsDevice, d, d);
            _textura.SetData(pixely);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                x += v;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                x -= v;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                y -= v;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                y += v;
            if (x < 0)
                x = 0;
                
            if (y < 0)
                y = 0;
            if (x > _sirkaOkna - w)
                x = _sirkaOkna - w;
            if (y > _vyskaOkna - h)
                y = _vyskaOkna - h;
            if (Keyboard.GetState().IsKeyDown(Keys.R))
                c = Color.Red;
            if (Keyboard.GetState().IsKeyDown(Keys.G))
                c = Color.Green;
            if (Keyboard.GetState().IsKeyDown(Keys.B))
                c = Color.Blue;
         

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_textura, new Rectangle(x, y, w, h), c);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
