﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OSGeo.MapGuide.MaestroAPI.Http {
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
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OSGeo.MapGuide.MaestroAPI.Http.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to MapGuide Debugging Information\n==============================\n\nMap Extents Min: ({0}, {1})\nMap Extents Max: ({2}, {3})\nMap Coordinate System: \n{4}.
        /// </summary>
        internal static string DebugWatermarkMessage {
            get {
                return ResourceManager.GetString("DebugWatermarkMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MapGuide Debugging Information\n==============================\n\nMap Extents Min: ({0}, {1})\nMap Extents Max: ({2}, {3})\nMap Coordinate System: \n{4}\nLayer Spatial Context: {5}.
        /// </summary>
        internal static string DebugWatermarkMessageLayer {
            get {
                return ResourceManager.GetString("DebugWatermarkMessageLayer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Displays the current map extents.
        /// </summary>
        internal static string Desc_GetExtents {
            get {
                return ResourceManager.GetString("Desc_GetExtents", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Gets the current map as a KML document.
        /// </summary>
        internal static string Desc_GetMapKml {
            get {
                return ResourceManager.GetString("Desc_GetMapKml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zoom to a specified scale.
        /// </summary>
        internal static string Desc_ZoomToScale {
            get {
                return ResourceManager.GetString("Desc_ZoomToScale", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not calculate the extents of the Feature Source. Preview is not possible.
        /// </summary>
        internal static string FailedToCalculateFeatureSourceExtents {
            get {
                return ResourceManager.GetString("FailedToCalculateFeatureSourceExtents", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Extra Tools.
        /// </summary>
        internal static string Label_ExtraTools {
            get {
                return ResourceManager.GetString("Label_ExtraTools", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Get Extents.
        /// </summary>
        internal static string Label_GetExtents {
            get {
                return ResourceManager.GetString("Label_GetExtents", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Get KML.
        /// </summary>
        internal static string Label_GetMapKml {
            get {
                return ResourceManager.GetString("Label_GetMapKml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tools.
        /// </summary>
        internal static string Label_Tools {
            get {
                return ResourceManager.GetString("Label_Tools", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zoom to Scale.
        /// </summary>
        internal static string Label_ZoomToScale {
            get {
                return ResourceManager.GetString("Label_ZoomToScale", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Preview Map.
        /// </summary>
        internal static string PreviewMap {
            get {
                return ResourceManager.GetString("PreviewMap", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The site version of this current connection is not known to support watermarks.
        /// </summary>
        internal static string SiteVersionDoesntSupportWatermarks {
            get {
                return ResourceManager.GetString("SiteVersionDoesntSupportWatermarks", resourceCulture);
            }
        }
    }
}
