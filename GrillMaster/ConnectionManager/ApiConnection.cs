using System;
using System.IO;
using System.Net;

namespace ConnectionManager
{
    public class ApiConnection
    {
        private string url;
        public ApiConnection(String url)
        {
            this.url = url;
        }

        public HttpWebResponse Get(string urn)
        {
            HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(string.Concat(this.url, urn));
            getRequest.Method = "GET";
            getRequest.Headers.Add("Accept", "Application/json");
            try
            {
                HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
                return getResponse;
            }
            catch (Exception e)
            {

                throw e;
            }
               
           
            

        }
    }
}
