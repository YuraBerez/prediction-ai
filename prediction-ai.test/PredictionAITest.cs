namespace prediction_ai.test;

public class Tests
{
    private const string API_KEY = "Your API Key";
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        Console.WriteLine(await new ProdictionService(API_KEY).GetProdictionAsync());
        Assert.Pass();
    }

    [Test]
    public async Task Test2()
    {
        var service = new ProdictionService();
        service.Configure(API_KEY);
        Console.WriteLine(await service.GetProdictionAsync());
        Assert.Pass();
    }

    [Test]
    public async Task Test3()
    {
        var service = new ProdictionService();
        service.Configure(API_KEY, "UK");
        Console.WriteLine(await service.GetProdictionAsync());
        Assert.Pass();
    }

    [Test]
    public async Task Test4()
    {
        Console.WriteLine(await new ProdictionService(API_KEY, "UK").GetProdictionAsync());
        Assert.Pass();
    }
}
