namespace Upplysning
{
    public interface IPersonResult
    {
        string Name { get; }
        string SpokenName { get; }
    }

    public interface IAddressResult
    {
        string Address { get; }
        string PostalCode { get; }
        string City { get; }
    }

    public interface IPersonnummerResult
    {
        string Personnummer { get; }
    }

    public class UpplysningPersonResult : IPersonResult, IPersonnummerResult, IAddressResult
    {
        internal UpplysningPersonResult(string name, string spokenName, string address, string postalCode, string city, string personnummer)
        {
            Name = name;
            SpokenName = spokenName;
            Personnummer = personnummer;
            Address = address;
            PostalCode = postalCode;
            City = city;
        }

        public string Name { get; }

        public string SpokenName { get; }

        public string Personnummer { get; }

        public string Address { get; }

        public string PostalCode { get; }

        public string City { get; }
    }
}