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
        public Vector2 Size
        {
            get
            {
                return _size;
            }
        }

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
            this._size = new Vector2(20, 20);
            this._position = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight /2) - _size / 2;
            this._direction = new Vector2(1, 1);
            this.Speed = 200f;

            this.texture = new Texture2D(graphics.GraphicsDevice, (int)_size.X, (int)_size.Y);

            Color[] data = new Color[(int)_size.X * (int)_size.Y];

            for (int i = 0; i < data.Length; ++i)
                data[i] = Color.White;

            texture.SetData(data);
        }

        public bool CollidePlayer(Player ply)
        {
            if (_position.Y < ply.Position.Y + ply.Size.Y &&
                _size.Y + _position.Y > ply.Position.Y &&
                _position.X < ply.Position.X + ply.Size.X &&
                _position.X + _size.X > ply.Position.X)
            {
                return true;
            }

            return false;
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, Player p1, Player p2)
        {
            if (CollidePlayer(p1))
            {
                int yDir = 0;

                if (p1.Position.Y + p1.Size.Y / 2 > this._position.Y + this._size.Y / 2)
                    yDir = -1;
                else
                    yDir = 1;

                this._direction = new Vector2(1, yDir);
            }

            if (CollidePlayer(p2))
            {
                int yDir = 0;

                if (p2.Position.Y + p2.Size.Y / 2 > this._position.Y + this._size.Y / 2)
                    yDir = -1;
                else
                    yDir = 1;

                this._direction = new Vector2(-1, yDir);
            }

            if (this._position.X <= 0 ||
                this._position.X >= (graphics.PreferredBackBufferWidth - this._size.X))
                this._position = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2) - _size / 2;

            if (this._position.Y <= 0 ||
                this._position.Y >= (graphics.PreferredBackBufferHeight - this._size.Y))
                this._direction.Y *= -1;

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
