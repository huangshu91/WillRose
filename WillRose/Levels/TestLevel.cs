using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
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
            clearColor = Color.CornflowerBlue;

            InitializeEntities();
        }

        private void InitializeEntities()
        {
            armor = content.Load<Texture2D>("unit_armor");

            var entity = createEntity("William", new Vector2(100, 300));
            entity.addComponent(new Sprite(armor));
            entity.addComponent(new WilliamComponent());

            var entity3 = createEntity("William2", new Vector2(300, 300));
            entity3.addComponent(new Sprite(armor));
            entity3.addComponent(new WilliamComponentJump());


            //var entity2 = createEntity("TestUnit", new Vector2(400, 300));
            //entity2.addComponent(new Sprite(armor));
            //var collider = new CircleCollider();
            //collider.isTrigger = true;
            //entity2.addComponent(collider);

            //collider.

        }

        public override void update()
        {
            base.update();
        }
    }
}
