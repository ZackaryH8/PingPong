using Raylib_CsLo;

namespace PingPong.Systems
{
    public class AudioManager
    {
        private static AudioManager _instance;
        public static AudioManager Instance => _instance ??= new AudioManager();

        private static Sound _paddleHitSound = Raylib.LoadSound("Assets/Audio/paddle_hit.ogg");
        // private static Sound _wallHitSound;
        // private static Sound _scoreSound;

        public void PlayPaddleHitSound()
        {

            Raylib.PlaySound(_paddleHitSound);
        }

        // public void PlayWallHitSound()
        // {
        //     Raylib.PlaySound(_wallHitSound);
        // }

        // public void PlayScoreSound()
        // {
        //     Raylib.PlaySound(_scoreSound);
        // }

        public void Dispose()
        {
            Raylib.UnloadSound(_paddleHitSound);
            // Raylib.UnloadSound(_wallHitSound);
            // Raylib.UnloadSound(_scoreSound);
        }
    }
}