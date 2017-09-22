using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace WillRose
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Core
    {

        Scene testlevel;

        Scene testlevel_physics;

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

            var texture = testlevel.content.Load<Texture2D>("test");
            var entity = testlevel.createEntity("entityId");
            entity.addComponent(new Sprite(texture));

            testlevel_physics = Scene.createWithDefaultRenderer(Color.Beige);

            Core.scene = testlevel;
        }
        
    }
}
