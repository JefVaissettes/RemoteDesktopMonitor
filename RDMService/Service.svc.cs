using ConsumeWebServiceRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RDMService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service : IServiceRDM

    {// PLAGE DES CODES ERREUR POUR LE WebService ---> [1 - 200[
        public const int CodeRet_Ok = 0;
        public const int CodeRet_PseudoUtilise = 1;
        public const int CodeRet_PseudoObligatoire = 2;
        public const int CodeRet_PseudoDownloadObligatoire = 3;
        public const int CodeRet_Logout = 4;
        public const int CodeRet_PasswordObligatoire = 5;
        public const int CodeRet_PasswordIncorrect = 6;
        public const int CodeRet_PseudoDownloadLogout = 7;
        public const int CodeRet_ParamKeyInconnu = 10;
        public const int CodeRet_ParamTypeInvalid = 11;
        public const int CodeRet_ErreurInterneService = 100;

        #region IServiceRDM Membres

        /// <summary>
        /// Permet de se loguer au WebService
        /// </summary>
        /// <param name="p">Dictionnaire contenant votre identifiant</param>
        /// <returns>Valeurs de retour contenant votre mot de passe. Il sera nécessaire pour le Logout et l'écriture de vos données</returns>
        public WSR_Result Login(WSR_Params p)
        {
            string pseudo = null;
            string password = null;
            WSR_Result ret = null;
            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
            {
                return ret;
            }

            //permet d'ajouter un compte  utilisateur dans la mémoire cache, 
            AccountError err = Account.Add(pseudo, out password);
            switch (err)
            {
                //si ok , la base nous envoie un password automatiquement.
                case AccountError.Ok:
                    return new WSR_Result(password, true);

                //on crée un compte utilisateur avec un pseudo obligatoire, obligé de taper un pseudo
                case AccountError.KeyNullOrEmpty:
                    return new WSR_Result(CodeRet_PseudoObligatoire, Properties.Resources.PSEUDOOBLIGATOIRE);

                //si le speudo existe déjà, il est déjà utilisé on nous renvoi un message d'erreur et on diot retapé un autre pseudo
                case AccountError.KeyExist:
                    return new WSR_Result(CodeRet_PseudoUtilise, Properties.Resources.PSEUDOUTILISE);

                default:
                    return new WSR_Result(CodeRet_ErreurInterneService, Properties.Resources.ERREURINTERNESERVICE);
            }



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

            //permet de supprimer un compte dans la mémoire cache
            AccountError err = Account.Remove(pseudo, password);

            switch (err)
            {
                case AccountError.Ok:
                    return new WSR_Result();

                case AccountError.KeyNullOrEmpty:
                    return new WSR_Result(CodeRet_PseudoObligatoire, Properties.Resources.PSEUDOOBLIGATOIRE);

                case AccountError.PasswordNullOrEmpty:
                    return new WSR_Result(CodeRet_PasswordObligatoire, Properties.Resources.PASSWORDOBLIGATOIRE);

                case AccountError.PasswordWrong:
                    return new WSR_Result(CodeRet_PasswordIncorrect, Properties.Resources.PASSWORDINCORRECT);

                case AccountError.keyNotFound:
                    return new WSR_Result(CodeRet_Logout, Properties.Resources.PSEUDONONLOGUE);
                default:
                    return new WSR_Result(CodeRet_ErreurInterneService, Properties.Resources.ERREURINTERNESERVICE);
            }

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
            List<string> lstKeys = null;
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
            //permet de connaître la liste des comptes utilisateurs stockés dans la mémoire cache
            AccountError err = Account.GetKeys(pseudo, password, out lstKeys);

            switch (err)
            {
                case AccountError.Ok:
                    return new WSR_Result(lstKeys, true);

                case AccountError.KeyNullOrEmpty:
                    return new WSR_Result(CodeRet_PseudoObligatoire, Properties.Resources.PSEUDOOBLIGATOIRE);

                case AccountError.PasswordNullOrEmpty:
                    return new WSR_Result(CodeRet_PasswordObligatoire, Properties.Resources.PASSWORDOBLIGATOIRE);

                case AccountError.keyNotFound:
                    return new WSR_Result(CodeRet_Logout, Properties.Resources.PSEUDONONLOGUE);

                case AccountError.PasswordWrong:
                    return new WSR_Result(CodeRet_PasswordIncorrect, Properties.Resources.PASSWORDINCORRECT);

                default:
                    return new WSR_Result(CodeRet_ErreurInterneService, Properties.Resources.ERREURINTERNESERVICE);
            }


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
            object data = null;

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
            ret = VerifParamType(p, "data", out data);//pas de vérification de paramètre
            if (ret != null)
            {
                return ret;
            }

            //permet d'écrire les données dans le compte utilisateur spécifié
            AccountError err = Account.WriteData(pseudo, password, data);

            switch (err)
            {
                case AccountError.Ok:
                    return new WSR_Result();

                case AccountError.KeyNullOrEmpty:
                    return new WSR_Result(CodeRet_PseudoObligatoire, Properties.Resources.PSEUDOOBLIGATOIRE);

                case AccountError.PasswordNullOrEmpty:
                    return new WSR_Result(CodeRet_PasswordObligatoire, Properties.Resources.PASSWORDOBLIGATOIRE);

                case AccountError.keyNotFound:
                    return new WSR_Result(CodeRet_Logout, Properties.Resources.PSEUDONONLOGUE);

                case AccountError.PasswordWrong:
                    return new WSR_Result(CodeRet_PasswordIncorrect, Properties.Resources.PASSWORDINCORRECT);

                default:
                    return new WSR_Result(CodeRet_ErreurInterneService, Properties.Resources.ERREURINTERNESERVICE);
            }

        }

        /// <summary>
        /// Permet de lire les données associées à un compte utilisateur
        /// </summary>
        /// <param name="p">Dictionnaire contenant votre identifiant, votre mot de passe et l'identifiant du compte à lire</param>
        /// <returns>Valeurs de retour contenant les données lues</returns>
        public WSR_Result DownloadData(WSR_Params p)
        {
            string pseudo = null;
            string password = null;
            string pseudoDownload = null;
            object data = null;
            WSR_Result ret = null;

            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
                return ret;

            ret = VerifParamType(p, "password", out password);
            if (ret != null)
                return ret;

            ret = VerifParamType(p, "pseudoDownload", out pseudoDownload);
            if (ret != null)
                return ret;

            //permet de lire les données dans un compte utilisateur spécifié
            AccountError err = Account.ReadData(pseudo, password, pseudoDownload, out data);

            switch (err)
            {
                case AccountError.Ok:
                    return new WSR_Result(data, false);

                case AccountError.KeyNullOrEmpty:
                    return new WSR_Result(CodeRet_PseudoObligatoire, Properties.Resources.PSEUDOOBLIGATOIRE);

                case AccountError.PasswordNullOrEmpty:
                    return new WSR_Result(CodeRet_PasswordObligatoire, Properties.Resources.PASSWORDOBLIGATOIRE);

                case AccountError.keyDownloadNullOrEmpty:
                    return new WSR_Result(CodeRet_PseudoDownloadObligatoire, Properties.Resources.PSEUDODOWNLOADOBLIGATOIRE);

                case AccountError.keyNotFound:
                    return new WSR_Result(CodeRet_Logout, Properties.Resources.PSEUDONONLOGUE);

                case AccountError.PasswordWrong:
                    return new WSR_Result(CodeRet_PasswordIncorrect, Properties.Resources.PASSWORDINCORRECT);

                case AccountError.keyDownloadNotFound:
                    return new WSR_Result(CodeRet_PseudoDownloadLogout, String.Format(Properties.Resources.PSEUDODOWNLOADNONLOGUE, pseudoDownload));

                default:
                    return new WSR_Result(CodeRet_ErreurInterneService, Properties.Resources.ERREURINTERNESERVICE);
            }
        }

        #endregion IService Membres

        #region Fonctions perso
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="p">Le parametre</param>
        /// <param name="key">La clé</param>
        /// <param name="value">La valeur</param>
        /// <returns></returns>
        private static WSR_Result VerifParamExist(WSR_Params p, string key, out object data)
        {
            data = null;

            if (!p.ContainsKey(key))
                return new WSR_Result(CodeRet_ParamKeyInconnu, String.Format(Properties.Resources.PARAMKEYINCONNU, key));

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
                    value = p[key] as T; // Permet de vérifier le type du paramètre 
                }
                catch (Exception) { } // Il peut y avoir exception si le type est inconnu (type personnalisé qui n'est pas dans les références)

                if (value == null)
                    return new WSR_Result(CodeRet_ParamTypeInvalid, String.Format(Properties.Resources.PARAMTYPEINVALID, key));
            }

            return null;
        }

        #endregion Fonctions perso
    }
}
