using Raylib_CsLo;

namespace PingPong.Systems
{
    public class ShaderManager
    {
        private static ShaderManager _instance;
        public static ShaderManager Instance => _instance ??= new ShaderManager();

        private readonly Dictionary<string, Shader> _shaders = new Dictionary<string, Shader>();

        // init
        public void Initialize()
        {
            // List of shaders
            string[] shaderPaths = new string[] { "Assets/Shaders/radialGradient.fs" };

            // for each shader path
            foreach (string shaderPath in shaderPaths)
            {
                // load shader
                Shader shader = Raylib.LoadShader(null, shaderPath);

                // add shader to dictionary
                // shaderpath filname without extension
                _shaders.Add(Path.GetFileNameWithoutExtension(shaderPath), shader);
            }
        }

        public Shader GetShader(string shaderName)
        {
            return _shaders[shaderName];
        }

        public void Dispose()
        {
            foreach (Shader shader in _shaders.Values)
            {
                Raylib.UnloadShader(shader);
            }
        }
    }
}