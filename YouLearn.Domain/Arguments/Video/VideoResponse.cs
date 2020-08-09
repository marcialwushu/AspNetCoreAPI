using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.Video
{
    public class VideoResponse
    {
        public string NomeCanal { get; set; }

        public Guid? IdPlayList { get; set; }

        public string NomePlayList { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Thumbnail { get; set; }

        public string IdVideoYoutube { get; set; }

        public int OrdemNaPlayList { get; set; }

        public string Url { get; set; }
    }
}
