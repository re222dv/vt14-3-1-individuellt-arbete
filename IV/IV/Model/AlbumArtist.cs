using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IV.Model {
    public class AlbumArtist : Validatable {

        public int AlbumID {
            get;
            set;
        }

        public int? ArtistID {
            get;
            set;
        }

        [Required]
        [StringLength(20)]
        public String Name {
            get;
            set;
        }

        public String ArtistName {
            get;
            set;
        }

        [Required]
        public DateTime Released {
            get;
            set;
        }
    }
}