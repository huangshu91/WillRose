using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillRose.Entities
{
    public class NpcEntity : Component, ITriggerListener
    {
        CircleCollider collider;
        Text text;

        public NpcEntity()
        {
        }

        public override void onAddedToEntity()
        {
            collider = new CircleCollider();
            collider.isTrigger = true;
            this.entity.addComponent(collider);
            //this.entity.addComponent(new Text(Graphics.instance.bitmapFont, "TESTTEST", new Vector2(0, 0), Color.White))
            //    .setRenderLayer(99);
        }

        public void onTriggerEnter(Collider other, Collider local)
        {
            text = new Text(Graphics.instance.bitmapFont, "testing trigger", new Vector2(-20, -50), Color.Black);
            this.entity.addComponent(text).setRenderLayer(99);
        }

        public void onTriggerExit(Collider other, Collider local)
        {
            this.entity.removeComponent(text);
        }
    }
}
