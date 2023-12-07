using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogLab2
{
    public sealed class MusicCatalog
    {
        private List<Song> playlist = new List<Song>();
        public IEnumerable<Song> Songs //внешний код может читать элементы из коллекции, не изменяя саму коллекцию -> обращаемся через catalog.Songs
        {
            get { return playlist; } //доступ к коллекции playlist
        }
        public void Add(Song song)
        {
            playlist.Add(song);
        }
        public void Remove(Song song)
        {
            playlist.Remove(song);
        }
        public IEnumerable<Song> Search(Predicate<Song> predicate) //predicate - функция, принимающая условие
        {
            return playlist.FindAll(predicate); //возврат нового списка из всех элементов, для которых предикат истинен
        }
    }
}
