using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GoogleClientLoginAC2DMTokenFetcher
{
    class Program
    {
        /// <summary>
        /// Login of Google client login service.
        /// </summary>
        private const String GOOGLE_CLIENT_LOGIN_URL = "https://www.google.com/accounts/ClientLogin";
        /// <summary>
        /// Account type to use.
        /// </summary>
        private const String ACCOUNT_TYPE = "GOOGLE";
        /// <summary>
        /// Service to get AuthToken for.
        /// </summary>
        private const String SERVICE = "ac2dm";
        /// <summary>
        /// Begin of result line for actual Auth token in response.
        /// </summary>
        private const string AUTH_LINE_START = "Auth=";
        /// <summary>
        /// Newline.
        /// </summary>
        private const string NEWLINE = "\n\r";
        /// <summary>
        /// Content-type for request.
        /// </summary>
        private const string CONTENT_TYPE = "application/x-www-form-urlencoded";
        /// <summary>
        /// Method for request.
        /// </summary>
        private const string METHOD_POST = "POST";

        /// <summary>
        /// Read input arguments from console in interactive mode.
        /// </summary>
        /// <param name="eMail">Read e-mail address.</param>
        /// <param name="password">Read password.</param>
        private static void GetInputFromConsoleInteractive(out string eMail, out string password)
        {
            Console.Write("Enter e-mail address of Google account: ");
            eMail = Console.ReadLine();
            Console.Write("Enter password for Google account: ");
            password = Console.ReadLine();
        }

        /// <summary>
        /// Main entry point.
        /// </summary>
        static void Main(string[] args)
        {
            var eMail = String.Empty;
            var password = String.Empty;

            GetInputFromConsoleInteractive(out eMail, out password);

            // Auth token from service.
            var authToken = String.Empty;

            try
            {
                SendGetTokenRequest(eMail, password, out authToken);
                if (String.IsNullOrEmpty(authToken))
                {
                    Console.WriteLine("No auth token, aborting...");
                    return;
                }

                // Print auth token with delimiters.
                Console.WriteLine("-----BEGIN AUTH TOKEN-----");
                Console.WriteLine(authToken);
                Console.WriteLine("-----END AUTH TOKEN-----");

            }
            catch (Exception ex0)
            {
                Console.WriteLine(ex0);
            }
        }

        /// <summary>
        /// Build data for post.
        /// </summary>
        private static String BuildPostDataString(string eMail, string password)
        {
            var postDataStringBuilder = new StringBuilder();

            postDataStringBuilder.Append("Email=");
            postDataStringBuilder.Append(eMail);
            postDataStringBuilder.Append("&");

            postDataStringBuilder.Append("Passwd=");
            postDataStringBuilder.Append(password);
            postDataStringBuilder.Append("&");

            postDataStringBuilder.Append("accontType=");
            postDataStringBuilder.Append(ACCOUNT_TYPE);
            postDataStringBuilder.Append("&");

            postDataStringBuilder.Append("service=");
            postDataStringBuilder.Append(SERVICE);

            return postDataStringBuilder.ToString();
        }

        /// <summary>
        /// Send actual request.
        /// </summary>
        private static void SendGetTokenRequest(string eMail, string password, out string authToken)
        {
            var postRequest = WebRequest.Create(GOOGLE_CLIENT_LOGIN_URL);
            postRequest.Method = METHOD_POST;
            postRequest.ContentType = CONTENT_TYPE;
            using (var postRequestStream = postRequest.GetRequestStream())
            {
                using (var postRequestStreamWriter = new StreamWriter(postRequestStream))
                {
                    var postDataString = BuildPostDataString(eMail, password);
                    postRequestStreamWriter.Write(postDataString);
                }
            }

            var postResponse = postRequest.GetResponse();
            using (var postResponseStream = postResponse.GetResponseStream())
            {
                using (var postResponseStreamReader = new StreamReader(postResponseStream))
                {
                    var completePostResponseText = postResponseStreamReader.ReadToEnd();

                    // Split complete text into separate lines.
                    var splitPostResponseLines = completePostResponseText.Split(NEWLINE.ToCharArray());

                    // Get line with auth token.
                    var authLine = splitPostResponseLines.
                        Where(line => line.StartsWith(AUTH_LINE_START, StringComparison.InvariantCultureIgnoreCase)).
                        FirstOrDefault();

                    // Get actual auth token.
                    authToken = authLine.Substring(AUTH_LINE_START.Length);

                }
            }
        }
    }
}
