using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ODD.Api.Infrastructure.Utility.Helpers.JsonReader.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Infrastructure.Utility.Helpers.JsonReader
{
    public static class JsonReaderHelper
    {

        public static string LoadJson(string path)
        {
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    return r.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex.InnerException);
            }
        }
        public static string GetSection(this string json, string key)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new JsonIsEmptyException();

            try
            {
                JObject jObject = JObject.Parse(json);
                JToken jUser = jObject[key];
                string jsonString = jUser.ToString();
                return jsonString;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex.InnerException);
            }




        }


    }
}

