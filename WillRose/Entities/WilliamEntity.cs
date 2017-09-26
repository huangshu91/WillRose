

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
    public class WilliamComponent : Component, ITriggerListener, IUpdatable
    {
        VirtualIntegerAxis _movementInput;
        VirtualButton _jumpInput;

        Mover _mover;

        EntityConstants.MovementStates _mState;

        public override void onAddedToEntity()
        {
            _jumpInput = new VirtualButton();
            _jumpInput.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.W));

            _movementInput = new VirtualIntegerAxis();
            _movementInput.nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.A, Keys.D));

            _mover = new Mover();

            this.entity.addComponent(_mover);
        }

        public void onTriggerEnter(Collider other, Collider local)
        {
            throw new NotImplementedException();
        }

        public void onTriggerExit(Collider other, Collider local)
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            var movement = new Vector2(_movementInput.value, 0);
            var jumping = _jumpInput.isPressed;

            _mState = EntityConstants.MovementStates.JUMP;

            var distance = Vector2.Multiply(movement, EntityConstants.PlayerVelocity);
            distance = Vector2.Multiply(distance, Time.deltaTime);

            Debug.log(distance);

            CollisionResult result;
            _mover.move(distance, out result);

            Debug.log(movement);
            Debug.log(jumping);
            Debug.log(Time.deltaTime);
        }
    }
}
