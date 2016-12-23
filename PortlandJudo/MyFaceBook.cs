using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Facebook;
using System.Net;

namespace PortlandJudo
{
    public class MyFaceBook
    {
        FacebookClient fb = new FacebookClient();
        string accessToken;
        const string facebookAppId = "707933159373580";
        const string sec = "09a246e04d10182cb33157067b905ff1";

        public MyFaceBook()
        {
            string login_url = "https://graph.facebook.com/oauth/access_token?grant_type=client_credentials&client_id="
                + facebookAppId  + "&client_secret=" + sec;
            string result = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(login_url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (System.IO.Stream stream = response.GetResponseStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                }
            }

            if (!result.Contains("access_token=")) return;
            
            accessToken = result.Split('=')[1];
            
        }

        public object GetGroupInfo()
        {
            FacebookClient fb = new FacebookClient(accessToken);
            dynamic result = fb.Get("PortlandJudo/feed");
            return result;
        }
    }
}