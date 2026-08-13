namespace IceFebruary.Proxy
{
    using System;

    /// <summary>
    /// Attribute for objects that can be visually displayed in the editor.
    /// Applies to the constructor whose arguments will be displayed in the editor.
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor)]
    public sealed class FieldProxy : GeneratorAttribute
    {
        /// <summary>
        /// Interface that a proxyable class implements.
        /// Interface must have an <see cref="InterfaceProxy"/> attribute.
        /// </summary>
        public Type InterfaceType { get; private init; }
        public FieldProxy(Type interfaceType = null)
        {
            InterfaceType = interfaceType;
        }
    }
}
