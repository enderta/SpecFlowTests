namespace SpecFlowProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var dic=new Dictionary<string, string>();
dic.Add("key1", "value1");
dic.Add("key2", "value2");
dic.Add("key3", "value3");
dic.Add("key4", "value4");

foreach (var item in dic)
{
    Console.WriteLine(item.Key + " " + item.Value);


}
        
for (var i=0; i<dic.Count; i++)
{
    Console.WriteLine(dic.ElementAt(i).Key.ToString() + " " + dic.ElementAt(i).Value.ToString().Count());
}
dic.Where(x => x.Key.StartsWith("key")).ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));
dic.ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));
Console.WriteLine(dic.Count);
Console.WriteLine(dic["key1"]);
Console.WriteLine(dic.ContainsKey("key1"));
Console.WriteLine(dic.ContainsValue("value1"));
dic.Remove("key1");
Console.WriteLine(dic.Count);

var list=new List<string>();
list.Add("key1");
list.Add("key2");
list.Add("key3");
list.ForEach(x => Console.WriteLine(x));

list.Where(x => x.StartsWith("key")).ToList().ForEach(x => Console.WriteLine(x));
Console.WriteLine(list[0]);

var set=new HashSet<string>();
set.Add("key1");
set.Add("key1");
set.Add("key2");
set.Add("key3");

Console.WriteLine(set.Count);
//itirate the set using lambda
set.ToList().ForEach(x => Console.WriteLine(x));
Console.WriteLine(set.Contains("key1"));
foreach (var item in set)
{
    Console.WriteLine(item);
}
    }
}