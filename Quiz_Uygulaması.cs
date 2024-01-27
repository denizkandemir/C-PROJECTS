using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Uygulamalar3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Are you a student or a teacher");
            string student_or_teacher = Console.ReadLine();
            string student_or_teacher2 = student_or_teacher.ToLower();
            check_student_or_teacher(student_or_teacher2);

            if (student_or_teacher2 == "teacher")
            {
                Console.WriteLine("How many questions do you want to enter");
                int numberOfQuestions = int.Parse(Console.ReadLine());

                //Classın içinde dizi oluşturup kullanmalı yöntem

                /* Teacher teacher = new Teacher();
                 teacher.Questions = new string[numberOfQuestions]; //Classtan oluşturulan her nesne için ayrı bir dizi olacağı için bu şekil tanumlaman lazım
                 teacher.Choices = new string[numberOfQuestions];
                 teacher.Answers = new string[numberOfQuestions];

                 for (int i = 0; i < numberOfQuestions; i++)
                 {
                     Console.WriteLine("Enter the " + ( i + 1 ) + ". question ");         
                     teacher.Questions[i] = Console.ReadLine();  

                     Console.WriteLine("Enter the choices for " + ( i + 1) + ". question. Please enter them with letter index, such as : a)1st chocice , b)2nd choice");             
                     teacher.Choices[i] = Console.ReadLine();

                     Console.WriteLine("Enter the right answer for " + (i + 1) + ". question");              
                     teacher.Answers[i] = Console.ReadLine();
                 }
                 for (int i = 0; i < numberOfQuestions; i++)
                 {
                     Console.WriteLine();
                     Console.WriteLine((i+1) + ". question is : " +  teacher.Questions[i]);

                     Console.WriteLine();
                     Console.WriteLine(teacher.Choices[i]);
                 }*/

                //Classın kendisini dizi yapıp kullanmalı yöntem

                Teacher[] teachers = new Teacher[numberOfQuestions];

                for (int i = 0; i < numberOfQuestions; i++)
                {
                    Teacher QuestionInfo = new Teacher();
                    Console.WriteLine("Enter the " + (i + 1) + ". question ");
                    QuestionInfo.Questions2 = Console.ReadLine();

                    Console.WriteLine("Enter the choices for " + (i + 1) + ". question. Please enter them with letter index, such as : a)1st chocice , b)2nd choice");
                    QuestionInfo.Choices2 = Console.ReadLine();

                    Console.WriteLine("Enter the right answer for " + (i + 1) + ". question");
                    QuestionInfo.Answers2 = Console.ReadLine();

                    teachers[i] = QuestionInfo;
                }
                int index = 1;
                foreach (var item in teachers)
                {
                    Console.WriteLine();
                    Console.WriteLine(index + ". question is : " + item.Questions2);
                    Console.WriteLine();
                    Console.WriteLine(item.Choices2);
                    Console.WriteLine();
                    Console.WriteLine("Right answer for " + index + ". question is : " + item.Answers2);
                    index++;
                }
            }
            else if (student_or_teacher2 == "student")
            {
                student Question1 = new student("What is the highest mountain of Turkey" , new string[] {"a) Erciyes" , "b) Ağrı", 
                    "c)Spil" , "d)Bozdağ" } , "b" );

                student Question2 = new student("What is the name of the dog that is belong to Atatürk", new string[] {"a) Kara" , "b) Max"
                 , "c) Fox" ,  "d) Rex" }, "c");

                student Question3 = new student("What is the biggest lake of Turkey", new string[] {"a) Van Lake" , "b) Salt Lake" ,
                  "c) Green Lake" , "d) Burdur Lake"} , "a");

                student Question4 = new student("What is the capital of Turkey", new string[] {"a) İstanbul" , "b)İzmir",
                  "c) Konya" , "d) Ankara"}, "d");

                student[] All_Question = {Question1 , Question2 , Question3 , Question4 };
                Quiz ALL = new Quiz(All_Question);

                Console.WriteLine(ALL.calculate_points(All_Question)); 

            }
            Console.Read();
        }

        static string check_student_or_teacher(string student_or_teacher3)
        {
            if (string.IsNullOrWhiteSpace(student_or_teacher3) == true)
            {
                Console.WriteLine("Student or teacher part can not be empty");
                Console.WriteLine("Are you a student or teacher");
                string student_or_teacher = Console.ReadLine();
                string student_or_teacher2 = student_or_teacher.ToLower();
                check_student_or_teacher(student_or_teacher2);
                return student_or_teacher2; 
            }
            else if (student_or_teacher3 != "student" && student_or_teacher3 != "teacher")
            {
                Console.WriteLine("You must enter student or teacher");
                Console.WriteLine("Are you a student or teacher");
                string student_or_teacher4 = Console.ReadLine();
                check_student_or_teacher(student_or_teacher4);
                return student_or_teacher4;
            }
            else { return student_or_teacher3; }
        }

        class Teacher
        {
            //Classın içinde dizi oluşturup kullanmalı yöntem

            /* public string[] Questions;

             public string[] Choices;

             public string[] Answers;*/

            //Classın kendisini dizi yapıp kullanmalı yöntem

           public string Questions2;

            public string Choices2;

            public string Answers2;
        }

        class student
        {
            public string text;

            public string[] choices;

            public string right_answer;

            public student(string Text , string[] Choices , string Right_answer) 
            { 
               text = Text;

               choices = Choices;

               right_answer = Right_answer;
            }
        }

        class Quiz
        {
            student[] Questions;

            int Question_index;

            int Right_Questions;

            public Quiz(student[] questions)
            {
                Questions = questions;
                Question_index = 0;
                Right_Questions = 0;
            }

            public int Answers_of_questions(student[] Questions)
            {
                bool right_questions = false;
                for (int i = 0; i < Questions.Length; i++)
                {
                    Console.WriteLine((Question_index + 1) + ". question of " + Questions.Length);
                    Console.WriteLine(Questions[i].text);
                    foreach (var item in Questions[i].choices)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Enter your answer");

                    string User_answer = Console.ReadLine();
                    right_questions = check_answers(User_answer,Questions);

                    if (right_questions == true)
                    {
                        Right_Questions++;
                    }   
                    Question_index++;
                }
                return Right_Questions;
            }
            
            public bool check_answers(string user_answer , student[] Questions )
            {
                bool check = false;
                
                if (user_answer == Questions[Question_index].right_answer)
                {
                    check = true;
                }
                else check = false;

                return check;
            }

            public double calculate_points(student[] Questions)
            {
                int number_of_rightanswers = Answers_of_questions(Questions);
                double multiply = 100 / Questions.Length;
                double sum = (number_of_rightanswers) * multiply;
                return sum;

            }
        }
    }
}
