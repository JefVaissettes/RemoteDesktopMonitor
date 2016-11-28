using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumeWebServiceRest
{
    public enum TypeSerializer
    {
        Xml = 0,
        Json = 1,
    }

    public static class ConsumeWSR
    {
        public static async Task<WSR_Result> Call(string adresseService, WSR_Params parametres, TypeSerializer typeSerializer, CancellationToken cancel)
        {
            try
            {
                using (HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite) })
                {
                    client.DefaultRequestHeaders.IfModifiedSince = DateTimeOffset.Now;

                    using (StringContent contentParametres = SerializeParam(parametres, typeSerializer))
                    {
                        using (HttpResponseMessage wcfResponse = await client.PostAsync(adresseService, contentParametres, cancel))
                        {
                            if (wcfResponse.IsSuccessStatusCode)
                            {
                                return DeserializeHttpContent(wcfResponse.Content, typeSerializer);
                            }
                            else
                            {
                                return new WSR_Result(WSR_Result.CodeRet_AppelService, string.Format(Properties.Resources.ERREUR_APPELSERVICE, wcfResponse.ReasonPhrase));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if(ex is TaskCanceledException) { return new WSR_Result(WSR_Result.CodeRet_TimeOutAnnul, string.Format(Properties.Resources.ERREUR_TIMEOUT, adresseService)); }
                else if (ex is SerializationException) { return new WSR_Result(WSR_Result.CodeRet_Serialize, String.Format(Properties.Resources.ERREUR_SERIALISATIONPARAMS)); }
                else { return new WSR_Result(WSR_Result.CodeRet_AppelService, String.Format(Properties.Resources.ERREUR_APPELSERVICE, ex.Message)); }
            }
        }

        private static StringContent SerializeParam(WSR_Params param, TypeSerializer typeSerializer)
        {
            try
            {
                if (param != null)
                {
                    if (typeSerializer == TypeSerializer.Xml)
                    {
                        using (MemoryStream memStream = new MemoryStream())
                        {
                            new DataContractSerializer(typeof(WSR_Params)).WriteObject(memStream, param);
                            string str = Encoding.UTF8.GetString(memStream.ToArray(), 0, (int)memStream.Length);
                            return new StringContent(str, Encoding.UTF8, Properties.Resources.SERIALISATION_XML);
                        }
                    }
                    else
                    {
                        using (MemoryStream memStream = new MemoryStream())
                        {
                            new DataContractJsonSerializer(typeof(WSR_Params)).WriteObject(memStream, param);
                            string str = Encoding.UTF8.GetString(memStream.ToArray(), 0, (int)memStream.Length);
                            return new StringContent(str, Encoding.UTF8, Properties.Resources.SERIALISATION_JSON);
                        }
                    }
                }
                else
                {
                    return new StringContent(String.Empty);
                }
            }
            catch (Exception ex)
            {
                throw new SerializationException(String.Format(Properties.Resources.ERREUR_SERIALISATIONPARAMS), ex);
            }
        }

        /// <summary>
        /// Cette méthode permet de désérialiser un objet
        /// </summary>
        /// <param name="content">Objet à désérialiser</param>
        /// <param name="typeSerializer">Type de sérialisation (Xml/Json)</param>
        /// <returns>Objet désérialisé</returns>
        private static WSR_Result DeserializeHttpContent(HttpContent content, TypeSerializer typeSerializer)
        {
            try
            {
                using (Stream s = content.ReadAsStreamAsync().Result)
                {
                    if (s.Length > 0)
                    {
                        if (typeSerializer == TypeSerializer.Xml)
                        {
                            return (WSR_Result)new DataContractSerializer(typeof(WSR_Result)).ReadObject(s);
                        }
                        else
                        {
                            return (WSR_Result)new DataContractJsonSerializer(typeof(WSR_Result)).ReadObject(s);
                        }
                    }
                    else
                    {
                        return default(WSR_Result);
                    }
                }
            }
            catch (Exception)
            {
                return new WSR_Result(WSR_Result.CodeRet_Deserialize, String.Format(Properties.Resources.ERREUR_DESERIALISATIONRETOUR));
            }
        }
    }
}
