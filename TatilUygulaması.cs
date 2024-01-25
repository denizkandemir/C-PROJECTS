using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Uygulamalar2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice = "";
            while (choice != "yes")
            {
                prices NY = new prices("NY", new int[] { 549, 261, 399 }, new int[] { 1600, 1500, 1400, 1700 }, 50,
                new string[] { "", "1) Artezen Hotel (5 stars)", "2) Pod Times Square (3 stars)", "3) Hotel Edison Times Square (4 stars)" } , 40);

                prices Paris = new prices("Paris", new int[] { 186, 422, 257 }, new int[] { 1200, 1000, 900, 1300 }, 30,
                new string[] { "", "1) Citadines Tour Eiffel Paris (3 stars)", "2) Paris j'Adore Hotel (5 stars)", "3) Le 123 Sebastopol (4 stars)" } , 45);

                prices London = new prices("London", new int[] { 173, 109, 70 }, new int[] { 1000, 1100, 900, 1200 }, 35,
                new string[] { "", "1) DoubleTree by Hilton Hotel (4 stars)", "2)Hilton London Kensington Hotel (4 stars)", "3)Alexandra Hotel (3 stars)" } , 50);

                prices Berlin = new prices("Berlin", new int[] { 88, 145, 86 }, new int[] { 900, 950, 800, 1000 }, 40,
                new string[] { "", "1) NH Berlin Alexanderplatz (4 stars)", "2) InterContinental Berlin (5 stars)", "3) Scandic Berlin(4 stars)" } , 30);

                prices LA = new prices("LA", new int[] { 195, 955, 270 }, new int[] { 2600, 2650, 2500, 2700 }, 50,
                new string[] { "", "1) Millenium Bitmore Los Angeles (4 stars)", "2) Four Season Los Angeles (5 stars)", "3) JW Marriot Los Angeles (4 stars)" }, 40);

                prices Adıyaman = new prices("çiğköfte", new int[] { 81, 74, 91 }, new int[] { 100, 80, 110, 90 }, 20,
                new string[] { "", "1) Bozdoğan Hotel (4 stars)", "2) Park Dedeman Adıyaman (4 stars)", "3) Ramada by Wyndham Adıyaman (3 stars)" }, 20);

                Console.WriteLine("Which city are you located");
                displaycities();
                string city1 = Console.ReadLine();
                string city = city1.ToLower();
                checkCity(city);
                Console.WriteLine();

                Console.WriteLine("Where do you want to go");
                Console.WriteLine();
                displaychoices();
                string destination1 = Console.ReadLine();
                string destination0 = destination1.ToLower();
                string destination = CheckDestination(destination0);

                switch (destination)
                {
                    case "ny":
                        NY.displayprices(city);
                        break;
                    case "paris":
                        Paris.displayprices(city);
                        break;
                    case "london":
                        London.displayprices(city);
                        break;
                    case "berlin":
                        Berlin.displayprices(city);
                        break;
                    case "la":
                        LA.displayprices(city);
                        break;
                    case "adıyaman":
                        Adıyaman.displayprices(city);
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Which hotel do you want to stay (Write it as a number)");
                int hotelchoice1 = Convert.ToInt32(Console.ReadLine());
                int hotelchoice = CheckHotel(hotelchoice1);

                Console.WriteLine("How many days do you want to stay");
                int days = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How many days do you want to rent a car");
                int rent = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Do you want a city tour");
                displayTour();
                string answer1 = Console.ReadLine();
                string answer = answer1.ToLower();
                    
                switch (destination)
                {
                    case "ny":
                        Console.WriteLine("Cost of your trip is : " + NY.calculate1(days, rent, city, hotelchoice, NY.tour,answer) + "$"); //TABİ BÖYLE YAPACAN AMK SINIFTAKİ METODA HOTEL VE FLİGHT DEĞERLERİNİ BÖYLE ANLATIRSIN ANCA
                        break;
                    case "paris":
                        Console.WriteLine("Cost of your trip is : " + Paris.calculate1(days, rent, city, hotelchoice, Paris.tour,answer) + "€");
                        break;
                    case "london":
                        Console.WriteLine("Cost of your trip is : " + London.calculate1(days, rent, city, hotelchoice, London.tour,answer) + "£");
                        break;
                    case "berlin":
                        Console.WriteLine("Cost of your trip is : " + Berlin.calculate1(days, rent, city, hotelchoice,Berlin.tour,answer) + "€");
                        break;
                    case "la":
                        Console.WriteLine("Cost of your trip is : " + LA.calculate1(days, rent, city, hotelchoice, LA.tour,answer) + "$");
                        break;
                    case "adıyaman":
                        Console.WriteLine("Cost of your trip is : " + Adıyaman.calculate1(days, rent, city, hotelchoice, Adıyaman.tour,answer) + "$");
                        break;
                    default:
                        Console.WriteLine("We do not have any flight or hotel to" + destination);
                        break;
                }

                Console.WriteLine("Do you want to quit calculating");
                string choice0 = Console.ReadLine();
                choice = choice0.ToLower();
               
            }
            Console.WriteLine("Exiting program....");
            
            Console.Read();
        }

        static void displaycities()
        {
            Console.WriteLine("Cities : ");
            string[] cities = { "izmir", "ankara", "istanbul", "antalya"};
            foreach (var item in cities)
            {
                Console.WriteLine(item);
            }
        }
        static string checkCity(string any_city)
        {
            if (string.IsNullOrWhiteSpace(any_city) == true)
            {
                Console.WriteLine("Location part can not be empty");
                Console.WriteLine("We do not have any flights from " + any_city);
                Console.WriteLine("Which city are you located");
                string city = Console.ReadLine();
                checkCity(city);
                return city;
            }
            else if (any_city != "izmir" && any_city != "ankara" && any_city != "istanbul" && any_city != "antalya")
            {
                Console.WriteLine("We do not have any flights from " + any_city);
                Console.WriteLine("Which city are you located");
                string city = Console.ReadLine();
                checkCity(city);
                return city;
            }
            /*else if ((any_city == "izmir") || (any_city == "ankara") || (any_city == "istanbul") || (any_city == "antalya"))
            {
                return true;
            }*/
            else return any_city; 
        }
        static void displaychoices()
        {
            Console.WriteLine("Choices : ");
            string[] choices = { "NY", "Paris", "London", "Berlin", "LA", "Adıyaman" };    
            foreach (string item in choices)
            {
               Console.WriteLine(item);
            }
        }
       
        static void displayTour()
        {
            Dictionary<string, int> City_dictionary = new Dictionary<string, int>()
            {
                {"NY",40 } , {"Paris" , 45 } , {"London" , 50 } , {"Berlin" , 30 } , {"LA" ,40 } , {"Adıyaman" , 20}   
            };

            foreach (var item in City_dictionary)
            {
                Console.WriteLine("Tour price for : " + item.Key + "  is : " + item.Value);
            }
            Console.WriteLine("Enter your answer as yes or no");
        }

        static string CheckDestination(string any_destination)
        {
            if (string.IsNullOrWhiteSpace(any_destination) == true)
            {
                Console.WriteLine("Location part can not be empty");
                Console.WriteLine("We do not have any flights to " + any_destination);
                Console.WriteLine("Where do you want to go");
                string destination = Console.ReadLine();
                CheckDestination(destination);
                return destination;
            }
            else if (any_destination != "ny" && any_destination != "paris" && any_destination != "london" && any_destination != "berlin"
                && any_destination != "adıyaman" && any_destination != "la" )
            {
                Console.WriteLine("We do not have any flights to " + any_destination);
                Console.WriteLine("Where do you want to go");
                string destination = Console.ReadLine();
                CheckDestination(destination);
                return destination;
            }
            else return any_destination;
        }

        static int CheckHotel(int any_hotel)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(any_hotel)) == true)
            {
                Console.WriteLine("Hotel part can not be empty");
                Console.WriteLine("Which hotel do you want to stay (Write it as a number");
                int hotel = Convert.ToInt32(Console.ReadLine());
                CheckHotel(hotel);
                return hotel;
            }
            else if(any_hotel < 1 ||  any_hotel > 3)
            {
                Console.WriteLine("Hotel part must be between 1 and 3");
                Console.WriteLine("Which hotel do you want to stay (Write it as a number");
                int hotel = Convert.ToInt32(Console.ReadLine());
                CheckHotel(hotel);
                return hotel;
            }
            else { return any_hotel; }
        }

       
        class prices
        {
            public prices(string destination, int[] hotel, int[] flight, int car, string[] hotelsname ,int tour)
            {
                this.destination = destination;
                this.hotel = hotel;
                this.car = car;
                this.flight = flight;
                this.index = 0;
                this.hotelsname = hotelsname;
                this.tour = tour;
            }
    
            public int index;
            public string destination;
            public int[] hotel;
            public int[] flight;
            public int car;
            public string[] hotelsname;
            public int tour;

            public int calculate1(int days, int rent,string city,int hotelchoice,int tour,string answer)
            {
                int flightindex = Calculateİndex(city);
                int result = (days * hotel[hotelchoice-1]) + calculatecar(rent) + flight[flightindex] + checkTour(answer);

                return result;
            }

            public int Calculateİndex(string city)
            {
                if (city == "izmir")
                { return index = 0; }
                else if (city == "ankara")
                { return index =  1; }
                else if (city == "istanbul")
                { return index = 2; }
                else if (city == "antalya")
                { return index = 3; }

                return 0;
            }   

            public int calculatecar(int rent) 
            {
                if (rent < 3)
                {
                    return (rent * car);
                }
                else if (rent >= 3 && rent < 7)  
                {
                    return (rent * car) - 50;
                } 
                else if (rent >= 7)
                {
                    return (rent * car) - 70;
                }
                else return 0;
            }

            public int checkTour(string answer)
            {
                if (string.IsNullOrWhiteSpace(answer) == true)
                {
                    tour = 0;
                    return tour;
                }
                else if (answer == "yes")
                {
                    Console.WriteLine("Tour prices for " + destination + "is " + tour);
                    return tour;
                }
                else 
                {
                   Console.WriteLine("You have not selected any tour for your journey"); 
                   tour = 0;
                   return tour;
                }
            }

            public void displayprices(string city) 
            {
                int flightindex = Calculateİndex(city);
                Console.WriteLine("Hotel price per day for " + destination + " is : " );
                Console.WriteLine();
               
                for (int i =0; i < 3; i++)
                {     
                    Console.WriteLine(hotelsname[i+1] + " : " + hotel[i]);                 
                }

                Console.WriteLine();
                Console.WriteLine("Flight price to " + destination + " is : " + flight[flightindex]);
                Console.WriteLine();
                Console.WriteLine("Car rent price per day for " + destination + " is : " + car);
                Console.WriteLine();
                Console.WriteLine("PS :  You win a discount for 50$ if you rent a car more than 3 days,you also win a 70$ discount if you rent a car more than 7 days");
                Console.WriteLine();
               
            }
                     
        }
      
    }
}
