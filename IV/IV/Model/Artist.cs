using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IV.Model {
    public class Artist : Validatable {

        uint ArtistID {
            get;
            set;
        }

        String Name {
            get;
            set;
        }

        DateTime Formed {
            get;
            set;
        }

        String Description {
            get;
            set;
        }
    }
}