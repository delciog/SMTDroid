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
	[Activity (Label = "Future Events")]			
	public class Events : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "Events" layout resource
			SetContentView (Resource.Layout.Events);

			// Get parameter from previous activity
			string userId = Intent.GetStringExtra ("user_id") ?? "-1";

			// Get the list
			ListView events = FindViewById<ListView>(Resource.Id.listEvents);

			// Get webservice
			appConfig config = new appConfig();
			var _service = new SMTWebsevice.SMT(config.SMTWebserviceURL);

			// Get events and populate list
			List<EventListItem> eventList = new List<EventListItem> ();
			List<SMTWebsevice.Event> wseList = _service.listEvents (SMTDroid.SMTWebsevice.queryTimeOption.Future).ToList();
			foreach (SMTWebsevice.Event item in wseList) {
				eventList.Add (new EventListItem(item.id, item.name));
			}

			events.Adapter = new EventListAdapter(this, eventList);

			events.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				var intent = new Intent(this, typeof(Event));
				List<string> eventId = new List<string>();
				eventId.Add(e.Id.ToString());
				intent.PutExtra("event_id", Convert.ToString(e.Id)); // Passing the chosen event ID to the next activity
				intent.PutExtra("user_id", userId); // Passing the chosen event ID to the next activity
				StartActivity(intent);	
			};

		}

		public class EventListAdapter : BaseAdapter<EventListItem> {
			List<EventListItem> items;
			Activity context;
			public EventListAdapter(Activity context, List<EventListItem> items) : base() {
				this.context = context;
				this.items = items;
			}
			public override long GetItemId(int position)
			{
				return (long)items[position].getId();
			}
			public override EventListItem this[int position] {  
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

		public class EventListItem
		{
			private String name;
			private int id;

			public EventListItem (int id, String name) 
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


