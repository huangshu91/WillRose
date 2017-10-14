using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillRose.Entities
{
    public static class EntityConstants
    {
        public enum MovementStates { REST, JUMP, RUN };

        public const int PlayerVelocity = 400;

        public const int JumpVelocity = 230;

        public const int PixelPerMeter = 20;
    }
}
