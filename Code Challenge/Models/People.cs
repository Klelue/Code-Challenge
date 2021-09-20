using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;


namespace Code_Challenge.Models
{

    public class People
    {


        private string firstName;

        private string lastName;

        private string title;

        private string nameAddition;

        private string ldapUser;

        private string roomNumber;


        public People(string ldapUser)
        {
            LdapUser = ldapUser;
        }


        [Key]
        [MaxLength (10)]
        public string LdapUser
        {
            get => ldapUser;
            set => ldapUser = value;
        }

        [RegularExpression(@"Dr\.")]
        [MaxLength (4)]
        public string Title
        {
            get => title;
            set => title = value;
        }

        [RegularExpression(@"[A-Z][a-z]+")]
        [MaxLength (25)]
        [Required]
        [JsonPropertyName("last name")]
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        [RegularExpression(@"[A-Z][a-z]+(\s[A-Z][a-z]+)?")]
        [MaxLength (50)]
        [Required]
        [JsonPropertyName("first name")]
        public string Firstname
        {
            get => firstName;
            set => firstName = value;
        }

        [RegularExpression(@"[(von)(van)(de)]")]
        [MaxLength (4)]
        [JsonPropertyName("name addition")]
        public string NameAddition
        {
            get => nameAddition;
            set => nameAddition = value;
        }

        [MaxLength(4)]
        [JsonIgnore]
        public string RoomNumber
        {
            get => roomNumber;
            set => roomNumber = value;

        }
    }
}
