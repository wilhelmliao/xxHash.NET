using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Extensions.Data.xxHash.Demo
{
    using Extensions.Data.xxHash;

    class Program
    {
        static private string CURRENT_PATH = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        static void Main(string[] args)
        {
            DemoXXHash64();
            DemoXXHash32();
            Bug_004_64();
            Bug_004_32();
            Console.ReadLine();
        }

        static private void Bug_004_64()
        {
            Stream stream = File.OpenRead(CURRENT_PATH + @"\Resources\bug004.txt");
            XXHash.State64 state = XXHash.CreateState64();
            XXHash.UpdateState64(state, new byte[] { 0x01 });
            XXHash.UpdateState64(state, stream);

            ulong result = XXHash.DigestState64(state);          // compute the XXH64 hash value.

            Console.WriteLine(result.ToString("x8"));
        }

        static private void Bug_004_32()
        {
            Stream stream = File.OpenRead(CURRENT_PATH + @"\Resources\bug004.txt");
            XXHash.State32 state = XXHash.CreateState32();
            XXHash.UpdateState32(state, new byte[] { 0x01 });
            XXHash.UpdateState32(state, stream);

            uint result = XXHash.DigestState32(state);          // compute the XXH32 hash value.

            Console.WriteLine(result.ToString("x8"));
        }

        static private void DemoXXHash64()
        {
            Stream stream = File.OpenRead(CURRENT_PATH + @"\Resources\letters.txt");// the data to be hashed
            XXHash.State64 state = XXHash.CreateState64();      // create and initialize a xxH states instance.
            // NOTE:
            //   xxHash require a xxH state object for keeping
            //   data, seed, and vectors.

            XXHash.UpdateState64(state, stream);                // puts the file stream into specified xxH state.

            ulong result = XXHash.DigestState64(state);          // compute the XXH32 hash value.

            Console.WriteLine(result.ToString("x8"));
        }
        static private void DemoXXHash32()
        {
            Stream stream = File.OpenRead(CURRENT_PATH + @"\Resources\letters.txt");// the data to be hashed
            XXHash.State32 state = XXHash.CreateState32();      // create and initialize a xxH states instance.
            // NOTE:
            //   xxHash require a xxH state object for keeping
            //   data, seed, and vectors.

            XXHash.UpdateState32(state, stream);                // puts the file stream into specified xxH state.

            uint result = XXHash.DigestState32(state);          // compute the XXH32 hash value.

            Console.WriteLine(result.ToString("x4"));
        }
    }
}
