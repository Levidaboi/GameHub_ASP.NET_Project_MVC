using Moq;
using NUnit.Framework;
using System;
using Repository;
using Models;
using System.Collections.Generic;
using System.Linq;
using Logic;

namespace TestLib
{

    [TestFixture]
    public class Testlib
    {
        [Test]
        public void GetAllUsers()
        {
            Mock<IRepo<User>> mock = new Mock<IRepo<User>>(MockBehavior.Loose);
            List<User>testLista = new List<User>() { new User() { Name = "HegeMate" , Age = 15 } , new User() { Name = "ParasztRagu", Age = 12 } ,
            new User() { Name = "Ercos", Age = 35 }};
            List<User> expectedLista = new List<User>() { testLista[0], testLista[1], testLista[2] };
            mock.Setup(x => x.AllItem()).Returns(testLista.AsQueryable);

            UserLogic ul = new UserLogic(mock.Object);
            var output = ul.GetUsers();


            Assert.That(output, Is.EquivalentTo(expectedLista));
            Assert.That(output.Count, Is.EqualTo(expectedLista.Count));

        }

        [Test]
        public void AddUser()
        {
            Mock<IRepo<User>> mock = new Mock<IRepo<User>>(MockBehavior.Loose);
            User u = new User { Name = "ZsozeAtya", Age = 35 };

            mock.Setup(x => x.Add(It.IsAny<User>()));
            UserLogic ul = new UserLogic(mock.Object);

            ul.AddNewUser(u);

            mock.Verify(x => x.Add(u), Times.Once);
        }

        [Test]
        public void EditAchi()
        {
            Mock<IRepo<Achievement>> mock = new Mock<IRepo<Achievement>>(MockBehavior.Loose);
            Achievement a = new Achievement { AchiId = "aaa111", Name = "Platina" };
            mock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<Achievement>()));
            AchiLogic al = new AchiLogic(mock.Object);

            al.UpdateAchi(a.AchiId, a);


            mock.Verify(x => x.Update(a.AchiId, a), Times.Once);

        }

        [Test]
        public void DeleteAchi()
        {
            Mock<IRepo<Achievement>> mock = new Mock<IRepo<Achievement>>(MockBehavior.Loose);

            mock.Setup(x => x.Delete(It.IsAny<string>()));
            AchiLogic al = new AchiLogic(mock.Object);
            Achievement a = new Achievement() { AchiId = "bbb222", Name = "kivitted" };

            al.DeleteAchi(a);


            mock.Verify(x => x.Delete(a), Times.Once);


        }

        [Test]
        public void GetAGame()
        {
            Mock<IRepo<Game>> mock = new Mock<IRepo<Game>>(MockBehavior.Loose);
            Game tesztg = new Game { Name = "Cyberpunk 2077", GameId = "aaa111" };
            string id = "aaa111";
            mock.Setup(x => x.Read(id)).Returns(tesztg);
            GameLogic gl = new GameLogic(mock.Object);


            Game expectedGame = gl.GetGame(id);

            Assert.That(expectedGame, Is.EqualTo(tesztg));

        }


        //public UserLogic GetTestLogic()
        //{
        //    Mock<IRepo<Game>> gmock = new Mock<IRepo<Game>>(MockBehavior.Loose);
        //    Mock<IRepo<Achievement>> amock = new Mock<IRepo<Achievement>>(MockBehavior.Loose);
        //    Mock<IRepo<User>> umock = new Mock<IRepo<User>>(MockBehavior.Loose);


        //    List<User>userList = new List<User>()
        //    {
        //        new User { Name = "Viperov" , UserId = "uuu111" },
        //        new User { Name = "Pleb" , UserId = "uuu222" },
        //        new User { Name = "Rachman" , UserId = "uuu333" }

        //    };


        //    List<Game> gameList = new List<Game>()
        //    {
        //        new Game { Name = "game1" , UserId = "uuu111" ,GameId = "ggg111" ,GameTime = 40},
        //        new Game { Name = "game2" , UserId = "uuu222" , GameId = "ggg222" , GameTime = 2},
        //        new Game { Name = "game3" , UserId = "uuu333" ,  GameId = "ggg333" , GameTime = 1},
        //        new Game { Name = "game3" , UserId = "uuu333" , GameId = "ggg444" , GameTime = 1 },
        //        new Game { Name = "game3" , UserId = "uuu333" , GameId = "ggg555" , GameTime =2 }

        //    };

        //    List<Achievement> achiList = new List<Achievement>()
        //    {
        //        new Achievement { Name = "achi1" , AchiId = "aaa111" , GameId = "ggg222" , achiLevel = AchiLevel.gold},
        //        new Achievement { Name = "achi2" , AchiId = "aaa222" , GameId = "ggg444" , achiLevel = AchiLevel.silver },
        //        new Achievement { Name = "achi3" , AchiId = "aaa333" , GameId = "ggg222" , achiLevel = AchiLevel.bronze }
                

        //    };


        //    umock.Setup(x => x.AllItem()).Returns(userList.AsQueryable());
        //    gmock.Setup(x => x.AllItem()).Returns(gameList.AsQueryable());
        //    amock.Setup(x => x.AllItem()).Returns(achiList.AsQueryable());



        //    return new UserLogic(umock.Object, gmock.Object, amock.Object);

        //}



        [Test]
        public void GetGameCount()
        {

        }


    }
}
