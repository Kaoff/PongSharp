using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongSharp
{
    class Ball
    {
        private Vector2 _position;
        public Vector2 Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        private Vector2 _size;
        private Texture2D texture;

        private Vector2 _direction;
        public Vector2 Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
            }
        }

        public float Speed { get; set; }

        public Ball(GraphicsDeviceManager graphics)
        {
            this._size = new Vector2(10, 10);
            this._position = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight /2) - _size / 2;
            this._direction = new Vector2(1, 0);
            this.Speed = 100f;

            this.texture = new Texture2D(graphics.GraphicsDevice, (int)_size.X, (int)_size.Y);

            Color[] data = new Color[(int)_size.X * (int)_size.Y];

            for (int i = 0; i < data.Length; ++i)
                data[i] = Color.White;

            texture.SetData(data);
        }

        public void Update(GameTime gameTime)
        {
            this._position += _direction * this.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            {
                sb.Draw(texture, _position, Color.White);
            }
            sb.End();
        }
    }
}
