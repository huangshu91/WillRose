﻿using Microsoft.Xna.Framework;
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

            var entity = createEntity("William", new Vector2(400, 200));
            entity.addComponent(new Sprite(armor));
            entity.addComponent(new WilliamComponent());
        }

        public override void update()
        {
            base.update();
        }
    }
}
