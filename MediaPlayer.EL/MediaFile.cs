using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.EL
{
    public class MediaFile:IMediaFile
    {
        #region Variables

        [Key]
        public int MediaFileId { get; set; }

        public int ShowListId { get; set; }

        private int id;
        private string name;
        private ExtensionType extension;
        private string description;
        private int time_intervall;
        private string source;
        #endregion

        #region Constructure
        public MediaFile()
        {
            id = 0;
            name = "";
            extension = ExtensionType.wrong;
            description = "";
            time_intervall = 0;
            source = "";
        }
        public MediaFile(int id, string name, ExtensionType extension,
            string description, int time_intervall, string source)
        {
            this.id = id;
            this.name = name;
            this.extension = extension;
            this.description = description;
            this.time_intervall = time_intervall;
            this.source = source;
        }
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public ExtensionType Extension
        {
            get { return extension; }
            set { extension = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Time_Interval
        {
            get { return time_intervall; }
            set { time_intervall = value; }
        }
        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "ID: " + id + ".\nName: " + name + ".\nExtension: " + extension
                + ".\nDescription: " + description + ".\nTime interval: " +
                time_intervall + ".\nSource: " + source + ".";
        }
        #endregion
    }
}
