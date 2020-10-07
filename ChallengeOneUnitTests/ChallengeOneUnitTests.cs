using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeOneRepository;

namespace ChallengeOneUnitTestsing
{
    [TestClass]
    public class ChallengeOneUnitTesting
    {
        MenuRepository _menurepo = new MenuRepository();

        [TestMethod]
        public void GET_CONTENT()
        {
            //arrange   //act 
            List<MenuContent> listofContents = new List<MenuContent>();
            int count = listofContents.Count;
            List<MenuContent> newlist = _menurepo.GetContents();
            int checkcount = newlist.Count;

            //act
            //act is get contents above already

            //assert
            Assert.AreEqual(count, checkcount);
        }

        //TESTING OF THE OTHER METHOD IS ALREADY DONE BECUASE OF THE LOGIC WITHIN THE METHOD FOR 
    }
}




