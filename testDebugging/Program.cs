using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace testDebugging
{
    class Program
    {
static void Main(string[] args)
{
    var user = new User
    {
        Id = 1,
        Name = "cash",
        Address = new List<Address>
        {
            new Address
            {
                Country = "TW",
                City = "Taichung"
            },
            new Address
            {
                Country = "JP",
                City = "Toke"
            },
        }
    };
    
    Console.WriteLine(user);

    Console.ReadLine();
}


        // private static string Merge(User user)
        // {
        //     if (user.Address.Count == 1)
        //     {
        //         return "yes";
        //     }
        //
        //     if (user.Address.Count == 2)
        //     {
        //         return "yes";
        //     }
        //
        //     return "noo";
        // }
    }

[DebuggerDisplay("Id : {Id} | Name : {Name} | Address : {MyAddress}")]
[DebuggerTypeProxy(typeof(AddressDebugView))]
public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Address> Address { get; set; }

    private string MyAddress => $"{Name} live in {Address.Count} address";
    
    private class AddressDebugView
    {
        private readonly User _user;
        
        public AddressDebugView(User user)
        {
            _user = user;
        }

        //[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        // [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public List<string> Countries => _user.Address.Select(x => x.Country).ToList();
    }
}

[DebuggerDisplay("Country : {Country} | City : {City}")]
public class Address
{
    public string Country { get; set; }

    public string City { get; set; }
}

    //-------- 03
// [DebuggerDisplay("Id : {Id} | Name : {Name} | Address : {MyAddress}")]
// public class User
// {
//     public int Id { get; set; }
//
//     public string Name { get; set; }
//
//     public List<Address> Address { get; set; }
//
//     private string MyAddress => $"{Name} live in {Address.Count} address";
// }
//
// [DebuggerDisplay("Country : {Country} | City : {City}")]
// public class Address
// {
//     public string Country { get; set; }
//
//     public string City { get; set; }
// }

    //-------- 02
// [DebuggerDisplay("Id : {Id} | Name : {Name} | Address : {Address}")]
// public class User
// {
//     public int Id { get; set; }
//
//     public string Name { get; set; }
//
//     public Address Address { get; set; }
// }
//
// [DebuggerDisplay("Country : {Country} | City : {City}")]
// public class Address
// {
//     public string Country { get; set; }
//
//     public string City { get; set; }
// }

    //-------- 01
    // [DebuggerDisplay("Id : {Id} | Name : {Name} | Address.Country : {Address.Country} | Address.City : {Address.City}")]
    // public class User
    // {
    //     public int Id { get; set; }
    //
    //     public string Name { get; set; }
    //
    //     public Address Address { get; set; }
    // }
    //
    // public class Address
    // {
    //     public string Country { get; set; }
    //
    //     public string City { get; set; }
    // }

// [DebuggerDisplay("Id : {Id} | Name : {Name}")]
// public class User
// {
//     public int Id { get; set; }
//
//     public string Name { get; set; }
// }
}