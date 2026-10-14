



















/*

var names = new List<string>()
{
	"Hector","Francisco","Ana","Hugo","Pedro"

};
var nameResults = from n in names where n.Length >= 3 && n.Length<=5 orderby n descending select n;
foreach (var name in nameResults)
{
	Console.WriteLine(name);
}



var names = new List<string>()
{
	"Hector","Francisco","Ana","Hugo","Pedro"

};
var nameResults = from n in names orderby n select n;
foreach (var name in nameResults)
{
	Console.WriteLine(name);
}



Func<string, int> contador = palabra => palabra.Length;
Console.WriteLine(contador ("Pedro"));


//Expresiones Lambda
Func<int, int, int> sub = (a, b) => a - b;//Los primeros 2 valores almacenan a y b y el tercero es para almacenar el resultado
Func<int, int> some = a => a * 2;
Func<int, int> some2 = a =>

{
	a = a + 1;
	return a * 5;
};




//Sirve para 

using System.Text.Json;

var pedro = new People() { Name = "Pedro", Age = 32 };
String json = JsonSerializer.Serialize(pedro);
Console.WriteLine(json);

string myJson = @"{""Name"":""Juan"",""Age"":36}";
People? juan = JsonSerializer.Deserialize<People>(myJson);
Console.WriteLine(juan?.Name);
Console.WriteLine(juan?.Age);

public class People
{
	public string Name { get; set; }
	public int Age { get; set; }
}



var number = new MyList<int>(5);
var beers  = new MyList<Beer>(5);

number.Add(1);
number.Add(2);
number.Add(3);
number.Add(4);
number.Add(5);

Console.WriteLine(number.GetContent());
beers.Add(new Beer() { Name = "Miller", Price = 39 });



public class MyList<T>
{
	private List<T> _list;
	private int _limit;
	public MyList(int limit)
	{
		_limit = limit;
		_list = new List<T>();


	}


	public void Add(T element)
	{
		if (_list.Count < _limit)
		{
			_list.Add(element);
		}

	}
	public string GetContent()
	{
		string content = "";
		foreach (var element in _list)
		{
			content += element + ", ";
		}
		return content;

	}

	public class Beer
	{
		//Taera: Que se muestre la lista beer y que muestre contenido.
		public string Name { get; set; }
		public string Price { get; set; }

		public override string ToString()
		{
			return "Nombre: " + Name + " Price: " + Price;
		}
	}

}







var sale = new Sale(15);     //new SaleWithTax(100, 12);
var message = sale.GetInfo();
Console.WriteLine(message);

Some(sale);
Some(beer);

//Funcion SOME
void Some(ISave save)
{
	save.Save();
}


class SaleWithTax : Sale
{
	public decimal Tax { get; set; }
	public SaleWithTax(decimal total, decimal tax) : base(total)
	{
		Tax = tax;
	}
	public override string GetInfo()
	{
		return "El total es: " + Total + " Impuestos es: " + Tax;
	}
}
class Sale: ISale, ISave
{
    public void Save()
	{
		Console.WriteLine();
	}
	
	public decimal Total { get; set; }

	public Sale(decimal total)
	{
		Total = total;
	}
	public virtual string GetInfo()
	{
		return "El total es: " + Total;
	}
}

public interface ISale
{
    decimal Total { get; set; }
}

public interface ISave
{
    public void Save();
}

public class Beer : ISave
{
    public void Save()
    {
        Console.WriteLine("Impresion de Beer");
    }
}

*/