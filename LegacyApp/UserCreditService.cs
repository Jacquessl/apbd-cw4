using System;
using System.Collections.Generic;

namespace LegacyApp
{
    public class UserCreditService : IDisposable
    {
        /// <summary>
        /// Simulating database
        /// </summary>
        public readonly Dictionary<string, int> _database =
            new Dictionary<string, int>()
            {
                {"Kowalski", 200},
                {"Malewski", 20000},
                {"Smith", 10000},
                {"Doe", 3000},
                {"Kwiatkowski", 1000},
                {"Andrzejewicz", 0}
            };
        
        public void Dispose()
        {
            //Simulating disposing of resources
        }
    }
}