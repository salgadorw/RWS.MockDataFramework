﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntegrationTests {
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
    internal class SqlScripts {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlScripts() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IntegrationTests.SqlScripts", typeof(SqlScripts).Assembly);
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
        ///   Looks up a localized string similar to 
        ///USE [MockedDB];
        ////****** Object:  Table [dbo].[testMock]    Script Date: 1/2/2021 4:00:48 AM ******/
        ///SET ANSI_NULLS ON;
        ///SET QUOTED_IDENTIFIER ON;
        ///CREATE TABLE [dbo].[testMock](
        ///	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
        ///	[test] [nchar](10) NULL,
        ///	[decimal] [decimal](18, 0) NULL,
        ///	[float] [float] NULL,
        ///	[datetime] [datetime] NULL,
        ///	[date] [date] NULL,
        ///	[hour] [time](7) NULL,
        /// CONSTRAINT [PK_testMock] PRIMARY KEY CLUSTERED(
        ///	[id] ASC
        ///)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGN [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CreateTables {
            get {
                return ResourceManager.GetString("CreateTables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DROP DATABASE IF EXISTS [MockedDB];
        ///
        ///CREATE DATABASE [MockedDB];
        ///
        ///ALTER DATABASE [MockedDB] SET COMPATIBILITY_LEVEL = 140;
        ///
        ///ALTER DATABASE [MockedDB] SET ANSI_NULL_DEFAULT OFF;
        ///
        ///ALTER DATABASE [MockedDB] SET ANSI_NULLS OFF ;
        ///
        ///ALTER DATABASE [MockedDB] SET ANSI_PADDING OFF;
        ///ALTER DATABASE [MockedDB] SET ANSI_WARNINGS OFF;
        ///ALTER DATABASE [MockedDB] SET ARITHABORT OFF;
        ///ALTER DATABASE [MockedDB] SET AUTO_CLOSE OFF;
        ///ALTER DATABASE [MockedDB] SET AUTO_SHRINK OFF;
        ///ALTER DATABASE [MockedDB] SET AUTO_ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DropAndCreateDatabase {
            get {
                return ResourceManager.GetString("DropAndCreateDatabase", resourceCulture);
            }
        }
    }
}
