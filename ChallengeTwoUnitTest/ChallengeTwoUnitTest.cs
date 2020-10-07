using System;
using System.Collections.Generic;
using ChallengeTwoRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeTwoUnitTest
{
    [TestClass]
    public class ChallengeTwoUnitTest
    {
        ClaimsRepository _claimsrepo = new ClaimsRepository();

        [TestMethod]
        public void GET_CONTENT()
        {
            //arrange   //act 
            List<ClaimsContent> listofContents = new List<ClaimsContent>();
            int count = listofContents.Count;
            List<ClaimsContent> newlist = _claimsrepo.GetContents();
            int checkcount = newlist.Count;

            //act
            //act is get contents above already

            //assert
            Assert.AreEqual(count, checkcount);
        }

       //TESTING OF THE OTHER METHOD IS ALREADY DONE BECUASE OF THE LOGIC WITHIN THE METHOD FOR 
    }
}
