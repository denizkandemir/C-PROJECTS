using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace HOCA_UYGULAMALR
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Write a python program should ask a word and an index number then remove the character at the given index
             # Example "I Love Python" with the index value 2 should return "I ove Python"*/


            /* Console.WriteLine("Enter a sentence");
             string word = Console.ReadLine();
             Console.WriteLine("Enter the index of the letter you want to remove");
             int index = int.Parse(Console.ReadLine());

             string new_word = word.Remove(index , 1); //indexten sonra(index dahil) 1 harf sil
             Console.WriteLine(new_word);            //Bu durumda index silinir

             Console.Read();*/

            Console.WriteLine("*********************");

            /*string[] all_letters = new string[100];
            int i = 51;
            int k = 2;
            string letter = null;
            while (letter != "quit") 
            {
                Console.WriteLine();
                Console.WriteLine("Enter the letter");
                Console.WriteLine();
                letter = Console.ReadLine();         
                if (i%2 != 0) 
                {
                    all_letters[i] = letter;
                }
                else 
                {
                    all_letters[i-k] = letter;
                }
                for (int j = 0; j < i+1; j++)
                {
                    Console.Write(all_letters[j]);
                }          
               
                i++;
                k = k+2;
            }*/

            Console.WriteLine("*****************");

            /* Exercise 3 - Letter Chain
            # Write a python program that takes letter from the user and add that letter to the string
            # New letter is added with its usage count to the string with the order right,left,right,left, ...
            # Program terminates when the user enter 'X'.*/




            /*Dictionary<char,int>Count = new Dictionary<char,int>();
            string chain = "X"; //Bu tarz örneklerde,bir verinin ne kadar basıldığını öğrenmek için dictionary baya mantıklı
            int number = 0; 
            string input = null;
            while (input != "quit")
            {
                Console.WriteLine("Enter the letter");
                input = Console.ReadLine();
                char letter = input[0];

                if(Count.ContainsKey(letter) == false) //Eğer o harf, dictionary de yoksa, valuesunu 1 olarak veriyoruz
                {
                    Count[letter] = 1;
                }
                else  //Eğer o harf, dictionary de varsa, value sini 1 arttırıyoruz
                { 
                  Count[letter] = Count[letter] + 1; 
                }

                if (number == 0)
                {
                    chain = chain + Count[letter] + letter; //Her seferinde chain varieablesini de kendine ekliyoruz ki,  
                    number = 1;                             //kullanıcının girdiği tüm harfler gözüksün
                }
                else
                {
                    chain = ""+letter + Count[letter] + chain; //önüne string bişi koymazsak mal olup char ın unicode unu veriyo
                    number =0;  //Her döngü döndüğünde sayının değerini, sırayla if e sonra else e gircek şekilde değiştiriyoruz
                }
                Console.WriteLine(chain);
            }*/




            //Quizde çıkan soru



            /* Dictionary<string,int>products = new Dictionary<string,int>();

             Console.WriteLine("How many products do you want to list");
             int number = int.Parse(Console.ReadLine());

             for (int i = 0; i < number; i++)
             {
                 Console.WriteLine("Enter the " + (i+1) + ". product");
                 string product = Console.ReadLine();
                 Console.WriteLine("Enter the price");
                 int price = int.Parse(Console.ReadLine());  
                 products[product] = price; //Anlaşılan , dictionary variable adına değil, variablenin 
                 //içindeki string değerine göre işlem yapıyor, o yüzden her döngü döndüğünde , dictionaryimiz yeni ürünlerle genişliyor
             }

             int total = 0;
             string search = null;
             while (search != "exit")
             {
                 Console.WriteLine("Enter the product you want to buy");
                 search = Console.ReadLine();
                 total += products[search];
                 Console.WriteLine("You have bought " + search + "for " + total);
                 products[search] += products[search] * 5 / 100;

             }*/



            //dizili yöntem




            /*Console.WriteLine("How many products do you want to list");
            int number = int.Parse(Console.ReadLine());

            string[] products = new string[number];
            int[] prices = new int[number];

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Enter the " + (i + 1) + ". product");
                products[i] = Console.ReadLine();
                Console.WriteLine("Enter the price");
                prices[i] = Convert.ToInt32(Console.ReadLine());

            }

            int total = 0;
            string search = null;
            while (search != "exit")
            {
                Console.WriteLine("Enter the product you want to buy");
                search = Console.ReadLine();
                for (int i = 0; i < products.Length; i++)
                {
                    if (search == products[i])
                    {
                        total += prices[i];
                        Console.WriteLine("You have bought " + search + "for  " + total);
                        prices[i] = prices[i] + (prices[i] * 5 / 100);
                        break;
                    }
                }

            }*/


            /* Exercise 4 - Eurovision Song Contest
            # Write a python program which takes the country list as an argument and returns name of winner country.
            # Every country should give points to other countries between 1 and 12 randomly.
            # Print the points of all countries.*/


            string[] countries = { "Germany", "France", "Belgium", "Portugal", "Greece", "Italy", "England", "Turkey", "Croatia", "Spain" };
            Dictionary<string,int>All_countries = new Dictionary<string,int>();

            foreach (string item in countries)
            {
                All_countries[item] = 0; //Tüm ülkeleri dictionary e atadık ve değerlerini sıfır a eşitledik
            }

            Random random = new Random();

            foreach (string item in countries)  
            {
                for (int j = 0; j < countries.Length; j++)
                {
                    All_countries[item] += random.Next(0, 12);
                }
            }

            foreach (string item in countries)
            {
                Console.WriteLine(item + " : " + All_countries[item]);
            }

            int max_Point = All_countries.Values.Max(); 

            foreach (string item in countries)
            {
                if (All_countries[item] == max_Point)
                {
                    Console.WriteLine("WINNER IS " + item);
                }
            }
           
           

           

            Console.Read();
        }
    }
}
