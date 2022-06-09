using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ProyectoFinal
{
    public class QRCode
    {
        private const string URL = "https://api.qrserver.com/v1/read-qr-code/";
        //private static string urlParameters = "?fileurl=C:\\Users\\josel\\Documents\\Patrones de Diseño y Arquitecturas de Software\\ProyectoFinal\\ProyectoFinal\\example.png";
        //private const string urlParameters = "?fileurl=http%3A%2F%2Fapi.qrserver.com%2Fv1%2Fcreate-qr-code%2F%3Fdata%3DHelloWorld";
        
        public QRCode()
        {

        }
        public string ReadQR(string value)
        {
            string urlParameters = "?fileurl=" + value;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                //string res = response.Content.ReadAsStringAsync().Result;
                JArray dataObjects = response.Content.ReadAsAsync<JArray>().Result;
                //Console.WriteLine(dataObjects[0]["symbol"][0]["data"]);

                //Console.WriteLine("QR Code Read succesfully");
                return dataObjects[0]["symbol"][0]["data"].ToString();
                // [{"type":"qrcode","symbol":[{"seq":0,"data":"HelloWorld","error":null}]}]
            }
            else
            {
                Console.WriteLine("ERROR: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return null;
        }

        public string CreateQR(string value)
        {
            /*string urlParameters = "?size=150x150&data=" + value;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                //string res = response.Content.ReadAsStringAsync().Result;
                //JArray dataObjects = response.Content.ReadAsAsync<JArray>().Result;
                string res = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine("QR Code Write succesfully");
                //Console.WriteLine(dataObjects);
                Console.WriteLine(res);
                // [{"type":"qrcode","symbol":[{"seq":0,"data":"HelloWorld","error":null}]}]
            }
            else
            {
                Console.WriteLine("ERROR: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return false;*/
            return string.Format("http://api.qrserver.com/v1/create-qr-code/?data={0}&size=100x100", value);
        }
    }
}
