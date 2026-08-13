namespace IceFebruary.Proxy
{
    using System;

    /// <summary>
    /// Attribute for interfaces implemented by proxied classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public sealed class InterfaceProxy : GeneratorAttribute { }
}
