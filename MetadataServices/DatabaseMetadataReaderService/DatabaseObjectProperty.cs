﻿namespace DatabaseMetadataReaderService
{
    public class DatabaseObjectProperty
    {
        public string Name { get; set; }

        public string DbPropertyType { get; set; }

        public bool IsNullable { get; set; }

        public bool IsUnique { get; set; }

        public bool IsAutoFilled { get; set; }

        public bool IsKey { get; set; }

        public bool IsForeingKey {get;set;}  

        public string DefaultValue { get; set; }
    }
}
