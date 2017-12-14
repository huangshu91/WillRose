using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.PhysicsShapes;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WillRose.Entities;

namespace WillRose.Levels
{
    public class TestLevel : Nez.Scene
    {
        Texture2D armor;
        Texture2D crom;

        public Dictionary<string, Texture2D> _textures;

        public TestLevel() : base() { }

        public override void initialize()
        {
            base.initialize();

            addRenderer(new DefaultRenderer());
            clearColor = Color.LightBlue;

            _textures = new Dictionary<string, Texture2D>();

            armor = content.Load<Texture2D>("unit_armor");
            crom = content.Load<Texture2D>("williamPixel_v4v2");
            var dust = content.Load<Texture2D>("dustball");

            _textures.Add("armor", armor);
            _textures.Add("crom", crom);
            _textures.Add("dust", dust);

            InitializeEntities();
            InitializeEnvironment();
        }

        private void InitializeEntities()
        {
            var entity = createEntity("William", new Vector2(100, 300));
            entity.addComponent(new Sprite(crom));

            var movecomp = new MovementComponent();
            entity.addComponent(movecomp);

            entity.addComponent(new WilliamComponent(crom, _textures["armor"]));

            camera.entity.addComponent(new FollowCamera(entity));

            //var entity3 = createEntity("William2", new Vector2(300, 300));
            //entity3.addComponent(new Sprite(armor));
            //entity3.addComponent(new WilliamComponentJump());

            var entity2 = createEntity("TestUnit", new Vector2(600, 480));
            Sprite cromSprite = new Sprite(armor);
            //cromSprite.color = Color.Black;
            entity2.addComponent(cromSprite);
            //entity2.scale = new Vector2(0.15f, 0.15f);
            entity2.addComponent(new NpcEntity());

            //var entity3 = createEntity("TestTest");
            //entity3.addComponent(new Text(Graphics.instance.bitmapFont, "TESTTEST3", new Vector2(565, 350), Color.Black))
            //    .setRenderLayer(999);
        }

        private void InitializeEnvironment()
        {
            var polyPoints = new Vector2[] { new Vector2(0, 0), new Vector2(1600, 0), new Vector2(1600, 300), new Vector2(0, 300) };
            var polygonEntity = createEntity("ground");
            polygonEntity.setPosition(0, 500);
            polygonEntity.addComponent(new PolygonMesh(polyPoints)).setColor(Color.DarkBlue);
            polygonEntity.addComponent(new PolygonCollider(polyPoints));
        }

        public override void update()
        {
            base.update();
        }
    }
}
