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

        private List<People> residents;

        public Room(string roomNumber)
        {
            RoomNumber = roomNumber;
        }

        [Key]
        [MaxLength (4)]
        public string RoomNumber
        {
            get => roomNumber;
            set => roomNumber = value;

        }

        public List<People> Residents
        {
            get => residents;
            set => residents = value;
        }
    }


    }
