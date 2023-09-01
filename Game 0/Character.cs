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
    public class Character
    {
        private Texture2D texture;

        private double animationTimer;
        private int animationFrame = 1;


        /// <summary>
        /// The position of the character
        /// </summary>
        public Vector2 Position = new Vector2(100, 300);

        /// <summary>
        /// Loads the cahracter sprite texture
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Kenny Toon Characters/Male Person/Tilesheet/character_malePerson_sheet");
        }

        /// <summary>
        /// Updates the character to walk in a single direction
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            Position += new Vector2(1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// Draws the animated sprite
        /// </summary>
        /// <param name="gameTime">the game time</param>
        /// <param name="spriteBatch">the SpriteBatch to draw the character</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 additivePosition)
        {

            // Update the animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;


            // Update animation frame
            if (animationTimer > 0.125)
            {
                animationFrame++;
                if (animationFrame > 7)
                {
                    animationFrame = 0;
                }

                animationTimer = 0;
            }

            var source = new Rectangle(animationFrame * 96, 512, 96, 128);
            spriteBatch.Draw(texture, new Vector2(Position.X + additivePosition.X, Position.Y + additivePosition.Y), source, Color.White);
        }
    }
}
