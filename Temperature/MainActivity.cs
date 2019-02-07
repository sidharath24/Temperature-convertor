using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Temperature
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView vCels, vFah;
        EditText tCels, tFah;
        Button btConv, btClr;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            vCels = (TextView)FindViewById(Resource.Id.tvCelcius);
            vFah = (TextView)FindViewById(Resource.Id.tvFah);
            tCels = (EditText)FindViewById(Resource.Id.etCelcius);
            tFah = (EditText)FindViewById(Resource.Id.etFah);
            btConv = (Button)FindViewById(Resource.Id.btnConv);
            btClr = (Button)FindViewById(Resource.Id.btnClr);

            btClr.Click += delegate
            {
                tCels.Text = "";
                tFah.Text = "";

            };


            btConv.Click += delegate
            {
                if(tCels.Text != "")
                {
                    //convert celcius to farenheit
                    double cel, fah;
                     cel = double.Parse(tCels.Text);
                     fah = (cel * 9 / 5) + 32;
                     tFah.Text = fah.ToString();

                }

                else if(tFah.Text!="")
                {
                    //Convert farenheit to celius
                    double cel, fah;
                    fah = double.Parse(tFah.Text);
                    cel = (fah - 32) * 5 / 9;
                    tCels.Text = cel.ToString();
                }

                else
                    Toast.MakeText(this, "Please enter the temperature to convert", ToastLength.Long).Show();
            };

            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

