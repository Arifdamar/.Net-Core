using System;
using System.Linq;

namespace consoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // "1","2","5a","10b","abc","10","50"
            // 1- Liste içerisindeki sayısal değerleri bulunuz.

            //    var liste = new List<string>()
            //    {
            //        "1","2","5a","10b","abc","10","50"
            //    };

            //    foreach (var item in liste)
            //    {
            //        try
            //        {                       
            //             int a = int.Parse(item);
            //             Console.WriteLine(a);
            //        }
            //        catch (Exception)
            //        {
            //            continue;
            //        }
            //    }

            // 2- Kullanıcı 'q' değerini girmedikçe aldığınız her değerin
            // sayısal olup olmadığını kontrol edin aksi halde hata mesajı veriniz.

            //    while(true)
            //    {
            //        Console.Write("sayı: ");
            //        string input = Console.ReadLine();

            //        if (input == "q")
            //             break;

            //         try
            //         {
            //             int sayi = int.Parse(input);
            //             Console.WriteLine("girdiğiniz sayı: {0}",sayi);
            //         }
            //         catch (Exception)
            //         {
            //             Console.WriteLine("geçersiz sayı");
            //             continue;
            //         }             

            //    }

            // 3- Girilen parola içinde türkçe karakter araması yapınız.  

            Console.Write("parola: ");
            string parola = Console.ReadLine();

            try
            {
                CheckPassword(parola);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        static void CheckPassword(string parola)
        {
            string turkce_karakterler = "ğ,Ğ,ç,Ç,ş,Ş,ü,Ü,ö,Ö,ı,İ";

            foreach (var karakter in parola)
            {
                if (turkce_karakterler.IndexOf(karakter) > -1)
                    throw new Exception("Parola türkçe karakter içeremez");
            }
            Console.Write("geçerli parola");
        }


    }

}