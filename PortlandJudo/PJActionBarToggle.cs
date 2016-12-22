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
using Android.Support.V7.App;
using Android.Support.V4.Widget;

namespace PortlandJudo
{
    class PJActionBarToggle : ActionBarDrawerToggle
    {
        Activity activity;
        PJActionBarToggle(Activity activity, DrawerLayout dl, int open, int close) : base(activity, dl, open, close)
        {
            this.activity = activity;
        }

        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);
            this.activity.ActionBar.Title = "Please select from list";
        }

        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
            this.activity.ActionBar.Title = "Drawer layout APP";
        }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }
    }
}