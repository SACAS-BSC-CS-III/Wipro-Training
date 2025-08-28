// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// File Handling -- 

// Input Stream & Output Stream

// Stream -- It is an representation of a sequence of data or bytes that flows from one direction to another

// Console.ReadLine(); -- > Input stream -- Keyboard

//  Stream or a pipe (where your data flows) -- save your data into a file. ( File input stream(Reading) and File output stream(Writing))

// Console.WriteLine(); --> Output Stream -- output devices  -- Monitor


// Input Stream -- Reading the data from file or Keyboard
// Output Stream --  Writing the data to a file or on Console
// File Stream --- which is used to read/write to files ( file based) 
// Memory Stream -- Read/ write the data in memory(RAM) not a file
// Network Stream - TCP/IP  -- which will transfer the data over a network.


// FileStream fs = new FileStream("datafile.txt",FileMode.Create);

// Keyboard ---InputStream---> To your app ---Output Stream ----> File / Console
// After this you can pass this file to 
// StreamReader
// StreamWriter
// BinaryReader
// BinaryWriter

// Stream input = Console.OpenStandardInput();
// StreamReader reader = new StreamReader(input);

// string  line = reader.ReadLine();
// Console.WriteLine(line);


// Stream output = Console.OpenStandardOutput();
// StreamWriter writer = new StreamWriter(output);

// writer.WriteLine("this is your code");



using System.IO;


class Program2
{


    static void Main()
    {

        string path = "file1.txt";
        string message = "File data related to c#";

        //To write using FileStream
        // Garbage collector 
        // Manually we have to close and open (we need not to write manually open / close /flush with using keyword it automatically does)
        FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

            fs.Write(data, 0, data.Length);

        fs.Close();

        FileStream fs1 = new FileStream(path, FileMode.Open, FileAccess.Read);
        
            // To read the data it is important to use buffer 
            byte[] buffer = new byte[fs1.Length];
            fs1.Read(buffer, 0, buffer.Length);

            string result = System.Text.Encoding.UTF8.GetString(buffer);
            Console.WriteLine(result);
            fs1.Close();
    }
}