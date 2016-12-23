/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Social;
using Xamarin.Social.Services;

namespace PortlandJudo
{
    class XamarinSocial
    {

    public void Connect()
    {
        var facebook = new FacebookService
        {
            ClientId = "<App ID from developers.facebook.com/apps>",
            RedirectUrl = new System.Uri("<Redirect URL from developers.facebook.com/apps>")
        };

        // 2. Create an item to share
        var item = new Item { Text = "Xamarin.Social is the bomb.com." };
        item.Links.Add(new Uri("http://github.com/xamarin/xamarin.social"));

        // 3. Present the UI on iOS
        var shareController = facebook.GetShareUI(item, result => {
            // result lets you know if the user shared the item or canceled
            DismissViewController(true, null);
        });
        PresentViewController(shareController, true, null);
    }
}
}*/