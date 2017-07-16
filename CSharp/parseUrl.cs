// Author: http://lemming.life
// Language: C#
// Purpose: Given a url extract the protocol, domain, and query string. 
// Date: July 15, 2017

using System;

namespace Snippets {
    class UrlParser {

        static string getProtocol(string url) {
            string lookFor = "://";
            int indexOf = url.IndexOf(lookFor);
            return url.Substring(0, indexOf);
        }

        static string getDomain(string url) {
            string lookFor1 = "://";
            string lookFor2 = "/";
            int indexOf1 = url.IndexOf(lookFor1) + lookFor1.Length;
            url = url.Substring(indexOf1, url.Length - indexOf1);
            int indexOf2 = url.IndexOf(lookFor2);
            return url.Substring(0, indexOf2);
        }

        static string getQuery(string url) {
            string lookFor = "/";
            int indexOf = url.LastIndexOf(lookFor) + 1;
            return url.Substring(indexOf, url.Length - indexOf);
        }

        public static void executeDriver() {
            string url = "http://google.com/theQuery123";
            Console.WriteLine("Url1 is: " + url);
            Console.WriteLine("Protocol: " + getProtocol(url));
            Console.WriteLine("Domain: " + getDomain(url));
            Console.WriteLine("Query: " + getQuery(url));

            url = "http://google.com/some/stuff/in/between/theQuery123";
            Console.WriteLine("\nUrl2 is: " + url);
            Console.WriteLine("Protocol: " + getProtocol(url));
            Console.WriteLine("Domain: " + getDomain(url));
            Console.WriteLine("Query: " + getQuery(url));
        }


    }
}

