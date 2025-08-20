using System.Collections.Generic;
using UnityEditor;

namespace NaughtyAttributes.Editor
{
    public class EditorAutoAssignPropertyValidator : PropertyValidatorBase
    {
        private static readonly HashSet<string> validated = new ();
        
        public override void ValidateProperty(SerializedProperty property)
        {
            var attr = PropertyUtility.GetAttribute<EditorAutoAssignAttribute>(property);
            
            var key = property.serializedObject.targetObject.GetInstanceID() + "|" + property.propertyPath;
            if (validated.Contains(key))
                return;
            
            if (property.objectReferenceValue is null)
            {
                var type = PropertyUtility.GetTargetTypeOfProperty(property);
                var asset = LoaderUtility.GetFirstAsset(type, attr.SearchString, attr.Verbose);
                property.objectReferenceValue = asset;
            }
            
            validated.Add(key);
        }
    }
}