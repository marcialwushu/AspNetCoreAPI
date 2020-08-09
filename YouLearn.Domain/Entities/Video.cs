using prmToolkit.NotificationPattern;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class Video : EntityBase
    {
        public Video(Canal canal, PlayList playList, string titulo, string descricao, string tags, int ordemNaPlayList, string idVideoYoutube, Usuario usuarioSugeriu)
        {
            Canal = canal;
            PlayList = playList;
            Titulo = titulo;
            Descricao = descricao;
            Tags = tags;
            OrdemNaPlayList = ordemNaPlayList;
            IdVideoYoutube = idVideoYoutube;
            UsuarioSugeriu = usuarioSugeriu;
            Status = EnumStatus.EmAnalise;

            new AddNotifications<Video>(this)
                .IfNullOrInvalidLength(x => x.Titulo, 1, 200, "Titulo obrigatório e deve conter de 1 a 200 caracteres")
                .IfNullOrInvalidLength(x => x.Descricao, 1, 250, "Descricao obrigatória e deve conter entre 1 a 50 caractares")
                .IfNullOrInvalidLength(x => x.Tags, 1, 50, "Tag obrigatória e deve conter enre 1 a 50 caracateres")
                .IfNullOrInvalidLength(x => x.IdVideoYoutube, 1, 50, "IdVideoYoutube é obrigatório e deve conter entre 1 a 50 caracteres");

            AddNotifications(canal);

            if(playList != null)
            {
                AddNotifications(playList);
            }
        }

        public Canal Canal { get; private set; }

        public PlayList PlayList { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public string Tags { get; private set; }

        public int OrdemNaPlayList { get; private set; }

        public string IdVideoYoutube { get; private set; }

        public Usuario UsuarioSugeriu { get; private set; }

        public EnumStatus Status { get; private set; }
    }
}
