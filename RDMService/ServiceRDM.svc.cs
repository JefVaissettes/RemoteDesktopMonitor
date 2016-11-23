﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConsumeWebServiceRest;

namespace RDMService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceRDM : IServiceRDM
    {
        //Plage des codes erreur pour le webservice
        public const int CODERET_OK = 0;
        public const int CODE_PSEUDOUTILISE = 1;
        public const int CODERET_PSEUDOOBLIGATOIRE = 2;
        public const int CODERET_PSEUDODOWNLOADOBLIGATOIRE = 3;
        public const int CODERET_LOGOUT = 4;
        public const int CODERET_PASSWORDOBLIGATOIRE = 5;
        public const int CODERET_PASSWORDINCORECT = 6;
        public const int CODERET_PSEUDODOWNLOADLOGOUT = 7;
        public const int CODERET_PARAMKEYINCONNU = 10;
        public const int CODERET_PARAMTYPEINVALID = 11;
        public const int CODERET_EURREURINTERNESERVICE = 100;

        #region IServiceRDM Membres

        /// <summary>
        /// Permet de se loguer au WebService
        /// </summary>
        /// <param name="p">Dictionnaire contenant votre identifiant</param>
        /// <returns>Valeurs de retour contenant votre mot de passe. Il sera nécessaire pour le Logout et l'écriture de vos données</returns>
        public WSR_Result Login(WSR_Params p)
        {
            string pseudo = null;
            //string password = null;            
            WSR_Result ret = null;

            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
            {
                return ret;
            }

            return null;
        }

        /// <summary>
        /// Permet de se Déloguer du WebService
        /// </summary>
        /// <param name="p">Dictionnaire contenant votre identifiant et votre mot de passe></param>
        /// <returns>Valeurs de retour</returns>
        public WSR_Result Logout(WSR_Params p)
        {
            string pseudo = null;
            string password = null;            
            WSR_Result ret = null;

            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
            {
                return ret;
            }

            ret = VerifParamType(p, "password", out password);
            if (ret != null)
            {
                return ret;
            }
            return null;
        }

        /// <summary>
        /// Permet d'obtenir la liste des utilisateurs logués au WebService
        /// </summary>
        /// <param name="p">Dictionnaire contenant votre identifiant et votre mot de passe</param>
        /// <returns>Valeurs de retour contenant la liste des utilisateurs connectés</returns>
        public WSR_Result GetPseudos(WSR_Params p)
        {
            string pseudo = null;
            string password = null;
            WSR_Result ret = null;

            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
            {
                return ret;
            }

            ret = VerifParamType(p, "password", out password);
            if (ret != null)
            {
                return ret;
            }
            return null;
        }

        /// <summary>
        /// Permet d'écrire des données associées à votre compte utilisateur
        /// </summary>
        /// <param name="p">Dictionnaire contenant votre identifiant, votre mot de passe et les données à écrire</param>
        /// <returns>Valeurs de retour</returns>
        public WSR_Result UploadData(WSR_Params p)
        {
            string pseudo = null;
            string password = null;
            Object data = null;
            WSR_Result ret = null;

            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
            {
                return ret;
            }

            ret = VerifParamType(p, "password", out password);
            if (ret != null)
            {
                return ret;
            }

            ret = VerifParamExist(p, "data", out data);
                if(ret != null)
            {
                return ret;
            }
            return null;
        }

        /// <summary>
        /// Permet d'écrire des données associées à votre compte utilisateur
        /// </summary>
        /// <param name="p">Dictionnaire contenant votre identifiant, votre mot de passe et les données à écrire</param>
        /// <returns>Valeurs de retour</returns>
        public WSR_Result DownloadData(WSR_Params p)
        {
            string pseudo = null;
            string password = null;
            string pseudoDownload = null;
            WSR_Result ret = null;

            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
            {
                return ret;
            }

            ret = VerifParamType(p, "password", out password);
            if (ret != null)
            {
                return ret;
            }

            ret = VerifParamType(p, "pseudoDownload", out pseudoDownload);
            if (ret != null)
            {
                return ret;
            }

            return null;
        }

        #endregion

        #region Fonctions perso

        private static WSR_Result VerifParamExist(WSR_Params p, string key, out object data)
        {
            data = null;

            if (!p.ContainsKey(key))
                return new WSR_Result(CODERET_PARAMKEYINCONNU, String.Format(Properties.Resources.PARAMKEYINCONNU, key));

            data = p.GetValueSerialized(key);

            return null;
        }

        private static WSR_Result VerifParamType<T>(WSR_Params p, string key, out T value) where T : class
        {
            object data = null;
            value = null;

            WSR_Result ret = VerifParamExist(p, key, out data);
            if (ret != null)
                return ret;

            if (p[key] != null)
            {
                try
                {
                    value = p[key] as T; // Permet de vérifier le type
                }
                catch (Exception) { } // Il peut y avoir exception si le type est inconnu (type personnalisé qui n'est pas dans les références)

                if (value == null)
                    return new WSR_Result(CODERET_PARAMTYPEINVALID, String.Format(Properties.Resources.PARAMTYPEINVALID, key));
            }

            return null;
        }

        #endregion
    }
}
