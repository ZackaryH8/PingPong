using System.Numerics;
using PingPong.Entities;
using Raylib_CsLo;

namespace PingPong.Systems
{
    public class InputManager
    {
        private static InputManager _instance;
        public static InputManager Instance => _instance ??= new InputManager();
        

        // update method
        public void Update()
        {
            // // Get paddle from entity manager
            // var paddle = EntityManager<Paddle>.Instance.GetAll()[0];

            // // Check if key is pressed
            // if (Raylib.IsKeyPressed(KeyboardKey.KEY_W))
            // {
            //     paddle.MoveUp();
            // }
            // else if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
            // {
            //     paddle.MoveDown();
            // }
        }
    }
}