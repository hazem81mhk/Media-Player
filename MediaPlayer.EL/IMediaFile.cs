namespace MediaPlayer.EL
{
    public interface IMediaFile
    {
        int ID { get; set; }

        string Name { get; set; }

        ExtensionType Extension { get; set; }
        string Description { get; set; }

        int Time_Interval { get; set; }

        string Source { get; set; }

    }
}