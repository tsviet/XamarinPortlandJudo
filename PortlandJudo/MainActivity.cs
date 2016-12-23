using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Java.IO;
using System.Threading;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PortlandJudo
{
    public class FeedJson
    {
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("story")]
        public string story { get; set; }
        [JsonProperty("created_time")]
        public string created_time { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
    }

    [Activity(Label = "PortlandJudo", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/CustomActionBarTheme")]
    public class MainActivity : Activity
    {
        DrawerLayout mDrawerLayout;
        List<string> list = new List<string>();
        ArrayAdapter mArrayAdapter;
        ListView mLeftDrawer;
        //ListView mRightDrawer;
        ActionBarDrawerToggle mDrawerToogle;
        protected TextView textView = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.myDrawer);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.leftListView);
            //mRightDrawer = FindViewById<ListView>(Resource.Id.rightListView);

            list.Add("Home");
            list.Add("Classes");
            list.Add("Events");
            list.Add("Contacts");
            mArrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemActivated1, list);
            mLeftDrawer.Adapter = mArrayAdapter;
            mDrawerToogle = new ActionBarDrawerToggle(this, mDrawerLayout, Resource.String.openDrawer, Resource.String.closeDrawer);
            mDrawerLayout.AddDrawerListener(mDrawerToogle);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetBackgroundDrawable(GetDrawable(Resource.Drawable.portland_header));
            ActionBar.SetTitle(Resource.String.empty_title);

            SetMainFeed();
        }

        private void SetMainFeed()
        {
            var testView = FindViewById<TextView>(Resource.Id.tvText);
            ScrollView scrollView = FindViewById<ScrollView>(Resource.Id.scrollView);
            MyFaceBook fb = new MyFaceBook();
            JObject jo = JObject.Parse(fb.GetGroupInfo().ToString());
            var mainLayout = new LinearLayout(this)
            {
                Orientation = Orientation.Vertical,
                LayoutParameters =
                           new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)

            };
            scrollView.AddView(mainLayout);

            foreach (var entry in jo["data"])
            {
                FeedJson resEntry = JsonConvert.DeserializeObject<FeedJson>(entry.ToString());
                var layout = new LinearLayout(this)
                {
                    Orientation = Orientation.Vertical,
                    LayoutParameters =
                           new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)

                };
                var id = new TextView(this);
                id.Text = resEntry.id;
                layout.AddView(id);
                mainLayout.AddView(layout);
                
            }

        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            mDrawerToogle.SyncState();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (mDrawerToogle.OnOptionsItemSelected(item))
            {
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

