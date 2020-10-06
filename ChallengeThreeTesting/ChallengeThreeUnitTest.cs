using System;
using System.Collections.Generic;
using ChallengeThreeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThreeTesting
{
    [TestClass]
    public class ChallengeThreeUnitTest
    {
        BadgeRepository _badgeRepository = new BadgeRepository();
        Dictionary<int, List<string>> _contentDirectory = new Dictionary<int, List<string>>();

        [TestMethod]
        public void ADD_CONTENT_TEST()   //ACT, ARRANGE, ASSERT//   //METHODS FROM REPO//
        {
            //ARRANGE//
            List<string> listOfDoors = new List<string>();

            //ACT//
            bool act = _badgeRepository.AddContentToDirectory(23, listOfDoors);

            //ASSERT//
            Assert.IsTrue(act);
        }

        [TestMethod]
        public void GET_CONTENTS()
        {
            //ARRANGE//
            List<string> listOfDoors = new List<string>();
            _badgeRepository.AddContentToDirectory(23, listOfDoors);

            //ACT//
            Dictionary<int, List<string>> _contentDirectory = _badgeRepository.GetContents();
            bool act = _contentDirectory.ContainsKey(23);
            bool acttwo = _contentDirectory.ContainsValue(listOfDoors);

            //ASSERT//
            Assert.IsTrue(act);
            Assert.IsTrue(acttwo);
        }

        [TestMethod]
        public void DELETE_BADGE_ITEMS()
        {
            //arrange//
            List<string> listOfDoors = new List<string>();
            
            listOfDoors.Add("A5");
            _badgeRepository.AddContentToDirectory(23, listOfDoors);

            //act//
            bool act = _badgeRepository.DeleteBageItems(23);

            //assert//
            Assert.IsTrue(act);
                
        }

    }
}
