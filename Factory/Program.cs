using System;

namespace Factory
{
	interface IOperator
	{
		double getResult(double operand1, double operand2);
	}

	class Add : IOperator
	{
		public double getResult(double operand1, double operand2)
		{
			return operand1 + operand2;
		}
	}

	class Sub : IOperator
	{
		public double getResult(double operand1, double operand2)
		{
			return operand1 - operand2;
		}
	}

	interface IFactory
	{
		IOperator createOperator();
	}

	class AddFactory : IFactory
	{
		public IOperator createOperator()
		{
			return new Add();
		}
	}

	class SubFactory : IFactory
	{
		public IOperator createOperator()
		{
			return new Sub();
		}
	}

	class MainClass
	{
		public static double getResultWithType(double operand1, string type, double operand2)
		{
			return ((IFactory)System.Reflection.Assembly.Load("Factory").CreateInstance("Factory." + type + "Factory")).createOperator().getResult(operand1, operand2);
		}

		public static void Main(string[] args)
		{
			IFactory factory = new AddFactory();
			Console.WriteLine("Add:" + factory.createOperator().getResult(3, 4));

			Console.WriteLine(":" + getResultWithType(2, "Add", 8));
			Console.WriteLine(":" + getResultWithType(10, "Sub", 1));
		}
	}
}
