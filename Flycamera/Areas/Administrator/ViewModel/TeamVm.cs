using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlyEntity;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class TeamVm
    {
        public Fly_Team Team { get; set; }
        public List<Fly_Team> ListTeam { get; set; }
        public bool IsPublish { get; set; }
        public bool IsDelete { get; set; }

        public TeamVm()
        {
            Team = new Fly_Team();
            ListTeam = new List<Fly_Team>();
            IsPublish = true;
            IsDelete = false;
        }
    }
}