using Android.App;
using Android.OS;
using Android.Widget;

namespace InstituteApp
{
    [Activity(Label = "TrainingRoomDetailsActivity")]
    public class TrainingRoomDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.TrainingRoomDetailsActivity);
            //receive the passed selected item id
            int roomId = Intent.GetIntExtra("roomId", 0);
            //creatig the room repo to grab the relevant room
            var repo = new XamarinTrainingRooms.RoomRepository();
            //selecting the specific room
            var room = repo.GetRooms(roomId);

            //Customizing the UI
            this.Title = "Allocated Room Details";
            this.FindViewById<TextView>(Resource.Id.textViewName).Text = room.name;
            this.FindViewById<TextView>(Resource.Id.textViewLocation).Text = room.location;
            


        }
    }
}