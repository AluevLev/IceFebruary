namespace IceFebruary.Proxy
{
    using System;

    /// <summary>
    /// Attribute for proxy wrappers linking structures or constructors to external data config assets.
    /// Applies to the constructor whose arguments will be displayed in the editor.
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Struct)]
    public sealed class DataObjectProxy : GeneratorAttribute { }
}