// using System;

// namespace bookStructure
// {
//     public struct Book
//     {
//         public string Name;
//         public string Author;
//         public decimal Price;
//         public short Year;

//     }

//     enum DaysOfWeek
//     {
//         Monday, Tuesday, Wednesday
//     }

//     enum Status
//     {
//         Pending,
//         Approved,
//         Rejected
//     }

//     class bookStructure
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Structure Example");

//             Book myBook = new Book();

//             myBook.Name = "Nitin";
//             myBook.Author = "Jitin";
//             myBook.Price = 180.25M;
//             myBook.Year = 2005;

//             Console.WriteLine(myBook.Name + myBook.Author + myBook.Price + myBook.Year);


//             DaysOfWeek t1 = DaysOfWeek.Monday;

//             if (t1 == DaysOfWeek.Tuesday || t1 == DaysOfWeek.Monday)
//             {
//                 Console.WriteLine("Either it can be Monday or Sunday");
//             }
//             else
//             {
//                 Console.WriteLine("Either it can be Monday or Sunday");
//             }

//             switch (t1)
//             {
//                 case DaysOfWeek.Monday:
//                     Console.WriteLine("It's Monday");
//                     break;
//                 case DaysOfWeek.Tuesday:
//                     Console.WriteLine("It's Tuesday");
//                     break;
//                 case DaysOfWeek.Wednesday:
//                     Console.WriteLine("It's Wednesday");
//                     break;
//                 default:
//                     Console.WriteLine("It's a Weekend");
//                     break;
//             }

//         }
//     }
// }

