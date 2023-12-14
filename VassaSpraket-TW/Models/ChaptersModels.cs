
using VassaSpraket_TW.Data.Models;



namespace VassaSpraket_TW.Models
{
    public class ChaptersViewModel
    {

        public int Id { get; set; }
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }



        public static implicit operator ChaptersViewModel(Chapters chapters) => new ChaptersViewModel
        {
            Id = chapters.Id,
            ChapterName = chapters.ChapterName,
            ChapterNumber = chapters.ChapterNumber
            
        };

    }



}
