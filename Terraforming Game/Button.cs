using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Terraforming_Game
{
    class Button
    {

        public enum State
        {
            None,
            Pressed,
            Hover,
            Released
        }

        private Rectangle _rectangle;
        private State _state;
        public State bState
        {
            get { return _state; }
            set { _state = value; } // you can throw some events here if you'd like
        }

        private Dictionary<State, Texture2D> _textures;

        public Button(Rectangle rectangle, Texture2D noneTexture, Texture2D hoverTexture, Texture2D pressedTexture)
        {
            _rectangle = rectangle;
            _textures = new Dictionary<State, Texture2D>
            {
                { State.None, noneTexture },
                { State.Hover, hoverTexture },
                { State.Pressed, pressedTexture },
                { State.Released, noneTexture }
            };
        }

        public void setPosition(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public bool Update(MouseState mouseState)
        {
            if (_rectangle.Contains(mouseState.X, mouseState.Y))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    bState = State.Pressed;
                else if (bState == State.Pressed)
                {
                    bState = State.Released;
                    return true;
                }
                else
                    bState = State.Hover;
            }
            else
            {
                bState = State.None;
            }
            return false;
        }

        // Make sure Begin is called on s before you call this function
        public void Draw(SpriteBatch s)
        {
            s.Draw(_textures[bState], _rectangle, Color.White);
        }

    }
}
