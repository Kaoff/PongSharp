using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace PongSharp
{
    class Player
    {
        private Vector2 _position;
        private Vector2 _size;
        private bool _isCPU;

        public Vector2 Position { get { return _position; } set { this._position = value; } }
        public Vector2 Size { get { return _size; } private set { } }
        public int Score { get; set; }
        public float Speed { get; set; }

        private Texture2D texture;
        private KeySet keySet;

        public Player(GraphicsDeviceManager graphics, Vector2 position, KeySet keySet)
        {
            this.Position = position;
            this.Score = 0;
            this.Speed = 200f;
            this.keySet = keySet;
            this._isCPU = (keySet == null);
            
            this._size = new Vector2(20, 80);

            this.texture = new Texture2D(graphics.GraphicsDevice, (int)_size.X, (int)_size.Y);

            Color[] data = new Color[(int)_size.X * (int)_size.Y];

            for (int i = 0; i < data.Length; ++i)
                data[i] = Color.White;

            texture.SetData(data);
        }

        public void Update(GraphicsDeviceManager graphics, GameTime time, Ball ball)
        {
            if (!_isCPU)
            {
                KeyboardState state = Keyboard.GetState();

                if (state.IsKeyDown(this.keySet.Up))
                {
                    this._position.Y -= this.Speed * (float)time.ElapsedGameTime.TotalSeconds;
                }

                if (state.IsKeyDown(this.keySet.Down))
                {
                    this._position.Y += this.Speed * (float)time.ElapsedGameTime.TotalSeconds;
                }
            }
            else
            {
                if (ball.Position.Y + ball.Size.Y / 2 < this._position.Y + this._size.Y / 2)
                    this._position.Y -= this.Speed * (float)time.ElapsedGameTime.TotalSeconds;

                if (ball.Position.Y + ball.Size.Y / 2 > this._position.Y + this._size.Y / 2)
                    this._position.Y += this.Speed * (float)time.ElapsedGameTime.TotalSeconds;
            }

            if (_position.Y < 10) _position.Y = 10;
            if (_position.Y > (graphics.PreferredBackBufferHeight - _size.Y - 10)) _position.Y = (graphics.PreferredBackBufferHeight - _size.Y - 10);
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
