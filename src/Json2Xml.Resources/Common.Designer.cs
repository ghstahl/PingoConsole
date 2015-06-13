﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.35317
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Json2Xml.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Common {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Common() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Json2Xml.Resources.Common", typeof(Common).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A full path to a file. i.e. c:\Temp\source.json.
        /// </summary>
        public static string ArgumentDescription_PathToFile {
            get {
                return ResourceManager.GetString("ArgumentDescription_PathToFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Path to File&gt;.
        /// </summary>
        public static string ArgumentName_PathToFile {
            get {
                return ResourceManager.GetString("ArgumentName_PathToFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ------------------------------------------.
        /// </summary>
        public static string Breaker_Small {
            get {
                return ResourceManager.GetString("Breaker_Small", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Converts from json to xml,  i.e. json to nuspec.
        /// </summary>
        public static string Description_Json2Xml {
            get {
                return ResourceManager.GetString("Description_Json2Xml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Converts from XML to json.
        ///Typically this is done first to get the json into Json.Net
        ///specific format..
        /// </summary>
        public static string Description_Xml2Json {
            get {
                return ResourceManager.GetString("Description_Xml2Json", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The output file [{0}] cannot be created!.
        /// </summary>
        public static string Error_OutputFileCanNotBeCreated {
            get {
                return ResourceManager.GetString("Error_OutputFileCanNotBeCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The source file [{0}] does not exist!.
        /// </summary>
        public static string Error_SourceFileDoesNotExist {
            get {
                return ResourceManager.GetString("Error_SourceFileDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There were errors when validating arguments.
        /// </summary>
        public static string Error_ValidateArgumentsSummary {
            get {
                return ResourceManager.GetString("Error_ValidateArgumentsSummary", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --------------------- {0} ---------------------.
        /// </summary>
        public static string Format_SmallTitleLine {
            get {
                return ResourceManager.GetString("Format_SmallTitleLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to     {0}.
        /// </summary>
        public static string Format_SwitchItem {
            get {
                return ResourceManager.GetString("Format_SwitchItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ------------------------------------ {0} ------------------------------------.
        /// </summary>
        public static string Format_TitleLine {
            get {
                return ResourceManager.GetString("Format_TitleLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to None.
        /// </summary>
        public static string None {
            get {
                return ResourceManager.GetString("None", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type of conversion to be performed..
        /// </summary>
        public static string OptionDescription_ConverstionType {
            get {
                return ResourceManager.GetString("OptionDescription_ConverstionType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Displays help.
        /// </summary>
        public static string OptionDescription_Help {
            get {
                return ResourceManager.GetString("OptionDescription_Help", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The path to the output file as result of the conversion..
        /// </summary>
        public static string OptionDescription_Output {
            get {
                return ResourceManager.GetString("OptionDescription_Output", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The path to the source file to be converted.  .
        /// </summary>
        public static string OptionDescription_Source {
            get {
                return ResourceManager.GetString("OptionDescription_Source", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Success.
        /// </summary>
        public static string Success {
            get {
                return ResourceManager.GetString("Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        public static string Switch_CommandTemplateDescription {
            get {
                return ResourceManager.GetString("Switch_CommandTemplateDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The conversion type [{0}]. i.e. -{1} {2}.
        /// </summary>
        public static string Switch_ConversionTypeDescription {
            get {
                return ResourceManager.GetString("Switch_ConversionTypeDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Conversion.
        /// </summary>
        public static string Switch_ConversionTypeLong {
            get {
                return ResourceManager.GetString("Switch_ConversionTypeLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to c.
        /// </summary>
        public static string Switch_ConversionTypeShort {
            get {
                return ResourceManager.GetString("Switch_ConversionTypeShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Help.
        /// </summary>
        public static string Switch_HelpLong {
            get {
                return ResourceManager.GetString("Switch_HelpLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?.
        /// </summary>
        public static string Switch_HelpShort {
            get {
                return ResourceManager.GetString("Switch_HelpShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Path to the output file. i.e. -{0} c:\Temp\out.nuspec.
        /// </summary>
        public static string Switch_OutputDescription {
            get {
                return ResourceManager.GetString("Switch_OutputDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Output.
        /// </summary>
        public static string Switch_OutputLong {
            get {
                return ResourceManager.GetString("Switch_OutputLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to o.
        /// </summary>
        public static string Switch_OutputShort {
            get {
                return ResourceManager.GetString("Switch_OutputShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Silent.
        /// </summary>
        public static string Switch_SilentLong {
            get {
                return ResourceManager.GetString("Switch_SilentLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to si.
        /// </summary>
        public static string Switch_SilentShort {
            get {
                return ResourceManager.GetString("Switch_SilentShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Path to the source file [.json|.xml]. i.e. -{0} c:\Temp\source.json.
        /// </summary>
        public static string Switch_SourceDescription {
            get {
                return ResourceManager.GetString("Switch_SourceDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Source.
        /// </summary>
        public static string Switch_SourceLong {
            get {
                return ResourceManager.GetString("Switch_SourceLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to s.
        /// </summary>
        public static string Switch_SourceShort {
            get {
                return ResourceManager.GetString("Switch_SourceShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Argument: {0}.
        /// </summary>
        public static string Title_Argument {
            get {
                return ResourceManager.GetString("Title_Argument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Arguments:.
        /// </summary>
        public static string Title_Arguments {
            get {
                return ResourceManager.GetString("Title_Arguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Description:.
        /// </summary>
        public static string Title_Description {
            get {
                return ResourceManager.GetString("Title_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Help.
        /// </summary>
        public static string Title_Help {
            get {
                return ResourceManager.GetString("Title_Help", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Switchs:.
        /// </summary>
        public static string Title_Switches {
            get {
                return ResourceManager.GetString("Title_Switches", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usage:.
        /// </summary>
        public static string Title_Usage {
            get {
                return ResourceManager.GetString("Title_Usage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Json2Xml -c Xml2Json --Source c:\Folder\a.xml --Output c:\Folder2\b.json
        ///Json2Xml --Conversion Json2Xml /Source c:\Folder2\b.json -o c:\Folder\c.nuspec.
        /// </summary>
        public static string Usage {
            get {
                return ResourceManager.GetString("Usage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome.
        /// </summary>
        public static string Welcome {
            get {
                return ResourceManager.GetString("Welcome", resourceCulture);
            }
        }
    }
}
