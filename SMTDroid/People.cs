﻿
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

namespace SMTDroid
{
	[Activity (Label = "People")]			
	public class People : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "Events" layout resource
			SetContentView (Resource.Layout.People);

			// Get parameter from previous activity
			string userId = Intent.GetStringExtra ("user_id") ?? "-1";

			// Get the list
			ListView people = FindViewById<ListView>(Resource.Id.listPeople);

			// Get webservice
			appConfig config = new appConfig();
			var _service = new SMTWebsevice.SMT(config.SMTWebserviceURL);

			// Get events and populate list
			List<PeopleListItem> peopleList = new List<PeopleListItem> ();
			List<SMTWebsevice.Contact> wspList = _service.listContacts().ToList();
			foreach (SMTWebsevice.Contact item in wspList) {
				peopleList.Add (new PeopleListItem(item.id, item.name));
			}

			people.Adapter = new PeopleListAdapter(this, peopleList);

			// If any event is selected
			people.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				var intent = new Intent(this, typeof(Person));
				List<string> eventId = new List<string>();
				eventId.Add(e.Id.ToString());
				intent.PutExtra("person_id", Convert.ToString(e.Id)); // Passing the chosen event ID to the next activity
				intent.PutExtra("user_id", userId); // Passing the chosen event ID to the next activity
				StartActivity(intent);	
			};
		}

		public class PeopleListAdapter : BaseAdapter<PeopleListItem> {
			List<PeopleListItem> items;
			Activity context;
			public PeopleListAdapter(Activity context, List<PeopleListItem> items) : base() {
				this.context = context;
				this.items = items;
			}
			public override long GetItemId(int position)
			{
				return (long)items[position].getId();
			}
			public override PeopleListItem this[int position] {  
				get { return items[position]; }
			}
			public override int Count {
				get { return items.Count(); }
			}
			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				View view = convertView; // re-use an existing view, if one is available
				if (view == null) // otherwise create a new one
					view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
				view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].ToString();
				return view;
			}
		}

		public class PeopleListItem
		{
			private String name;
			private int id;

			public PeopleListItem (int id, String name) 
			{
				this.id = id;
				this.name = name.ToString();
			}

			public float getId() {
				return id;
			}

			public void setId(int id) {
				this.id = id;
			}

			public String getName() {
				return name;
			}

			public void setName(String name) {
				this.name = name;
			}

			public override String ToString() {
				return this.name;
			}
		}
	}
}

