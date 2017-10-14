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

        public TestLevel() : base() { }

        public override void initialize()
        {
            base.initialize();

            addRenderer(new DefaultRenderer());
            clearColor = Color.LightBlue;

            InitializeEntities();
            InitializeEnvironment();
        }

        private void InitializeEntities()
        {
            armor = content.Load<Texture2D>("unit_armor");

            var entity = createEntity("William", new Vector2(100, 300));
            entity.addComponent(new Sprite(armor));
            entity.addComponent(new WilliamComponent(armor));

            camera.entity.addComponent(new FollowCamera(entity));

            //var entity3 = createEntity("William2", new Vector2(300, 300));
            //entity3.addComponent(new Sprite(armor));
            //entity3.addComponent(new WilliamComponentJump());

            //var entity2 = createEntity("TestUnit", new Vector2(400, 300));
            //entity2.addComponent(new Sprite(armor));
            //var collider = new CircleCollider();
            //collider.isTrigger = true;
            //entity2.addComponent(collider);

            //collider.

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
