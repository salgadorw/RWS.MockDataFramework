﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MockMetadataReader.SqlServerImplementation {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ReadSqlServerMetadataQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ReadSqlServerMetadataQueries() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MockMetadataReader.SqlServerImplementation.ReadSqlServerMetadataQueries", typeof(ReadSqlServerMetadataQueries).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH TableConstraints (TABLE_NAME, CONSTRAINT_NAME, CONSTRAINT_TYPE, COLUMN_NAME)  
        ///AS  
        ///(  
        ///    SELECT tc.TABLE_NAME, tc.CONSTRAINT_NAME, tc.CONSTRAINT_TYPE, cu.COLUMN_NAME
        ///    FROM MockedDB.INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc 
        ///	inner join MockedDB.INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE cu on cu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME
        ///	
        ///   
        ///)
        ///SELECT c.TABLE_CATALOG, c.TABLE_NAME, c.COLUMN_NAME, c.COLUMN_DEFAULT, c.CHARACTER_MAXIMUM_LENGTH, c.NUMERIC_PRECISION, c.DATA_TYPE, IIF(c.IS_NULLABLE = [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GetDatabaseMetadataObjects {
            get {
                return ResourceManager.GetString("GetDatabaseMetadataObjects", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM [{0}].INFORMATION_SCHEMA.KEY_COLUMN_USAGE.
        /// </summary>
        internal static string GetDatabaseMetadataObjectsKeyProperties {
            get {
                return ResourceManager.GetString("GetDatabaseMetadataObjectsKeyProperties", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT RC.CONSTRAINT_NAME, CUPK.TABLE_NAME, CUPK.COLUMN_NAME, CUFK.TABLE_NAME FKTABLE, CUFK.COLUMN_NAME FKCOLUMN  FROM[{0}].INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS RC INNER JOIN 
        ///[{0}].INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS CUPK ON RC.UNIQUE_CONSTRAINT_NAME = CUPK.CONSTRAINT_NAME INNER JOIN 
        ///[{0}].INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS CUFK ON RC.CONSTRAINT_NAME = CUFK.CONSTRAINT_NAME WHERE RC.CONSTRAINT_NAME IN (
        ///SELECT CONSTRAINT_NAME FROM[{0}].INFORMATION_SCHEMA.TABLE_CONSTRAINTS   [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GetDatabaseMetadataRelationships {
            get {
                return ResourceManager.GetString("GetDatabaseMetadataRelationships", resourceCulture);
            }
        }
    }
}
