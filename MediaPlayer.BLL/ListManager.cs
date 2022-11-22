// Created by: Hazem Kudaimi.
// Date: 22/11/2022

using MediaPlayer.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.BLL
{
    public class ListManager
    {
        private List<ShowList> showLists = new();
        private List<ShowList> dbShowList = new();

        public ListManager() { }

        public List<ShowList> ShowLists
        {
            get{ return showLists; }
            set { showLists = value;}
        }

        public List<ShowList> DbShowList
        {
            get { return dbShowList; }
            set { dbShowList = value;}
        }
    }
}
