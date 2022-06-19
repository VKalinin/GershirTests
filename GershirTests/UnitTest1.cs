using OpenQA.Selenium;

namespace GershirTests
{
    public class Tests
    {
        private IWebDriver driver;

        private const string _firstName = "Vladyslav";
        private const string _phoneNumber = "0992132687";
        private const string _textAreaComment = "Тест успешно пройден";
        private const int _clicksN = 5;
        private const int _sleepN = 400;

        
        private readonly By _gershirBeerButton = By.XPath("//span[text()='Пиво «Гершир»']");
        private readonly By _lightBeerButton = By.XPath("/html/body/div[1]/div[1]/div[2]/div/div/div[4]/div[2]/div/div[3]/h3/a");
        private readonly By _addToCardButton = By.XPath("//button[@name='add-to-cart']");
        private readonly By _plusButton = By.XPath("//input[@value='+']");
        private readonly By _checkOutButton = By.XPath("//p[@class='woocommerce-mini-cart__buttons buttons']/a[text()='Оформление заказа']");
        private readonly By _firstNameField = By.XPath("//span[@class='woocommerce-input-wrapper']/input[@name='billing_first_name']");
        private readonly By _phoneNumberField = By.XPath("//span[@class='woocommerce-input-wrapper']/input[@name='billing_phone']");
        private readonly By _textAreaCommentField = By.XPath("//span[@class='woocommerce-input-wrapper']/textarea[@name='order_comments']");


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://dostavka.gershir.com.ua/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var gershirbeer = driver.FindElement(_gershirBeerButton);
            gershirbeer.Click();
            Thread.Sleep(400);
            var lightBeer = driver.FindElement(_lightBeerButton);
            lightBeer.Click();
            Thread.Sleep(400);
            var plusButton = driver.FindElement(_plusButton);
            var doMultipleClicks = (_clicksN, _sleepN);
            {
                for(int i = 0; i < _clicksN; i++)
                {
                    plusButton.Click();
                    Thread.Sleep(_sleepN);

                }
            }
            var addToCard = driver.FindElement(_addToCardButton);
            addToCard.Click();
            Thread.Sleep(1000);
            var checkOut = driver.FindElement(_checkOutButton);
            checkOut.Click();
            var firstNameField = driver.FindElement(_firstNameField);
            firstNameField.SendKeys(_firstName);
            var phoneNumberField = driver.FindElement(_phoneNumberField);
            phoneNumberField.SendKeys(_phoneNumber);
            var textAreaCommentField = driver.FindElement(_textAreaCommentField);
            textAreaCommentField.SendKeys(_textAreaComment);
            Thread.Sleep(5000);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}