using Ardalis.GuardClauses;
using TestSolutoin.Infrastructure;

namespace TestSolution.Domain
{
    public class User : AutidableClass
    {
        private string _name;
        private string _address;
        private int _age;


        public User(string? name, string? address, int age)
        {
            _name = Guard.Against.NullOrEmpty(name, nameof(name));
            _address = Guard.Against.NullOrEmpty(address, nameof(address));
            _age = Guard.Against.NegativeOrZero(age, nameof(age));
        }

        public string Name { get => _name; private set => _name = value; }
        public string Address { get => _address; private set => _address = value; }
        public int Age { get => _age; private set => _age = value; }

        public void SetName(string name)
        {

            _name = name;
        }
        public void SetAddress(string address)
        {
            _address = Guard.Against.IsFoundOrNot(address, nameof(address));
        }
        public void SetAge(int age)
        {
            _age = age;
        }

        private bool IsValid(string name)
        {
            return true;
        }
    }
}