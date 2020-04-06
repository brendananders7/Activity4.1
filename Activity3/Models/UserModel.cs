using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Activity3.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public String Username { get; set; }

        [DataMember]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public String Password { get; set; }

        public UserModel()
        {
            this.Username = "";
            this.Password = "";
        }

        public UserModel(String Username, String Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

    }
}