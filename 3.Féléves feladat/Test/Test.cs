using Moq;
using NUnit.Framework;
using System;
using Repository;
using Models;
using System.Collections.Generic;
using System.Linq;
using Logic;

namespace Test
{

    [TestFixture]
    public class Test
    {
        [Test]
        public void GetAllUsers() 
        {
            Mock<IRepo<User>> mock = new Mock<IRepo<User>>(MockBehavior.Loose);
            List<User> testLista = new List<User>() { new User() { Name = "HegeMate" , Age = 15 } , new User() { Name = "ParasztRagu", Age = 12 } ,
            new User() { Name = "Ercos", Age = 35 }};
            List<User> expectedLista = new List<User>() { testLista[0] , testLista[1]  , testLista[2] };
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
            User u = new User { Name = "ZsozeAtya" , Age = 35};

            mock.Setup(x => x.Add(It.IsAny<User>()));
            UserLogic ul = new UserLogic(mock.Object);

            ul.AddNewUser(u);

            mock.Verify(x => x.Add(u), Times.Once);
        }

        [Test]
        public void EditAchi()
        {
            Mock<IRepo<Achievement>> mock = new Mock<IRepo<Achievement>>(MockBehavior.Loose);
            Achievement a = new Achievement { AchiId = "aaa111" , Name = "Platina" };
            mock.Setup(x => x.Update(It.IsAny<string>(),It.IsAny<Achievement>()));
            AchiLogic al = new AchiLogic(mock.Object);

            al.UpdateAchi(a.AchiId ,a);


            mock.Verify(x => x.Update(a.AchiId,a), Times.Once);

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


        [Test]
        public void GetBestGamer()
        {
            Mock<IRepo<User>> umock = new Mock<IRepo<User>>(MockBehavior.Loose);
            Mock<IRepo<Game>> gmock = new Mock<IRepo<Game>>(MockBehavior.Loose);
            Mock<IRepo<Achievement>> amock = new Mock<IRepo<Achievement>>(MockBehavior.Loose);




        }


    }
}
