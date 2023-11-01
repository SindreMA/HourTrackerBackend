using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HourTrackerBackend.Helpers
{
    public class GeneralHelper
    {
        private UserManager<User> userManager;

        public GeneralHelper(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        internal object FirstLoadData(string username)
        {
            var context = new TrackerContext();
            var user = context.Users.FirstOrDefault(x=> x.UserName.ToLower() == username.ToLower());

            var data = new
            {
                userData = user,
            };
            return data;
        }
    }
}
