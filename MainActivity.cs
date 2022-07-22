using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using XamarinTrainingRooms;

namespace InstituteApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    [System.Obsolete]
    public class MainActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            //Roomrepository from the shared library
            var repo = new RoomRepository();
            //receive the list of rooms available
            var rooms = repo.GetRooms();
            //set the received available rooms list into a arrayadapter in android
            var adapter = new ArrayAdapter<XamarinTrainingRooms.XamarinTrainingRooms>(this,Resource.Layout.RoomListItem,rooms.ToArray());
            //assign the adapter to the ListAdapter of the current instance
            this.ListAdapter = adapter;
        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            //To pass data between activities
            var intent = new Intent(this, typeof(TrainingRoomDetailsActivity));
            //For selecting the id of the item clicked on
            var selectedItem = ((ArrayAdapter<XamarinTrainingRooms.XamarinTrainingRooms>)ListAdapter).GetItem(position);
            //pass the selected id through intent and start the activity
            intent.PutExtra("roomId", selectedItem.id);
            StartActivity(intent);
        }
    }
}