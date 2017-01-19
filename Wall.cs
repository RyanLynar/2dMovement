using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ExtraObjects
{
    public class Wall 
    {
        Vector2 position;
        int width, height;
        SpriteRender render;
        public Wall()
        {
            position = new Vector2(0, 0);
            width = 5;
            height = 5;
            render = new SpriteRender();
         
        }
        public Wall(Vector2 pos,int width, int height)
        {
            position = pos;
            this.width = width;
            this.height = height;
        }
    }
}
