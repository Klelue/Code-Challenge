using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Code_Challenge.Models
{
    public class Room
    {
        
        private string roomNumber;


        private List<People> residents { get; }

        public void AddResident(People resident)
        {
            residents.Add(resident);

            List<ulong> list = new List<ulong>();
       
        }

        [Key]
        public String RoomNumber
        {
            get => roomNumber;
            set => roomNumber = value;
        }
    }


    }
