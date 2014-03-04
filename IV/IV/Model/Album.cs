using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IV.Model {
    public class Album : Validatable {

        uint AlbumID {
            get;
            set;
        }

        uint? ArtistID {
            get;
            set;
        }

        String Name {
            get;
            set;
        }

        DateTime Released {
            get;
            set;
        }
    }
}