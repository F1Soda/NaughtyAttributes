using System;

namespace NaughtyAttributes
{
    /// <summary>
    /// <para>
    /// Automatically assigns an asset reference to a field if the field is <c>null</c>.
    /// </para>
    /// 
    /// <para>
    /// ⚠ This attribute is <b>Editor-only</b>.  
    /// The assignment occurs once, during the custom inspector's property drawing phase.  
    /// In other words, the asset will be auto-assigned only when the inspector for the target object is opened first time in scene.
    /// </para>
    ///
    /// 
    /// <para>
    /// At runtime (in a build), this attribute has no effect.  
    /// However, since Unity serializes references, any values auto-assigned in the editor will be saved into the scene or prefab, 
    /// and thus remain available in builds.
    /// </para>
    /// 
    /// <para>
    /// If used together with the <see cref="RequiredAttribute"/>, ensure that this attribute is placed <b>before</b> 
    /// <c>[Required]</c> to avoid false validation errors.
    /// </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EditorAutoAssignAttribute : ValidatorAttribute
    {
        public string SearchString { get; private set; }
        public bool Verbose { get; private set; }

        public EditorAutoAssignAttribute(string searchString, bool verbose = true)
        {
            SearchString = searchString;
            Verbose = verbose;
        }
    }
}