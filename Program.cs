﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMyDateClass
{

    class MyDate
    {
        private int year;
        private int month;
        private int day;

        private static string[] strMonths = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
        private static string[] weekDays2 = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        private static int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    
        public static Boolean isLeapYear(int year) {
            if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            else return false;                      
        }

        public static Boolean isValid(int year, int month, int day) {
            Boolean a1;

            a1 = false;
            if ((year > 0 && year <10000) &&
                (month > 0 && month < 13 ) &&
                (day > 0 && day <= daysInMonths[month-1])|| (isLeapYear(year)))
            { 
                a1 = true;
            }

            if (!(isLeapYear(year)) && month==2 && day>=29)
            {
                a1 = false;
            }

            return a1;
        }

        public static int getDayOfWeek(int year, int month, int day) {

            DateTime dateValue = new DateTime(year, month, day);

            return (int)dateValue.DayOfWeek;

        }

        public MyDate(int year, int month, int day)
        {
            setDate(year, month, day);
        }

        public void setDate(int year, int month, int day) {
            this.year = year;
            this.month = month;
            this.day = day;

            if (isValid(year, month, day)==false)
            {
                Console.WriteLine("Invalid year, month or day!");
            }
           
        }

        public void setYear(int year) {

            if (year > 0 && year < 10000)
            {
                this.year = year;
            }
            else { Console.WriteLine("Invalid year!"); }
        }

        public void setMonth(int month)
        {

            if (month > 0 && month < 13)
            {
                this.month = month;
            }
            else { Console.WriteLine("Invalid year!"); }
        }

        public void setDay(int day)
        {

            if ((day > 0 && day < daysInMonths[month-1])|| (month == 2 && isLeapYear(year) && day == 29))
            {
                this.day = day;
            }

            else { Console.WriteLine("Invalid day!"); }
        }

        public int getDay() {return day;}
        public int getMonth() {return month;}
        public int getYear() { return year; }

        public override string ToString()
        {

            DateTime dateValue = new DateTime(year, month, day);

            return $"{ weekDays2[(int)dateValue.DayOfWeek]}  {day} {strMonths[month - 1]} {year}";


        }

        public MyDate nextDay() {

           
            if (isLeapYear(year))
            {
                daysInMonths[1] = 29;
            }

            if ((day == daysInMonths[month - 1]) && month==12)
            {
                month = 1;
                day = 1;
                year += 1; 
            }

            else if (day == daysInMonths[month - 1])
            {
                month += 1;
                day = 1;
            }
            else day += 1;

            if (month > 12)
            {
                month = 1;
                year = +1;

            }



            

            MyDate oDen = new MyDate(year, month, day);

            return oDen;
          
        }

        public MyDate nextMonth()
        {

            month = month + 1;
            MyDate oMesic = new MyDate(year, month, day);
            return oMesic;

        }

        public MyDate nextYear() {
            
            year = year + 1;

            MyDate oRok = new MyDate(year, month, day);
            return oRok;
        }

        public MyDate previousDay()
        {

            if (isLeapYear(year))
            {
                daysInMonths[1] = 29;
            }

            if (month == 1 && day==1)
            {
                month = 12;
                year = year - 1;
                day = daysInMonths[month - 1];
            }
            else
            {
                day = day - 1;
            }
      
            MyDate oDen = new MyDate(year, month, day);

            return oDen;
        }
                public MyDate previousMonth() {
            month = month - 1;

            if (day > daysInMonths[month - 1])
            {
                day = daysInMonths[month - 1];
            }

            MyDate oMesic = new MyDate(year, month, day);
            return oMesic;
        }

        public MyDate previousYear()
        {
            if (isLeapYear(year) && month == 2)
            {
                day -= 1;
            }
            year = year - 1;

            MyDate oRok = new MyDate(year, month, day);
            return oRok;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //MyDate d1 = new MyDate(2012, 2, 28);
            //Console.WriteLine(d1);
            //Console.WriteLine(d1.nextDay());
            //Console.WriteLine(d1.nextDay());
            //Console.WriteLine(d1.nextMonth());
            //Console.WriteLine(d1.nextYear());

            //MyDate d2 = new MyDate(2012, 1, 2);
            //Console.WriteLine(d2);
            //Console.WriteLine(d2.previousDay());
            //Console.WriteLine(d2.previousDay());
            //Console.WriteLine(d2.previousMonth());
            //Console.WriteLine(d2.previousYear());

            //MyDate d3 = new MyDate(2012, 2, 29);
            //Console.WriteLine(d3.previousYear());

            //MyDate d4 = new MyDate(2099, 11, 31);
            //MyDate d4 = new MyDate(2011, 2, 22);

            //Console.ReadLine();



            MyDate d6 = new MyDate(2011, 12, 28);
            //MyDate d7 = new MyDate(2012, 03, 02);


            int rok;
            int mesic;
            int den;

            do
            {

                Console.WriteLine(d6.nextDay());

                rok = d6.getYear();
                mesic = d6.getMonth();
                den = d6.getDay();


                //takhle to funguje, ale moc nechapu proc nebo, radsi bych dal a zaroven while( mesic != 03 && den!=3);
            } while ( mesic != 03 || den!=3 );


            Console.ReadKey();

        }
    }
}
