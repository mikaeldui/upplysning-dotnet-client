using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Upplysning.Tests
{
    [TestClass]
    public class PersonLookupTests
    {
        [TestMethod]
        public async Task SearchForPerson()
        {
            using UpplysningClient client = new();

            var result = await client.GetPeopleAsync("Anna");

            Assert.IsTrue(result.Length > 0);
        }
    }
}
