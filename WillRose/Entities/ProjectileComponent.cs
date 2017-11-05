using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillRose.Entities
{
    public class ProjectileComponent : Component, IUpdatable
    {
        Texture2D _texture;
        Sprite _sprite;

        Mover _mover;
        
        public ProjectileComponent()
        {

        }

        public override void onAddedToEntity()
        {

        }

        public void update()
        {

        }
    }
}
