using System;
using System.Threading;

namespace LegacyApp
{
    public class Client
    {
        public string Name { get; internal set; }
        public int ClientId { get; internal set; }
        public string Email { get; internal set; }
        public string Address { get; internal set; }
        public string Type { get; set; }
        
        /// <summary>
        /// Simulating fetching a client from remote database
        /// </summary>
        /// <returns>Returning client object</returns>
        public Client GetById(int clientId)
        {
            int randomWaitTime = new Random().Next(2000);
            Thread.Sleep(randomWaitTime);
            if (ClientRepository.Database.ContainsKey(clientId))
                return ClientRepository.Database[clientId];

            throw new ArgumentException($"User with id {clientId} does not exist in database");
            
        }
    }
}