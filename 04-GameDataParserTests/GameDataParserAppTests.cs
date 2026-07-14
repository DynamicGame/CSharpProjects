using _04_GameDataParser.App;
using _04_GameDataParser.UserInteractorFiles;
using Moq;
using NUnit.Framework;

namespace _04_GameDataParserTests
{
    [TestFixture]
    public class GameDataParserAppTests
    {
        private Mock<IUserInteractor> _userInteractor;
        private Mock<IGameDataReader> _gameDataReader;
        private Mock<IGameDataPrinter> _gameDataPrinter;
        private GameDataParserApp _cut;

        [SetUp]
        public void Setup()
        {
            _userInteractor = new Mock<IUserInteractor>();
            _gameDataPrinter = new Mock<IGameDataPrinter>();
            _gameDataReader = new Mock<IGameDataReader>();
            _cut = new GameDataParserApp(_userInteractor.Object,
                _gameDataReader.Object, _gameDataPrinter.Object);
        }

        [Test]
        public void Run_VerifyUserInteractorIsCalledWithEnterFileNameMessage()
        {
            _cut.Run();
            _userInteractor.Verify(mock => mock.WriteLine(_04_GameDataParser.Resource.EnterFileNameMessage));
        }

        [Test]
        public void Run_VerifyGameDataReaderIsCalledWithPathFromReadValidFilePath()
        {
            var fileName = "Data.txt";
            var gameDataList = new List<GameData>()
            {
                new GameData(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>() ),
                new GameData(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>() ),
                new GameData(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>() ),
            };
            _userInteractor.Setup(mock => mock.ReadValidFilePath()).
                            Returns(fileName);
            _gameDataReader.Setup(mock => mock.Read(_userInteractor.Object.ReadValidFilePath())).
                Returns(gameDataList);
            
            
            _cut.Run();

            _gameDataReader.Verify(mock => mock.Read(fileName));

        }

        [Test]
        public void Run_VerifyReadValidFilePathReturnsFileName()
        {
            var fileName = "Data.txt";
            var gameDataList = new List<GameData>()
            {
                new GameData(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>() ),
                new GameData(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>() ),
                new GameData(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>() ),
            };
            _userInteractor.Setup(mock => mock.ReadValidFilePath()).
                            Returns(fileName);


            _cut.Run();

            Assert.AreEqual(fileName, _userInteractor.Object.ReadValidFilePath());

        }

        [Test]
        public void Run_VerifyGameDataPrinterIsCalledWithValidData()
        {
            var fileName = "Data.txt";
            var gameDataList = new List<GameData>()
            {
                new GameData(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>() ),
                new GameData(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>() ),
                new GameData(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>() ),
            };
            _userInteractor.Setup(mock => mock.ReadValidFilePath()).
                            Returns(fileName);
            _gameDataReader.Setup(mock => mock.Read(_userInteractor.Object.ReadValidFilePath())).
                Returns(gameDataList);
            _gameDataPrinter.Setup(mock => mock.Print(gameDataList));

            _cut.Run();

            _gameDataPrinter.Verify(mock => mock.Print(gameDataList));
        }

    }
}
