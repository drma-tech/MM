﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MM.Shared.Enums.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Change {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Change() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MM.Shared.Enums.Resources.Change", typeof(Change).Assembly);
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
        ///   Looks up a localized string similar to If you are not willing to move. Even so, you will still have suggestions for profiles outside your selected region (if that person is willing to move to your region).
        /// </summary>
        internal static string NoChange_Description {
            get {
                return ResourceManager.GetString("NoChange_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to I am not willing to move.
        /// </summary>
        internal static string NoChange_Name {
            get {
                return ResourceManager.GetString("NoChange_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If you are willing to move if the need arises (only within the selected region).
        /// </summary>
        internal static string OpenToChange_Description {
            get {
                return ResourceManager.GetString("OpenToChange_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to I am willing to move.
        /// </summary>
        internal static string OpenToChange_Name {
            get {
                return ResourceManager.GetString("OpenToChange_Name", resourceCulture);
            }
        }
    }
}