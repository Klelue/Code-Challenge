using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Code_Challenge.Models
{
    [DataContract]
    public class Room
    {
        [DataMember]
        private string roomNumber { get; set; }

        [DataMember]
        private List<People> residents { get; }

        public void AddResident(People resident)
        {
            residents.Add(resident);

            List<ulong> list = new List<ulong>();
       
        }
    }


    }
