using Microsoft.Xna.Framework;
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

        MovementComponent _mover;
        
        Vector2 _velocity;

        public ProjectileComponent(Texture2D tex, Vector2 force)
        {
            _texture = tex;
            _velocity = force;
            _sprite = new Sprite(_texture);
        }

        public override void onAddedToEntity()
        {
            _mover = this.entity.getComponent<MovementComponent>();
            this.entity.addComponent(_sprite);
        }

        public void update()
        {
            if (_mover == null) return;

            if (entity.localPosition.Y > 1000) return;

            _velocity.Y = (float)UpdateJump();
            _mover.update(_velocity);
        }

        private double UpdateJump()
        {
            double distance = _velocity.Y * Time.deltaTime;
            distance += 0.5 * Physics.gravity.Y * Time.deltaTime; // should be deltatime squared, test values
            distance *= EntityConstants.PixelPerMeter; // conversion from meters to pixels
            distance *= 1; // invert axis

            // update velocity
            _velocity.Y += Physics.gravity.Y * Time.deltaTime;

            return distance;
        }
    }
}
