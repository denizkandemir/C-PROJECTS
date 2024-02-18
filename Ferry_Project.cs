using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*You are tasked with developing a program to calculate ferry ticket prices based on the size of
            vehicles. Additionally, the program should check if the ferry area is full based on the total size of
            vehicles onboard. When the ferry reaches its maximum capacity, the program should print a list of all
            vehicles onboard.
            Requirements:
            • The program should prompt users to input details about their vehicle for ferry transportation,
              including:
            – Vehicle type (car, motorcycle, truck)
            – License plate number
            – Size of the vehicle
            • The program should calculate the ticket price for each vehicle based on the following pricing
              rules:
              – Cars: 5 dollars per size unit
              – Motorcycles: 2 dollars per size unit
              – Trucks: 10 dollars per size unit

              - Adult: 10$
              - Child: 5$
              - Baby:  1$
           
             Ferry's capasite should determine by random class between (50 - 100)
             Ferry's human capasite should determine by random class between (2 , 10)
            */


            string choice = "";
          
            while (choice != "exit")
            {
                Random number = new Random();
                int capacity = number.Next(50, 100);
                int person_capacity = number.Next(2,10);
                /*Person capacity represents the number of human that can be on board
                 except the humans that are coming with their vehicle */

                ArrayList All_vehicles = new ArrayList();
                ArrayList All_persons = new ArrayList();

                int person_total = 0;
                int total = 0;
                CheckFerry(capacity,person_capacity);
                int index = 1;
                int i = 0;
                int j = 0;

                while (i < capacity)
                {
                    Vehicle vehicles = new Vehicle();
                    Console.WriteLine("Add or exit");
                    choice  = Console.ReadLine();
                    if (choice.ToLower() == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("What is the type of the vehicle");
                        vehicles.type = Console.ReadLine();
                        Console.WriteLine("What is the size of this vehicle");
                        vehicles.size = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("What is the plate number of this vehicle");
                        vehicles.plate = Console.ReadLine();
                        Console.WriteLine("");

                        if (vehicles.CheckI(i, capacity, vehicles) == false)
                        {
                            i += 0;
                        }
                        else 
                        { 
                            i += vehicles.size;
                            vehicles.price = vehicles.Calculate_price(vehicles);
                            total += vehicles.Calculate_price(vehicles);

                            All_vehicles.Add(vehicles);
                        }          
                    }
                }
                while (j < person_capacity)
                {
                    Person person = new Person();
                    Console.WriteLine("");

                    Console.WriteLine("What is the full name of the " + index + ".person");
                    person.name = Console.ReadLine();
                    Console.WriteLine("Is this person an adult or child or baby");
                    person.type = Console.ReadLine();
                    index++;

                    person.payment = person.Calculate(person);
                    if (person.payment == 0)
                    {
                        j += 0;
                    }
                    else
                    {
                        person.CheckJ(j, person_capacity);
                        person_total += person.payment;
                        All_persons.Add(person);
                        j++;
                    } 
                }
                index = 1;
                Console.WriteLine("Vehicles in that ferry are : ");
                Console.WriteLine("");
                foreach (Vehicle item in All_vehicles)
                {
                    Console.WriteLine(index + ". vehicle's features are");

                    Console.WriteLine("Vehicle type is : " + item.type);
                    Console.WriteLine("Vehicle's plate is : " + item.plate);                 
                    Console.WriteLine("Vehicle's size is : " + item.size);
                    Console.WriteLine("Vehicle's payment is : " + item.price);
                    Console.WriteLine("");
                    index++;
                }

                index = 1;
                Console.WriteLine("People on this ferry are : ");
                foreach (Person item in All_persons)
                {
                    Console.WriteLine("");
                    Console.WriteLine(index + ".person is : ");
                    Console.WriteLine("Person's full name is : " + item.name);
                    Console.WriteLine("Person is a/an : " + item.type);
                    Console.WriteLine("Person's payment is : " + item.payment);
                    index++;
                }
                Console.WriteLine("");
                Console.WriteLine("Total money that has been payed to ferry is : " + (total + person_total));
                Console.WriteLine("");

            }
            Console.Read();
        }

        static void CheckFerry(int anyCapacity,int any_person_capacity)
        {
            if (anyCapacity < 70)
            {
                Console.WriteLine("A small ferry is coming...");
                Console.WriteLine("Vehicle capacity of this ferry is : " + anyCapacity);
                Console.WriteLine("Human capacity of this ferry is : " + any_person_capacity);
                Console.WriteLine("");
            }
            else if (anyCapacity < 85 && anyCapacity > 70)
            {
                Console.WriteLine("A big ferry is coming");
                Console.WriteLine("Capacity of this ferry is : " + anyCapacity);
                Console.WriteLine("Human capacity of this ferry is : " + any_person_capacity);
                Console.WriteLine("");
            }
            else if (anyCapacity < 100 && anyCapacity > 85)
            {
                Console.WriteLine("An enormus ferry is coming... ");
                Console.WriteLine("Capacity of this ferry is : " + anyCapacity);
                Console.WriteLine("Human capacity of this ferry is : " + any_person_capacity);
                Console.WriteLine("");
            }
        }
    }

    class Vehicle
    {
        public string type;

        public string plate;

        public int size;

        public int price;

        public int Calculate_price(Vehicle any_vehicle)
        {
            if (any_vehicle.type.ToLower() == "truck")
            {
                return any_vehicle.size * 10;
            }
            else if (any_vehicle.type.ToLower() == "car")
            {
                return any_vehicle.size * 5;
            }
            else if (any_vehicle.type.ToLower() == "motor" || any_vehicle.type == "bike")
            {
                return any_vehicle.size * 2;
            }
            return any_vehicle.size = 0;
        }

        public bool CheckI(int i, int anyCapacity, Vehicle any_Vehicle)
        {
            if ((i + any_Vehicle.size) > anyCapacity)
            {
                Console.WriteLine("The last vehicle that you have entered can not fit in this ferry");
                Console.WriteLine("Please wait for the other ferry or enter a vehicle that has a smaller size than : "
                + (anyCapacity - i));
                return false;

            }
            else if ((i + any_Vehicle.size) == anyCapacity)
            {
                Console.WriteLine("This ferry's vehicle capacity is full now");
                Console.WriteLine("You may now enter the people's information");
                return true;
            }
            return true;
        }
    }
    
    class Person
    {
        public string name;

        public string type;

        public int payment;

        public int Calculate(Person any_person)
        {
            if (any_person.type.ToLower() == "adult")
            {
                return 10;
            }
            else if (any_person.type.ToLower() == "child" || any_person.type == "kid")
            {
                return 5;
            }
            else if (any_person.type.ToLower() == "baby")
            {
                return 1;
            }
            else 
            {
                Console.WriteLine("Please enter adult or child or baby!!");
                return 0;
            }
        }

        public void CheckJ(int j,int any_capacity)
        {
            if ((j + 1) == any_capacity)
            {
                Console.WriteLine("This ferry is full now");
                Console.WriteLine("Ferry is leaving the shore");
            }
        }
    }
}
