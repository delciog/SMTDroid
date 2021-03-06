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
	[Activity (Label = "Event")]			
	public class Event : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "Event" layout resource
			SetContentView (Resource.Layout.Event);

			// Get parameter from previous activity
			string eventId = Intent.GetStringExtra ("event_id") ?? "-1";
			string userId = Intent.GetStringExtra ("user_id") ?? "-1";


			// Get webservice and event data attached to controls
			appConfig config = new appConfig();
			var _service = new SMTWebsevice.SMT(config.SMTWebserviceURL);
			if (eventId != "-1") {
				SMTWebsevice.Event selectedEvent = _service.getEventById (eventId);

				// Get controls
				TextView txtEventName = FindViewById<TextView>(Resource.Id.txtEventName);
				TextView txtURL = FindViewById<TextView>(Resource.Id.txtURL);
				TextView txtLocation = FindViewById<TextView>(Resource.Id.txtLocation);
				TextView txtDateTime = FindViewById<TextView>(Resource.Id.txtDateTime);
				TextView txtDescription = FindViewById<TextView>(Resource.Id.txtDescription);
				ToggleButton tbAttend = FindViewById<ToggleButton>(Resource.Id.tbAttend);
				TextView textPeopleAttending = FindViewById<TextView> (Resource.Id.textPeopleAttending);
				ListView listPeopleAttending = FindViewById<ListView>(Resource.Id.listPeopleAttending);

				// Assign values to controls
				txtEventName.Text = selectedEvent.name;
				txtURL.Text = selectedEvent.url;
				txtLocation.Text = selectedEvent.location;
				txtDateTime.Text = selectedEvent.session.ToString();
				txtDescription.Text = selectedEvent.description;

				// Set toogle button descriptions
				if (selectedEvent.session > DateTime.UtcNow) {
					tbAttend.TextOn = "You're attending!";
					tbAttend.TextOff = "You're not attenting";
					textPeopleAttending.Text = "People attending";
				} else {
					tbAttend.TextOn = "You attended!";
					tbAttend.TextOff = "You didn't attend";
					textPeopleAttending.Text = "People attended";
				}


				//Set initial value
				tbAttend.Checked = _service.isAttendingEvent(eventId, userId);

				// Add handler
				tbAttend.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
					bool status = _service.toggleAttendEvent(eventId, userId);
					if (status != e.IsChecked) {
						tbAttend.TextOn = "Error";
						tbAttend.TextOff = "Error";
					}
				};

				// Get contact attending this event and populate list
				List<ContactListItem> contactList = new List<ContactListItem> ();
				List<SMTWebsevice.Contact> wscList = _service.listContactsInEvent(eventId, SMTDroid.SMTWebsevice.queryTimeOption.All).ToList();
				foreach (SMTWebsevice.Contact item in wscList) {
					string contactSummary = item.name + (item.jobTitle == string.Empty ? "" : " / " + item.jobTitle) + (item.organisation == string.Empty ? "" : " / " + item.organisation);
					contactList.Add (new ContactListItem(item.id, contactSummary));
				}

				listPeopleAttending.Adapter = new EventListAdapter(this, contactList);

				// If any contact is selected
				listPeopleAttending.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var intent = new Intent(this, typeof(Person));
					List<string> personId = new List<string>();
					personId.Add(e.Id.ToString());
					intent.PutExtra("person_id", Convert.ToString(e.Id)); // Passing the chosen event ID to the next activity
					intent.PutExtra("user_id", userId); // Passing the chosen event ID to the next activity
					StartActivity(intent);	
				};
			}

		}

		public class EventListAdapter : BaseAdapter<ContactListItem> {
			List<ContactListItem> items;
			Activity context;
			public EventListAdapter(Activity context, List<ContactListItem> items) : base() {
				this.context = context;
				this.items = items;
			}
			public override long GetItemId(int position)
			{
				return (long)items[position].getId();
			}
			public override ContactListItem this[int position] {  
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

		public class ContactListItem
		{
			private String name;
			private int id;

			public ContactListItem (int id, String name) 
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

