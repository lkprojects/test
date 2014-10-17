using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;

namespace YieldsScraping
{
    class Program
    {

        private static string URL1 = @"http://bituachnet.mof.gov.il/bituachTsuotUI/Tsuot/UI/bituachTsuotUI.aspx";
        private static string URL2 = @"http://bituachnet.mof.gov.il/bituachTsuotUI/Tsuot/UI/horadatXMLMain.aspx";
        private static string URL3 = @"http://bituachnet.mof.gov.il/bituachTsuotUI/Tsuot/UI/horadatXML.aspx";

        private static string ExtractViewState(string s)
        {
            string viewStateNameDelimiter = "__VIEWSTATE";
            string valueDelimiter = "value=\"";

            int viewStateNamePosition = s.IndexOf(viewStateNameDelimiter);
            int viewStateValuePosition = s.IndexOf(
                  valueDelimiter, viewStateNamePosition
               );

            int viewStateStartPosition = viewStateValuePosition +
                                         valueDelimiter.Length;
            int viewStateEndPosition = s.IndexOf("\"", viewStateStartPosition);

            return HttpUtility.UrlEncodeUnicode(
                     s.Substring(
                        viewStateStartPosition,
                        viewStateEndPosition - viewStateStartPosition
                     )
                  );
        }
        
        static void Main(string[] args)
        {
            //Step 1 - Get to URL1
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest webRequest = WebRequest.Create(URL1) as HttpWebRequest;
            webRequest.CookieContainer = cookies;

            StreamReader responseReader = new StreamReader(
                  webRequest.GetResponse().GetResponseStream()
               );
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();

            // extract the viewstate value and build out POST data
            string viewState = ExtractViewState(responseData);

            //Select  "all the policies" to the list
            string postData = "ScriptManager1=UpdatePanel5|addone&__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&output=0000&search=&searchHid=&rblDoch=dochTsuot&OclusiyaTihkur=&HevrotTihkur1=&HevrotTihkur2=&HevrotTihkur3=&dblClick=&SelectList=&InputNumber=&optRange=lastYear&shanimad=2014&hodashad=8&shanimme=2013&hodashme=9&strSortField=&strSignToolTip=&strPerutToolTip=&strPerutName=&ReportViewer1$ctl04=&ReportViewer1$ctl05=&ReportViewer1$ctl06=1&addone=%3C"
                              + "&__VIEWSTATE="  + viewState;

            // //Step 2 - POST on URL1 with post data and viewState - selecting "all policies"
            webRequest = WebRequest.Create(URL1) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "*/*";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.101 Safari/537.36";
            webRequest.CookieContainer = cookies;
            webRequest.Headers.Add("X-MicrosoftAjax", "Delta=true");
            webRequest.Headers.Add("Cache-Control", "no-cache");
            webRequest.Headers.Add("Accept-Language", "en-US,en;q=0.7,he;q=0.3");
            webRequest.Referer = "http://bituachnet.mof.gov.il/bituachTsuotUI/Tsuot/UI/bituachTsuotUI.aspx";
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            webRequest.Headers.Add("DNT", "1");
            webRequest.ConnectionGroupName = "Keep-Alive";

            // write the form values into the request message
            StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
            requestWriter.Write(postData);
            requestWriter.Close();

            // we don't need the contents of the response, just the cookie it issues
            //webRequest.GetResponse().Close();
            responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            responseData = responseReader.ReadToEnd();
            responseReader.Close();



            // Step 3 - Press the "generate XML button"
            //postData = "ScriptManager1=UpdatePanel3|cbXML&__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&output=0000&search=&searchHid=&rblDoch=dochTsuot&OclusiyaTihkur=&HevrotTihkur1=&HevrotTihkur2=&HevrotTihkur3=&dblClick=&SelectList=&InputNumber=&optRange=lastYear&shanimad=2014&hodashad=8&shanimme=2013&hodashme=9&strSortField=&strSignToolTip=&strPerutToolTip=&strPerutName=&ReportViewer1$ctl04=&ReportViewer1$ctl05=&ReportViewer1$ctl06=1&cbXML=XML%20%D7%94%D7%95%D7%A8%D7%93%D7%AA%20%D7%A7%D7%95%D7%91%D7%A5"
            //           + "&__VIEWSTATE="  + viewState;


            postData = "ScriptManager1=UpdatePanel3|cbXML&__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&input=0000&output=0000&search=&searchHid=&rblDoch=dochTsuot&OclusiyaTihkur=&HevrotTihkur1=&HevrotTihkur2=&HevrotTihkur3=&dblClick=&SelectList=&InputNumber=&optRange=lastYear&shanimad=2014&hodashad=8&shanimme=2013&hodashme=9&strSortField=&strSignToolTip=&strPerutToolTip=&strPerutName=&cbXML=XML%20%D7%94%D7%95%D7%A8%D7%93%D7%AA%20%D7%A7%D7%95%D7%91%D7%A5"
                       + "&__VIEWSTATE=" + viewState;


            webRequest = WebRequest.Create(URL1) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.101 Safari/537.36";
            webRequest.CookieContainer = cookies;

            webRequest.Headers.Add("X-MicrosoftAjax", "Delta=true");
            webRequest.Headers.Add("Cache-Control", "no-cache");
            webRequest.Headers.Add("Accept-Language", "en-US,en;q=0.7,he;q=0.3");
            webRequest.Referer = "http://bituachnet.mof.gov.il/bituachTsuotUI/Tsuot/UI/bituachTsuotUI.aspx";
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            webRequest.Headers.Add("DNT", "1");
            webRequest.ConnectionGroupName = "Keep-Alive";
           
            // write the form values into the request message
            requestWriter = new StreamWriter(webRequest.GetRequestStream());
            requestWriter.Write(postData);
            requestWriter.Close();
            responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            responseData = responseReader.ReadToEnd();
            responseReader.Close();

            
            // Step 4 - Get URL2
            webRequest = WebRequest.Create(URL2) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookies;
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.101 Safari/537.36";

            // we don't need the contents of the response, just the cookie it issues
            responseReader = new StreamReader(
                            webRequest.GetResponse().GetResponseStream()
                         );
            responseData = responseReader.ReadToEnd();
            responseReader.Close();

            
            // STEP 5 - POST URL2 with "click commit button"
            webRequest = WebRequest.Create(URL2) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookies;
            webRequest.Accept = "*/*";
            webRequest.Headers.Add("X-MicrosoftAjax", "Delta=true");
            webRequest.Headers.Add("Cache-Control", "no-cache");
            webRequest.Headers.Add("Origin", "http://bituachnet.mof.gov.il");
            webRequest.Headers.Add("Accept-Language", "en-US,en;q=0.8,he;q=0.6");
            webRequest.Referer = "http://bituachnet.mof.gov.il/bituachTsuotUI/Tsuot/UI/horadatXMLMain.aspx";
            webRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.101 Safari/537.36";

            postData = "ScriptManager1=UpdatePanelAll|cbBatzea&__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&shanimad=2014&hodashad=8&shanimme=2013&hodashme=9&rdl=Radio1&dblClick=&SelectList=&cbBatzea=%D7%91%D7%A6%D7%A2"
                        + "&__VIEWSTATE=" + viewState;

            requestWriter = new StreamWriter(webRequest.GetRequestStream());
            requestWriter.Write(postData);
            requestWriter.Close();
            responseReader = new StreamReader(
                       webRequest.GetResponse().GetResponseStream()
                    );
            responseData = responseReader.ReadToEnd();
            responseReader.Close();

                      
            // Step 6 - get the XML data
            webRequest = WebRequest.Create(URL3) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.CookieContainer = cookies;
            webRequest.Accept = " text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.101 Safari/537.36";
            responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());

            // and read the response
            responseData = responseReader.ReadToEnd();
            responseReader.Close();

            Console.WriteLine(responseData);         

        }
    }
}
