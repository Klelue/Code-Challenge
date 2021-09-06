using System;
using System.Runtime.Serialization;


namespace Code_Challenge.Models
{
    [DataContract]
    public class People
    {

        [DataMember]
        private String firstName { get; set; }

        [DataMember]
        private String lastName { get; set; }

        [DataMember]
        private String title { get; set; }

        [DataMember]
        private String nameAddition { get; set; }

        [DataMember]
        private String ldapUser { get; set; }

        
    }
}
