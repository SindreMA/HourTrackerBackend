﻿using HourTrackerBackend.Modals;
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

            var projects = context.Projects
            .Include(p => p.Mechanics)
            .Include(p => p.Todos)
            .Include(p => p.Common).ThenInclude(c => c.Comments)
            .ToList();

            var mechanics = context.Mechanics
            .Include(m => m.Projects)
            .Include(m => m.Common).ThenInclude(c => c.Comments)
            .ToList();

            var data = new
            {
                user = user,
                projects = projects,
                mechanics = mechanics
            };
            return data;
        }
    }
}
