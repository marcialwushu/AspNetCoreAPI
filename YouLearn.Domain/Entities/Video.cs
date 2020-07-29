using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Entities
{
    public class Video
    {
        public Guid Id { get; set; }

        public Canal Canal { get; set; }

        public PlayList PlayList { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Tags { get; set; }

        public int OrdemNaPlaylist { get; set; }

        public string IdVideoYoutube { get; set; }

        public Usuario UsuarioSugeriu { get; set; }

        public string Status { get; set; }
    }
}
