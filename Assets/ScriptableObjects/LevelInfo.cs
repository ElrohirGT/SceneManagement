using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "Scriptable Objects/LevelInfo")]
    public class LevelInfo : ScriptableObject
    {
        public string levelName;
        public Texture2D image;
        public string sceneName;
    }
}
