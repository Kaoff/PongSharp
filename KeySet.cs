using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace PongSharp
{
    class KeySet
    {
        public Keys Up { get; set; }
        public Keys Down { get; set; }
    
        public KeySet(Keys up, Keys down)
        {
            this.Up = up;
            this.Down = down;
        }
    }
}
