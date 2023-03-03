using JCI.RetailSurveyTool.DataBase.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Jci.RetailSurveyTool.TechnicianApp.Services
{
    public class RestService
    {
        private readonly string baseURL;
        HttpClient client;
        private JsonSerializerSettings serializerSettings;

        public RestService(string baseURL)
        {
            client = new HttpClient();
            this.baseURL = baseURL;
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            this.serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto
            };


        }
        public async Task<Audit> GetAuditAsync(int id)
        {

            Uri uri = new Uri(baseURL + $"Audit/{id}");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Audit>(content, serializerSettings);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw ex;
            }
            throw new Exception("Could not do search");
        }
        public async Task<List<Audit>> SearchForAudits(int customerID, string storeNumber, int top = 10, int skip = 0)
        {

            Uri uri = new Uri(baseURL + $"Audit/byCustomer/{customerID}/{storeNumber}?top={top}&skip={skip}");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Audit>>(content, serializerSettings);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw ex;
            }
            throw new Exception("Could not do search");
        }

        public async Task<List<SVMX_WO>> GetWOsAsync()
        {
            Uri uri = new Uri(baseURL + $"SVMAXWO/WOs/");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<SVMX_WO>>(content, serializerSettings);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw ex;
            }
            throw new Exception("Could not do search");
        }
        public async Task<List<SVMX_WO>> GetWOByTechAsync(string email)
        {
            //email = "mohammed.1.rahman-ext@jci.com";
            Uri uri = new Uri(baseURL + $"SVMAXWO/byTech/{email}");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<SVMX_WO>>(content, serializerSettings);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw ex;
            }
            throw new Exception("Could not do search");
        }
        public async Task<SVMX_WO> GetWOByNumberAsync(string number)
        {
            //https://jciretailsurveytoolwebportaltest.azurewebsites.net/api/SVMAXWO/byWO/WO-01575850
            Uri uri = new Uri(baseURL + $"SVMAXWO/byWO/{number}");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SVMX_WO>(content, serializerSettings);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw ex;
            }
            throw new Exception("Could not do search");

        }

        public async Task<T> PostItem<T>(T item) where T : class
        {

            var content = JsonConvert.SerializeObject(item, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            return await PostItem<T>(content);

        }
        public async Task<T> PostItem<T>(String content) where T : class
        {
            Uri uri = new Uri(baseURL + typeof(T).Name);
            try
            {

#if DEBUG
                Debug.WriteLine(@"\tINFO {0}", content);
#endif


                HttpResponseMessage response = await client.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                   
#if DEBUG
                    Debug.WriteLine(@"\tINFO {0}", responseContent);
#endif
                    return JsonConvert.DeserializeObject<T>(responseContent, serializerSettings);

                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(@"\tINFO {0}", responseContent);
                    throw new Exception(responseContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw ex;
            }
            throw new Exception("Failed posting");
        }
        public async Task PutItem<T>(T item, string pathEnd) where T : class
        {
            Uri uri = new Uri(baseURL + typeof(T).Name + "/" + pathEnd);
            try
            {
                //var content = JsonConvert.SerializeObject(item);

                var content = JsonConvert.SerializeObject(item, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
#if DEBUG
                Debug.WriteLine(@"\tINFO {0}", content);
#endif
                HttpResponseMessage response = await client.PutAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
#if DEBUG
                    Debug.WriteLine(@"\tINFO {0}", responseContent);
#endif


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw ex;
            }
        }

        public async Task<T> PutAudit<T>(String content, String pathEnd) where T : class
        {
            Uri uri = new Uri(baseURL + typeof(T).Name + "/" + pathEnd);
            try
            {
                //var content = JsonConvert.SerializeObject(item);

                #if DEBUG
                Debug.WriteLine(@"\tINFO {0}", content);
                #endif

                HttpResponseMessage response = await client.PutAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));


                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();


#if DEBUG
                    Debug.WriteLine(@"\tINFO {0}", responseContent);
#endif
                    return JsonConvert.DeserializeObject<T>(responseContent, serializerSettings);

                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(@"\tINFO {0}", responseContent);
                    throw new Exception(responseContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw ex;
            }
        }

        public async Task<List<T>> GetItems<T>() where T : class
        {
            var Items = new List<T>();
            Uri uri = new Uri(baseURL + typeof(T).Name);
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<T>>(content, serializerSettings);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw ex;
            }
            return Items;
        }

    }
}
