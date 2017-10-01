using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using static Nez.VirtualAxis;

namespace WillRose
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Core
    {

        Scene testlevel;

        Scene testlevel_physics;

        Entity testent;

        VirtualAxis _move;

        public GameEngine() : base()
        {
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            testlevel = Scene.createWithDefaultRenderer(Color.CornflowerBlue);

            testlevel_physics = Scene.createWithDefaultRenderer(Color.Beige);

            testent = testlevel_physics.createEntity("test");
            var text = testlevel_physics.content.Load<Texture2D>("dustball");

            testent.transform.setPosition(new Vector2(100, 100));

            testent.addComponent(new Sprite(text));
            testent.addComponent(new BoxCollider());
            testent.addComponent(new Mover());
            
            Core.scene = testlevel_physics;

            _move = new VirtualAxis(new Node[] { new KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.A, Keys.D)});
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Debug.info(_move.ToString());
        }

    }
}
