using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;


namespace Code_Challenge.Models
{

    public class People
    {


        private String firstName;

        

        private String lastName;

        private String title;

        private String nameAddition;

        private String ldapUser;

        public People(string ldapUser)
        {
            LdapUser = ldapUser;
        }

        [Key]
        public String LdapUser
        {
            get => ldapUser;
            set => ldapUser = value;
        }

        [RegularExpression(@"Dr\.")]
        public String Title
        {
            get => title;
            set => title = value;
        }

        [RegularExpression(@"[A-Z][a-z]+(\s[A-Z][a-z]+)?")]
        [Required]
        public String LastName
        {
            get => lastName;
            set => lastName = value;
        }

        [RegularExpression(@"[A-Z][a-z]+")]
        [Required]
        public String Firstname
        {
            get => firstName;
            set => firstName = value;
        }

        [RegularExpression(@"[(von)(van)(de)]")]
        public String NameAddition
        {
            get => nameAddition;
            set => nameAddition = value;
        }

    }
}
