using System;
using System.Threading;

namespace LegacyApp
{
    public class User
    {
        public User(Client client, DateTime dateOfBirth, string emailAddress, string firstName, string lastName)
        {
            Client = client;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            setType();
        }

        public Client Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        private void setType()
        {
            if (Client.Type == "VeryImportantClient")
            {
                HasCreditLimit = false;
            }
            else if (Client.Type == "ImportantClient")
            {
                int creditLimit = GetCreditLimit(LastName);
                creditLimit = creditLimit * 2;
                CreditLimit = creditLimit;
            }
            else
            {
                HasCreditLimit = true;
                int creditLimit = GetCreditLimit(LastName);
                CreditLimit = creditLimit;
            }
        }
        /// <summary>
        /// This method is simulating contact with remote service which is used to get info about someone's credit limit
        /// </summary>
        /// <returns>Client's credit limit</returns>
        private int GetCreditLimit(string lastName)
        {
            int randomWaitingTime = new Random().Next(3000);
            Thread.Sleep(randomWaitingTime);
            var userCreditService = new UserCreditService();
            if (userCreditService._database.ContainsKey(lastName))
                return userCreditService._database[lastName];

            throw new ArgumentException($"Client {lastName} does not exist");
        }
    }
}