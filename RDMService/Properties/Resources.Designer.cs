﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RDMService.Properties {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RDMService.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
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
        ///   Recherche une chaîne localisée semblable à Erreur par défaut..
        /// </summary>
        internal static string EURREURINTERNESERVICE {
            get {
                return ResourceManager.GetString("EURREURINTERNESERVICE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Pseudo et password obligatoire..
        /// </summary>
        internal static string LOGOUT {
            get {
                return ResourceManager.GetString("LOGOUT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Le paramètre de la clé {0} n&apos;est pas connu..
        /// </summary>
        internal static string PARAMKEYINCONNU {
            get {
                return ResourceManager.GetString("PARAMKEYINCONNU", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Le type {0} de paramètre n&apos;est pas valide..
        /// </summary>
        internal static string PARAMTYPEINVALID {
            get {
                return ResourceManager.GetString("PARAMTYPEINVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Password incorect..
        /// </summary>
        internal static string PASSWORDINCORECT {
            get {
                return ResourceManager.GetString("PASSWORDINCORECT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Password obligatoire..
        /// </summary>
        internal static string PASSWORDOBLIGATOIRE {
            get {
                return ResourceManager.GetString("PASSWORDOBLIGATOIRE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Deconnexion pour la vision des data..
        /// </summary>
        internal static string PSEUDODOWNLOADLOGOUT {
            get {
                return ResourceManager.GetString("PSEUDODOWNLOADLOGOUT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Obligation de se connecter pour voir toutes les data de tous les pseudos..
        /// </summary>
        internal static string PSEUDODOWNLOADOBLIGATOIRE {
            get {
                return ResourceManager.GetString("PSEUDODOWNLOADOBLIGATOIRE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Le pseudo est obligatoire..
        /// </summary>
        internal static string PSEUDOOBLIGATOIRE {
            get {
                return ResourceManager.GetString("PSEUDOOBLIGATOIRE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Le pseudo est déjà utilisé..
        /// </summary>
        internal static string PSEUDOUTILISE {
            get {
                return ResourceManager.GetString("PSEUDOUTILISE", resourceCulture);
            }
        }
    }
}
