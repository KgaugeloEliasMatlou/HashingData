using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class program
{
    static void Main()
    {

        Console.WriteLine("Enter a password to be hashed..");
        string pw = Console.ReadLine();
        Console.WriteLine();

        Hashdata hd = new Hashdata();
        Console.WriteLine("The Hash value for " + pw + " is :  ");
        string pwh = hd.CreateHash(pw);

        Console.WriteLine(pwh);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("When the user logs in later , we ll get a password..");
        Console.WriteLine("and compare it to the previous hash..");

        Console.WriteLine("Enter the Orginal password: ");
        string pw2 = Console.ReadLine();

        string pwh2 = hd.CreateHash(pw2);

        Console.WriteLine();
        Console.WriteLine("first hash  "+pwh);
        Console.WriteLine("second hash "+ pwh2);

        if(pwh == pwh2)
        {
            Console.WriteLine("Files Match.");
        }
        else
        {
            Console.WriteLine("No Match ");
        }

    }
}
public class Hashdata
{
    public string CreateHash(string input)
    {
        HashAlgorithm sha = SHA256.Create();
        byte[] hashData = sha.ComputeHash(Encoding.Default.GetBytes(input));
        return Convert.ToBase64String(hashData);
    }
}
