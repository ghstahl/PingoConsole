﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.35317
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MEF.ConsoleRunner.Core.Resources {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MEF.ConsoleRunner.Core.Resources.Common", typeof(Common).Assembly);
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
        ///   Looks up a localized string similar to Available Commands:.
        /// </summary>
        public static string AvailableCommands {
            get {
                return ResourceManager.GetString("AvailableCommands", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Displays general help information and help information about other commands..
        /// </summary>
        public static string Description_Help {
            get {
                return ResourceManager.GetString("Description_Help", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For more help please visit: https://www.somesite.com/myconsole/help.
        /// </summary>
        public static string Footer {
            get {
                return ResourceManager.GetString("Footer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} Version: {1}
        ///usage: {0} &lt;command&gt; [args] [options]
        ///Type &apos;{0} help &lt;command&gt;&apos; for help on a specific command..
        /// </summary>
        public static string Format_HeaderString {
            get {
                return ResourceManager.GetString("Format_HeaderString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown Command: &apos;{0}&apos;.
        /// </summary>
        public static string Format_UnknownCommand {
            get {
                return ResourceManager.GetString("Format_UnknownCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unkown Exception: {0}.
        /// </summary>
        public static string Format_UnknownException {
            get {
                return ResourceManager.GetString("Format_UnknownException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to usage: {0} {1} {2}.
        /// </summary>
        public static string Format_UsageFormat {
            get {
                return ResourceManager.GetString("Format_UsageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Help.
        /// </summary>
        public static string LongHelpOption {
            get {
                return ResourceManager.GetString("LongHelpOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Help.
        /// </summary>
        public static string Name_Help {
            get {
                return ResourceManager.GetString("Name_Help", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ?.
        /// </summary>
        public static string ShortHelpOption {
            get {
                return ResourceManager.GetString("ShortHelpOption", resourceCulture);
            }
        }
    }
}
