using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.Models;

namespace Birth_Clinic.DummyData
{
    public class DatabaseSeed
    {
        public static void AddFatherAndMother()
        {
            using var context = new AppDbContext();

            Parent parent = new Parent()
            {
                DueDate = new DateTime(2021, 04, 14),

            };

            Father newFather = new Father()
            {
                FirstName = "Peter",
                LastName = "Wann",
                Parent = parent,
            };

            Mother newMother = new Mother()
            {
                FirstName = "Line",
                LastName = "Design",
                Parent = parent,
            };
            parent.Father = newFather;
            parent.Mother = newMother;
            context.Add(newFather);
            context.Add(newMother);
            context.Add(parent);
        

            Parent parent2 = new Parent()
            {
                DueDate = new DateTime(2021, 04, 17),

            };

            Father newFather2 = new Father()
            {
                FirstName = "Alexander",
                LastName = "Wodstrup",
                Parent = parent2,
            };

            Mother newMother2 = new Mother()
            {
                FirstName = "Ursula",
                LastName = "Flemmingsen",
                Parent = parent2,
            };
            parent2.Father = newFather2;
            parent2.Mother = newMother2;
            context.Add(newFather2);
            context.Add(newMother2);
            context.Add(parent2);

            Parent parent3 = new Parent()
            {
                DueDate = new DateTime(2021, 07, 20),

            };

            Father newFather3 = new Father()
            {
                FirstName = "Palle",
                LastName = "Nielsen",
                Parent = parent3,
            };

            Mother newMother3 = new Mother()
            {
                FirstName = "Francesca",
                LastName = "Musollini",
                Parent = parent3,
            };
            parent3.Father = newFather3;
            parent3.Mother = newMother3;
            context.Add(newFather3);
            context.Add(newMother3);
            context.Add(parent3);

            Parent parent4 = new Parent()
            {
                DueDate = new DateTime(2021, 04, 16),

            };

            //Father newFather4 = new Father()
            //{
            //    FirstName = "August",
            //    LastName = "Andersen",
            //    Parent = parent4,
            //};

            Mother newMother4 = new Mother()
            {
                FirstName = "Karen",
                LastName = "Ingemann",
                Parent = parent4,
            };
            //parent4.Father = newFather4;
            parent4.Mother = newMother4;
            //context.Add(newFather4);
            context.Add(newMother4);
            context.Add(parent4);
            context.SaveChanges();
        }
    }
}
