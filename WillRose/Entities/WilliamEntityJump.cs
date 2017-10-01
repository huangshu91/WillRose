

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nez;
using Nez.Sprites;
using Nez.Textures;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace WillRose.Entities
{
    public class WilliamComponentJump : Component, ITriggerListener, IUpdatable
    {
        VirtualIntegerAxis _movementInput;
        VirtualButton _jumpInput;
        VirtualButton _test;

        Vector2 _velocity;

        Mover _mover;

        EntityConstants.MovementStates _mState;

        public WilliamComponentJump()
        {
        }

        public override void onAddedToEntity()
        {
            _mState = EntityConstants.MovementStates.JUMP;
            _velocity = new Vector2(0, 0);

            _jumpInput = new VirtualButton();
            _jumpInput.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.Up));

            _test = new VirtualButton();
            _test.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.Down));

            _movementInput = new VirtualIntegerAxis();
            _movementInput.nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Left, Keys.Right));
            _mover = new Mover();

            this.entity.addComponent(_mover);
            this.entity.addComponent(new BoxCollider());
        }

        public void onTriggerEnter(Collider other, Collider local)
        {
            Debug.log("Enter");
            Debug.log("Enter");
            Debug.log("Enter");
            Debug.log("Enter");
        }

        public void onTriggerExit(Collider other, Collider local)
        {
            Debug.log("Exit");
            Debug.log("Exit");
            Debug.log("Exit");
            Debug.log("Exit");
            Debug.log("Exit");
        }

        public void update()
        {
            var movement = new Vector2(_movementInput.value, 0);
            // hack for now since we have no ground
            if (this.entity.localPosition.Y >= 500)
            {
                _velocity.Y = 0;
                _mState = EntityConstants.MovementStates.REST;
            }

            if (_jumpInput.isPressed && _mState == EntityConstants.MovementStates.REST)
            {
                _velocity.Y = -1 * EntityConstants.PlayerVelocity / EntityConstants.PixelPerMeter;
                _mState = EntityConstants.MovementStates.JUMP;
            }

            var distance = Vector2.Multiply(movement, EntityConstants.PlayerVelocity);
            distance = Vector2.Multiply(distance, Time.deltaTime);

            if (_mState == EntityConstants.MovementStates.JUMP)
            {
                distance.Y = (float)UpdateJump();
            }

            Debug.log(this.transform.localPosition);

            CollisionResult result;
            //_mover.move(distance, out result);
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
