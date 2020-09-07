using OpenTokSDK;
using System;
using System.Configuration;
using System.Net;

namespace HelloWorld
{
    public class OpenTokService
    {
        public OpenTokService()
        {
            int _APIKey = 0;
            string _APISecret = null;
            try
            {
                string _APIKeyString = ConfigurationManager.AppSettings["API_KEY"];
                _APISecret = ConfigurationManager.AppSettings["API_SECRET"];
                _APIKey = Convert.ToInt32(_APIKeyString);
            }

            catch (Exception _Exception)
            {
                if (!(_Exception is ConfigurationErrorsException || _Exception is FormatException || _Exception is OverflowException))
                {
                    throw _Exception;
                }
            }

            finally
            {
                if (_APIKey == 0 || _APISecret == null)
                {
                    Console.WriteLine("The OpenTok API Key and API Secret were not set in the application configuration. " + "Set the values in App.config and try again. (apiKey = {0}, apiSecret = {1})", _APIKey, _APISecret);
                    Console.ReadLine();
                    Environment.Exit(-1);
                }
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            OpenTok = new OpenTok(_APIKey, _APISecret);
            Session = OpenTok.CreateSession();
        }

        public Session Session { get; protected set; }
        public OpenTok OpenTok { get; protected set; }
    }
}
