using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillRose.Entities
{
    public class MovementComponent : Component
    {
        private Mover _mover;

        public Vector2 _velocity;

        public EntityConstants.MovementStates _mState;
        public EntityConstants.MovementDirection _mDirection;

        private Sprite _sprite;

        public CollisionResult result;

        public MovementComponent()
        {
            _velocity = new Vector2(0, 0);
        }

        public override void onAddedToEntity()
        {
            _sprite = this.getComponent<Sprite>();
            _mover = new Mover();

            this.entity.addComponent(_mover);
            this.entity.addComponent(new BoxCollider());
        }

        public void update()
        {

        }

        public void update(Vector2 update)
        {
            if (update.X > 0)
            {
                _mDirection = EntityConstants.MovementDirection.RIGHT;
            }
            else if (update.X < 0)
            {
                _mDirection = EntityConstants.MovementDirection.LEFT;
            }

            _mover.move(update, out result);
        }

        public double UpdateGravity()
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
