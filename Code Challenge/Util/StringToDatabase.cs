﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Code_Challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace Code_Challenge.Util
{
    public class StringToDatabase
    {
        public List<Room> intoDatabase(List<string> valuesList) 
        {
            List<Room> rooms = new List<Room>();

            foreach (string valueLine in valuesList)
            {
                string[] values = valueLine.Split(",");
                
                rooms.Add(createRoom(values));
            }
        }

        private Room createRoom(string[] values)
        {
            Room room = new Room(values[0]);
            for(int i = 1; i < values.Length; i++)
            {
                if (values[i].Length > 0)
                {
                    room.AddResident(createPeople(values[i]));
                }
            }
            
            return room;
        }

        private People createPeople(string value)
        {
            List<string> peopleValues = value.Split(" ").ToList();
            string ldapUser = peopleValues[^1].Substring(1, peopleValues[^1].Length-2);
           
            People people = new People(ldapUser);

            if (peopleValues[0].Equals("Dr."))
            {
                people.Title = "Dr.";
                peopleValues.Remove("Dr.");
            }

            string[] nameAdditions = {"von", "van", "de"};
            foreach (string nameAddition in nameAdditions)
            {
                if (peopleValues.Equals(nameAddition))
                {
                    people.NameAddition = nameAddition;
                    peopleValues.Remove(nameAddition);
                }
            }

            people.LastName = peopleValues[^1];
            peopleValues.RemoveAt(peopleValues.Count-1);

            string firstName = "";
            foreach (string name in peopleValues)
            {
                firstName += " " + name;
            }

            people.Firstname = firstName.Substring(1);

            return people;
        }
    }
}
