using UnityEngine;

namespace NaughtyAttributes.Test
{
    public class EditorAutoAssignTest : MonoBehaviour
    {
        [EditorAutoAssign("icon-github")]
        public Texture2D texture;
        
        public EditorAutoAssignNest1 nest1;
    }
    
    [System.Serializable]
    public class EditorAutoAssignNest1
    {
        [EditorAutoAssign("icon-github")]
        [AllowNesting]
        public Texture2D texture;
        
        public EditorAutoAssignNest2 nest2;
    }
    
    [System.Serializable]
    public class EditorAutoAssignNest2
    {
        [EditorAutoAssign("icon-github")]
        [AllowNesting]
        public Texture2D texture;
    }
}