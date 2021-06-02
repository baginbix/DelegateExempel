using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DelegateExempel
{
    // delegate säger hur metoden måste se ut
    // I detta fallet måste returvärdet måste vara void
    // Det får inte finnas några parametrar
    delegate void Click();
    class Button
    {
        Texture2D texture;
        Vector2 position;
        // Man använder delegate som ett objekt
        Click function;
        public Rectangle ClickBox
        {
            get;
            private set;
        }
        /// <summary>
        /// Konstruktorn
        /// </summary>
        /// <param name="tex">Texturen</param>
        /// <param name="pos">Positionen</param>
        /// <param name="size">Storleken</param>
        /// <param name="click">Metoden som ska anropas när man klickar på knappen</param>
        public Button(Texture2D tex, Vector2 pos,Vector2 size, Click click)
        {
            texture = tex;
            position = pos;
            // Spara metoden som skickas in i function
            function = click;
            ClickBox = new Rectangle(position.ToPoint(), size.ToPoint());
        }

        /// <summary>
        /// Anropa när man klickar på knappen
        /// </summary>
        public void OnClick()
        {
            // Invoke anropar metoden som finns i function
            function.Invoke();
        }

        //Test
        public void Draw(SpriteBatch spriteBatch)
        {
            //New Test
            spriteBatch.Draw(texture, ClickBox, Color.White);
        }
    }
}
