using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_0
{
    public class BackgroundElement
    {
        public Vector2 Position { get; set; }
        public string TextureName;

        public Texture2D texture;

        public BackgroundElement(Vector2 position, string textureName)
        {

            Position = position;
            TextureName = textureName;
        }


        /// <summary>
        /// Loads the sprite texture using the provided ContentManager
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(TextureName);
        }


        /// <summary>
        /// Draws the sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 additivePosition)
        {
            spriteBatch.Draw(texture, new Vector2(Position.X + additivePosition.X, Position.Y + additivePosition.Y), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}
