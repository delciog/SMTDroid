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
	[Activity (Label = "Person")]			
	public class Person : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "Person" layout resource
			SetContentView (Resource.Layout.Person);

			// Get parameter from previous activity
			string userId = Intent.GetStringExtra ("user_id") ?? "-1";
			string contactId = Intent.GetStringExtra ("person_id") ?? "-1";

			// Get webservice and event data attached to controls
			appConfig config = new appConfig();
			var _service = new SMTWebsevice.SMT(config.SMTWebserviceURL);
			if (contactId != "-1") {
				SMTWebsevice.Contact selectedContact = _service.getContactById (contactId);

				// Get controls
				TextView textName = FindViewById<TextView>(Resource.Id.textName);
				//TextView textNextEvent = FindViewById<TextView>(Resource.Id.textNextEvent); // remove this?
				TextView textJobTitle = FindViewById<TextView>(Resource.Id.textJobTitle);
				TextView textOrganisation = FindViewById<TextView>(Resource.Id.textOrganisation);
				TextView textNotes = FindViewById<TextView>(Resource.Id.textNotes);
				ToggleButton toggleContactMet = FindViewById<ToggleButton>(Resource.Id.toggleContactMet);
				ListView listFutureEvents = FindViewById<ListView>(Resource.Id.listFutureEvents);

				// Assign values to controls
				textName.Text = selectedContact.name;
				//textNextEvent.Text = selectedContact.name; // remove this?
				textJobTitle.Text = selectedContact.jobTitle;
				textOrganisation.Text = selectedContact.organisation;
				textNotes.Text = selectedContact.notes;

				toggleContactMet.TextOn = "You've met!";
				toggleContactMet.TextOff = "You haven't met";

				//Set initial value
				toggleContactMet.Checked = _service.isContactMet(userId, contactId);

				// Add handler
				toggleContactMet.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
					bool status = _service.toggleContactMet(userId, contactId);
					if (status != e.IsChecked) {
						toggleContactMet.TextOn = "Error";
						toggleContactMet.TextOff = "Error";
					}
				};

				// Get events and populate list
				List<EventListItem> eventList = new List<EventListItem> ();
				List<SMTWebsevice.Event> wseList = _service.listEventsByContact(contactId, SMTDroid.SMTWebsevice.queryTimeOption.Future).ToList();
				foreach (SMTWebsevice.Event item in wseList) {
					eventList.Add (new EventListItem(item.id, item.name));
				}

				listFutureEvents.Adapter = new EventListAdapter(this, eventList);

				// If any event is selected
				listFutureEvents.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var intent = new Intent(this, typeof(Event));
					List<string> eventId = new List<string>();
					eventId.Add(e.Id.ToString());
					intent.PutExtra("event_id", Convert.ToString(e.Id)); // Passing the chosen event ID to the next activity
					intent.PutExtra("user_id", userId); // Passing the chosen event ID to the next activity
					StartActivity(intent);	
				};
			}
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

