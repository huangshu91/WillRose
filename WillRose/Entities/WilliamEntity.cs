

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
using Microsoft.Xna.Framework.Graphics;

namespace WillRose.Entities
{
    public class WilliamComponent : Component, ITriggerListener, IUpdatable
    {
        VirtualIntegerAxis _movementInput;
        VirtualButton _jumpInput;
        VirtualButton _test;

        Vector2 _velocity;

        Mover _mover;
        Texture2D armor;

        CollisionResult result;

        EntityConstants.MovementStates _mState;

        public WilliamComponent(Texture2D sprite)
        {
            armor = sprite;
        }

        public override void onAddedToEntity()
        {
            _mState = EntityConstants.MovementStates.JUMP;
            _velocity = new Vector2(0, 0);

            _jumpInput = new VirtualButton();
            _jumpInput.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.W));

            _test = new VirtualButton();
            _test.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.S));

            _movementInput = new VirtualIntegerAxis();
            _movementInput.nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.A, Keys.D));
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

            if (_jumpInput.isPressed && _mState == EntityConstants.MovementStates.REST)
            {
                _velocity.Y = -1 * EntityConstants.JumpVelocity / EntityConstants.PixelPerMeter;
                _mState = EntityConstants.MovementStates.JUMP;
            }

            var distance = Vector2.Multiply(movement, EntityConstants.PlayerVelocity);
            distance = Vector2.Multiply(distance, Time.deltaTime);

            if (_mState == EntityConstants.MovementStates.JUMP)
            {
                distance.Y = (float)UpdateJump();
            }
            //var ground = this.transform.localPosition;
            //ground.Y += armor.Height / 2 + 1;
            //var hit = Physics.linecast(this.transform.localPosition, ground);
            //if (result.below)

            Debug.log(this.transform.localPosition);
            
            _mover.move(distance, out result);

            //Debug.log(result);

            var ground = this.transform.localPosition;

            Debug.log(ground);

            ground.Y += armor.Height / 2 + 1;
            var hit = Physics.linecast(this.transform.localPosition, ground);

            Debug.log(ground);

            if (hit.collider != null && hit.collider.entity.name.Equals("ground"))
            {
                _velocity.Y = 0;
                _mState = EntityConstants.MovementStates.REST;
            }
            else
            {
                _mState = EntityConstants.MovementStates.JUMP;
            }

            Debug.log(_mState);
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
