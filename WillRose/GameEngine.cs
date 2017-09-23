using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using WillRose.Levels;

namespace WillRose
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Core
    {
        Scene.SceneResolutionPolicy policy;

        Scene testlevel;
        Scene testlevel_physics;

        public GameEngine() : base()
        {
            // michelle: play around with this
            policy = Scene.SceneResolutionPolicy.None; 
            Scene.setDefaultDesignResolution(400, 400, policy);

            Window.AllowUserResizing = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            testlevel = new TestLevel();

            testlevel_physics = Scene.createWithDefaultRenderer(Color.Beige);

            Core.scene = testlevel;
        }
        
    }
}
