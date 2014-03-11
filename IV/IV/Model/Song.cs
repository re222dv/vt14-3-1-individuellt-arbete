using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IV.Model {
    public class Song : Validatable {

        public int SongID {
            get;
            set;
        }

        public int AlbumID {
            get;
            set;
        }

        public int ArtistID {
            get;
            set;
        }

        [Required]
        public byte Number {
            get;
            set;
        }

        [Required]
        [StringLength(30)]
        public String Name {
            get;
            set;
        }

        [Required]
        public short Length {
            get;
            set;
        }

        public String LengthMinutes {
            get {
                return String.Format("{0}:{1:00}", Length / 60, Length % 60);
            }
            set {
                var parts = value.Split(':');
                Length = (short) (short.Parse(parts[0]) * 60);
                Length += short.Parse(parts[1]);
            }
        }
    }
}