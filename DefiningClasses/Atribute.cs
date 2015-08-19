namespace AttributeVersion
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
    AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method,
    AllowMultiple = false)]

    public class Version : Attribute
    {
        public int major { get; set; }
        public int minor { get; set; }


        public Version(string version)
        {
            string[] versionParts = version.Split('.');

            this.major = int.Parse(versionParts[0]);
            this.minor = int.Parse(versionParts[1]);
        }
    }

}
