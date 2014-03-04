using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IV.Model {
    public class Song : Validatable {

        uint SongID {
            get;
            set;
        }

        uint AlbumID {
            get;
            set;
        }

        uint ArtistID {
            get;
            set;
        }

        byte Number {
            get;
            set;
        }

        String Name {
            get;
            set;
        }

        ushort Length {
            get;
            set;
        }
    }
}