xxHash.NET [![Build Status](https://travis-ci.org/wilhelmliao/xxHash.NET.svg?branch=master)](https://travis-ci.org/wilhelmliao/xxHash.NET)
==========
A .NET implementation of [xxHash](https://github.com/Cyan4973/xxHash). 

### Synopsis ###

##### xxHash API approach #####
*The following snippet demonstrates computing the **XXH32** hash value of the input string "test".*
```csharp
byte[] input = Encoder.ASCII.GetBytes("test");      // the data to be hashed
uint result = XXHash.XXH32(input);                  // compute the XXH32 hash value. => '1042293711'
                                                    // NOTE:
                                                    //   you can specified seed as the second parameter.
```

*The following snippet computes the **XXH32** hash value of the input file "test.doc".*
```csharp
Stream stream = File.OpenRead(@"C:\test.doc");      // the data to be hashed
XXHash.State32 state = XXHash.CreateState32();      // create and initialize a xxH states instance.
                                                    // NOTE:
                                                    //   xxHash require a xxH state object for keeping
                                                    //   data, seed, and vectors.
                                                    
UpdateState32(state, stream);                       // puts the file stream into specified xxH state.

uint result = DigestState32(state);                 // compute the XXH32 hash value.
```

##### HashAlgorithm approach #####
In addition, the assembly provides two class -- XXHash32 and XXHash64 are implementation of System.Security.Cryptography.HashAlgorithm.
```csharp
byte[] input = Encoder.ASCII.GetBytes("test");       // the data to be hashed.
using (HashAlgorithm xxh32 = XXHash32.Create())
{
  byte[] result = xxh32.ComputeHash(input);          // compute the hash.
}
```
or
```csharp
byte[] input = Encoder.ASCII.GetBytes("test");       // the data to be hashed
using (HashAlgorithm xxh32 = XXHash32.Create())
{
  xxh32.TransformFinalBlock(input, 0, input.Length);
  byte[] result = xxh32.Hash;                        // retrieves the hash value.
}
```


The assembly provides majority implementation of xxHash APIs.
<<<<<<< HEAD


=======
>>>>>>> a740e1d5e54ef4a2671bb45018e6a3138b52367e
| original xxHash API name | XXH32             | XXH64             |
|--------------------------|-------------------|-------------------|
| XXH*nn*                  | XXH32()           | XXH64()           |
| XXH*nn*_state_t          | State32           | State64           |
| XXH*nn*_createState      | CreateState32()   | CreateState64()   |
| XXH*nn*_freeState        | *not implement*   | *not implement*   |
| XXH*nn*_reset            | ResetState32()    | ResetState64()    |
| XXH*nn*_update           | UpdateState32()   | UpdateState64()   |
| XXH*nn*_digest           | DigestState32()   | DigestState64()   |


#### Copyright ####
Copyright (c) 2015 Wilhelm Liao. See LICENSE for further details.