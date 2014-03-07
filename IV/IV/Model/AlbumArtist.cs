using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IV.Model {
    public class AlbumArtist : Album {

        public String ArtistName {
            get;
            set;
        }
    }
}