using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.EL
{
    public class ShowList
    {
        [Key]
        public int Id { get; set; }
        private List<MediaFile> mediaFiles = new List<MediaFile>();
        private string name;

        public ShowList()
        {
            this.name = "";
        }

        public ShowList(List<MediaFile> fileList, string name)
        {
            this.mediaFiles = fileList;
            this.name = name;
        }

        public List<MediaFile> MediaFiles
        {
            get { return mediaFiles; }
            set { mediaFiles = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
