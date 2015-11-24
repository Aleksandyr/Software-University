﻿namespace GenericList
{
    using System;

    [AttributeUsage(AttributeTargets.Struct |
        AttributeTargets.Class |
        AttributeTargets.Interface |
        AttributeTargets.Enum |
        AttributeTargets.Method,
        AllowMultiple = true)]
    class VersionAttribute : Attribute
    {
        public VersionAttribute(double version)
        {
            this.Version = string.Format("{0:#.###}", version);
        }

        public string Version { get; set; }
    }
}
