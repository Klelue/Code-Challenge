﻿using System;
using System.Collections.Generic;
using System.Linq;
using Code_Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Code_Challenge.Util
{
    public class StringToDatabase
    {
        private CodeChallengeDbContext db;
        public StringToDatabase(CodeChallengeDbContext db)
        {
            this.db = db;
        }

        public ActionResult SaveStringsIntoDatabase(List<string> valuesList)
        {

            List<Room> rooms = new List<Room>();

            foreach (string valueLine in valuesList)
            {
                string[] values = valueLine.Split(",");
                rooms.Add(CreateRoom(values));
            }
            return ContainsDublicates(rooms, out var actionResult) ? actionResult : SaveRoomsIntoDatabase(rooms);
        }

        private ActionResult SaveRoomsIntoDatabase(List<Room> rooms)
        {
            try
            {
                DeleteTableRows();
                db.Room.AddRange(rooms);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Something went wrong with adding values to database");
            }

            return new OkObjectResult("Import went well");
        }

        private static bool ContainsDublicates(List<Room> rooms, out ActionResult actionResult)
        {
            foreach (Room room in rooms)
            {
                if (rooms.FindAll(r => r.RoomNumber == room.RoomNumber).Count > 1)
                {
                    {
                        actionResult = new BadRequestObjectResult("There is a duplicate room number");
                        return true;
                    }
                }

                foreach (People people in room.Residents)
                {
                    if (room.Residents.FindAll(p => p.LdapUser.Equals(people.LdapUser)).Count > 1)
                    {
                        {
                            actionResult = new BadRequestObjectResult("There is a duplicate person");
                            return true;
                        }
                    }
                }
            }

            actionResult = new OkObjectResult("No duplicates");
            return false;
        }

        private Room CreateRoom(string[] values)
        {
            Room room = new Room(values[0]);
            List<People> residents = new List<People>();
            for(int i = 1; i < values.Length; i++)
            {
                if (values[i].Length > 0)
                {
                    People people = CreatePeople(values[i], room.RoomNumber);
                    residents.Add(people);
                }
            }

            room.Residents = residents;
            
            return room;
        }

        private People CreatePeople(string value, string roomNumber)
        {
            List<string> peopleValues = value.Split(" ").ToList();
            string ldapUser = peopleValues[^1].Substring(1, peopleValues[^1].Length-2);
            peopleValues.RemoveAt(peopleValues.Count-1);
           
            People people = new People(ldapUser);

            if (peopleValues[0].Equals("Dr."))
            {
                people.Title = "Dr.";
                peopleValues.Remove("Dr.");
            }

            string[] nameAdditions = {"von", "van", "de"};
            foreach (string nameAddition in nameAdditions)
            {
                if (peopleValues.Contains(nameAddition))
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

            people.RoomNumber = roomNumber;
            return people;
        }

        private void DeleteTableRows()
        {
            db.Database.ExecuteSqlRaw("DELETE FROM People");
            db.Database.ExecuteSqlRaw("DELETE FROM Room");
            db.SaveChanges();
        }
    }
}
