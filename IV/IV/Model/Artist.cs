using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IV.Model {
    public class Artist : Validatable {

        public String Date {
            get {
                return Formed.ToString("yyyy-MM-dd");
            }
            set {
                
            }
        }

        public int ArtistID {
            get;
            set;
        }

        [Required]
        [StringLength(20)]
        public String Name {
            get;
            set;
        }

        [Required]
        public DateTime Formed {
            get;
            set;
        }

        [Required]
        public String Description {
            get;
            set;
        }
    }
}